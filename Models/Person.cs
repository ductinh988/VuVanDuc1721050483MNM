using System;
using System.ComponentModel.DataAnnotations;

namespace BaiThucHanh1402.Models
{ 
    public class Person
    {
        [Key]
        [Required]
        public string  PersonID { get; set; }
        [MinLength(3),MaxLength(30)]
        [Required(ErrorMessage="không được để trống")]
        public string  PersonName { get; set; }
        [MinLength(3),MaxLength(30)]
        [Required(ErrorMessage="không được để trống")]
         public string Address { get; set;}

    }
}