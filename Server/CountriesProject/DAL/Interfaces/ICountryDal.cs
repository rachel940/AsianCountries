using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICountryDal
    {
        Task<List<Country>> GetAllCountries();
    }
}
