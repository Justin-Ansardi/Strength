using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StrengthEFcore;
using StrengthEFcore.DataAcessFunctions;

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

        public string GetAllWorkoutsForUser(int userId)
        {
            var query =   DAF.GetUserWorkoutData(_entityContext, userId).ToList();
            //var output = JsonConvert.SerializeObject(query.Select(x => x.ExerciseBouts.Select(y => y.SetReps)));
            var output = JsonConvert.SerializeObject(query);
            return output;

        }

       

    }

    //public static record WorkoutDTO
    //{

    //}
}
