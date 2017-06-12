using System.Data.SQLite;

namespace VisStudengManager.Utils
{
    //验证器
    static class LoginValidater
    {
        //登录验证
        static public bool Login(string name ,string password,int type)
        {
            SQLiteConnection sql_con = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
            sql_con.Open();
            string ValidateSql = "SELECT password,authority FROM User where account = '" +name+ "'";
            SQLiteCommand com = new SQLiteCommand(ValidateSql, sql_con);
            SQLiteDataReader reader = com.ExecuteReader();
            if(reader.Read())
            {
                if(reader["password"].ToString().Equals(password)&& int.Parse(reader["authority"].ToString())==type)
                {
                    reader.Close();
                    sql_con.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    sql_con.Close();
                    return false;
                }
            }
            else
            {
                reader.Close();
                sql_con.Close();
                return false;
            }
        }
        //注册验证
        static public int Register (string name,string password,int type)
        {
            SQLiteConnection sql_con = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
            sql_con.Open();
            string ValidateSql = "SELECT Account FROM User where Account = " + "'" + name + "'";
            SQLiteCommand com = new SQLiteCommand(ValidateSql, sql_con);
            SQLiteDataReader reader = com.ExecuteReader();
            if(reader.Read())
            {
                reader.Close();
                return RegisterConst.ACCOUNTREUSE_FAIL;
            }
            else if(type == Const.ADMINISTRATOR)
            {
                reader.Close();
                sql_con.Close();
                return RegisterConst.REGISTER_ADMIN_FAIL;
            }
            else
            {
                reader.Close();
                SQLiteConnection sql_insert = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
                sql_insert.Open();
                //这个地方添加用户数据
                string InsertSql = "INSERT INTO User (account,password,islogin,authority,Forbidden) Values (" + "'" + name + "','"+password+"','"+false+"',"+type+",'"+false+"')";
                SQLiteCommand insertCom = new SQLiteCommand(InsertSql, sql_insert);
                insertCom.ExecuteNonQuery();
                sql_insert.Close();
                return RegisterConst.SUCCESS;
            }

        }
    }
}
