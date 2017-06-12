using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisStudengManager.DataModel
{
    class ClassRoom
    {
        public int clno {
            set;
            get;
        }
        public string bno
        {
            set;
            get;
        }
        public string floor
        {
            set;
            get;
        }
        public ClassRoom(int clno,string bno,string floor)
        {
            this.clno = clno;
            this.bno = bno;
            this.floor = floor;
        }
    }
}
