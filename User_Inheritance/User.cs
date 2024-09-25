using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Inheritance
{
    internal class User : User_Base
    {
        public User(string name, string surname, int age, string email, string password, UserRole userRole) : base(name, surname, age, email, password, userRole)
        {



        }
    }
}
