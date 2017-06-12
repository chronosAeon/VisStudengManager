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
    class DepartmentData : DataIterface<Department>
    {
        public List<Department> department = new List<Department>();

        public void Add(Department additem)
        {
            department.Add(additem);
        }

        public void delSimulation(int index)
        {
            department.RemoveAt(index);
        }

        public List<Department> getDataAll()
        {
            return department;
        }

        public void insertStudentDataToDb(Department data)
        {
            SQLiteConnection sql_con = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
            sql_con.Open();
            string sqlnsert = "insert into Department (deptno,deptname) values" + "('" + ((Department)data).deptno + "','" + ((Department)data).deptname + "')";
            SQLiteCommand insert_command = new SQLiteCommand(sqlnsert, sql_con);
            insert_command.ExecuteNonQuery();
            sql_con.Close();
        }

        public void modifySimulation(int index, Department data)
        {
            department.RemoveAt(index);
            department.Insert(index, data);
        }


        public void readDataFromDb()
        {
            SQLiteConnection sql_connection;
            if (File.Exists(@"Data_Db.sqlite"))
            {
                sql_connection = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
                sql_connection.Open();
                if (DbOperator.checkExistTable("Data_Db.sqlite", "Department"))
                {
                    this.department.Clear();
                    string sql = "select * from Department";
                    SQLiteCommand command = new SQLiteCommand(sql, sql_connection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        this.Add(new Department(reader["deptno"].ToString(), reader["deptname"].ToString()));
                    }
                    sql_connection.Close();
                }
                else
                {
                    string sql = "Create table Department (deptno varchar(20),deptname varchar(20))";
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
                string sql = "Create table Department (deptno varchar(20),deptname varchar(20))";
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
            string sql_clean = "delete from Department ";
            SQLiteCommand clean_command = new SQLiteCommand(sql_clean, sql_connection);
            clean_command.ExecuteNonQuery();
            //添加现有的前端数据到数据库
            foreach (Department item in department)
            {
                insertStudentDataToDb(item);
            }
            sql_connection.Close();
        }
        public void clearAllMemoryData()
        {
            this.department.Clear();
        }
    }
}
