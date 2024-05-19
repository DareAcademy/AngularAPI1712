using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic1712Angular.data
{
    [Table("Patients")]
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }
        [ForeignKey("country")]
        public int Country_Id { get; set; }
        public Country country { get; set; }
    }
}
