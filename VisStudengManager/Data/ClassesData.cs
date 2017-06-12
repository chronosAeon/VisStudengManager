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
    class ClassesData : DataIterface<Classes>
    {
        public List<Classes> classes = new List<Classes>();

        public void Add(Classes additem)
        {
            classes.Add(additem);
        }

        public void delSimulation(int index)
        {
            classes.RemoveAt(index);
        }

        public List<Classes> getDataAll()
        {
            return classes;
        }

        public void insertStudentDataToDb(Classes data)
        {
            SQLiteConnection sql_con = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
            sql_con.Open();
            string sqlnsert = "insert into Classes (cno,cname,credit,category,deptno) values" + "('" + data.cno + "','" + data.cname + "','" + data.credit+ "','" + data.category + "','"+data.deptno+ "')";
            SQLiteCommand insert_command = new SQLiteCommand(sqlnsert, sql_con);
            insert_command.ExecuteNonQuery();
            sql_con.Close();
        }

        public void modifySimulation(int index, Classes data)
        {
            classes.RemoveAt(index);
            classes.Insert(index, data);
        }


        public void readDataFromDb()
        {
            SQLiteConnection sql_connection;
            if (File.Exists(@"Data_Db.sqlite"))
            {
                sql_connection = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
                sql_connection.Open();
                if (DbOperator.checkExistTable("Data_Db.sqlite", "Classes"))
                {
                    this.classes.Clear();
                    string sql = "select * from Classes";
                    SQLiteCommand command = new SQLiteCommand(sql, sql_connection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        this.Add(new Classes(reader["cno"].ToString(), reader["cname"].ToString(), reader["credit"].ToString(), reader["category"].ToString(), reader["deptno"].ToString()));
                    }
                    sql_connection.Close();
                }
                else
                {
                    //创建表的sql语句
                    string sql = "Create table Classes (cno varchar(20),cname varchar(20),credit varchar(20) , category varchar(20)  , deptno varchar(20))";
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
                string sql = "Create table Classes (cno varchar(20),cname varchar(20),credit varchar(20) , category varchar(20)  , deptno varchar(20))";
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
            string sql_clean = "delete from Classes ";
            SQLiteCommand clean_command = new SQLiteCommand(sql_clean, sql_connection);
            clean_command.ExecuteNonQuery();
            //添加现有的前端数据到数据库
            foreach (Classes item in classes)
            {
                insertStudentDataToDb(item);
            }
            sql_connection.Close();
        }
        public void clearAllMemoryData()
        {
            this.classes.Clear();
        }
    }
}
