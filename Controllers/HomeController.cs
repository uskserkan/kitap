using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Kitabim.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kitap.Models;
using Kitabim.Data;

namespace kitap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KitabimDbContext _context;

        public HomeController(ILogger<HomeController> logger, KitabimDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var images = new List<string>
            {
                "/images/slide1.png",
                "/images/slide2.png",
                "/images/slide3.png"
            };

            
            var latestBooks = await _context.Books
                                            .OrderBy(r => EF.Functions.Random())
                                            .Take(4)
                                            .ToListAsync();

            ViewData["Images"] = images;
            ViewData["LatestBooks"] = latestBooks;

            return View(images);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
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
