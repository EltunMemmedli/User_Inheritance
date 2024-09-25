using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Inheritance
{
    internal class Admin : User_Base
    {
        public Admin(string name, string surname, int age, string email, string password, UserRole userRole) : base(name, surname, age, email, password, userRole)  
        {
        }
    }
}
