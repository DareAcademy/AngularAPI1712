using Clinic1712Angular.Models;

namespace Clinic1712Angular.services
{
    public interface ICountryService
    {
        void Create(CountryDTO countryDTO);
        List<CountryDTO> GetAll();

        void Delete(int Id);
        CountryDTO Get(int ID);

        void Update(CountryDTO countryDTO);
    }
}
