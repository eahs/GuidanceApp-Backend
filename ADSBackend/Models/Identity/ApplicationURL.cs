using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ADSBackend.Models.Identity
{
    public class ApplicationURL : IdentityRole<int>
    {
        [Required]
        [Display(Name ="Website Type")]
        public string Type { get; set; }
    }
}
