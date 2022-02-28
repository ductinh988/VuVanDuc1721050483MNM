using System;
using System.ComponentModel.DataAnnotations;

namespace BaiThucHanh1402.Models
{ 
    public class Student
    {
        [Key]
        public String  StudentID { get; set; }
         [MinLength(3),MaxLength(30)]
          [Required(ErrorMessage="không được để trống")]
         
        public string  StudentName { get; set; }
         [Required(ErrorMessage="không được để trống")]
         [MinLength(3),MaxLength(30)]
         public string Address { get; set;}

    }
}