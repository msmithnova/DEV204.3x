using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Generic List of type Student
            List<Student> students = new List<Student>();

            Student stud1 = new Student("Tom", "Thumb", 12, "Computer Science");
            Student stud2 = new Student("Fred", "Flintstone", 45, "Geology");
            Student stud3 = new Student("Mickey", "Mouse", 35, "Animation");

            float[] grades = new float[] { 88, 92, 97, 83, 82, 97, 92, 88, 82, 95, 91, 98, 92, 94, 89 };
            for (int i = 0; i < 5; i++)
            {
                stud1.Grades.Push(grades[i]);
                stud2.Grades.Push(grades[i + 5]);
                stud3.Grades.Push(grades[i + 10]);
                stud1.GradesSet.Add(grades[i]);
                stud2.GradesSet.Add(grades[i + 5]);
                stud3.GradesSet.Add(grades[i + 10]);
            }

            students.Add(stud1);
            students.Add(stud2);
            students.Add(stud3);

            foreach (Student stud in students)
            {
                Console.WriteLine(stud.FirstName + " " + stud.LastName + " has grades of: ");
                foreach (float grade in stud.GradesSet)
                {
                    Console.Write(grade + ", ");
                }
                Console.WriteLine();
            }

            stud1.Grades.Pop();
            stud1.Grades.Push(85);
            stud2.Grades.Pop();
            stud2.Grades.Push(97);
            stud3.Grades.Pop();
            stud3.Grades.Push(93);

            bool exists = students.Contains<Student>(stud1);
            Console.WriteLine(exists.ToString());

            students.Remove(stud3);
            Console.WriteLine(students.Count());

            exists = students.Contains<Student>(stud3);
            Console.WriteLine(exists.ToString());
        }
    }

    class Student
    {
        public Student(string first, string last, int age, string prog)
        {
            this.FirstName = first;
            this.LastName = last;
            this.Age = age;
            this.Program = prog;
            this.Grades = new Stack<float>();
            this.GradesSet = new SortedSet<float>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Program { get; set; }
        public Stack<float> Grades { get; set; }
        public SortedSet<float> GradesSet { get; set; }
    }
}
