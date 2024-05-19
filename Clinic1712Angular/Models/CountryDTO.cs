using AutoMapper;
using Clinic1712Angular.data;
using System.ComponentModel.DataAnnotations;

namespace Clinic1712Angular.Models
{
    [AutoMap(typeof(Country),ReverseMap =true)]
    public class CountryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please fill out the country code")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please fill out the country name")]
        public string Name { get; set; }
    }
}
