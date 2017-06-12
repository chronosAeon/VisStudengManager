using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace VisStudengManager.Utils
{
    static class DbOperator
    {
        static public bool chackExistDb(string DbName)
        {
            if (File.Exists(DbName)){
                return true;
            }
            else
            {
                return false;
            }
        }
        static public void createDb(string DbName)
        {
            SQLiteConnection.CreateFile(DbName);
        }
        static public bool checkExistTable(string DbName, string TableName)
        {
                SQLiteConnection connection = new SQLiteConnection("Data Source=" + DbName + ";Version=3;");
                connection.Open();
                string checkExistSql = "select count(*) from sqlite_master where type = 'table' and name = '" + TableName + "'";
                SQLiteCommand com = new SQLiteCommand(checkExistSql, connection);
                SQLiteDataReader reader = com.ExecuteReader();
                reader.Read();
            if (int.Parse(reader[0].ToString()) == 1)
            {
                //关闭读取器就会自带关闭connection但是关闭connection关闭不不会关reader所以必须关闭读取器否则后面无法写数据
                reader.Close();
                //MessageBox.Show("有这个表");
                connection.Close();
                //如果存在这个表
                return true;
            }
            else
            {
                reader.Close();
                //MessageBox.Show("没有这个表");
                connection.Close();
                //如果不存在这个表
                return false;
            }
       }
    }
}
