using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Strength_MVC.Models;
using StrengthEFcore;
using System.Diagnostics;

namespace Strength_MVC.Controllers
{
    public class UserWorkoutBoutViewModel
    {
        public string UserName { get; set; }
        public List<WorkoutViewModel> Workouts { get; set; }
    }

    public class WorkoutViewModel
    {
        public string WorkoutName { get; set; }
        public List<ExerciseBout> Bouts { get; set; }
    }

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EntityContext _entityContext;

        public HomeController(ILogger<HomeController> logger, EntityContext entityContext )
        {
            _logger = logger;
            _entityContext = entityContext;
        }

        public IActionResult Index()
        {

            var test = _entityContext.ExerciseBout.Select(x => x).ToList();

            var viewModel = _entityContext.Users
                .Include(u => u.Workouts)
                    .ThenInclude(w => w.ExerciseBouts)
                .Select(user => new UserWorkoutBoutViewModel
                {
                    UserName = user.Name,
                    Workouts = user.Workouts.Select(workout => new WorkoutViewModel
                    {
                        WorkoutName = workout.Name,
                        Bouts = workout.ExerciseBouts.ToList()
                    }).ToList()
                }).ToList();

            return View(viewModel);
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
