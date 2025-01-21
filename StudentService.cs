using UkasNøttBackend.Data;

namespace UkasNøttBackend
{
    internal class StudentService
    {
        public List<Student> StudentsList { get; private set; } = new List<Student>();
        private readonly StudentDBContext studentDBContext;

    
        public StudentService(StudentDBContext studentDBContext)
        {
            studentDBContext = studentDBContext;
            var tempTeam = 0;
            var txtFile = "C:\\Users\\robin\\Desktop\\UkasNøttBackend\\UkasNøttBackend\\Students.txt";
            var textData = File.ReadAllLines(txtFile);
            var studentName = string.Empty;
            var studentDescription = string.Empty;


            foreach (var line in textData)
            {

                if (line.Contains("Team"))
                {
                    tempTeam++;
                }

                else if (line.Contains(" "))
                {
                    studentName = line;
                }
                else
                {
                    studentDescription = line;
                    Student newStudent = new Student()
                    {
                        Name = studentName,
                        Description = studentDescription,
                        TeamNumber = tempTeam

                    };

                    studentDBContext.Students.Add(newStudent);
                    //StudentsList.Add(newStudent);
                    
                };
            }

        }

        //public void WriteStudentsFromFile()
        //{
        //    foreach (var student in StudentsList)
        //    {
        //        Console.WriteLine($"name:{student.Name}, description:{student.Description}, team: {student.TeamNumber} ");
        //    }
        //}

    }
}
