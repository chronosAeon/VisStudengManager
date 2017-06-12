using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisStudengManager
{
    //高频率使用的操作数据库的接口
    interface DataIterface<T>
    {
        //从数据库读取数据
        void readDataFromDb();
        //添加一条前端数据
        void Add(T additem);
        //删除一条前端数据
        void delSimulation(int index);
        //修改一条前端数据
        void modifySimulation(int index, T data);
        //查询一条前端数据
        //T findSimulation<T>(int index)
        //获取前端所有数据
        List<T> getDataAll();
        //同步前端数据到后端
        void updateAccoClient();
        void insertStudentDataToDb(T data);
        void clearAllMemoryData();
    }
}
