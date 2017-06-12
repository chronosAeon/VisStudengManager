using System.Windows.Forms;
using VisStudengManager;

namespace VisStudengManager
{
    partial class DIsplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new MenuStrip();
            ActiveLoadUI(MemoryData.Level);

            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1204, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
           
            // 
            // DIsplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 642);
            //挂载组件
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DIsplay";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DIsplay_FormClosing);
            this.Load += new System.EventHandler(this.DIsplay_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ActiveLoadUI(int authority)
            
        {
            if (authority == Const.STUDENT)
            {
                LoadStudentUi();
            }
            else if(authority==Const.TEACHER)
            {
                this.Text = "老师";
                LoadTeacherUi();
            }
            else
            {
                this.Text = "管理员";
                LoadAdministratorUi();
            }
}

        //权限UI,加载的是toolscript的东西
        private void LoadStudentUi()
        {
            this.Text = "学生";

            


            ToolStripMenuItem AccountToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem PassChangeToolStripMenuItem = new ToolStripMenuItem();

            ToolStripMenuItem ClassRoomToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem StudyToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem SearchClassRoomStripMenuItem = new ToolStripMenuItem();


            ToolStripMenuItem TeacherToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem TeacherSearchToolStripMenuItem = new ToolStripMenuItem();
            TeacherToolStripMenuItem.DropDownItems.Add(TeacherSearchToolStripMenuItem);

            ToolStripMenuItem ClassToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem ClassSearchToolStripMenuItem = new ToolStripMenuItem();
            ClassRoomToolStripMenuItem.DropDownItems.Add(SearchClassRoomStripMenuItem);



            this.menuStrip1.Items.Add(AccountToolStripMenuItem);
            this.menuStrip1.Items.Add(ClassRoomToolStripMenuItem);
            this.menuStrip1.Items.Add(TeacherToolStripMenuItem);
            this.menuStrip1.Items.Add(ClassToolStripMenuItem);

            // 
            // AccountToolStripMenuItem
            // 
            AccountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                PassChangeToolStripMenuItem});
            AccountToolStripMenuItem.Name = "AccountToolStripMenuItem";
            AccountToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            AccountToolStripMenuItem.Text = "账号管理";
            // 
            // PassChangeToolStripMenuItem
            // 
            PassChangeToolStripMenuItem.Name = "PassChangeToolStripMenuItem";
            PassChangeToolStripMenuItem.Size = new System.Drawing.Size(60, 22);
            PassChangeToolStripMenuItem.Text = "密码更改";
            PassChangeToolStripMenuItem.Click += new System.EventHandler(this.PasswordChange_click);
            // 
            // 教室ToolStripMenuItem
            // 
            ClassRoomToolStripMenuItem.DropDownItems.AddRange(new ToolStripMenuItem[] { StudyToolStripMenuItem, SearchClassRoomStripMenuItem });
            ClassRoomToolStripMenuItem.Name = "教室ToolStripMenuItem";
            ClassRoomToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            ClassRoomToolStripMenuItem.Text = "教室";

            StudyToolStripMenuItem.Name = "自习ToolStripMenuItem";
            StudyToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            StudyToolStripMenuItem.Text = "自习教室借阅";
            StudyToolStripMenuItem.Click += new System.EventHandler(this.Study_click);

            SearchClassRoomStripMenuItem.Name = "借阅ToolStripMenuItem";
            SearchClassRoomStripMenuItem.Size = new System.Drawing.Size(60, 21);
            SearchClassRoomStripMenuItem.Text = "教室查询";
            SearchClassRoomStripMenuItem.Click += new System.EventHandler(this.ClassRoomSearch_click);
            // 
            // 老师ToolStripMenuItem
            // 
            TeacherToolStripMenuItem.DropDownItems.AddRange(new ToolStripMenuItem[] { TeacherSearchToolStripMenuItem });
            TeacherToolStripMenuItem.Name = "老师ToolStripMenuItem";
            TeacherToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            TeacherToolStripMenuItem.Text = "老师";

            TeacherSearchToolStripMenuItem.Name = "老师查询ToolStripMenuItem";
            TeacherSearchToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            TeacherSearchToolStripMenuItem.Text = "老师查询";
            TeacherSearchToolStripMenuItem.Click += new System.EventHandler(this.TeacherSearch_click);
            // 
            // 课程ToolStripMenuItem
            ClassToolStripMenuItem.DropDownItems.AddRange(new ToolStripMenuItem[] { ClassSearchToolStripMenuItem });
            ClassToolStripMenuItem.Name = "课程ToolStripMenuItem";
            ClassToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            ClassToolStripMenuItem.Text = "课程";

            ClassSearchToolStripMenuItem.Name = "课程查询ToolStripMenuItem";
            ClassSearchToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            ClassSearchToolStripMenuItem.Text = "课程查询";
            ClassSearchToolStripMenuItem.Click += new System.EventHandler(this.ClassSearch_click);

