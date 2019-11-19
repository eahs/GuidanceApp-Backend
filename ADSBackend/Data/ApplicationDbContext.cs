using ADSBackend.Models;
using ADSBackend.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ADSBackend.Models.LinksModels;
using ADSBackend.Models.CalendarViewModel;
using ADSBackend.Models.JobsViewModel;
using ADSBackend.Models.AppointmentModel;
using ADSBackend.Models.SummerWork;

namespace ADSBackend.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ConfigurationItem> ConfigurationItem { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<ADSBackend.Models.LinksModels.LinkItem> LinkItem { get; set; }

        public DbSet<ADSBackend.Models.CalendarViewModel.Calendar> Calendar { get; set; }

        public DbSet<ADSBackend.Models.JobsViewModel.Jobs> Jobs { get; set; }

        public DbSet<ADSBackend.Models.AppointmentModel.Appointment> Appointment { get; set; }

        public DbSet<ADSBackend.Models.SummerWork.SummerWork> SummerWork { get; set; }
        

    }
}
