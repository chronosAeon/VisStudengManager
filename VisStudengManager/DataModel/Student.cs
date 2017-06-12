using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VisStudengManager.DataModel
{
    //内存中的模拟数据模型
    class Student
    {
        public int student_num
        {
            set;
            get;
        }
        public string name
        {
            set;
            get;
        }
        public string sex
        {
            set;
            get;
        }
        public int age
        {
            set;
            get;
        }
        public string major
        {
            set;
            get;
        }
        public string Place_of_origin
        {
            set;
            get;
        }
        public string Interest
        {
            set;
            get;
        }
        public Student(int num, string name, string sex, int age, string major, string place, string interest)
        {
            this.student_num = num;
            this.name = name;
            this.sex = sex;
            this.age = age;
            this.major = major;
            this.Place_of_origin = place;
            this.Interest = interest;
        }
        public Student(Student data)
        {
            this.student_num = data.student_num;
            this.name = data.name;
            this.sex = data.sex;
            this.age = data.age;
            this.major = data.major;
            this.Place_of_origin = data.Place_of_origin;
            this.Interest = data.Interest;
        }
        public bool Equals(Student student)
        {
            if (this.student_num == student.student_num && this.age == student.age && this.major.Equals(student.major) && this.Place_of_origin.Equals(student.Place_of_origin) && this.sex.Equals(student.sex) && this.name.Equals(student.name) && this.Interest.Equals(student.Interest))
            {
                return true;
            }

            else return false;
        }
    }
}
