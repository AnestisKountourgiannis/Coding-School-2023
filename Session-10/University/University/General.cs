using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace University
{
    public class General
    {
        public University University { get; set; }
        private int _amountOfSchedules = 0;
        public General()
        {
            University = new University();
            University.Students = new List<Student>();
            University.Courses = new List<Course>();
            University.Grades = new List<Grade>();
            University.Professors = new List<Professor>();
            University.ScheduledCourses = new List<Schedule>();
        }
        public string GetUniName()
        {
            return University.Name;
        }
        public List<Student> GetStudents()
        {
            return University.Students;
        }
        public List<Course> GetCourses()
        {
            return University.Courses;
        }
        public List<Grade> GetGrades()
        {
            return University.Grades;
        }
        public void SetCourse(Guid courseID, Guid professorID, DateTime datetime)
        {
            University.ScheduledCourses[_amountOfSchedules++] = new Schedule(courseID, professorID, datetime);
        }
        public void Serialize(object obj)
        {
            string jsonString = JsonSerializer.Serialize(obj);
        }
        public void SerializeToFile(object obj, string fileName)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(obj, options);
            File.WriteAllText(fileName, jsonString);
        }
        public T Deserialize<T>(string fileName)
        {

            string jsonString = File.ReadAllText(fileName);
            T? obj = JsonSerializer.Deserialize<T>(jsonString);
            return obj;
        }
        public void PopulateData()
        {
            Random rnd = new Random();
            University.Courses.Add(new Course("101", " C# "));
            University.Courses.Add(new Course("102", " Python "));
            University.Professors.Add(new Professor("Fotis Chrysoulas", 44, "1", University.Courses));
            University.Professors.Add(new Professor("Dimitris Raptodimos", 40, "2", University.Courses));
            University.Students.Add(new Student("Anestis Kountourgiannis", 24, 141023, University.Courses));
            University.Students.Add(new Student("Random Guy", 33, 141022, University.Courses));

            for (int i = 0; i < University.Courses.Count(); i++)
            {
                University.ScheduledCourses.Add(new Schedule(University.Courses[i].ID, University.Professors[rnd.Next(0, 1)].ID, DateTime.Now));
            }
            for (int i = 0; i < University.Courses.Count(); i++)
            {
                for (int j = 0; j < University.Students.Count(); j++)
                {

                    University.Grades.Add(new Grade(University.Courses[i].ID, University.Students[i].ID, rnd.Next(5, 10)));
                }
            }
        }
    }
}