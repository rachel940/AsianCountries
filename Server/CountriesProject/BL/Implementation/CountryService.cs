using BL.Interfaces;
using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Implementation
{
    public class CountryService : ICountryService
    {
        private readonly ICountryDal _countryDal;
        public CountryService(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        public async Task<List<Country>> GetCountriesByRegionAsync(string region)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(region))
                {
                    throw new ArgumentNullException(nameof(region));
                }

                var countries = await _countryDal.GetAllCountries();
                if (countries != null)
                {
                    return countries.Where(c => c.Region.ToLower() == region.ToLower()).ToList();
                }
                return countries;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving countries by region", ex);
            }
        }
    }
}
