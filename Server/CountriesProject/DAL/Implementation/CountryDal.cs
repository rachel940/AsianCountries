using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DAL.Implementation
{
    public class CountryDal : ICountryDal
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public CountryDal(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        //Get All Countries from url api
        public async Task<List<Country>> GetAllCountries()
        {
            try
            {
                string apiUrl = _configuration.GetSection("UrlApi").Value;

                var response = await _httpClient.GetStringAsync(apiUrl);
                if (!string.IsNullOrEmpty(response))
                {
                    return JsonConvert.DeserializeObject<List<Country>>(response);
                }
                return new List<Country>();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the data from api.", ex);
            }
        }
    }
}
