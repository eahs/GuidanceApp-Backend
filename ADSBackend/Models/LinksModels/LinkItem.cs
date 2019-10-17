using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ADSBackend.Models.LinksModels
{
    public class LinkItem
    {
        public string Id { get; set; }
        [Required]
        [StringLength(75, ErrorMessage ="Title cannot be longer than 75 characters.")]
        [Display(Name ="Website Title")]
        public string Title { get; set; }
        [Display(Name="Website Description")]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Url)]
        [Display(Name ="Website URL")]
        public string Link { get; set; }
        [Required]
        [Display(Name ="Website Type")]
        public string Type { get; set; }

    }
}
