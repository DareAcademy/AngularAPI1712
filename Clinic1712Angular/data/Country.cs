using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic1712Angular.data
{
    [Table("Countries")]
    public class Country
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public List<Patient> lipatients { get; set; }
    }
}
