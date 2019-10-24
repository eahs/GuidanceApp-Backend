using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ADSBackend.Models.JobsViewModel
{
    public class Jobs
    {
        [Key]
        public string AJobs { get; set; }
        [Required]
        [Display(Name = "Jobs Name")]
        public string JobTitle { get; set; }
        [Required]
        [Display(Name = "Job Description")]
        public string JobDetail { get; set; }
     
        [Display(Name = "Hourly Wage")]
        public string Wage { get; set; }
  
        [Display(Name = "Work Hours")]
        public string Hours { get; set; }
     
    }

}
