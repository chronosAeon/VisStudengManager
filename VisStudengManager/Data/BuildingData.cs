using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisStudengManager.Utils;
using System.Data.SQLite;
using VisStudengManager.DataModel;

namespace VisStudengManager.Data
{
     class BuildingData : DataIterface<Building>
    {
        public List<Building> building = new List<Building>();
        private static SQLiteConnection sql_connection;
        public void Add (Building additem)
        {
            building.Add(additem);
        }

        public void delSimulation(int index)
        {
            building.RemoveAt(index);
        }

        public List<Building> getDataAll()
        {
            return building;
        }

        public void insertStudentDataToDb(Building data)
        {
            sql_connection = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
            sql_connection.Open();
            string sqlnsert = "insert into Building (bno,bname) values" + "('" + ((Building)data).bno + "'," + ((Building)data).bname + "')";
            SQLiteCommand insert_command = new SQLiteCommand(sqlnsert, sql_connection);
            insert_command.ExecuteNonQuery();
            sql_connection.Close();
        }

        public void modifySimulation(int index, Building data)
        {
            building.RemoveAt(index);
            building.Insert(index, data);
        }

        public void readDataFromDb()
        {
            if (File.Exists(@"Data_Db.sqlite"))
            {
                sql_connection = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
                sql_connection.Open();
                //检查表是否存在;
                if (DbOperator.checkExistTable("Data_Db.sqlite", "Building"))
                {
                    this.building.Clear();
                    string sql = "select * from Building";
                    SQLiteCommand command = new SQLiteCommand(sql, sql_connection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        this.Add(new Building(reader["bno"].ToString(), reader["bname"].ToString()));
                    }
                    sql_connection.Close();
                }
                else
                {
                    //如果表不存在
                    string sql = "Create table Building (bno varchar(20)  , bname varchar(20))";
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
                string sql = "Create table Building (bno varchar(20)  , bname varchar(20))";
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
            string sql_clean = "delete from Building ";
            SQLiteCommand clean_command = new SQLiteCommand(sql_clean, sql_connection);
            clean_command.ExecuteNonQuery();
            //添加现有的前端数据到数据库
            foreach (Building item in building)
            {
                insertStudentDataToDb(item);
            }
            sql_connection.Close();
        }
        public void clearAllMemoryData()
        {
            this.building.Clear();
        }

    }
}
