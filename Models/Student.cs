using System;
using System.ComponentModel.DataAnnotations;

namespace BaiThucHanh1402.Models
{ 
    public class Student
    {
        [Key]
        public int  StudentID { get; set; }
        public string  StudentName { get; set; }

    }
}