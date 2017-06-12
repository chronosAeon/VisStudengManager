using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisStudengManager.Utils
{
    class ActiveUIController
    {
        private Form form;
        public ActiveUIController(Form form)
        {
            this.form = form;
        }
        public void AddControls(params Control[] controls)
        {
            foreach (Control item in controls)
            {
                this.form.Controls.Add(item);
            }
        }
        public void ClearAllControls()
        {
            this.form.Controls.Clear();
        }
    }
}
