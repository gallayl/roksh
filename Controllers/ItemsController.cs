using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using roksh.Data;
using roksh.Models;

namespace roksh.Controllers
{

    [Authorize]
    public class ItemsController : GenericODataController<Item>
    {
        public ItemsController(ApplicationDbContext db) : base(db.Items, db)
        {
        }

        [EnableQuery]
        public override IQueryable<Item> Get()
        {
            var userId = this.UserId;
            var entities = base._dbset.Where(item => item.Package.Owner.Id == userId);
            return entities;
        }

        [EnableQuery]
        public override SingleResult Get(int key)
        {
            var userId = this.UserId;
            return SingleResult.Create(_dbset.Where(a => a.Id == key && a.Package.Owner.Id == userId));
        }

    }
}