using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Collections;
using VisStudengManager.Data;
//重构0.1v
namespace VisStudengManager
{
    //读入内存中的数据，每一个表都可以直接读入内存，方便多交互操作，不会每退一次数据又要重新加载一次
    static class MemoryData
    {
        static public string account;
        static public string password;
        static public int Level;
        static public BuildingData building_data = new BuildingData();
        static public ClassesData classes_data = new ClassesData();
        static public ClassRoomData class_room_data = new ClassRoomData();
        static public ClassRoomBorrowData class_room_borrow_data = new ClassRoomBorrowData();
        static public DepartmentData department_data = new DepartmentData();
        static public StudentData student_data = new StudentData();
        static public TeacherClassData teacher_class_data = new TeacherClassData();
        static public TeachersData teacher_data = new TeachersData();
        static public UsersData users_data = new UsersData();
    }
}
