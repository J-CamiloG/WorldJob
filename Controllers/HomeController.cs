using Microsoft.AspNetCore.Mvc;
using JobWebApp.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JobWebApp.Data;
using System.Diagnostics;



namespace JobWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly JobDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(JobDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var jobs = await _context.Jobs.ToListAsync();
            return View(jobs);
        }

        public IActionResult Privacy()
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
