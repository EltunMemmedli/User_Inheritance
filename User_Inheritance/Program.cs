using System.Collections;
using System.Text.RegularExpressions;
using User_Inheritance;

Admin Admin = new Admin("Eltun", "Memmedli", 18, "eltun.memmedli.06@gmail.com", "2006", UserRole.Admin);
User user_1 = new User("Cavid", "Memmedli", 15, "cavid.memmedli.09@gmail.com", "2009", UserRole.User);
User user_2 = new User("Ehmed", "Qurbanli", 25, "ehmed.qurbanli.99@gmail.com", "1999", UserRole.User);

UserController Users = new UserController();

Users.AddUsers(Admin);
Users.AddUsers(user_1);
Users.AddUsers(user_2);

Options:
Console.WriteLine($"Please, choose one:\n\n" +
                    $"1.Sign In,\n" +
                    $"2.Sign Up\n" +
                    $"===============");

string input = Console.ReadLine();
int choose;
Console.Clear();

if (int.TryParse(input, out choose) && choose > 0 && choose < 3)
{
    if (choose == 1)
    {
    email:
        string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
        Regex regex = new Regex(pattern);


        Console.WriteLine("Please, enter your email");
        string email = Console.ReadLine();
        Console.Clear();

        bool Ismatch = regex.IsMatch(email);

        if (!(string.IsNullOrEmpty(email)) && Ismatch)
        {
        password:
            Console.Write("Please, enter your password: ");
            string password = Console.ReadLine();
            Console.Clear();

            if (!(string.IsNullOrEmpty(password)))
            {
                Users.SignIn(email, password);

                ArrayList allUsers = Users.GetUsers();

                foreach (User_Base allUser in allUsers)
                {
                    if (password == allUser.Password && allUser.UserRole == UserRole.Admin)
                    {

                    Secim:
                        Console.WriteLine("\n\nSelect the option:\n" +
                                            "1.Add new user,\n" +
                                            "2.Delete user,\n" +
                                            "3.Update user,\n" +
                                            "4.Upadate profil\n" +
                                            "======================");

                        string Secim = Console.ReadLine();
                        int secim;

                        if (int.TryParse(Secim, out secim) && secim > 0 && secim < 5)
                        {
                            if (secim == 1)
                            {
                                Console.Clear();


                                Console.WriteLine("Write new user's name");
                                string name = Console.ReadLine();
                                Console.Clear();

                                Console.WriteLine("Write new user's surname");
                                string surname = Console.ReadLine();
                                Console.Clear();

                            age:
                                Console.Write("Write new user's age: ");
                                string age = Console.ReadLine();
                                int yas;

                                if (int.TryParse(age, out yas) && yas > 0)
                                {
                                    Console.Clear();

                                Email:
                                    Console.WriteLine("Write new user's email");
                                    string Email = Console.ReadLine();
                                    Console.Clear();
                                    bool IsMatch = regex.IsMatch(Email);

                                    if (!(string.IsNullOrEmpty(Email)) && IsMatch)
                                    {
                                    Password:
                                        Console.WriteLine("Write new user's password");
                                        string Password = Console.ReadLine();
                                        Console.Clear();

                                        if (!(string.IsNullOrEmpty(Password)))
                                        {
                                            Users.AddNewUsers(name, surname, yas, Email, password, UserRole.User);

                                            Console.WriteLine("User succesfully added!");

                                            int counter = 1;
                                            foreach (User_Base user in allUsers)
                                            {
                                                if (user.UserRole == UserRole.User)
                                                {
                                                    Console.WriteLine(
                                                                         $"\nUser's info:\n" +
                                                                         $"User ID: {counter++},\n" +
                                                                         $"Name: {user.Name},\n" +
                                                                         $"Surname: {user.Surname},\n" +
                                                                         $"Age: {user.Age},\n" +
                                                                         $"Email: {user.Email},\n" +
                                                                         $"Role: {user.UserRole}");
                                                }

                                            }
                                        Kec:
                                            Thread.Sleep(2000);
                                            Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                            string Kec = Console.ReadLine();

                                            if (Kec.ToLower() == "f")
                                            {
                                                Console.Clear();
                                                goto Secim;
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                                goto Kec;
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Write user's password!");
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                            goto Password;
                                        }

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Write user's email!");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        goto Email;
                                    }

                                }

                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Invalid syntax! Pleas, try again!");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    goto age;
                                }

                            }

                            else if (secim == 2)
                            {
                                Console.Clear();
                            Delete:
                                bool valid = false;
                                int counter = 1;
                                int say = allUsers.Count;
                                foreach (User_Base users in allUsers)
                                {

                                    if (users.UserRole == UserRole.User)
                                    {

                                        valid = true;
                                        Console.WriteLine(
                                                          $"\nUser's info:\n" +
                                                          $"User ID: {counter++},\n" +
                                                          $"Name: {users.Name},\n" +
                                                          $"Surname: {users.Surname},\n" +
                                                          $"Age: {users.Age},\n" +
                                                          $"Email: {users.Email},\n" +
                                                          $"Role: {users.UserRole}");
                                    }
                                }
                                if (valid)
                                {
                                    Console.Write("\n\nEnter the User ID: ");
                                    string UserID = Console.ReadLine();
                                    int Userid;

                                    if (int.TryParse(UserID, out Userid) && Userid > 0 && Userid < say + 1)
                                    {
                                        Users.DeleteUser(Userid);
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Invalid syntax!");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        goto Delete;
                                    }
                                }
                            Kec:
                                Thread.Sleep(2000);
                                Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                string Kec = Console.ReadLine();

                                if (Kec.ToLower() == "f")
                                {
                                    Console.Clear();
                                    goto Secim;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                    goto Kec;
                                }


                            }

                            else if (secim == 3)
                            {
                                Console.Clear();
                            Updated:
                                bool valid = false;
                                int counter = 1;
                                int say = allUsers.Count;
                                foreach (User_Base users in allUsers)
                                {

                                    if (users.UserRole == UserRole.User)
                                    {

                                        valid = true;
                                        Console.WriteLine(
                                                          $"\nUser's info:\n" +
                                                          $"User ID: {counter++},\n" +
                                                          $"Name: {users.Name},\n" +
                                                          $"Surname: {users.Surname},\n" +
                                                          $"Age: {users.Age},\n" +
                                                          $"Email: {users.Email},\n" +
                                                          $"Role: {users.UserRole}");
                                    }
                                }
                                if (valid)
                                {
                                    Console.Write("\n\nEnter the User ID: ");
                                    string UserID = Console.ReadLine();
                                    int Userid;

                                    if (int.TryParse(UserID, out Userid) && Userid > 0 && Userid < say + 1)
                                    {
                                        Console.Clear();
                                    Sifre:
                                        Console.Write("Enter the user's password: ");
                                        string OldPassword = Console.ReadLine();
                                        bool valid_1 = false;

                                        foreach (User_Base Password in allUsers)
                                        {
                                            if (Password.UserRole == UserRole.User && OldPassword == Password.Password)
                                            {
                                                valid_1 = true;
                                                break;
                                            }
                                        }

                                        if (valid_1)
                                        {
                                            valid_1 = true;
                                            Console.Clear();
                                            Console.WriteLine("Enter user's new name");
                                            string name = Console.ReadLine();
                                            Console.Clear();

                                            Console.WriteLine("Enter user's new surname");
                                            string surname = Console.ReadLine();
                                            Console.Clear();

                                        Age1:
                                            Console.WriteLine("Enter user's new age");
                                            string age = Console.ReadLine();
                                            int Age;

                                            if (int.TryParse(age, out Age) && Age > 0)
                                            {
                                                Console.Clear();
                                            Eamil1:
                                                Console.WriteLine("Enter user's new email");
                                                string Email = Console.ReadLine();
                                                bool ismatch = regex.IsMatch(Email);

                                                if (!(string.IsNullOrEmpty(Email)) && ismatch)
                                                {
                                                    Console.Clear();
                                                Password1:
                                                    Console.Write("Enter user's new password: ");
                                                    string Password1 = Console.ReadLine();

                                                    if (!(string.IsNullOrEmpty(Password1)))
                                                    {
                                                        Console.Clear();
                                                        Users.UpdatedUser(Userid, name, surname, Age, Email, Password1, UserRole.User);

                                                    Kec_1:
                                                        Thread.Sleep(2000);
                                                        Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                                        string Kec_1 = Console.ReadLine();

                                                        if (Kec_1.ToLower() == "f")
                                                        {
                                                            Console.Clear();
                                                            goto Secim;
                                                        }
                                                        else
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                                            goto Kec;
                                                        }


                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Console.WriteLine("Invalid syntax!");
                                                        Thread.Sleep(1000);
                                                        Console.Clear();
                                                        goto Password1;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Invalid syntax!");
                                                    Thread.Sleep(1000);
                                                    Console.Clear();
                                                    goto Eamil1;
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Invalid syntax!");
                                                Thread.Sleep(1000);
                                                Console.Clear();
                                                goto Age1;
                                            }
                                        }

                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Invalid syntax! Please try again.");
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                            goto Sifre;
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Invalid syntax!");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        goto Updated;
                                    }
                                }
                            Kec:
                                Thread.Sleep(2000);
                                Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                string Kec = Console.ReadLine();

                                if (Kec.ToLower() == "f")
                                {
                                    Console.Clear();
                                    goto Secim;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                    goto Kec;
                                }
                            }

                            else if (secim == 4)
                            {
                                Console.Clear();
                                Console.Write("Enter your password: ");
                                string UpdateProp = Console.ReadLine();

                                if (!(string.IsNullOrEmpty(UpdateProp)) && UpdateProp == allUser.Password)
                                {

                                    Console.Clear();
                                    bool matchFound = false;


                                    foreach (User_Base users in allUsers)
                                    {

                                        if (password == users.Password)
                                        {
                                            matchFound = true;

                                            Console.WriteLine(
                                                              $"Your info:\n" +
                                                              $"Name: {users.Name},\n" +
                                                              $"Surname: {users.Surname},\n" +
                                                              $"Age: {users.Age},\n" +
                                                              $"Email: {users.Email},\n" +
                                                              $"Password: {users.Password},\n" +
                                                              $"Role: {users.UserRole}");
                                            break;
                                        }

                                    }

                                    Console.Write("\nEnter the property ID: ");
                                    string OldPropertyID = Console.ReadLine();
                                    int OldProperty;

                                    if (int.TryParse(OldPropertyID, out OldProperty) && OldProperty < 6)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Enter new property");
                                        string newProperty = Console.ReadLine();
                                        Console.Clear();
                                        Users.UpdateProfil(UpdateProp, OldProperty, newProperty);
                                        bool matchFound1 = false;


                                        foreach (User_Base users in allUsers)
                                        {

                                            if (password == users.Password)
                                            {
                                                matchFound1 = true;

                                                Console.WriteLine(
                                                                  $"Your info:\n" +
                                                                  $"Name: {users.Name},\n" +
                                                                  $"Surname: {users.Surname},\n" +
                                                                  $"Age: {users.Age},\n" +
                                                                  $"Email: {users.Email},\n" +
                                                                  $"Password: {users.Password},\n" +
                                                                  $"Role: {users.UserRole}");
                                                break;
                                            }

                                        }
                                    }
                                }
                            Kec:
                                Thread.Sleep(2000);
                                Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                                string Kec = Console.ReadLine();

                                if (Kec.ToLower() == "f")
                                {
                                    Console.Clear();
                                    goto Secim;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                    goto Kec;
                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid syntax! Pleas, try again!");
                            Thread.Sleep(1000);
                            Console.Clear();
                            goto Secim;
                        }
                    }

                    else if (password == allUser.Password && allUser.UserRole == UserRole.User)
                    {

                    Option:
                        Console.WriteLine("\n\nSelect option:\n" +
                                             "1.Update profile\n" +
                                             "===================");
                        string secim = Console.ReadLine();
                        int Secim;

                        if (int.TryParse(secim, out Secim) && Secim > 0 && Secim < 2)
                        {
                            Console.Clear();
                            Console.Write("Enter your password: ");
                            string UpdateProp = Console.ReadLine();

                            if (!(string.IsNullOrEmpty(UpdateProp)) && UpdateProp == allUser.Password)
                            {

                                Console.Clear();
                                bool matchFound = false;


                                foreach (User_Base users in allUsers)
                                {

                                    if (password == users.Password)
                                    {
                                        matchFound = true;

                                        Console.WriteLine(
                                                          $"Your info:\n" +
                                                          $"Name: {users.Name},\n" +
                                                          $"Surname: {users.Surname},\n" +
                                                          $"Age: {users.Age},\n" +
                                                          $"Email: {users.Email},\n" +
                                                          $"Password: {users.Password},\n" +
                                                          $"Role: {users.UserRole}");
                                        break;
                                    }

                                }

                                Console.Write("\nEnter the property ID: ");
                                string OldPropertyID = Console.ReadLine();
                                int OldProperty;

                                if (int.TryParse(OldPropertyID, out OldProperty) && OldProperty < 6)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Enter new property");
                                    string newProperty = Console.ReadLine();
                                    Console.Clear();
                                    Users.UpdateProfil(UpdateProp, OldProperty, newProperty);
                                    bool matchFound1 = false;


                                    foreach (User_Base users in allUsers)
                                    {

                                        if (password == users.Password)
                                        {
                                            matchFound1 = true;

                                            Console.WriteLine(
                                                              $"Your info:\n" +
                                                              $"Name: {users.Name},\n" +
                                                              $"Surname: {users.Surname},\n" +
                                                              $"Age: {users.Age},\n" +
                                                              $"Email: {users.Email},\n" +
                                                              $"Password: {users.Password},\n" +
                                                              $"Role: {users.UserRole}");
                                            break;
                                        }

                                    }
                                }
                            }
                        Kec:
                            Thread.Sleep(2000);
                            Console.WriteLine("\nPress 'f' to return to the start or any other key to exit...");

                            string Kec = Console.ReadLine();

                            if (Kec.ToLower() == "f")
                            {
                                Console.Clear();
                                goto Option;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


                                goto Kec;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid syntax!");
                            Thread.Sleep(1000);
                            Console.Clear();
                            goto Option;
                        }
                    }
                    /*return;*/
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please write your password!");
                Thread.Sleep(1000);
                Console.Clear();
                goto password;

            }



        }
        else
        {
            Console.Clear();
            Console.WriteLine("Please write your email!");
            Thread.Sleep(1000);
            Console.Clear();
            goto email;

        }

    }

    else if (choose == 2)
    {
        Console.Clear();

        Console.WriteLine("Enter your name ");
        string name = Console.ReadLine();
        Console.Clear();

        Console.WriteLine("Enter your surname");
        string surname = Console.ReadLine();
        Console.Clear();
    Age:
        Console.WriteLine("Enter your age");
        string Age = Console.ReadLine();
        int age;

        if (int.TryParse(Age, out age) && age > 0)
        {
            Console.Clear();
        Email2:
            Console.WriteLine("Enter your email");
            string email = Console.ReadLine();

            string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            Regex regex = new Regex(pattern);

            bool IsMatch = regex.IsMatch(email);
            if (!(string.IsNullOrEmpty(email)) && IsMatch)
            {
                Console.Clear();
            Password2:
                Console.WriteLine("Enter your password");
                string password = Console.ReadLine();
                if (!(string.IsNullOrEmpty(password)))
                {
                    Users.SignUp(name, surname, age, email, password, UserRole.User);

                    ArrayList User = Users.GetUsers();
                    foreach(User_Base AllUser in User) 
                    {
                    Option:
                        Console.WriteLine("\n\nSelect option:\n" +
                                             "1.Update profile\n" +
                                             "===================");
                        string secim = Console.ReadLine();
                        int Secim;

                        if (int.TryParse(secim, out Secim) && Secim > 0 && Secim < 2)
                        {
                            Console.Clear();
                            password:
                            Console.Write("Enter your password: ");
                            string UpdateProp = Console.ReadLine();

                            if (!(string.IsNullOrEmpty(UpdateProp)) && UpdateProp == AllUser.Password)
                            {

                                Console.Clear();
                                bool matchFound = false;


                                foreach (User_Base users in User)
                                {

                                    if (password == users.Password)
                                    {
                                        matchFound = true;

                                        Console.WriteLine(
                                                          $"Your info:\n" +
                                                          $"Name: {users.Name},\n" +
                                                          $"Surname: {users.Surname},\n" +
                                                          $"Age: {users.Age},\n" +
                                                          $"Email: {users.Email},\n" +
                                                          $"Password: {users.Password},\n" +
                                                          $"Role: {users.UserRole}");
                                        break;
                                    }

                                }
                            PropID:
                                Console.Write("\nEnter the property ID: ");
                                string OldPropertyID = Console.ReadLine();
                                int OldProperty;

                                if (int.TryParse(OldPropertyID, out OldProperty) && OldProperty < 6)
                                {
                                    Console.Clear();
                                    
                                    Console.WriteLine("Enter new property");
                                    string newProperty = Console.ReadLine();
                                    Console.Clear();
                                    Users.UpdateProfil(UpdateProp, OldProperty, newProperty);
                                    bool matchFound1 = false;


                                    foreach (User_Base users in User)
                                    {

                                        if (password == users.Password)
                                        {
                                            matchFound1 = true;

                                            Console.WriteLine(
                                                              $"Your info:\n" +
                                                              $"Name: {users.Name},\n" +
                                                              $"Surname: {users.Surname},\n" +
                                                              $"Age: {users.Age},\n" +
                                                              $"Email: {users.Email},\n" +
                                                              $"Password: {users.Password},\n" +
                                                              $"Role: {users.UserRole}");
                                            break;
                                        }

                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Invalid ID!");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    goto PropID;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid password!");
                                Thread.Sleep(1000);
                                Console.Clear();
                                goto password;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid syntax!");
                            Thread.Sleep(1000);
                            Console.Clear();
                            goto Option;
                        }

                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid syntax!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    goto Password2;
                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid syntax!");
                Thread.Sleep(1000);
                Console.Clear();
                goto Email2;
            }


        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid syntax!");
            Thread.Sleep(1000);
            Console.Clear();
            goto Age;
        }
    }

}
else
{
    Console.Clear();
    Console.WriteLine("Invalid option! Please, try again.");
    Thread.Sleep(1000);
    Console.Clear();
    goto Options;
}