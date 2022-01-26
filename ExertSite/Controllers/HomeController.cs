using ExertSite.Data;
using ExertSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ExertSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            Container viewModel = new Container();
            viewModel.Sliders = _context.Sliders.OrderBy(x=>x.SliderPosition);
            viewModel.Portfolios = _context.Portfolios;
            viewModel.Services = _context.Services;
            viewModel.Projects = _context.Projects;
            viewModel.GrowTexts = _context.GrowText;
            viewModel.Clients = _context.Client;
            viewModel.Contacts = _context.Contact;
            viewModel.Members = _context.Members;
            
            
            return View(viewModel);
        }

        public IActionResult Admin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
