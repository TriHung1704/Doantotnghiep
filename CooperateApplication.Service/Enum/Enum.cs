using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperateApplication.Service.Enum
{
    public class Enum
    {
        public enum EmployeeType
        {
            EmployeeHRM = 2,
            EmployeeMentor = 3
        }
        
        public enum PostTypeName
        {
            Recruitment = 1,
            Internship = 2,
            Seminar = 3,
        }

        public enum EmployeeLock
        {
            Lock = 1,
            UnLock = 2
        }
    }
}
