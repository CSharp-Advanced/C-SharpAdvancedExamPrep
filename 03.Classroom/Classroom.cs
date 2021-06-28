using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private readonly List<Student> students;
        public int Capacity { get; }

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }

        public int Count => students.Count;
        public string RegisterStudent(Student student)
        {
            if (Capacity <= Count)
            {
                return "No seats in the classroom";
            }
            students.Add(student);
            return $"Added student {student.FirstName} {student.LastName}";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            bool isStudentExists = students.Exists(x => x.FirstName == firstName && x.LastName == lastName);
            if (isStudentExists)
            {
                students.Remove(students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName));
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject)
        {
            var studentsSubject = students.Where(x => x.Subject == subject).ToList();

            if (studentsSubject.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");
                foreach (Student student in students)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
                return sb.ToString().TrimEnd();
            }
            else
            {
                return "No students enrolled for the subject";
            }
        }

        public int GetStudentsCount() => Count;

        public Student GetStudent(string firstname, string lastName)
            => students.FirstOrDefault(x => x.FirstName == firstname && x.LastName == lastName);

    }
}
