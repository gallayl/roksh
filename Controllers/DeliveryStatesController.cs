using Microsoft.AspNetCore.Authorization;
using roksh.Data;
using roksh.Models;

namespace roksh.Controllers
{

    [Authorize]
    public class DeliveryStatesController : GenericODataController<DeliveryState>
    {

        public DeliveryStatesController(ApplicationDbContext db) : base(db.DeliveryStates, db)
        {
        }
    }
}