using CAS.BOL.DataTypes;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public DegreeTypes? Degree { get; set; } //int 0,1,2
        public SpeciallityTypes? Speciallity { get; set; }
        public string PhoneNo { get; set; }
        public decimal DrFee { get; set; }

        [NotMapped]
        public SelectList? DegreeList { get; set; }

        [NotMapped]
        public SelectList? SpeciallityList { get; set; }
        public virtual IEnumerable<Appointments> Appointments { get; set; }
    }
}
