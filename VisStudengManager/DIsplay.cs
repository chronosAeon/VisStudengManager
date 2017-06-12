using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using VisStudengManager.Utils;
using Plugin_Ab;
using DiyMenuItem;
using VisStudengManager.DataModel;

namespace VisStudengManager
{
    //这个界面实现动态挂载组件的UI系统
    public partial class DIsplay : Form
    {
        ActiveUIController UImanager;
        BindingSource bs = new BindingSource();
        public DIsplay()
        {
            //获取当前UI
            UImanager = new ActiveUIController(this);
            InitializeComponent();
            MemoryData.users_data.readDataFromDb();
        }
        /*
            插件平台代码
        */
        //params  path 插件文件地址,laster 后缀
        private void LoadDlls(string path,string laster)
        {
            //获取所有符合命名规则的DLL
            string[] files = Directory.GetFiles(path, laster);
            for (int i = 0; i < files.Length; i++)
            {
                LoadAddin(files[i]);
            }
        }
        private void LoadAddin(string file)
        {
            Assembly assembly = Assembly.LoadFrom(file);
            Type[] types = assembly.GetTypes();
            foreach(var t in types)
            {
                var instance = assembly.CreateInstance(t.ToString());
                if (instance is plugin_Ab)
                {
                    add_MenuItem((plugin_Ab)instance);
                }
            }
            
        }
        private void add_MenuItem(plugin_Ab item)
        {
            Diy_MenuItem diyMenuItem = new Diy_MenuItem(item);
            this.menuStrip1.Items.Add(diyMenuItem);
        }


