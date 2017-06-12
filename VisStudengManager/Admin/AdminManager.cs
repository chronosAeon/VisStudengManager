using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisStudengManager.Admin
{
    class AdminManager : DataUfIterface<user>
    {
        /// <summary>
        ///维护一个user集合，同时对用户的账号密码，登录状态的管理
        /// </summary>
        AdminManager instance = null;
        //数据库连接符
        private SQLiteConnection connection;

        private AdminManager()
        {
            //如果数据库存在，判断表是否存在，存在就ok，不存在就创建一个表
            if (File.Exists(@"Data_Db.sqlite"))
            {
                connection = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
                connection.Open();
                string findTableSql = "Select Count(*) From sqlite_master where type = 'table' and name='User' ";
                SQLiteCommand com = new SQLiteCommand(findTableSql, connection);
                SQLiteDataReader reader = com.ExecuteReader();
                reader.Read();
                //证明没有表
                if (int.Parse(reader[0].ToString()) != 0)
                {
                    //这里希望主键能自增
                    string CreateTable = "Create table User (id Integer PRIMARY KEY, Account Text not null,password not null , type integer not null , isLogin boolean not null)";
                    SQLiteCommand CreateCom = new SQLiteCommand(CreateTable, connection);
                    CreateCom.ExecuteNonQuery();
                }
            }
            //数据库不存在
            else
            {
                //创建数据库
                SQLiteConnection.CreateFile("Data_Db.sqlite");
                //获取数据库连接
                connection = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
                connection.Open();
                //这里希望主键能自增
                string CreateTable = "Create table User (id Integer PRIMARY KEY, Account Text not null,password Text not null , type integer not null , isLogin boolean not null)";
                SQLiteCommand CreateCom = new SQLiteCommand(CreateTable, connection);
                CreateCom.ExecuteNonQuery();
            }
        }

        public void addData(user data)
        {
            string addSql = "insert into User (name,password,type,isLogin)values('" + data.Account + "','" + data.password + "','" + data.loginstatus.LoginStyle + "','" + data.loginstatus.isLogin + ")";
            SQLiteCommand com = new SQLiteCommand(addSql, connection);
            com.ExecuteNonQuery();
        }

        public void delData(int index)
        {
            string delSql = "delete from User where id = " + index;
            SQLiteCommand com = new SQLiteCommand(delSql, connection);
            com.ExecuteNonQuery();
        }

        public List<user> getAllData()
        {
            string getAllSql = "Select * From User";
            SQLiteCommand com = new SQLiteCommand(getAllSql, connection);
            com.ExecuteNonQuery();
        }

        //获取单例
        public AdminManager getinstance()
        {
            if (this.instance == null)
            {
                this.instance = new AdminManager();
                return instance;
            }
            else
            {
                return instance;
            }
        }

        public void modifyData(int index, user data)
        {
            throw new NotImplementedException();
        }

        public user searchData(user data)
        {
            throw new NotImplementedException();
        }

    }
}
