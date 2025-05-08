using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reworkwk7ex3
{
    internal class Program
    {
        // Method to read CSV file
        public static List<Student> ReadCsv(string fileName)
        { //init a new list to hold
            List<Student> students = new List<Student>();

            // to read the file
            using (StreamReader reader = new StreamReader(@"D:\Students.csv"))
            {
                string line;
                //read file 
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(',');  // split word by word

                    // if line has name and grade
                    if (words.Length == 2)
                    { // get name
                        string name = words[0];
                        //convert to int
                        int grade = Convert.ToInt32(words[1]);

                        // Create a Student object and add it to the list
                        students.Add(new Student(name, grade));
                    }
                }
            }

            return students;  // return it
        }





        static void Main(string[] args)
        {


            // Define CSV file
            string fileName = "students.csv";

            // Call the ReadCsv method to get the list of students
            var students = ReadCsv(fileName);

            // show the names and grades 
            Console.WriteLine("Student Names and Grades:");
            // loop through each student
            foreach (var student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}");
            }

        }
    }
}
// define class student
public class Student
{
    public string Name { get; set; }
    public int Grade { get; set; }
    // constructor
    public Student(string name, int grade)
    {
        Name = name;
        Grade = grade;
    }
}
