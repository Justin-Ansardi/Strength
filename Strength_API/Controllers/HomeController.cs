using Microsoft.AspNetCore.Mvc;
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
            var result = DAF.GetUserWorkoutData(_entityContext, userId).ToList();

            return JsonConvert.SerializeObject(result);
        }

       

    }
}
