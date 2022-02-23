using System;
using System.ComponentModel.DataAnnotations;

namespace BaiThucHanh1402.Models
{ 
    public class Person
    {
        [Key]
        public int  PersonID { get; set; }
        public string  PersonName { get; set; }

    }
}