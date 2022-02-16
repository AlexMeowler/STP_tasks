using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Student
    {
        public string StudentName { get; set; }
        public bool IsEnrolled { get; set; }

        public Student(string name, bool ch)
        {
            StudentName = name;
            IsEnrolled = ch;
        }

        public string FullStudentData => StudentName + "\t" + IsEnrolled;
    }
}
