using System;
using System.Collections.Generic;

namespace StudentsAPI.Managers
{
    internal class StudentsManager
    {
        internal StudentsManager()
        {
        }

        Accessors.StudentsAccessor StudentsAccessor = new Accessors.StudentsAccessor();


        internal List<Models.StudentModel> GetStudents()
        {

            return StudentsAccessor.GetAllStudents();
        }

        internal Models.StudentModel GetStudent(int StudentID)
        {

            return StudentsAccessor.GetAllStudents().Find(x => x.ID)
        }


    }
}