            //插件加载
            LoadDlls(Application.StartupPath + "\\plugin", "*.Saddin.dll");
            //+"/plugin/"Application.StartupPath = "D:\\数据库项目\\VisStudengManager\\VisStudengManager\\bin\\Debug"
        }
        private void LoadTeacherUi()
        {
            this.Text = "老师";
            ToolStripMenuItem AccountToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem PassChangeToolStripMenuItem = new ToolStripMenuItem();

            ToolStripMenuItem ClassToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem ClassOperatorToolStripMenuItem = new ToolStripMenuItem();

            ToolStripMenuItem StudentToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem StudentOperatorToolStripMenuItem = new ToolStripMenuItem();

            this.menuStrip1.Items.Add(AccountToolStripMenuItem);
            this.menuStrip1.Items.Add(ClassToolStripMenuItem);
            this.menuStrip1.Items.Add(StudentToolStripMenuItem);


            AccountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                PassChangeToolStripMenuItem});
            AccountToolStripMenuItem.Name = "AccountToolStripMenuItem";
            AccountToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            AccountToolStripMenuItem.Text = "账号管理";
            // 
            // PassChangeToolStripMenuItem
            // 
            PassChangeToolStripMenuItem.Name = "PassChangeToolStripMenuItem";
            PassChangeToolStripMenuItem.Size = new System.Drawing.Size(60, 22);
            PassChangeToolStripMenuItem.Text = "密码更改";
            PassChangeToolStripMenuItem.Click += new System.EventHandler(this.PasswordChange_click);

            ClassToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ClassOperatorToolStripMenuItem });
            ClassToolStripMenuItem.Name = "ClassOperatorToolStripMenuItem";
            ClassToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            ClassToolStripMenuItem.Text = "授课管理";

            ClassOperatorToolStripMenuItem.Name = "ClassOperatorToolStripMenuItem";
            ClassOperatorToolStripMenuItem.Size = new System.Drawing.Size(60, 22);
            ClassOperatorToolStripMenuItem.Text = "授课操作";
            ClassOperatorToolStripMenuItem.Click += new System.EventHandler(this.ClassOperator_click);

            StudentToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { StudentOperatorToolStripMenuItem });
            StudentToolStripMenuItem.Name = "StudentToolStripMenuItem";
            StudentToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            StudentToolStripMenuItem.Text = "学生管理";

            StudentOperatorToolStripMenuItem.Name = "StudentOperatorToolStripMenuItem";
            StudentOperatorToolStripMenuItem.Size = new System.Drawing.Size(60, 22);
            StudentOperatorToolStripMenuItem.Text = "学生操作";
            StudentOperatorToolStripMenuItem.Click += new System.EventHandler(this.StudentOperator_click);
        }
        private void LoadAdministratorUi()
        {
            this.Text = "管理员";
            //账号管理
            ToolStripMenuItem AccountToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem PassChangeToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem UserManagerItem = new ToolStripMenuItem();
            
            //课程管理
            ToolStripMenuItem ClassToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem ClassOperatorToolStripMenuItem = new ToolStripMenuItem();

            //学生管理
            ToolStripMenuItem StudentToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem StudentOperatorToolStripMenuItem = new ToolStripMenuItem();

            //教师管理
            ToolStripMenuItem TeacherToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem TeacherOperatorToolStripMenuItem = new ToolStripMenuItem();

            //教室管理
            ToolStripMenuItem ClassRoomToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem ClassRoomOperatorToolStripMenuItem = new ToolStripMenuItem();

            this.menuStrip1.Items.Add(AccountToolStripMenuItem);
            this.menuStrip1.Items.Add(ClassToolStripMenuItem);
            this.menuStrip1.Items.Add(StudentToolStripMenuItem);
            this.menuStrip1.Items.Add(TeacherToolStripMenuItem);
            this.menuStrip1.Items.Add(ClassRoomToolStripMenuItem);

            AccountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                PassChangeToolStripMenuItem,UserManagerItem});
            AccountToolStripMenuItem.Name = "AccountToolStripMenuItem";
            AccountToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            AccountToolStripMenuItem.Text = "账号管理";
            // 
            // PassChangeToolStripMenuItem
            // 
            PassChangeToolStripMenuItem.Name = "PassChangeToolStripMenuItem";
            PassChangeToolStripMenuItem.Size = new System.Drawing.Size(60, 22);
            PassChangeToolStripMenuItem.Text = "密码更改";
            PassChangeToolStripMenuItem.Click += new System.EventHandler(this.PasswordChange_click);

            UserManagerItem.Name = "UserManager";
            UserManagerItem.Size = new System.Drawing.Size(60, 22);
            UserManagerItem.Text = "账号管理";
            UserManagerItem.Click += new System.EventHandler(this.UiManager_click);


            ClassToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ClassOperatorToolStripMenuItem });
            ClassToolStripMenuItem.Name = "ClassOperatorToolStripMenuItem";
            ClassToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            ClassToolStripMenuItem.Text = "授课管理";

            ClassOperatorToolStripMenuItem.Name = "ClassOperatorToolStripMenuItem";
            ClassOperatorToolStripMenuItem.Size = new System.Drawing.Size(60, 22);
            ClassOperatorToolStripMenuItem.Text = "授课操作";
            ClassOperatorToolStripMenuItem.Click += new System.EventHandler(this.ClassOperator_click);

            StudentToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { StudentOperatorToolStripMenuItem });
            StudentToolStripMenuItem.Name = "StudentToolStripMenuItem";
            StudentToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            StudentToolStripMenuItem.Text = "学生管理";

            StudentOperatorToolStripMenuItem.Name = "StudentOperatorToolStripMenuItem";
            StudentOperatorToolStripMenuItem.Size = new System.Drawing.Size(60, 22);
            StudentOperatorToolStripMenuItem.Text = "学生操作";
            StudentOperatorToolStripMenuItem.Click += new System.EventHandler(this.StudentOperator_click);


        }
        #endregion

        //自习按键触发ui
        private void LoadStudyOnclickUi(BindingSource bs)
        {
            //这个dg是在局部域但是却要加载在一个form里面，dg的生命周期本来很短但是你把它强行不回收给加载了
            //导致他的引用被使用无法回收，但是动态加载其他的区域后，这个引用不被使用，就不确定这个是否会被收回。
            this.UImanager.ClearAllControls();
            BindingNavigator bn = new BindingNavigator();
            DataGridView dg = new DataGridView();
            dg.Location = new System.Drawing.Point(600, 25);
            dg.Name = "dg";
            dg.Size = new System.Drawing.Size(600, 600);
            dg.Text = "dg";
            //this.Controls.Add(dg);
            this.UImanager.AddControls(this.menuStrip1, dg);
            dg.DataSource = bs.DataSource;
            //调整各字段的行宽
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        //密码修改按键触发ui
        public void LoadPasswordChangeOnclickUi()
        {
            this.UImanager.ClearAllControls();
            TextBox password = new TextBox();
            password.Location = new System.Drawing.Point(600, 250);
            password.Name = "password";
            password.Size = new System.Drawing.Size(200, 120);
            password.Text = "修改密码";
            TextBox comfirmPas = new TextBox();
            comfirmPas.Location = new System.Drawing.Point(600, 300);
            comfirmPas.Name = "comfirmPas";
            comfirmPas.Size = new System.Drawing.Size(200, 120);
            comfirmPas.Text = "确认密码";
            Button comfirmBtn = new Button();
            comfirmBtn.Location = new System.Drawing.Point(600, 400);
            comfirmBtn.Name = "comfirmBtn";
            comfirmBtn.Size = new System.Drawing.Size(100, 100);
            comfirmBtn.Text = "确定";
            this.UImanager.AddControls(this.menuStrip1, comfirmPas, password,comfirmBtn);
            comfirmBtn.Click += new System.EventHandler(this.comfirmBtn_click);
        }
        //教室查询触发ui
        public void LoadClassRoomOnclickUi(BindingSource bs)
        {
            this.UImanager.ClearAllControls();
            BindingNavigator bn = new BindingNavigator();
            DataGridView dg = new DataGridView();
            dg.Location = new System.Drawing.Point(600, 25);
            dg.Name = "dg";
            dg.Size = new System.Drawing.Size(600, 600);
            dg.Text = "dg";
            this.UImanager.AddControls(this.menuStrip1,dg);
            dg.DataSource = bs.DataSource;
            //调整各字段的行宽
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        //教师查询触发ui
        public void LoadTeachers_searchOnclickUi(BindingSource bs)
        {
            this.UImanager.ClearAllControls();
            BindingNavigator bn = new BindingNavigator();
            DataGridView dg = new DataGridView();
            dg.Location = new System.Drawing.Point(600, 25);
            dg.Name = "dg";
            dg.Size = new System.Drawing.Size(600, 600);
            dg.Text = "dg";
            this.UImanager.AddControls(this.menuStrip1, dg);
            dg.DataSource = bs.DataSource;
            //调整各字段的行宽
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        //课程查询触发ui
        public void LoadClasses_searchOnclickUi(BindingSource bs)
        {
            this.UImanager.ClearAllControls();
            BindingNavigator bn = new BindingNavigator();
            DataGridView dg = new DataGridView();
            dg.Location = new System.Drawing.Point(600, 25);
            dg.Name = "dg";
            dg.Size = new System.Drawing.Size(600, 600);
            dg.Text = "dg";
            this.UImanager.AddControls(this.menuStrip1, dg);
            dg.DataSource = bs.DataSource;
            //调整各字段的行宽
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        //private void LoadS
        private MenuStrip menuStrip1;

    }
}