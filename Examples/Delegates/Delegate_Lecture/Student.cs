using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate_Lecture
{
    public class Student
    {
        // These shouldn't be public, but are for the sake of the demo
        public int age;
        public string name;
        public float GPA;

        public Student(int _age, string _name, float _GPA)
        {
            age = _age;
            name = _name;
            GPA = _GPA;
        }
    }
}



