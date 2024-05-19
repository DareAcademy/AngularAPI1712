using AutoMapper;
using Clinic1712Angular.data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic1712Angular.Models
{
    [AutoMap(typeof(Patient), ReverseMap = true)]
    public class PatientDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please fill out the first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please fill out the last name")]
        public string LastName { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please fill out the phone")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please fill out the date of birth")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Please fill out the country")]
        public int Country_Id { get; set; }
    }
}
