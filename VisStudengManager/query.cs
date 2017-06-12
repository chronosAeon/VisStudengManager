using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisStudengManager
{
    public partial class query : Form
    {
        public query()
        {
            InitializeComponent();
            this.queryList.DataSource = new String[] { "学号", "姓名", "性别", "年龄", "专业", "籍贯", "兴趣" };
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            DIsplay display = new DIsplay();
            display.ShowDialog();
            this.Close();
        }

        private void comfirmBtn_Click(object sender, EventArgs e)
        {
            //if (this.querycontentText.Text == "")
            //{
            //    MessageBox.Show("请输入数据");
            //}
            //else
            //{
            //    Model model = new Model();
            //    switch (this.queryList.Text)
            //    {
            //        case "学号":
            //            {
            //                int input;
            //                bool res = int.TryParse(this.querycontentText.Text.ToString(), out input);
            //                if (!res)
            //                {
            //                    MessageBox.Show("不成功,请重新输入");
            //                    this.querycontentText.Clear();
            //                }
            //                else
            //                {
            //                    model.queryByNum(input);
            //                    if (Data.studentTempdata.Length == 0)
            //                    {
            //                        this.querycontentText.Clear();
            //                        MessageBox.Show("未找到数据请重新查找");
            //                    }
            //                    else
            //                    {
            //                        MessageBox.Show("成功查询，正在返回");
            //                        this.Hide();
            //                        DIsplay display = new DIsplay();
            //                        display.ShowDialog();
            //                        this.Close();
            //                    }
            //                }
            //            }
            //            break;
            //        case "姓名":
            //            {
            //                String input;
            //                input = this.querycontentText.Text.ToString();
            //                model.queryByName(input);
            //                if (Data.studentTempdata.Length == 0)
            //                {
            //                    this.querycontentText.Clear();
            //                    MessageBox.Show("未找到数据请重新查找");
            //                }
            //                else
            //                {
            //                    MessageBox.Show("成功查询，正在返回");
            //                    this.Hide();
            //                    DIsplay display = new DIsplay();
            //                    display.ShowDialog();
            //                    this.Close();
            //                }
            //            }
            //            break;
            //        case "年龄":
            //            {
            //                int input;
            //                bool res = int.TryParse(this.querycontentText.Text.ToString(), out input);
            //                if (!res)
            //                {
            //                    MessageBox.Show("不成功,请重新输入");
            //                    this.querycontentText.Clear();
            //                }
            //                else
            //                {
            //                    model.queryByAge(input);
            //                    if (Data.studentTempdata.Length == 0)
            //                    {
            //                        this.querycontentText.Clear();
            //                        MessageBox.Show("未找到数据请重新查找");
            //                    }
            //                    else
            //                    {
            //                        MessageBox.Show("成功查询，正在返回");
            //                        this.Hide();
            //                        DIsplay display = new DIsplay();
            //                        display.ShowDialog();
            //                        this.Close();
            //                    }
            //                }
            //            }
            //            break;
            //        case "兴趣":
            //            {
            //                String input;
            //                input = this.querycontentText.Text.ToString();
            //                model.queryByInterest(input);
            //                if (Data.studentTempdata.Length == 0)
            //                {
            //                    this.querycontentText.Clear();
            //                    MessageBox.Show("未找到数据请重新查找");
            //                }
            //                else
            //                {
            //                    MessageBox.Show("成功查询，正在返回");
            //                    this.Hide();
            //                    DIsplay display = new DIsplay();
            //                    display.ShowDialog();
            //                    this.Close();
            //                }
            //            }
            //            break;
            //        case "籍贯":
            //            {
            //                String input;
            //                input = this.querycontentText.Text.ToString();
            //                model.queryByPlace(input);
            //                //if (Data.studentTempdata.Length == 0)
            //                //{
            //                //    this.querycontentText.Clear();
            //                //    MessageBox.Show("未找到数据请重新查找");
            //                //}
            //                else
            //                {
            //                    MessageBox.Show("成功查询，正在返回");
            //                    this.Hide();
            //                    DIsplay display = new DIsplay();
            //                    display.ShowDialog();
            //                    this.Close();
            //                }
            //            }
            //            break;
            //        case "专业":
            //            {
            //                String input;
            //                input = this.querycontentText.Text.ToString();
            //                model.queryByMajor(input);
            //                if (Data.studentTempdata.Length == 0)
            //                {
            //                    this.querycontentText.Clear();
            //                    MessageBox.Show("未找到数据请重新查找");
            //                }
            //                else
            //                {
            //                    MessageBox.Show("成功查询，正在返回");
            //                    this.Hide();
            //                    DIsplay display = new DIsplay();
            //                    display.ShowDialog();
            //                    this.Close();
            //                }
            //            }
            //            break;
            //        case "性别":
            //            {
            //                String input;
            //                input = this.querycontentText.Text.ToString();
            //                model.queryBySex(input);
            //                if (Data.studentTempdata.Length == 0)
            //                {
            //                    this.querycontentText.Clear();
            //                    MessageBox.Show("未找到数据请重新查找");
            //                }
            //                else
            //                {
            //                    MessageBox.Show("成功查询，正在返回");
            //                    this.Hide();
            //                    DIsplay display = new DIsplay();
            //                    display.ShowDialog();
            //                    this.Close();
            //                }
            //                break;
            //            }

            //    
            
        }
    }
}
