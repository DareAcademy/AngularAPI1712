using AutoMapper;
using Clinic1712Angular.data;
using Clinic1712Angular.Models;
using Microsoft.EntityFrameworkCore;
namespace Clinic1712Angular.services
{
    public class CountryService: ICountryService
    {
        ClinicContext context;
        IMapper mapper;

        public CountryService(ClinicContext _context,IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        public void Create(CountryDTO countryDTO)
        {
            Country newCountry = mapper.Map<Country>(countryDTO);
            context.countries.Add(newCountry);
            context.SaveChanges();
        }

        public void Update(CountryDTO countryDTO)
        {
            Country newCountry = mapper.Map<Country>(countryDTO);
            context.countries.Attach(newCountry);
            context.Entry(newCountry).State = EntityState.Modified;
            context.SaveChanges();

        }

        public List<CountryDTO> GetAll()
        {
            List<Country> allCountries = context.countries.ToList();
            List<CountryDTO> countries = mapper.Map<List<CountryDTO>>(allCountries);
            return countries;
        }

        public CountryDTO Get(int ID)
        {
            Country country = context.countries.Find(ID);
            CountryDTO countrryDTO = mapper.Map<CountryDTO>(country);
            return countrryDTO;
        }

        public void Delete(int Id)
        {
            Country country = context.countries.Find(Id);
            context.countries.Remove(country);
            context.SaveChanges();
        }
    }
}
