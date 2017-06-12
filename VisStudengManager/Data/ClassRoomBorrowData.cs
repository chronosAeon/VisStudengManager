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
    class ClassRoomBorrowData : DataIterface<ClassRoomBorrow>
    {
        public List<ClassRoomBorrow> classBorrow = new List<ClassRoomBorrow>();

        public void Add(ClassRoomBorrow additem)
        {
            classBorrow.Add(additem);
        }

        public void delSimulation(int index)
        {
            classBorrow.RemoveAt(index);
        }

        public List<ClassRoomBorrow> getDataAll()
        {
            return classBorrow;
        }

        public void insertStudentDataToDb(ClassRoomBorrow data)
        {
            SQLiteConnection sql_con = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
            sql_con.Open();
            string sqlnsert = "insert into ClassRoomBorrow (clno,sno,usedate,weekday,period,use,usestatus) values" + "('" + ((ClassRoomBorrow)data).clno + "'," + ((ClassRoomBorrow)data).sno + "'," + ((ClassRoomBorrow)data).usedate +"','"+((ClassRoomBorrow)data).Weekday+"','"+((ClassRoomBorrow)data).Period+"','"+((ClassRoomBorrow)data).Period+"','"+((ClassRoomBorrow)data).Use+"','"+((ClassRoomBorrow)data).Usestatus+ "')";
            SQLiteCommand insert_command = new SQLiteCommand(sqlnsert, sql_con);
            insert_command.ExecuteNonQuery();
            sql_con.Close();
        }

        public void modifySimulation(int index, ClassRoomBorrow data)
        {
            classBorrow.RemoveAt(index);
            classBorrow.Insert(index, data);
        }

        public void readDataFromDb()
        {
            SQLiteConnection sql_connection;
            if (File.Exists(@"Data_Db.sqlite"))
            {
                    sql_connection = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
                    sql_connection.Open();
                if (DbOperator.checkExistTable("Data_Db.sqlite", "ClassRoomBorrow"))
                {
                    this.classBorrow.Clear();
                    string sql = "select * from ClassRoomBorrow";
                    SQLiteCommand command = new SQLiteCommand(sql, sql_connection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        this.Add(new ClassRoomBorrow(reader["clno"].ToString(), reader["sno"].ToString(), reader["usedate"].ToString(), reader["weekday"].ToString(), reader["period"].ToString(), reader["use"].ToString(), reader["usestatus"].ToString()));
                    }
                    sql_connection.Close();
                }
                else
                {
                    //创建表的sql语句
                    string sql = "Create table ClassRoomBorrow (clno varchar(20),sno varchar(20),usedate varchar(20) , weekday varchar(20)  , period varchar(20),use varchar(20),usestatus varchar(20))";
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
                string sql = "Create table ClassRoomBorrow (clno varchar(20),sno varchar(20),usedate varchar(20) , weekday varchar(20)  , period varchar(20),use varchar(20),usestatus varchar(20))";
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
            string sql_clean = "delete from ClassRoomBorrow ";
            SQLiteCommand clean_command = new SQLiteCommand(sql_clean, sql_connection);
            clean_command.ExecuteNonQuery();
            //添加现有的前端数据到数据库
            foreach (ClassRoomBorrow item in classBorrow)
            {
                insertStudentDataToDb(item);
            }
            sql_connection.Close();
        }
        public void clearAllMemoryData()
        {
            this.classBorrow.Clear();
        }
    }
}