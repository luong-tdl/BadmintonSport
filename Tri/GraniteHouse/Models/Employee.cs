using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteHouse.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime BirthData { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [Display(Name= "Vị trí tuyển dụng")]
        public int VitriEmployeeId { get; set; }
        [ForeignKey("VitriEmployeeId")]
        public virtual PositionEmployee PositionEmployee { get; set; }
    }
}
