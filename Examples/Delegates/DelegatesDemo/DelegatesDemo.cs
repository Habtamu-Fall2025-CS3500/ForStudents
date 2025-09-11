using System;
using System.Collections.Generic;

namespace Delegate_Lecture
{
    class DelegatesDemo
    {

        // This declares a new type called Filter.
        // Variables of that type hold functions
        // that input a student and output a bool
        public delegate bool Filter(Student s);


        /// <summary>
        /// A method that has the right signature for a Filter
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool FilterByGPA(Student s)
        {
            return s.GPA > 3.0;
        }

        static void Main(string[] args)
        {

            // Part 4 - Delegates

            List<Student> students = new List<Student>();
            students.Add(new Student(21, "Dan", 4.0f));
            students.Add(new Student(21, "Jess", 3.0f));
            students.Add(new Student(20, "Carlos", 3.4f));
            students.Add(new Student(26, "Ann", 3.8f));
            students.Add(new Student(19, "Maria", 4.0f));
            students.Add(new Student(32, "Sriram", 3.3f));

            // filter all the students using the FilterByGPA method as the Filter delegate
            List<Student> output = FilterStudents(students, FilterByGPA);

            foreach (Student s in output)
                Console.WriteLine(s.name + ", " + s.age + ", " + s.GPA);

        }

        /// <summary>
        /// Returns all students who meet some condition
        /// </summary>
        /// <param name="input">All students</param>
        /// <param name="filter">The delegate that defines the condition to apply</param>
        /// <returns>A new list of students that meet the filter condition</returns>
        public static List<Student> FilterStudents(List<Student> input, Filter filter)
        {
            List<Student> output = new List<Student>();
            foreach (Student s in input)
            {
                // Notice that we are invoking the 'filter' argument
                // filter is a variable that holds a method, so we can invoke it
                if (filter(s))
                    output.Add(s);
            }
            return output;
        }
    }
}



