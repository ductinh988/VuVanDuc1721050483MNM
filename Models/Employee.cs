using System;
using System.ComponentModel.DataAnnotations;

namespace BaiThucHanh1402.Models
{ 
    public class Employee
    {
        [Key]
        
        [MinLength(3),MaxLength(30)]
        public string  EmployeeID { get; set; }
         [Required]
         [MinLength(3),MaxLength(30)]
        public string  EmployeeName { get; set; }
        [Required(ErrorMessage="không được để trống")]
         [MinLength(3),MaxLength(30)]
        public string Address { get; set;}
    }
}