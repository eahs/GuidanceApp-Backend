using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ADSBackend.Models.CalendarViewModel
{
    public class Calendar
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Event Title")]
        public string Title { get; set; }
        [Display(Name = "Event Description")]
        public string Desc { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string Date { get; set; }
    }
}
