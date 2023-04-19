using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperateApplication.Repositories.Enums
{
    public class CooperateEnums
    {
        public enum PostTypeName
        {
            Recruitment = 1,
            Internship = 2,
            Seminar = 3,
        }
        
        public enum UserTypeName
        {
            SAdmin = 0,
            Employee = 1,
            Student = 2,
            Lecturers = 3
        }
    }
}
