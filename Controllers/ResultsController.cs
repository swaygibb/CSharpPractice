using CSharpPractice.Helpers;
using CSharpPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            var query = PowerliftingResult
                .Recent(_context.PowerliftingResults.Include(r => r.Meet));

            return View(query.ToList());
        }


        public async Task<IActionResult> Search(string searchString, int page = 1, int pageSize = 20)
        {
            ViewData["CurrentFilter"] = searchString;

            var results = _context.PowerliftingResults.Include(r => r.Meet).AsQueryable();
            results = SearchHelper.SearchQuery(results, searchString);
            var (currentPage, totalPages, resultRecords) = PagingHelper.SetPowerliftingPaging(results, page, pageSize);

            ViewData["CurrentPage"] = currentPage;
            ViewData["TotalPages"] = totalPages;

            return View(await resultRecords.ToListAsync());
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
