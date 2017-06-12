using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisStudengManager.Utils;
namespace VisStudengManager
{
    public partial class Enter : Form
    {
        public Enter()
        {
            if (!DbOperator.chackExistDb(@"Data_Db.sqlite"))
            {
                DbOperator.createDb(@"Data_Db.sqlite");
            }
            InitializeComponent();
            // 设置窗体的类型  
            const string showInfo = "启动画面：我们正在努力的加载程序，请稍后...";
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            ShowInTaskbar = false;
            bitmap = new Bitmap(Properties.Resources.SplashScreen);
            ClientSize = bitmap.Size;

            using (Font font = new Font("Consoles", 15))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.DrawString(showInfo, font, Brushes.White, 130, 100);
                }
            }
            BackgroundImage = bitmap;
        }

            /// <summary>  
            /// 启动画面本身  
            /// </summary>  
            static Enter instance;

            /// <summary>  
            /// 显示的图片  
            /// </summary>  
            Bitmap bitmap;

            public static Enter Instance
            {
                get
                {
                    return instance;
                }
                set
                {
                    instance = value;
                }
            }


            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    if (bitmap != null)
                    {
                        bitmap.Dispose();
                        bitmap = null;
                    }
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            public static void ShowSplashScreen()
            {
                instance = new Enter();
                instance.Show();
            }
        }
    }
