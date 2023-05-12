using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.BOL
{
    [Table("Departments")]
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        [Required]
        public string DeptName { get; set; }


    }
}
