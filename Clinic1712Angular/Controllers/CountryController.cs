using Clinic1712Angular.Models;
using Clinic1712Angular.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic1712Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Sales")]
    public class CountryController : ControllerBase
    {
        ICountryService countryService;

        public CountryController(ICountryService _countryService)
        {
            countryService = _countryService;
        }

        [HttpPost]
        public void Create(CountryDTO countryDTO)
        {
            countryService.Create(countryDTO);
        }

        [HttpGet]
        [Route("GetAll")]
        public List<CountryDTO> GetAll()
        {
            return countryService.GetAll();
        }

        [HttpGet]
        [Route("Get")]
        public CountryDTO Get(int Id)
        {
            return countryService.Get(Id);
        }

        [HttpDelete]
        public void Delete(int Id)
        {
            countryService.Delete(Id);
        }

        [HttpPut]
        public void Update(CountryDTO countryDTO)
        {
            countryService.Update(countryDTO);
        }
    }
}
