using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using roksh.Data;
using roksh.Models;

namespace roksh.Controllers
{
    public class GenericODataController<T> : ODataController where T : class, IEntity, new()
    {
        protected readonly DbSet<T> _dbset;
        protected readonly ApplicationDbContext _dbContext;

        public string UserId { get { return User.FindFirstValue(ClaimTypes.NameIdentifier); } }

        public async Task<ApplicationUser> GetCurrentUser()
        {
            return await this._dbContext.Users.FindAsync(this.UserId);
        }

        public GenericODataController(DbSet<T> dbset, ApplicationDbContext dbcontext)
        {
            _dbset = dbset;
            _dbContext = dbcontext;
        }

        [EnableQuery]
        public virtual IQueryable<T> Get()
        {
            return _dbset;
        }

        [EnableQuery]
        public virtual SingleResult Get(int key)
        {
            return SingleResult.Create(_dbset.Where(a => a.Id == key));
        }

        [EnableQuery]
        public virtual async Task<IActionResult> Post([FromBody] T entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _dbset.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return Created(entity);
        }

        public async Task<IActionResult> Patch([FromODataUri] int key, Delta<T> product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await _dbset.FirstAsync(e => e.Id == key);
            if (entity == null)
            {
                return NotFound();
            }
            product.Patch(entity);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbset.Any(p => p.Id == key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(entity);
        }

        public async Task<IActionResult> Delete([FromODataUri] int key)
        {
            var product = await _dbset.FirstAsync(e => e.Id == key);
            if (product == null)
            {
                return NotFound();
            }
            _dbset.Remove(product);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

    }
}