using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisStudengManager.DataModel { 
    class Teachers
    {
        public string tno
        {
            set;
            get;
        }
        public string tname
        {
            set;
            get;
        }
        public string sex
        {
            set;
            get;
        }
        public string deptno
        {
            set;
            get;
        }
        public string title
        {
            set;
            get;
        }
        public string tid
        {
            set;
            get;
        }
        public Teachers(string tno , string tname,string sex ,string deptno,string title,string tid)
        {
            this.tno = tno;
            this.tname = tname;
            this.sex = sex;
            this.deptno = deptno;
            this.title = title;
            this.tid = tid;
        }
    }
}
