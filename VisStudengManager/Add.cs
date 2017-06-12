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
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void yesBtn_Click(object sender, EventArgs e)
        {
            int num = int.Parse(this.numerText.Text);
            string name = this.nameText.Text;
            int age = int.Parse(this.ageText.Text);
            string sex = this.sexText.Text;
            string major = this.majorText.Text;
            string place = this.placeText.Text;
            string interest = this.interestText.Text;
            //Data.addSimulation(new StudentData(num,name,sex,age,major,place,interest));
            //Data.insertFromDb(num, name, age, sex, place, sex, interest);
            this.Hide();
            DIsplay dis = new DIsplay();
            dis.ShowDialog();
            this.Close();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            DIsplay dis = new DIsplay();
            dis.ShowDialog();
            this.Close();
        }
    }
}
