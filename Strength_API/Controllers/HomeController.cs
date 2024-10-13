using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StrengthEFcore;

namespace Strength_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController
    {
        private readonly EntityContext _entityContext;

        public HomeController(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        [HttpGet(Name = "GetAllWorkoutsForUser")]
        //public IEnumerable<Workout> GetAllWorkoutsForUser(int userId)
        //{
        //    var workouts = _entityContext.Workout.Select(x => x).ToList();
        //    var bouts = _entityContext.ExerciseBout.Select(x => x).Where(x => workouts.Any(x.WorkoutId) == true);
        //    }


        public IEnumerable<Workout> GetAllWorkoutsForUser(int userId) =>
        _entityContext.Workout.Select(x => x).Include(x => x.ExerciseBouts).Where(x => x.UserId == userId).ToList();




    }
}
