namespace VisStudengManager
{
    partial class Admin
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
            this.accound = new System.Windows.Forms.Label();
            this.accoundText = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.Label();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.title = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.Button();
            this.custom = new System.Windows.Forms.Button();
            this.Student = new System.Windows.Forms.RadioButton();
            this.Teacher = new System.Windows.Forms.RadioButton();
            this.System = new System.Windows.Forms.RadioButton();
            this.register = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // accound
            // 
            this.accound.AutoSize = true;
            this.accound.Location = new System.Drawing.Point(218, 198);
            this.accound.Name = "accound";
            this.accound.Size = new System.Drawing.Size(41, 12);
            this.accound.TabIndex = 0;
            this.accound.Text = "账号：";
            // 
            // accoundText
            // 
            this.accoundText.Location = new System.Drawing.Point(291, 189);
            this.accoundText.Name = "accoundText";
            this.accoundText.Size = new System.Drawing.Size(133, 21);
            this.accoundText.TabIndex = 1;
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Location = new System.Drawing.Point(218, 250);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(41, 12);
            this.password.TabIndex = 2;
            this.password.Text = "密码：";
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(291, 241);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(133, 21);
            this.passwordText.TabIndex = 3;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(440, 62);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(101, 12);
            this.title.TabIndex = 4;
            this.title.Text = "学生管理系统登录";
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(495, 189);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(112, 73);
            this.login.TabIndex = 6;
            this.login.Text = "Login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // custom
            // 
            this.custom.Location = new System.Drawing.Point(495, 284);
            this.custom.Name = "custom";
            this.custom.Size = new System.Drawing.Size(112, 23);
            this.custom.TabIndex = 7;
            this.custom.Text = "custom";
            this.custom.UseVisualStyleBackColor = true;
            this.custom.Click += new System.EventHandler(this.custom_Click);
            // 
            // Student
            // 
            this.Student.AutoSize = true;
            this.Student.Location = new System.Drawing.Point(220, 319);
            this.Student.Name = "Student";
            this.Student.Size = new System.Drawing.Size(71, 16);
            this.Student.TabIndex = 8;
            this.Student.TabStop = true;
            this.Student.Text = "学生登录";
            this.Student.UseVisualStyleBackColor = true;
            // 
            // Teacher
            // 
            this.Teacher.AutoSize = true;
            this.Teacher.Location = new System.Drawing.Point(220, 372);
            this.Teacher.Name = "Teacher";
            this.Teacher.Size = new System.Drawing.Size(71, 16);
            this.Teacher.TabIndex = 9;
            this.Teacher.TabStop = true;
            this.Teacher.Text = "教师登录";
            this.Teacher.UseVisualStyleBackColor = true;
            // 
            // System
            // 
            this.System.AutoSize = true;
            this.System.Location = new System.Drawing.Point(220, 430);
            this.System.Name = "System";
            this.System.Size = new System.Drawing.Size(83, 16);
            this.System.TabIndex = 10;
            this.System.TabStop = true;
            this.System.Text = "管理员登录";
            this.System.UseVisualStyleBackColor = true;
            // 
            // register
            // 
            this.register.Location = new System.Drawing.Point(679, 189);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(75, 73);
            this.register.TabIndex = 11;
            this.register.Text = "register";
            this.register.UseVisualStyleBackColor = true;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // Admin
            // 
            this.ClientSize = new System.Drawing.Size(1080, 636);
            this.Controls.Add(this.register);
            this.Controls.Add(this.System);
            this.Controls.Add(this.Teacher);
            this.Controls.Add(this.Student);
            this.Controls.Add(this.custom);
            this.Controls.Add(this.login);
            this.Controls.Add(this.title);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.password);
            this.Controls.Add(this.accoundText);
            this.Controls.Add(this.accound);
            this.Name = "Admin";
            this.Text = "Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label accound;
        private System.Windows.Forms.TextBox accoundText;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button custom;
        private System.Windows.Forms.RadioButton System;
        private System.Windows.Forms.RadioButton Teacher;
        private System.Windows.Forms.RadioButton Student;
        private System.Windows.Forms.Button register;
    }
}