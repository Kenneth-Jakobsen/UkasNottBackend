using UkasNottBackend.Data;

namespace UkasNottBackend
{
    internal class StudentService
    {
        public List<Student> StudentsList { get; private set; } = new List<Student>();
        private readonly StudentDBContext studentDBContext;

    
        public StudentService(StudentDBContext studentDBContext)
        {
            studentDBContext = studentDBContext;
            var tempTeam = 0;
            string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            var txtFile = _filePath + "\\Students.txt";
            var textData = File.ReadAllLines(txtFile);
            var studentName = string.Empty;
            var studentDescription = string.Empty;


            if (!studentDBContext.Teams.Any() || !studentDBContext.Students.Any())
                foreach (var line in textData)
                {

                    if (line.Contains("Team"))
                    {
                        tempTeam++;
                        var team = new Team()
                        {
                            Id = tempTeam,
                            TeamName = line
                        };

                        studentDBContext.Teams.Add(team);
                        studentDBContext.SaveChanges();

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
                        studentDBContext.SaveChanges();

                        //StudentsList.Add(newStudent);

                    };
                }
            else
            {
                Console.WriteLine("Det finnes allerede data!");
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
