using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.BOL
{
    [Table("Patients")]
    public class Patients
    {
        [Key]
        public int PId { get; set; }

        [Required(ErrorMessage = "Patient Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        public string City { get; set; }
        public int PhoneNo { get; set; }

        public virtual IEnumerable<Appointments> Appointments { get; set; }
        
       
    }
}
