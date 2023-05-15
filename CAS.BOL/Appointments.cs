using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.BOL
{
    [Table("Appointments")]
    public class Appointments
    {
        [Key]
        public int AppId { get; set; }

        [Required(ErrorMessage = "Appointment no is required")]
        public string AppNo { get; set; }

        [ForeignKey("Patients")]
        [DisplayName("Patient")]

        public int PId { get; set; }
        public virtual Patients? Patients { get; set; }

        [ForeignKey("Doctors")]
        [DisplayName("Doctor")]

        public int DId { get; set; }
        public virtual Doctors? Doctors { get; set; }

        public DateTime AppDateTime { get; set; }

        [Required(ErrorMessage = "Dr Fee is required")]
        public decimal DrFee { get; set; }
        public decimal Discount { get; set; }
        public decimal AfterDiscount { get; set; }

        [Required(ErrorMessage = "Fee Status is required")]
        public string FeeStatus { get; set; }

        [Required(ErrorMessage = "Appointment Status is required")]
        public string AppStatus { get; set; }

        [NotMapped]
        public SelectList? PatientsList { get; set; }

        [NotMapped]
        public SelectList? DoctorsList { get; set; }
    }
}
