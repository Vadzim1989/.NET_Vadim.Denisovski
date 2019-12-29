using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public class Student : IComparable<Student>
    {
        /// <summary>
        /// Student name
        /// </summary>
        private string studentName;
        /// <summary>
        /// test name
        /// </summary>
        private string testName;
        /// <summary>
        /// student mark
        /// </summary>
        private double mark;
        /// <summary>
        /// get/set student name
        /// </summary>
        public string name
        {
            get
            {
                return studentName;
            }
            set
            {
                if (studentName.Length < 1)
                    throw new Exception("Input some name");
                studentName = value;
            }
        }
        /// <summary>
        /// get/set test name
        /// </summary>
        public string TestName
        {
            get
            {
                return testName;
            }
            set
            {
                if (testName.Length < 1)
                    throw new Exception("Input some name");
                testName = value;
            }

        }
        /// <summary>
        /// get/set date of testing
        /// </summary>
        public DateTime TestDate { get; set; }
        /// <summary>
        /// get/set mark
        /// </summary>
        public double Mark
        {
            get
            {
                return mark;
            }
            set
            {
                if (value < 0.0 || value > 100.0)
                    throw new ArgumentException("Mark can not be less than zero and more than one hundred percent.");
                mark = value;
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sName"></param>
        /// <param name="tName"></param>
        /// <param name="dateTime"></param>
        /// <param name="mark"></param>
        public Student(string sName, string tName, DateTime dateTime, double mark)
        {
            studentName = sName;
            testName = tName;
            TestDate = dateTime;
            this.mark = mark;
        }
        /// <summary>
        /// Student Comparison
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public virtual int CompareTo(Student student)
        {
            if (student != null)
                return this.Mark.CompareTo(student.Mark);
            else
                throw new Exception("It is not Student");
        }
        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   studentName == student.studentName &&
                   testName == student.testName &&
                   mark == student.mark &&
                   name == student.name &&
                   TestName == student.TestName &&
                   TestDate == student.TestDate &&
                   Mark == student.Mark;
        }
        /// <summary>
        /// HashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            var hashCode = -1829382906;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(studentName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(testName);
            hashCode = hashCode * -1521134295 + mark.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TestName);
            hashCode = hashCode * -1521134295 + TestDate.GetHashCode();
            hashCode = hashCode * -1521134295 + Mark.GetHashCode();
            return hashCode;
        }
    }
}
