using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisStudengManager.DataModel;
using VisStudengManager.Utils;

namespace VisStudengManager.Data
{
    class StudentData : DataIterface<Student>
    {
        public List<Student> student = new List<Student>();

        public void Add(Student additem)
        {
            student.Add(additem);
        }

        public void delSimulation(int index)
        {
            student.RemoveAt(index);
        }

        public List<Student> getDataAll()
        {
            return student;
        }

        public void insertStudentDataToDb(Student data)
        {
            SQLiteConnection sql_con = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
            sql_con.Open();
            string sqlnsert = "insert into Student (student_num,name,sex,age,major,Place_of_origin,Interest) values" + "(" + ((Student)data).student_num + ",'" + ((Student)data).name+"','"+ ((Student)data).sex + "'," + ((Student)data).age + ",'"+ ((Student)data).major + "','"+ ((Student)data).Place_of_origin + "','"+ ((Student)data).Interest +"')";
            SQLiteCommand insert_command = new SQLiteCommand(sqlnsert, sql_con);
            insert_command.ExecuteNonQuery();
            sql_con.Close();
        }

        public void modifySimulation(int index, Student data)
        {
            student.RemoveAt(index);
            student.Insert(index, data);
        }

        public void readDataFromDb()
        {
            SQLiteConnection sql_connection;
            if (File.Exists(@"Data_Db.sqlite"))
            {
                sql_connection = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
                sql_connection.Open();
                if (DbOperator.checkExistTable("Data_Db.sqlite", "Student"))
                {
                    this.student.Clear();
                    string sql = "select * from Student";
                    SQLiteCommand command = new SQLiteCommand(sql, sql_connection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        this.Add(new Student(int.Parse(reader["student_num"].ToString()), reader["name"].ToString(), reader["sex"].ToString(), int.Parse(reader["age"].ToString()), reader["major"].ToString(), reader["Place_of_origin"].ToString(), reader["Interest"].ToString()));
                    }
                    sql_connection.Close();
                }
                else
                {
                    //创建表的sql语句
                    string sql = "Create table Student (student_num integer,name varchar(20),sex varchar(20),age integer,major varchar(20),Place_of_origin varchar(20),Interest varchar(20))";
                    //创建指令
                    SQLiteCommand command = new SQLiteCommand(sql, sql_connection);
                    //执行指令
                    command.ExecuteNonQuery();
                    sql_connection.Close();
                }
            }
            else
            {
                //创建数据库
                SQLiteConnection.CreateFile("Data_Db.sqlite");
                //获取数据库连接
                sql_connection = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
                //打开数据库
                sql_connection.Open();

                //这里应该是先检查这张表是不是存在！！！！！！！

                //创建表的sql语句
                string sql = "Create table Student (student_num integer,name varchar(20),sex varchar(20),age integer,major varchar(20),Place_of_origin varchar(20),Interest varchar(20))";
                //创建指令
                SQLiteCommand command = new SQLiteCommand(sql, sql_connection);
                //执行指令
                command.ExecuteNonQuery();
                sql_connection.Close();
            }
        }

        public void updateAccoClient()
        {
            SQLiteConnection sql_connection = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
            sql_connection.Open();
            //清空表数据
            string sql_clean = "delete from Student ";
            SQLiteCommand clean_command = new SQLiteCommand(sql_clean, sql_connection);
            clean_command.ExecuteNonQuery();
            //添加现有的前端数据到数据库
            foreach (Student item in student)
            {
                insertStudentDataToDb(item);
            }
            sql_connection.Close();
        }
        public void clearAllMemoryData()
        {
            this.student.Clear();
        }
    }
}