using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisStudengManager.DataModel
{
    class Building
    {
        public string bno
        {
            set;
            get;
        }
        public string bname
        {
            set;
            get;
        }
        public Building(string bno,string bname)
        {
            this.bno = bno;
            this.bname = bname;
        }
    }
}
