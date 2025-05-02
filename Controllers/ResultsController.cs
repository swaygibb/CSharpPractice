using CSharpPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CSharpPractice.Controllers
{
    public class ResultsController : Controller
    {
        private readonly AppDbContext _context;

        public ResultsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var recentResults = PowerliftingResult
                .Recent(_context.PowerliftingResults.Include(recentResults => recentResults.Meet))
                .ToList();

            return View(recentResults);
        }

        public async Task<IActionResult> Search(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var results = _context.PowerliftingResults.Include(r => r.Meet).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                results = results.Where(r =>
                    r.Name.Contains(searchString) ||
                    (r.Division != null && r.Division.Contains(searchString)) ||
                    (r.Meet != null && !string.IsNullOrEmpty(r.Meet.MeetName) && r.Meet.MeetName.Contains(searchString)) || 
                    (r.Meet != null && !string.IsNullOrEmpty(r.Meet.Federation) && r.Meet.Federation.Contains(searchString)))
                    .Take(20);
            }


            return View(await results.ToListAsync());
        }

        public IActionResult Details(int Id)
        {
            var result = _context.PowerliftingResults
                .Include(r => r.Meet)
                .FirstOrDefault(r => r.Id == Id);

            return View(result);
        }
    }
}
