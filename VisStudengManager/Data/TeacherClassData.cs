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
    class TeacherClassData : DataIterface<TeacherClass>
    {
        public List<TeacherClass> teacherClass = new List<TeacherClass>();

        public void Add(TeacherClass additem)
        {
            teacherClass.Add(additem);
        }

        public void delSimulation(int index)
        {
            teacherClass.RemoveAt(index);
        }

        public List<TeacherClass> getDataAll()
        {
            return teacherClass;
        }

        public void insertStudentDataToDb(TeacherClass data)
        {
            SQLiteConnection sql_con = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
            sql_con.Open();
            string sqlnsert = "insert into TeacherClass (tno,clno,cno,weekday,period) values" + "('" + ((TeacherClass)data).tno + "','" + ((TeacherClass)data).clno+ "','" + ((TeacherClass)data).cno + "','" + ((TeacherClass)data).weekday + "','" + ((TeacherClass)data).period + "')";
            SQLiteCommand insert_command = new SQLiteCommand(sqlnsert, sql_con);
            insert_command.ExecuteNonQuery();
            sql_con.Close();
        }

        public void modifySimulation(int index, TeacherClass data)
        {
            teacherClass.RemoveAt(index);
            teacherClass.Insert(index, data);
        }

        public void readDataFromDb()
        {
            SQLiteConnection sql_connection;
            if (File.Exists(@"Data_Db.sqlite"))
            {
                sql_connection = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
                sql_connection.Open();
                if (DbOperator.checkExistTable("Data_Db.sqlite", "TeacherClass"))
                {
                    this.teacherClass.Clear();
                    string sql = "select * from TeacherClass";
                    SQLiteCommand command = new SQLiteCommand(sql, sql_connection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        this.Add(new TeacherClass(reader["tno"].ToString(), reader["clno"].ToString(), reader["cno"].ToString(), reader["weekday"].ToString(), reader["period"].ToString()));
                    }
                    sql_connection.Close();
                }
                else
                {
                    //创建表的sql语句
                    string sql = "Create table TeacherClass (tno varchar(20),clno varchar(20),cno varchar(20),weekday varchar(20),period varchar(20))";
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
                string sql = "Create table TeacherClass (tno varchar(20),clno varchar(20),cno varchar(20),weekday varchar(20),period varchar(20))";
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
            string sql_clean = "delete from TeacherClass ";
            SQLiteCommand clean_command = new SQLiteCommand(sql_clean, sql_connection);
            clean_command.ExecuteNonQuery();
            //添加现有的前端数据到数据库
            foreach (TeacherClass item in teacherClass)
            {
                insertStudentDataToDb(item);
            }
            sql_connection.Close();
        }
        public void clearAllMemoryData()
        {
            this.teacherClass.Clear();
        }
    }
}
