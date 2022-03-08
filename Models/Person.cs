using System;
using System.ComponentModel.DataAnnotations;

namespace BaiThucHanh1402.Models
{ 
    public class Person
    {
        [Key]
        [Required]
        [Display(Name="id")]
        public string  PersonID { get; set; }
        [MinLength(3),MaxLength(30)]
        [Required(ErrorMessage="không được để trống")]
        [Display(Name="tên người")]
        public string  PersonName { get; set; }
        [MinLength(3),MaxLength(30)]
        [Required(ErrorMessage="không được để trống")]
        [Display(Name="quê quán")]
         public string Address { get; set;}

    }
}