using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ADSBackend.Models.JobsViewModel
{
    public class Jobs
    {
        public string AJobs { get; set; }
        public string JobTitle { get; set; }
        [Display(Name = "Job")]
        public string JobDetail { get; set; }
        [Display(Name = "Job Description")]
        public string Wage { get; set; }
        [Display(Name = "Wage")]
        public string Hours { get; set; }
        [Display(Name = "Hours")]
        public string Test { get; set; }
    }

}
