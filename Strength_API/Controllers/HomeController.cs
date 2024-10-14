using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using StrengthEFcore;
using StrengthEFcore.CreationalFucntions;
using StrengthEFcore.DataAcessFunctions;
using System.Net.Mime;

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

        //[HttpGet(Name = "GetAllWorkoutsForUser")]
        //public string GetAllWorkoutsForUser(int userId)
        //{
        //    var result = DAF.GetUserWorkoutData(_entityContext, userId).ToList();

        //    return JsonConvert.SerializeObject(result);
        //}



        [HttpGet(Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public string GetAllUsers()
        {
            var result = DAF.GetAllUsers(_entityContext).ToList();

            return JsonConvert.SerializeObject(result);
        }



        [HttpPost(Name = "CreateNewUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> CreateNewUser(User user)
        {
            if (user == null)
            {
                return new BadRequestResult();
            }

            await CF.CreateNewUser(_entityContext, user);

            return new CreatedAtRouteResult(nameof(CreateNewUser), new { id = user.Id }, user);
        }



    }
}
