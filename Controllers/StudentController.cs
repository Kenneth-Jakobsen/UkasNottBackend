using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UkasNøttBackend;
using UkasNøttBackend.Data;
namespace UkasNøttBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentDBContext studentDBContext;

        public StudentController(StudentDBContext studentDBContext)
        {
            //CreateNewStudentService(studentDBContext);
            this.studentDBContext = studentDBContext;
        }

        [HttpGet(Name = "GetStudent")]
        public List<Student> GetStudents()
        {

            //var teams = studentDBContext.Teams.ToList();
            var students = studentDBContext.Students.ToList();
            HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return students;
        }

        //private void CreateNewStudentService(StudentDBContext studentDBContext)
        //{
        //    StudentService studentService = new StudentService(studentDBContext);
        //}

    }
}
