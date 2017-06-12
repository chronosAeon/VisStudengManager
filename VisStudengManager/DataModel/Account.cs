using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisStudengManager.DataModel
{
    class Account
    {
        //对于一个要datagridview绑定的数据类里面一定不能是字段，要像这样写成属性才能正确读取。
        public string name
        {
            get;
        }
        public string password
        {
            get;
            set;
        }
        public bool isLogin
        {
            get;
            set;
        }
        public int type
        {
            get;
            set;
        }
        public bool Forbidden
        {
            get;
            set;
        }
        public Account(string name,string password,bool islogin,int type,bool Forbidden)
        {
            this.name = name;
            this.password = password;
            this.isLogin = islogin;
            this.type = type;
            this.Forbidden = false;
        }
        private void changePass(string newPass)
        {
            this.password = newPass;
        }

        public static implicit operator Account(bool v)
        {
            throw new NotImplementedException();
        }
    }
}
