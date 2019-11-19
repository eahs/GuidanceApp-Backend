using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ADSBackend.Models.AppointmentModel
{
    public class Appointment
    {
        [Key]
        public string Appoint { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Grade Level")]
        public int Grade { get; set; }
        [Required]
        [Display(Name = "Counselor")]
        public string Counselor { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public string Date { get; set; }
        [DataType(DataType.Duration)]
        [Display(Name = "Time")]
        public string Time { get; set; }
        [Display(Name = "Description")]
        public string Desc { get; set; }

        
    }
}
