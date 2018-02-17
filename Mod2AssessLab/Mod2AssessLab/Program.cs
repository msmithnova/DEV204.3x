using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod2AssessLab
{
    struct Student
    {
        public string firstName;
        public string lastName;
        public int id;

        public void Study()
        {
            Console.WriteLine($"{firstName} {lastName} is studying.");
        }
    }

    struct Teacher
    {
        public string firstName;
        public string lastName;
        public string courseName;

        public void GradeAssignment()
        {
            Console.WriteLine($"{firstName} {lastName} is grading assignments.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student[] studentArray = new Student[5];
            Student student = new Student
            {
                firstName = "John",
                lastName = "Doe",
                id = 12345678
            };
            studentArray[0] = student;
            Console.WriteLine($"Student with index 0 has a first name of {studentArray[0].firstName}");
            Console.WriteLine($"Student with index 0 has a first name of {studentArray[0].lastName}");
            Console.WriteLine($"Student with index 0 has a first name of {studentArray[0].id}");
            studentArray[0].Study();
            Console.WriteLine();
            
            string[] FirstNames = { "Jane", "Bill", "Sara", "Bob" };
            string[] LastNames = { "Jones", "Smith", "Johnson", "White" };
            int id = 12345678;
            for (int i = 1; i < studentArray.Length; i++)
            {
                studentArray[i] = new Student { firstName = FirstNames[i-1], lastName = LastNames[i-1], id = ++id };
            }

            foreach (Student s in studentArray)
            {
                Console.WriteLine($"Student {s.firstName} {s.lastName} has an id of {s.id}.");
            }
            Console.WriteLine();

            Teacher teacher = new Teacher
            {
                firstName = "Donald",
                lastName = "Knuth",
                courseName = "Algorithms and Data Structures"
            };
            Console.WriteLine($"Teacher {teacher.firstName} {teacher.lastName} teaches {teacher.courseName}");
            teacher.GradeAssignment();
            Console.WriteLine();


            // Part 2
            Console.WriteLine(Average(new int[] { 1, 3, 1, 1 }));
            Console.WriteLine(Average(new int[] { -3, 2 }));
            Console.WriteLine(Average(new int[] { -2, 4, -1, 6 }));
            Console.WriteLine(Average(new int[] { 3, 2, 1, 4, 3, 2 }));
            Console.WriteLine();

            // Part 3
            Console.WriteLine(Reversal("abcad"));
            Console.WriteLine(Reversal("a0b c1d"));
            Console.WriteLine();

            // Part 4
            Console.WriteLine(Ksmallest(new int[] { 2, 1, 4 }, 3));
            Console.WriteLine(Ksmallest(new int[] { 7, 2, 1, 6, 1 }, 3));
            Console.WriteLine();

            // Part 5
            Console.WriteLine(Difference(new int[] { 3, 2, 9, 5 }));
            Console.WriteLine(Difference(new int[] { 1, 1, 1, 1 }));
            Console.WriteLine();

            // Part 6
            Console.WriteLine(Parentheses("a(())b()"));
            Console.WriteLine(Parentheses("(()1()"));
            Console.WriteLine();
        }

        // Part 2
        public static int Average(int[] a)
        {
            int result = 0;
            foreach (int num in a)
            {
                result += num;
            }
            double res = Math.Round((double)result / a.Length);
            return (int) res;
        }

        //Part 3
        public static string Reversal(string s)
        {
            string result = "";
            result += s[0];
            for (int i = s.Length - 2; i > 0; i--)
            {
                result += s[i];
            }
            result += s[s.Length - 1];
            return result;
        }

        // Part 4
        public static int Ksmallest(int[] a, int k)
        {
            Array.Sort(a);
            int kth = 1;
            int smallest = a[0];
            foreach(int num in a)
            {
                if(num != smallest)
                {
                    kth++;
                }
                if(kth == k)
                {
                    return num;
                }
            }
            // return -1 if not found
            return -1;
        }

        // Part 5
        public static int Difference(int[] a)
        {
            return a.Max() - a.Min();
        }

        // Part 6
        public static int Parentheses(string s)
        {
            int max = 0;
            int count = 0;
            foreach(char c in s)
            {
                if(c == '(') {
                    count++;
                    if (count > max) max = count;
                }
                else if (c == ')') count--;
            }
            if (count == 0) return max;
            else return 0;
        }
    }
}
