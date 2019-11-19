using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ADSBackend.Models.StaffViewModel
{
    public class Staff
    {
        public string id { get; set; }
        [Required]
        [Display(Name = "Counselor Name")]
       
        public string CName { get; set; }
        [Required]
        [Display(Name = "Counselor Grade Level")]
        public int CGrade { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Counselor Email")]
        public string CEmail { get; set; }


    }
}
