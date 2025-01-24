using Microsoft.AspNetCore.Mvc;
using UkasNottBackend.Data;

namespace UkasNottBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly StudentDBContext studentDBContext;

        public TeamController(StudentDBContext studentDBContext)
        {
            //CreateNewStudentService(studentDBContext);
            this.studentDBContext = studentDBContext;
        }

        [HttpGet(Name = "GetTeam")]
        public List<Team> GetTeam()
        {

            var teams = studentDBContext.Teams.ToList();
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return teams;
        }

    }
}
