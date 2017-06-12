using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisStudengManager.DataModel
{
    class Department
    {
        public string deptno
        {
            set;
            get;
        }
        public string deptname
        {
            set;
            get;
        }
        public Department(string deptno,string deptname)
        {
            this.deptno = deptno;
            this.deptname = deptname;
        }
    }
}
