using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisStudengManager.DataModel
{
    class TeacherClass
    {
        public string tno
        {
            set;
            get;
        }
        public string clno
        {
            set;
            get;
        }
        public string cno
        {
            set;
            get;
        }
        public string weekday
        {
            set;
            get;
        }
        public string period
        {
            set;
            get;
        }
        public TeacherClass(string tno,string clno,string cno,string weekday,string period)
        {
            this.tno = tno;
            this.clno = clno;
            this.cno = cno;
            this.weekday = weekday;
            this.period = period;
        }
    }
}
