using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisStudengManager.Utils;
using System.Data.SQLite;
namespace VisStudengManager
{
    public partial class Admin : Form
    {
        static private void checking()
        {
            if (!DbOperator.checkExistTable("Data_Db.sqlite", "User"))
            {
                SQLiteConnection CreateConnect = new SQLiteConnection("Data Source=Data_Db.sqlite;Version=3;");
                CreateConnect.Open();
                string createTable = "Create table User (account Text PRIMARY KEY Not Null, password Text Not Null, islogin boolean not Null,authority integer Not null,Forbidden boolean Not null )";
                //创建指令
                SQLiteCommand command = new SQLiteCommand(createTable, CreateConnect);
                //执行指令
                command.ExecuteNonQuery();
                CreateConnect.Close();
            }
        }
        public Admin()
        {
            //如果不存在users这张表
            checking();
            InitializeComponent();
            Student.Checked = true;
        }
        private void login_Click(object sender, EventArgs e)
        {
            string account = this.accoundText.Text;
            string password = this.passwordText.Text;
            //判断登录类型，并且记得给memory赋权限
            if(Student.Checked==true)
            {
                bool  res = LoginValidater.Login(account,password,Const.STUDENT);
                if (res)
                {
                    //控制权限
                    MemoryData.Level = Const.STUDENT;
                    MemoryData.account = account;
                    MemoryData.password = password;
                    this.Hide();
                    DIsplay display = new DIsplay();
                    display.ShowDialog();
                    this.Close();
                }
                else
                {
                    this.accoundText.Clear();
                    this.passwordText.Clear();
                    MessageBox.Show("账号密码错误或账号类型错误");
                }
            }
            else if(Teacher.Checked==true)
            {
                bool res = LoginValidater.Login(account, password,Const.TEACHER);
                if (res)
                {
                    MemoryData.Level = Const.TEACHER;
                    MemoryData.account = account;
                    MemoryData.password = password;
                    this.Hide();
                    DIsplay display = new DIsplay();
                    display.ShowDialog();
                    this.Close();
                }
                else
                {
                    this.accoundText.Clear();
                    this.passwordText.Clear();
                    MessageBox.Show("账号密码错误或账号类型错误");
                }
            }
            else
            {
                //控制权限
                bool res = LoginValidater.Login(account, password, Const.ADMINISTRATOR);
                if (res)
                {
                    MemoryData.Level = Const.ADMINISTRATOR;
                    MemoryData.account = account;
                    MemoryData.password = password;
                    this.Hide();
                    DIsplay display = new DIsplay();
                    display.ShowDialog();
                    this.Close();
                }
                else
                {
                    this.accoundText.Clear();
                    this.passwordText.Clear();
                    MessageBox.Show("账号密码错误或账号类型错误");
                }
                
            }      
        }
        private void custom_Click(object sender, EventArgs e)
        {
            //数据库里不会存游客账号，只用控制内存权限就好了
            MemoryData.Level = Const.CUSTOMER;
            this.Hide();
            MainMenu menu = new MainMenu();
            menu.ShowDialog();
            this.Close();
        }
        private void register_Click(object sender, EventArgs e)
        {
            string account = this.accoundText.Text;
            string password = this.passwordText.Text;
            //输入不能为空
            if (!(accound.Equals("") && password.Equals("")))
            {
                if (Student.Checked)
                {
                    int res = LoginValidater.Register(account, password, Const.STUDENT);
                    reShowBox(res);
                    this.accoundText.Clear();
                    this.passwordText.Clear();
                }
                else if (Teacher.Checked)
                {
                    LoginValidater.Register(account, password, Const.TEACHER);
                    this.accoundText.Clear();
                    this.passwordText.Clear();
                }
                else
                {
                    LoginValidater.Register(account, password, Const.ADMINISTRATOR);
                    this.accoundText.Clear();
                    this.passwordText.Clear();
                }
            }
        }
        private void reShowBox(int resCode)
        {
            switch(resCode)
            {
                case RegisterConst.ACCOUNTREUSE_FAIL:
                    {
                        MessageBox.Show("账号已被占用请重新注册");
                    }
                    break;
                case RegisterConst.REGISTER_ADMIN_FAIL:
                    {
                        MessageBox.Show("不能注册管理权限账号");
                    }
                    break;
                case RegisterConst.SUCCESS:
                    {
                        MessageBox.Show("账号注册成功");
                    }
                    break;
            }
        }
    }
}
