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
    class TeachersData : DataIterface<Teachers>
    {
        public List<Teachers> teachers = new List<Teachers>();

        public void Add(Teachers additem)
        {
            teachers.Add(additem);
        }

        public void delSimulation(int index)
        {
            teachers.RemoveAt(index);
        }

        public List<Teachers> getDataAll()
        {
            return teachers;
        }

        public void insertStudentDataToDb(Teachers data)
        {
            SQLiteConnection sql_con = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
            sql_con.Open();
            string sqlnsert = "insert into Teacher (tno,tname,sex,deptno,title,tid) values" + "('" + ((Teachers)data).tno + "','" + ((Teachers)data).tname + "','" + ((Teachers)data).sex + "','" + ((Teachers)data).deptno + "','" + ((Teachers)data).title + "','" + ((Teachers)data).tid + "')";
            SQLiteCommand insert_command = new SQLiteCommand(sqlnsert, sql_con);
            insert_command.ExecuteNonQuery();
            sql_con.Close();
        }

        public void modifySimulation(int index, Teachers data)
        {
            teachers.RemoveAt(index);
            teachers.Insert(index, data);
        }

        public void readDataFromDb()
        {
            SQLiteConnection sql_connection;
            if (File.Exists(@"Data_Db.sqlite"))
            {
                this.teachers.Clear();
                sql_connection = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
                sql_connection.Open();
                if (DbOperator.checkExistTable("Data_Db.sqlite", "Teacher"))
                {
                    string sql = "select * from Teacher";
                    SQLiteCommand command = new SQLiteCommand(sql, sql_connection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        this.Add(new Teachers(reader["tno"].ToString(), reader["tname"].ToString(), reader["sex"].ToString(), reader["deptno"].ToString(), reader["title"].ToString(), reader["tid"].ToString()));
                    }
                    reader.Close();
                    sql_connection.Close();
                }
                else
                {
                    //创建表的sql语句
                    string sql = "Create table Teacher (tno varchar(20),tname varchar(20),sex varchar(20),deptno varchar(20),title varchar(20),tid varchar(20))";
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
                string sql = "Create table Teacher (tno varchar(20),tname varchar(20),sex varchar(20),deptno varchar(20),title varchar(20),tid varchar(20))";
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
            string sql_clean = "delete from Teacher ";
            SQLiteCommand clean_command = new SQLiteCommand(sql_clean, sql_connection);
            clean_command.ExecuteNonQuery();
            //添加现有的前端数据到数据库
            foreach (Teachers item in teachers)
            {
                insertStudentDataToDb(item);
            }
            sql_connection.Close();
        }
        public void clearAllMemoryData()
        {
            this.teachers.Clear();
        }
    }
}
