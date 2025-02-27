using Kitabim.Data;
using Kitabim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq; 
using System.Threading.Tasks;


namespace Kitabim.Controllers
{
    public class ProductsController : Controller
    {
        private readonly KitabimDbContext _context;
        private object? searchString;

        public ProductsController(KitabimDbContext context)
        {
            _context = context;
        }

        // GET: /Products/
       public async Task<IActionResult> Index(string genre, string sortOrder, string searchString, int? pageNumber)
{
    int pageSize = 9;

    var books = from b in _context.Books
                select b;

    if (!string.IsNullOrEmpty(genre))
    {
        books = books.Where(b => b.Genre == genre);
    }

    if (!string.IsNullOrEmpty(searchString))
    {
        books = books.Where(b => b.Title.Contains(searchString) || b.Author.Contains(searchString));
    }

    switch (sortOrder)
    {
        case "price_asc":
            books = books.OrderBy(b => b.Price);
            break;
        case "price_desc":
            books = books.OrderByDescending(b => b.Price);
            break;
        default:
            books = books.OrderBy(b => b.Title);
            break;
    }

    ViewData["Genres"] = await _context.Books.Select(b => b.Genre).Distinct().ToListAsync();
    ViewData["CurrentFilter"] = searchString;

    return View(await PaginatedList<Book>.CreateAsync(books.AsNoTracking(), pageNumber ?? 1, pageSize));
}


        // GET: /Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
    }
}
