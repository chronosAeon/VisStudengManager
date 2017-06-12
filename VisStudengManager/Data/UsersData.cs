using System;
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
    class UsersData : DataIterface<Account>
    {
        public List<Account> users = new List<Account>();
        private SQLiteConnection sql_connection;

        public void Add(Account additem)
        {
            users.Add(additem);
        }

        public void delSimulation(int index)
        {
            users.RemoveAt(index);
        }

        public List<Account> getDataAll()
        {
            return users;
        }

        public void insertStudentDataToDb(Account data)
        {
            SQLiteConnection sql_con = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
            sql_con.Open();
            string sqlnsert = "insert into  User(account,password,islogin,authority,forbidden) values" + "('" + data.name + "','" + data.password + "'," + data.isLogin + "," + data.type + "," + data.Forbidden + ")";
            SQLiteCommand insert_command = new SQLiteCommand(sqlnsert, sql_con);
            insert_command.ExecuteNonQuery();
            sql_con.Close();
        }

        public void modifySimulation(int index, Account data)
        {
            users.RemoveAt(index);
            users.Insert(index, data);
        }

        public void readDataFromDb()
        {
            if (File.Exists(@"Data_Db.sqlite"))
            {
                sql_connection = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
                sql_connection.Open();
                //检查表是否存在;
                if (DbOperator.checkExistTable("Data_Db.sqlite", "User"))
                {
                    this.users.Clear();
                    string sql = "select * from User";
                    SQLiteCommand command = new SQLiteCommand(sql, sql_connection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        this.Add(new Account(reader["account"].ToString(),reader["password"].ToString(), bool.Parse(reader["islogin"].ToString()), int.Parse(reader["authority"].ToString()), bool.Parse(reader["forbidden"].ToString())));
                    }
                    sql_connection.Close();
                }
                else
                {
                    //如果表不存在
                    string sql = "Create table User (account Text PRIMARY KEY Not Null, password Text Not Null, islogin boolean not Null,authority integer Not null,Forbidden boolean Not null )";
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
                string sql = "Create table User (account Text PRIMARY KEY Not Null, password Text Not Null, islogin boolean not Null,authority integer Not null,Forbidden boolean Not null )";
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
            string sql_clean = "delete from User ";
            SQLiteCommand clean_command = new SQLiteCommand(sql_clean, sql_connection);
            clean_command.ExecuteNonQuery();
            //添加现有的前端数据到数据库
            foreach (Account item in users)
            {
                insertStudentDataToDb(item);
            }
            sql_connection.Close();
        }

        public void clearAllMemoryData()
        {
            this.users.Clear();
        }
    }
}
