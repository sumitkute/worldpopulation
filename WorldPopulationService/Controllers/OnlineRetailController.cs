using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using world.data;

namespace WorldPopulationService.Controllers
{
    public class OnlineRetailController : ApiController
    {
        public async Task<IHttpActionResult> Get()
        {
            var items = await DocumentDBRepository<Invoice>.GetItemsAsync(x =>x.Quantity > 0, 100);
            if (items.Count() == 0)
                return NotFound();
            return Ok(items);
        }
    }
}
