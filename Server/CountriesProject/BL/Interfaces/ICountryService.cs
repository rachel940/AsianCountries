using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ICountryService
    {
        Task<List<Country>> GetCountriesByRegionAsync(string region);
    }
}
