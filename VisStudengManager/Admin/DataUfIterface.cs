using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisStudengManager.Admin
{
    //低频操作数据库的接口
    interface DataUfIterface<T>
    {
        //添加数据
        void addData(T data);
        //删除数据
        void delData(int index);
        //查找数据
        T searchData(T data);
        //获得所有数据
        List<user> getAllData();
        //修改数据
        void modifyData(int index, T data);
        
    }
}
