using ADSBackend.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ADSBackend.Configuration
{
    public class ApplicationRoleSeed
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public ApplicationRoleSeed(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public void CreateRoles()
        {
            var roles = new List<string>
            {
                "Admin",
                "User"
            };

            foreach (var roleName in roles)
            {
                if (!_roleManager.RoleExistsAsync(roleName).Result)
                {
                    var role = new ApplicationRole { Name = roleName };

                    _roleManager.CreateAsync(role).Wait();
                }
            }
        }
        public void CreateURLTypes()
        {
            var Types = new List<string>
            {
                "Test", //Used for SAT and ACT test links
                "Scholarship" //Used for Scholarship links
            };

            foreach (var typeName in Types)
            {
                if (!_roleManager.RoleExistsAsync(typeName).Result)
                {
                    var type = new ApplicationRole { Name = typeName };
                    _roleManager.CreateAsync(type).Wait();
                }
            }
        }
    }
}