        private void PasswordChange_click(object sender, EventArgs e)
        {
            LoadPasswordChangeOnclickUi();
            
            //解挂载和挂载控件的demo
            //this.Controls.Clear();
            //Thread.Sleep(2000);
            //UImanager.AddControls(this.menuStrip1);
        }
        private void comfirmBtn_click(object sender,EventArgs e)
        {
            Control[] pass = (Control[]) Controls.Find("password", false);
            Control[] confirm = (Control[])Controls.Find("comfirmPas", false);
            string passwordText = pass[0].Text;
            string confrimText = confirm[0].Text;
            if(StrOperator.fnIsDigitOrLetter(passwordText,0, passwordText.Length)&& StrOperator.fnIsDigitOrLetter(confrimText, 0, confrimText.Length))
            {
                if(passwordText.Equals(confrimText))
                {
                    MessageBox.Show("修改成功");
                    pass[0].Text = "";
                    confirm[0].Text = "";
                    //判断修改的账号不是空字符串
                    if ((!passwordText.Equals("")) && (!confrimText.Equals("")))
                    {
                        Account findResult = MemoryData.users_data.users.Find((Account w) => { return w.password == MemoryData.password; });
                        //修改memorydata.user数组数据
                        if (findResult != null)
                        {
                            findResult.password = passwordText;
                        }
                        //修改memorydata的数据
                        MemoryData.password = passwordText;
                        //在关闭程序的时候同步
                    }
                }
                else
                {
                    MessageBox.Show("两次密码输入不匹配");
                    pass[0].Text = "";
                    confirm[0].Text = "";
                }
            }
            else
            {
                MessageBox.Show("请输入正确的密码格式");
                pass[0].Text = "";
                confirm[0].Text = "";
            }
        }
        private void Study_click(object sender,EventArgs e)
        {
            //这里读取是直接添加而不是删除内存数据之后再重新添加，所以readDataFromDb这个是写的有点问题的，
            //应该是删除了之后再重新添加
            MemoryData.class_room_borrow_data.readDataFromDb();
            bs.DataSource = MemoryData.class_room_borrow_data.classBorrow;
            LoadStudyOnclickUi(bs);
        }
        private void ClassRoomSearch_click(object sender, EventArgs e)
        {
            MemoryData.class_room_data.readDataFromDb();
            bs.DataSource = MemoryData.class_room_data.class_room;
            LoadClassRoomOnclickUi(bs);
        }
        private void TeacherSearch_click(object sender, EventArgs e)
        {
            MemoryData.teacher_data.readDataFromDb();
            bs.DataSource = MemoryData.teacher_data.teachers;
            LoadTeachers_searchOnclickUi(bs);
        }
        private void ClassSearch_click(object sender, EventArgs e)
        {
            MemoryData.classes_data.readDataFromDb();
            bs.DataSource = MemoryData.classes_data.classes;
            LoadClasses_searchOnclickUi(bs);
        }
        private void UiManager_click(object sender,EventArgs e)
        {

        }
        //老师界面按键触发
        private void ClassOperator_click(object sender,EventArgs e)
        {

        }
        private void StudentOperator_click(object sender, EventArgs e)
        {

        }
        private void DIsplay_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (DialogResult.OK == MessageBox.Show("你确定要关闭应用程序吗？", "关闭提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            //{
            //    this.FormClosing -= new FormClosingEventHandler(this.DIsplay_FormClosing);
            //    //为保证Application.Exit();时不再弹出提示，所以将FormClosing事件取消
            //    //从表格数据拿数据,放置到前端数据源
            //    bs = (BindingSource)this.dataGridView1.DataSource;
            //    //保存修改数据

            //    //Data.updateAccoClient(Data.getDataAll());


            //    //最好用这个exitThread()，用exit如果返回再打开会出现弹出两次对话框的情况，因为Application。exit
            //    Application.ExitThread();
                /*Application.Exit();*///退出整个应用程序
            //}
            //else
            //{
            //    e.Cancel = true;  //取消关闭事件
            //}
        }
        //缓冲数据库数据
        private void DIsplay_Load(object sender, EventArgs e)
        {
            if (MemoryData.Level == Const.STUDENT)
            {
                MemoryData.teacher_data.readDataFromDb();
                MemoryData.class_room_data.readDataFromDb();
                MemoryData.classes_data.readDataFromDb();
            }
            else if(MemoryData.Level == Const.TEACHER)
            {
                MemoryData.student_data.readDataFromDb();
                MemoryData.teacher_class_data.readDataFromDb();
            }
            else 
            {
                MemoryData.student_data.readDataFromDb();
                MemoryData.teacher_data.readDataFromDb();
                MemoryData.teacher_class_data.readDataFromDb();
                MemoryData.class_room_borrow_data.readDataFromDb();
                MemoryData.classes_data.readDataFromDb();
                MemoryData.building_data.readDataFromDb();
                MemoryData.department_data.readDataFromDb();
                MemoryData.class_room_data.readDataFromDb();
    }
        }
            //    if (administator.isAdmin == true)
            //    {
            //        this.addBtn.Enabled = true;
            //        this.deleteBtn.Enabled = true;
            //        this.queryBtn.Enabled = true;
            //    }
            //    bs = new BindingSource();
            //    bs.DataSource = Data.getDataAll();
            //    //这个是给下一条和下一页做数据绑定
            //    this.bindingNavigator1.BindingSource = bs;
            //    this.dataGridView1.DataSource = bs;
            //    for(int i=0;i<Data.studentTempdata.Length;i++)
            //    {
            //        for(int j=0;j<Data.getDataAll().Length;j++)
            //        {
            //            if (Data.studentTempdata[i].Equals(Data.getDataAll()[j]))
            //            {
            //                this.dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.Yellow;    
            //            }
            //        }
            //    }
            //}

        private void add_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add add = new Add();
            add.ShowDialog();
            this.Close();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            //    //rowNum就是索引
            //    int rowNum = this.dataGridView1.CurrentRow.Index;
            //    Data.delSimulation(rowNum);
            //    //不采用同时删掉数据库数据和前端数据的方法，每次进行这种删除后前端的行数更新了，而后端数据并没有更新
            //    //解决方案：1.采用每次前端作删除的操作时，同时以前端数据为基准进行对数据更新。
            //    //2.采用算法规避这个问题，持久化存贮一个数组存储删除数据的行号，当前删除的行大于等于多少行就会多加几就是它的id，这个可能存在算法bug需要多测试，但是这个方法极大程度的减少了数据库的耗时操作。
            //    //Data.deleteFormDb(rowNum+1);
            //    //现有的前端数据传入数据进行后台同步
            //    Data.updateAccoClient(Data.getDataAll());
            //    bs.DataSource = Data.getDataAll();
            //    this.dataGridView1.DataSource = bs;

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            //    //从表格数据拿数据,放置到前端数据源
            //    bs = (BindingSource)this.dataGridView1.DataSource;
            //    //保存修改数据
            //    Data.updateAccoClient(Data.getDataAll());
            //    this.Hide();
            //    MainMenu menu = new MainMenu();
            //    menu.ShowDialog();
            //    this.Close();
        }

        private void queryBtn_Click(object sender, EventArgs e)
        {
        }

        //    this.Hide();
        //    query query = new query();
        //    query.ShowDialog();
        //    this.Close();
        //}



        ////private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        ////{
        ////    this.Hide();
        ////    Add add = new Add();
        ////    add.ShowDialog();
        ////    this.Close();
        ////}

        ////private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        ////{
        ////    this.bs.MoveNext();
        ////}

        ////private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        ////{
        ////    this.bs.MovePrevious();
        ////}
    }
    }

