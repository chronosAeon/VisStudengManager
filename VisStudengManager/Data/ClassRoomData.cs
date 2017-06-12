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
    class ClassRoomData : DataIterface<ClassRoom>
    {
        public List<ClassRoom> class_room = new List<ClassRoom>();
        public void Add(ClassRoom additem)
        {
            class_room.Add(additem);
        }
        public void delSimulation(int index)
        {
            class_room.RemoveAt(index);
        }

        public List<ClassRoom> getDataAll()
        {
            return this.class_room;
        }

        public void insertStudentDataToDb(ClassRoom data)
        {
            SQLiteConnection sql_connection = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
            sql_connection.Open();
            string sqlnsert = "insert into ClassRoom (clno,bno,floor) values" + "('" + ((ClassRoom)data).clno + "','" + ((ClassRoom)data).bno +"','"+((ClassRoom)data).floor+"')";
            SQLiteCommand insert_command = new SQLiteCommand(sqlnsert, sql_connection);
            insert_command.ExecuteNonQuery();
            sql_connection.Close();
        }

        public void modifySimulation(int index, ClassRoom data)
        {
            class_room.RemoveAt(index);
            class_room.Insert(index, data);
        }


        public void readDataFromDb()
        {
            //SQLiteConnection sql_connection;
            if (File.Exists(@"Data_Db.sqlite"))
            {
                bool res = DbOperator.checkExistTable("Data_Db.sqlite", "ClassRoom");
                if (res)
                {
                    this.class_room.Clear();
                    SQLiteConnection sql_connection = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
                    sql_connection.Open();
                    string sql = "select * from ClassRoom";
                    SQLiteCommand command = new SQLiteCommand(sql, sql_connection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        this.Add(new ClassRoom(int.Parse(reader["clno"].ToString()), reader["bno"].ToString(), reader["floor"].ToString()));
                    }
                    //这个地方非常注意！！！！！一定要关，否则一定写不了，因为sqlite实行库级锁粒度非常大，读操作可以并发，但是写操作之前只要有读操作没有关那么写操作一定会出database is locked的问题
                    sql_connection.Close();
                }
                else
                {
                    SQLiteConnection sql_connection = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
                    sql_connection.Open();
                    //创建表的sql语句
                    string sql = "Create table ClassRoom (clno integer , bno varchar(20)  , floor varchar(20))";
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
                SQLiteConnection sql_connection = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
                //打开数据库
                sql_connection.Open();

                //这里应该是先检查这张表是不是存在！！！！！！！

                //创建表的sql语句
                string sql = "Create table ClassRoom (clno integer , bno varchar(20)  , floor varchar(20))";
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
            string sql_clean = "delete from ClassRoom ";
            SQLiteCommand clean_command = new SQLiteCommand(sql_clean, sql_connection);
            clean_command.ExecuteNonQuery();
            //添加现有的前端数据到数据库
            foreach (ClassRoom item in class_room)
            {
                insertStudentDataToDb(item);
            }
            sql_connection.Close();
        }
        public void clearAllMemoryData()
        {
            this.class_room.Clear();
        }
    }
}
