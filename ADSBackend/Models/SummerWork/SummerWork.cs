using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ADSBackend.Models.SummerWork
{
    public class SummerWork

    {
        [Key]
        public string SummerID { get; set; }
        [Required]
        [Display(Name = "Class")]
        public string Class { get; set; }
   
        [Display(Name = "Classroom Code")]
        public string Classroom { get; set; }
        [DataType(DataType.Url)]
        [Display(Name = "Link to work")]
        public string Link { get; set; }

    }
}
