using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taxi.Web.Data;
using Taxi.Web.Helpers;

namespace Taxi.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxisController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;

        public TaxisController(
                    DataContext context,
                        IConverterHelper converterHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
        }

        [HttpGet("{plaque}")]
        public async Task<IActionResult> GetTaxiEntity([FromRoute] string plaque)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taxiEntity = await _context.Taxis
                        .Include(t => t.User) //Drivers
                            .Include(t => t.Trips)
                                .ThenInclude(t => t.TripDetails)
                                    .Include(t => t.Trips)
                                        .ThenInclude(t => t.User) //Passenger
                                            .FirstOrDefaultAsync(t => t.Plaque == plaque);
            
            if (taxiEntity == null)
            {
                return NotFound();
            }

            return Ok(_converterHelper.ToTaxiResponse(taxiEntity));
        }       
        private bool TaxiEntityExists(int id)
        {
            return _context.Taxis.Any(e => e.Id == id);
        }
    }
}