using CSharpPractice.Helpers;
using CSharpPractice.Models;
using Helpers;
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
            var pagingData = PagingHelper.SetPowerliftingPaging(results, page, pageSize);

            ViewData["CurrentPage"] = pagingData.Page;
            ViewData["TotalPages"] = pagingData.TotalPages;

            return View(await pagingData.Results.ToListAsync());
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
