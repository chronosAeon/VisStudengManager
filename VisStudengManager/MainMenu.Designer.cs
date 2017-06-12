namespace VisStudengManager
{
    partial class MainMenu
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
            this.showBtn = new System.Windows.Forms.Button();
            this.MenuLabel = new System.Windows.Forms.Label();
            this.quitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // showBtn
            // 
            this.showBtn.Location = new System.Drawing.Point(217, 179);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(112, 23);
            this.showBtn.TabIndex = 0;
            this.showBtn.Text = "显示所有学生数据";
            this.showBtn.UseVisualStyleBackColor = true;
            this.showBtn.Click += new System.EventHandler(this.showBtn_Click);
            // 
            // MenuLabel
            // 
            this.MenuLabel.AutoSize = true;
            this.MenuLabel.Location = new System.Drawing.Point(258, 98);
            this.MenuLabel.Name = "MenuLabel";
            this.MenuLabel.Size = new System.Drawing.Size(41, 12);
            this.MenuLabel.TabIndex = 1;
            this.MenuLabel.Text = "主菜单";
            // 
            // quitBtn
            // 
            this.quitBtn.Location = new System.Drawing.Point(217, 281);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(112, 23);
            this.quitBtn.TabIndex = 6;
            this.quitBtn.Text = "退出";
            this.quitBtn.UseVisualStyleBackColor = true;
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 463);
            this.Controls.Add(this.quitBtn);
            this.Controls.Add(this.MenuLabel);
            this.Controls.Add(this.showBtn);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button showBtn;
        private System.Windows.Forms.Label MenuLabel;
        private System.Windows.Forms.Button quitBtn;
    }
}