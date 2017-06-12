using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisStudengManager.DataModel
{
    class Classes
    {
        public string cno
        {
            set;
            get;
        }
        public string cname
        {
            set;
            get;
        }
        public string credit
        {
            set;
            get;
        }
        public string category
        {
            set;
            get;
        }
        public string deptno
        {
            set;
            get;
        }
        public Classes(string cno,string cname,string credit,string category,string deptno)
        {
            this.cno = cno;
            this.cname = cname;
            this.credit = credit;
            this.category = category;
            this.deptno = deptno;
        }
    }
}
