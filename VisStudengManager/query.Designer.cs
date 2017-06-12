namespace VisStudengManager
{
    partial class query
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
            this.queryList = new System.Windows.Forms.ListBox();
            this.comfirmBtn = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.querycontentText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // queryList
            // 
            this.queryList.FormattingEnabled = true;
            this.queryList.ItemHeight = 12;
            this.queryList.Location = new System.Drawing.Point(25, 74);
            this.queryList.Name = "queryList";
            this.queryList.Size = new System.Drawing.Size(120, 28);
            this.queryList.TabIndex = 0;
            // 
            // comfirmBtn
            // 
            this.comfirmBtn.Location = new System.Drawing.Point(25, 148);
            this.comfirmBtn.Name = "comfirmBtn";
            this.comfirmBtn.Size = new System.Drawing.Size(75, 23);
            this.comfirmBtn.TabIndex = 1;
            this.comfirmBtn.Text = "确定";
            this.comfirmBtn.UseVisualStyleBackColor = true;
            this.comfirmBtn.Click += new System.EventHandler(this.comfirmBtn_Click);
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(152, 148);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(75, 23);
            this.back.TabIndex = 2;
            this.back.Text = "返回";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // querycontentText
            // 
            this.querycontentText.Location = new System.Drawing.Point(152, 81);
            this.querycontentText.Name = "querycontentText";
            this.querycontentText.Size = new System.Drawing.Size(120, 21);
            this.querycontentText.TabIndex = 3;
            // 
            // query
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.querycontentText);
            this.Controls.Add(this.back);
            this.Controls.Add(this.comfirmBtn);
            this.Controls.Add(this.queryList);
            this.Name = "query";
            this.Text = "query";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox queryList;
        private System.Windows.Forms.Button comfirmBtn;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.TextBox querycontentText;
    }
}