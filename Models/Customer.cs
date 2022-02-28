using System;
using System.ComponentModel.DataAnnotations;

namespace BaiThucHanh1402.Models
{ 
    public class Customer :Person
    {
        public string  Email { get; set; }
         [Required(ErrorMessage="không được để trống")]
        public string  Gender { get; set; }
        [DataType(DataType.Date)]
         [Required(ErrorMessage="không được để trống")]
         public DateTime Birthday { get; set;}

    }
}