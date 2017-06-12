using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisStudengManager.Admin
{
    /*
        用户类定义账号密码，改变账号密码的方法。
    */
    class user
    {
        //账号
        public string Account
        {
            set;
            get;
        }
        //密码
        public string password
        {
            set;
            get;
        }
        //登录状态
        public LoginStatus loginstatus;
        //构造一个用户
        public user(string account,string password)
        {
            this.Account = account;
            this.password = password;
            loginstatus = new LoginStatus();
        }
        //更改密码
        public void changePassword(string password)
        {
            this.password = password;
        }
        //确认登录
        public bool confirm (string account,string password)
        {
            if (this.Account == account && this.password == password)
            {
                return true;
            }
            else
                return false;
        }
    }
}
