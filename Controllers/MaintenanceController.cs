using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UkasNøttBackend.Data;

namespace UkasNøttBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaintenanceController : ControllerBase
    {

        private readonly StudentDBContext studentDBContext;

        public MaintenanceController(StudentDBContext studentDBContext)
        {
            //CreateNewStudentService(studentDBContext);
            this.studentDBContext = studentDBContext;
        }

        [HttpDelete(Name = "DeleteData")]
        public IActionResult DeleteData()
        {

            foreach (var entityType in studentDBContext.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                studentDBContext.Database.ExecuteSqlRaw($"DELETE FROM {tableName}");
            }
            
            studentDBContext.SaveChanges();
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Ok();
        }

        [HttpPut(Name = "PutData")]
        public IActionResult PutData()
        {

            new StudentService(studentDBContext);
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Ok();
        }

    }
}
