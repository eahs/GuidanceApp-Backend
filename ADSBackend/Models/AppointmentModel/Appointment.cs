using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ADSBackend.Models.AppointmentModel
{
    public class Jobs
    {
        [Key]
        public string Appointment { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Councelor")]
        public string Councelor { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Hourly Wage")]
        public string Wage { get; set; }
        [DataType(DataType.Duration)]
        [Display(Name = "Work Hours")]
        public string Hours { get; set; }
        public string Test { get; set; }
    }
}
