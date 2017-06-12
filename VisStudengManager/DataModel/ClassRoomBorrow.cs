using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisStudengManager.DataModel
{
    class ClassRoomBorrow
    {
        public string clno
        {
            set;
            get;
        }
        public string sno
        {
            set;
            get;
        }
        public string usedate
        {
            set;
            get;
        }
        public string Weekday
        {
            set;
            get;
        }
        public string Period
        {
            set;
            get;
        }
        public string Use
        {
            set;
            get;
        }
        public string Usestatus
        {
            set;
            get;
        }
        public ClassRoomBorrow(string clno,string sno,string usedate,string Weekday,string Period,
            string Use,string UseStatus)
        {
            this.clno = clno;
            this.sno = sno;
            this.usedate = usedate;
            this.Weekday = Weekday;
            this.Period = Period;
            this.Use = Use;
            this.Usestatus = UseStatus;
        }
    }
}
