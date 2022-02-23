using System;
using System.ComponentModel.DataAnnotations;

namespace BaiThucHanh1402.Models
{ 
    public class Employee
    {
        [Key]
        public int  EmployeeID { get; set; }
        public string  EmployeeName { get; set; }

    }
}