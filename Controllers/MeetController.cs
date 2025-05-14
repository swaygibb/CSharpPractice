using CSharpPractice.Models;
using CSharpPractice.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CSharpPractice.Controllers
{
    public class MeetController : Controller
    {
        private readonly Repository<Meet> _meetRepository;

        public MeetController(AppDbContext context)
        {
            _meetRepository = new Repository<Meet>();
            _meetRepository.Add(new Meet
            {
                Id = 1,
                MeetID = 1001,
                MeetName = "North Dakota Open"
            });
            _meetRepository.Add(new Meet
            {
                Id = 2,
                MeetID = 1002,
                MeetName = "Minnesota Open"
            });
        }

        public IActionResult Index()
        {
            // Covariance Example: Assigning IEnumerable<Meet> to IEnumerable<IEntity>
            IEnumerable<Meet> meets = _meetRepository.GetAll();
            IEnumerable<IEntity> entities = meets; // Covariance: Meet is derived from IEntity

            return Json(entities);
        }

        public IActionResult Details(int id)
        {
            // Contravariance Example: Using a contravariant delegate
            Action<IEntity> logEntity = LogEntity; // Contravariance: IEntity is more generic than Meet
            var meet = _meetRepository.GetById(id);

            if (meet == null)
            {
                return NotFound();
            }

            logEntity(meet); // Passing a Meet instance to a delegate expecting IEntity

            return Json(meet);
        }

        // Contravariant delegate example
        private void LogEntity(IEntity entity)
        {
            Console.WriteLine($"Entity ID: {entity.Id}");
        }
    }
}