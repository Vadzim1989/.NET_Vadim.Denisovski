using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Task5
{
    /// <summary>
    /// Class STUDENT
    /// </summary>
    [Serializable]
    public class Student : IComparable
    {
        private string studentName;
        private string testTitle;
        private int grade;
        private DateTime dateTest;
        /// <summary>
        /// Name of Student
        /// </summary>
        public string StudentName
        {
            get => studentName;
            set
            {
                if (value.Length < 1)
                {
                    throw new Exception("Wrong Name of Student");
                }
                else
                {
                    studentName = value;
                }
            }
        }
        /// <summary>
        /// Title of the test
        /// </summary>
        public string TestTitle
        {
            get => testTitle;
            set
            {
                if (value.Length < 1)
                {
                    throw new Exception("Wrong Title of test");
                }
                else
                {
                    testTitle = value;
                }
            }
        }
        /// <summary>
        /// Grade of the test
        /// </summary>
        public int Grade
        {
            get => grade;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("Wrong grade");
                }
                else
                {
                    grade = value;
                }
            }
        }
        /// <summary>
        /// Date of the test
        /// </summary>
        public DateTime DateTest
        {
            get => dateTest;
            set
            {
                if (value > DateTime.Now)
                {
                    throw new Exception("Wrong Date and/or Time");
                }
                else
                {
                    dateTest = value;
                }
            }
        }
        /// <summary>
        /// Default constructor for XMLSerialization
        /// </summary>
        public Student()
        {

        }
        /// <summary>
        /// Main Constructor for student
        /// </summary>
        /// <param name="name">Name of student</param>
        /// <param name="gr">Grade</param>
        /// <param name="test">Test Title</param>
        /// <param name="date">Date</param>
        public Student(string name, int gr, string test, DateTime date)
        {
            StudentName = name;
            Grade = gr;
            TestTitle = test;
            DateTest = date;
        }
        /// <summary>
        /// Realization of IComparable
        /// </summary>
        /// <param name="obj">Input object</param>
        /// <returns>-1 for less, 0 for equal, 1 for more</returns>
        public int CompareTo(object obj)
        {
            if (obj is Student c)
            {
                return this.grade.CompareTo(c.grade);
            }
            else throw new Exception("Wrong Student for Compare");
        }
    }
}
