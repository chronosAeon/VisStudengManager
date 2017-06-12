using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisStudengManager
{
    //这个类控制登录状态
     class LoginStatus
    {
       
        const int CUSTOM = 0;
        const int ADMINISTRATOR = 1;
        const int STUDENT = 2;
        const int TEACHER = 3;
        public enum Status { CUSTOM, ADMINISTRATOR, STUDENT, TEACHER};
        public int LoginStyle;
        public bool isLogin; 
        //状态类的构造函数，默认是未登录和游客状态
        public LoginStatus()
        {
           isLogin = false;
           LoginStyle = CUSTOM;
        }
        //登录种类是那个种类，教师，学生，管理员，游客
        public void changeStatus(Status status)
        {
            this.LoginStyle = (int)status;
        }
        //登录状态离线或者在线
        public void changeIsLogin()
        {
            if(!isLogin)
            {
                isLogin = true;
            }
            else
            {
                isLogin = false;
            }
        }
    }
}
