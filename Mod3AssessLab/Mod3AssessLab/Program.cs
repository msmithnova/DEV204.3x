using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod3AssessLab
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList studentList = new ArrayList();
            Student student1 = new Student("John", "Doe", 1234);
            Student student2 = new Student("Jane", "Jones", 2345);
            Student student3 = new Student("Bob", "White", 3456);
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                student1.AddGrade(Math.Round(rand.NextDouble() * 20 + 80, 2));
                student2.AddGrade(Math.Round(rand.NextDouble() * 20 + 80, 2));
                student3.AddGrade(Math.Round(rand.NextDouble() * 20 + 80, 2));
            }
            studentList.Add(student1);
            studentList.Add(student2);
            studentList.Add(student3);
            Console.WriteLine("Students in student list: \n");
            foreach (Student student in studentList)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} with id of {student.Id}.");
                Console.Write("Grades: ");
                foreach (double grade in student.Grades)
                {
                    Console.Write($"{grade}, ");
                }
                Console.WriteLine("\n");
            }
        }
    }

    public class Student
    {
        private string firstName;
        private string lastName;
        private int id;
        private Stack grades = new Stack();

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Id { get => id; set => id = value; }
        public Stack Grades { get => grades; }

        public Student(string firstName, string lastName, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }

        public void AddGrade(double grade)
        {
            grades.Push(grade);
        }
    }

}
