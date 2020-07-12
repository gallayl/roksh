using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using roksh.Data;
using roksh.Models;
using roksh.Services;

namespace roksh.Controllers
{

    [Authorize]
    public class PackagesController : GenericODataController<Package>
    {

        private readonly IDataFetcher _fetcher;

        public PackagesController(ApplicationDbContext db, IDataFetcher fetcher) : base(db.Packages, db)
        {
            _fetcher = fetcher;
        }

        [EnableQuery]
        public override IQueryable<Package> Get()
        {
            var userId = this.UserId;
            var entities = base._dbset.Where(package => package.Owner.Id == userId);
            return entities;
        }

        [EnableQuery]
        public override SingleResult Get(int key)
        {
            var userId = this.UserId;
            return SingleResult.Create(_dbset.Where(a => a.Id == key && a.Owner.Id == userId));
        }

        [EnableQuery]
        public override async Task<IActionResult> Post(Package package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentUser = await this.GetCurrentUser();
            var items = await _fetcher.GetItems();
            package.Owner = currentUser;
            package.Items = items;
            var created = await _dbset.AddAsync(package);
            await _dbContext.SaveChangesAsync();
            return Created(package);
        }
    }
}