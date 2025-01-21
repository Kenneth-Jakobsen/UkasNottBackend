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
            this.studentDBContext = studentDBContext;
        }

        [HttpGet(Name = "GetStudentTeam")]
        public List<Student> GetStudents()
        {
            var students = studentDBContext.Students.ToList();
            return students;
        }


        [HttpPost(Name = "PostStudentTeam")]
        public void AddStudent(Student student)
        {
            var newStudent = new Student()
            {
                Name = student.Name,
                Description = student.Description,
                TeamNumber = student.TeamNumber
            };

            studentDBContext.Students.Add(newStudent);

            studentDBContext.SaveChanges();
        }

    }
}
