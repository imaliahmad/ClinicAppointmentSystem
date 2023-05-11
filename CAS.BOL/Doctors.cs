using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.BOL
{
    [Table("Doctors")]
    public class Doctors
    {
        [Key]
        public int DId { get; set; }

        [Required(ErrorMessage = "Doctor Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Doctor Degree is required")]
        public string Degree { get; set; }
        public string Speciallity { get; set; }
        public decimal Salary { get; set; }
        public int PhoneNo { get; set; }
        public virtual IEnumerable<Appointments> Appointments { get; set; }
    }
}
