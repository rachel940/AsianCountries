using BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Countries.Controllers
{
    [Produces("application/json")]
    [Route("countries/[controller]/[Action]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Country>>> GetAsianCountries()
        {
            try
            {
                var asianCountries = await _countryService.GetCountriesByRegionAsync(RegionConstants.Asia);

                if (asianCountries != null)
                    return Ok(asianCountries);

                if (asianCountries == null || !asianCountries.Any())
                {
                    return NoContent();
                }

                return BadRequest();
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing GetAsianCountries.");
            }
        }
    }
}
