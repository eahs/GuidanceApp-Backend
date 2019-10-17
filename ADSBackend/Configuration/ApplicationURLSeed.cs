using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADSBackend.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace ADSBackend.Configuration
{
    public class ApplicationURLSeed
    {
        private readonly RoleManager<ApplicationURL> _typeManager;
        public ApplicationURLSeed(RoleManager<ApplicationURL> typeManager)
        {
            _typeManager = typeManager;
        }
        public void CreateURLTypes()
        {
            var Types = new List<string>
            {
                "Test", //Used for SAT and ACT test links
                "Scholarship" //Used for Scholarship links
            };

            foreach(var typeName in Types)
            {
                if (!_typeManager.RoleExistsAsync(typeName).Result)
                {
                    var type = new ApplicationURL { Name = typeName };
                    _typeManager.CreateAsync(type).Wait();
                }
            }
        }
    }
}
