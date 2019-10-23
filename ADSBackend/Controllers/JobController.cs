using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ADSBackend.Data;
using ADSBackend.Models.LinksModels;
using ADSBackend.Models.Identity;

namespace ADSBackend.Controllers
{
    public class JobController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IActionResult Index()
        {
            return View("Index", new List<ADSBackend.Models.JobsViewModel.Jobs>());
        }
        public async Task<IActionResult> Create()
        {

            return View();
        }
    }
}