using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace User_Inheritance
{
    internal class UserController
    {

        ArrayList Users;


        public UserController()
        {
            Users = new ArrayList();


        }

        public void AddUsers(User_Base user)
        {
            Users.Add(user);
        }


        public ArrayList GetUsers()
        {
            return Users;
        }


        public void SignIn(string email, string password)
        {
            bool matchFound = false;


            foreach (User_Base users in Users)
            {

                if (password == users.Password && email == users.Email)
                {
                    matchFound = true;
                    Console.WriteLine("Login successful.");


                    Console.WriteLine($"\nWelcome {users.Name}\n\n" +
                                      $"Your info:\n" +
                                      $"Name: {users.Name},\n" +
                                      $"Surname: {users.Surname},\n" +
                                      $"Age: {users.Age},\n" +
                                      $"Email: {users.Email},\n" +
                                      $"Role: {users.UserRole}");
                    break;
                }

            }


            if (!matchFound)
            {
                Console.WriteLine("Cannot find");
            }


        }

        public void AddNewUsers(string name,
                                    string surname,
                                    int age,
                                    string Email,
                                    string password,
                                    UserRole userRole)
        {
            User_Base newUser = new User_Base
                    (
                        name = name,
                        surname = surname,
                        age = age,
                        Email = Email,
                        password = password,
                        UserRole.User
                    );

            Users.Add(newUser);
        }


        public void DeleteUser(int ID)
        {
            Users.RemoveAt(ID);
            Console.Clear();
            Console.WriteLine("User has succesfully deleted!");
            bool valid = false;
            int counter = 1;
            foreach (User_Base notDeleted in Users)
            {

                if (notDeleted.UserRole == UserRole.User)
                {
                    valid = true;
                    Console.WriteLine($"\nUser's info:\n" +
                                          $"User ID: {counter++},\n" +
                                          $"Name: {notDeleted.Name},\n" +
                                          $"Surname: {notDeleted.Surname},\n" +
                                          $"Age: {notDeleted.Age},\n" +
                                          $"Email: {notDeleted.Email},\n" +
                                          $"Role: {notDeleted.UserRole}");
                }

            }
            if (valid)
            {
                return;
            }

        }

        public void UpdatedUser(int ID, string name, string surname, int age, string email, string password, UserRole userRole)
        {
            User_Base newUser = new User_Base
                 (
                     name = name,
                     surname = surname,
                     age = age,
                     email = email,
                     password = password,
                     UserRole.User
                 );

            Users[ID] = newUser;
            Console.Clear();
            Console.WriteLine("User has succesfully updated!");
            bool valid = false;
            int counter = 1;
            foreach (User_Base notDeleted in Users)
            {

                if (notDeleted.UserRole == UserRole.User)
                {
                    valid = true;
                    Console.WriteLine($"\nUser's info:\n" +
                                          $"User ID: {counter++},\n" +
                                          $"Name: {notDeleted.Name},\n" +
                                          $"Surname: {notDeleted.Surname},\n" +
                                          $"Age: {notDeleted.Age},\n" +
                                          $"Email: {notDeleted.Email},\n" +
                                          $"Role: {notDeleted.UserRole}");
                }

            }
            if (valid)
            {
                return;
            }

        }

        public void UpdateProfil(string password, int propertyID, string newProperty)
        {
            foreach (User_Base Property in Users)
            {
                if (password == Property.Password)
                {
                    User_Base NewUser = Property;

                    if (propertyID == 1) //Name
                    {
                        NewUser.Name = newProperty;
                    }
                    else if (propertyID == 2) //Surname
                    {
                        NewUser.Surname = newProperty;
                    }
                    else if (propertyID == 3) //Age
                    {


                        if (int.TryParse(newProperty, out int NewProperty) && NewProperty > 0)
                        {
                            NewUser.Age = int.Parse(newProperty);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Imvalid syntax!\n");
                            break;
                        }
                    }
                    else if (propertyID == 4) //Email
                    {
                        string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
                        Regex regex = new Regex(pattern);

                        bool valid = regex.IsMatch(newProperty);
                        if (!(string.IsNullOrEmpty(newProperty)) && valid)
                        {
                            NewUser.Email = newProperty;
                        }
                        else
                        {
                            Console.WriteLine("Invalid email!");
                        }
                    }
                    else if (propertyID == 5) //Password
                    {
                        if (!(string.IsNullOrEmpty(newProperty)))
                        {
                            NewUser.Password = newProperty;
                        }
                        else
                        {
                            Console.WriteLine("Invalid password!");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Can not find!");
                    }
                    NewUser = Property;
                }
            }
        }

        public void SignUp(string name,
                            string surname,
                            int age,
                            string email,
                            string password,
                            UserRole userrole)
        {
            User_Base newUser = new User_Base(name, surname, age, email, password, userrole);
            Users.Add(newUser);
            int counter = 1;
            Console.Clear();



            Console.WriteLine($"\nUser - ID: {counter++}" +
                                $"\nYour info:\n" +
                                $"Name: {newUser.Name},\n" +
                                $"Surname: {newUser.Surname},\n" +
                                $"Age: {newUser.Age},\n" +
                                $"Email: {newUser.Email},\n" +
                                $"Role: {newUser.UserRole}");


        }
    }
}
