using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using UserModel;
using System.IO;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics;

namespace UserModel
{
    public class UserList //(colectie de obiecte de tip User)
    {
        public List<User> Users { get; set; }

        public UserList()
        {
            Users = new List<User>();
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Email{ get; set; }
        public string Password{ get; set; }
        public bool LoggedIn{ get; set; }

        /*
        public override bool Equals(object obj)
        {
            if(obj is User) return false;

            User user = obj as User;

            return user.Username==Username && user.Email==Email && user.Password==Password;
        }
        */


        public void RegisterAccount(UserList list)
        {
            Console.WriteLine("REGISTER YOUR ACCOUNT:");
            Console.Write("Email: ");
            Email = Console.ReadLine();

            Console.Write("Password: ");
            Password = Console.ReadLine();

            Console.Write("Username: ");
            Username = Console.ReadLine();

            list.Users.Add(new User { Username = Username, Email = Email, Password = Password });

            SaveToFile();
            Console.WriteLine('\n');
        }

        public void LoadAccount()
        {
            Console.WriteLine("What is your Email?");
            Email= Console.ReadLine();

            //If we found it:
            if (SearchFileForEmail(Email) != null)
            {
                Console.WriteLine("Email found!");
                Console.WriteLine("...");
                Console.WriteLine("But what's your Password?");
                string[] info = SearchFileForEmail(Email).Split(',');

                Password = Console.ReadLine();
                while (Password != info[1])
                {
                    Console.WriteLine("WRONG Password. Try again.");
                    Password= Console.ReadLine();
                }

                Console.WriteLine("Login Success!");
                Username = info[2];
                Console.WriteLine($"Your username is: {Username}");

                LoggedIn = true;
            }
            else Console.WriteLine("Email not found!");

            Console.WriteLine('\n');
        }


            //Find if Email exists:
        public string SearchFileForEmail(string email)
        {
            int lineNumber=0;

            foreach (var line in File.ReadLines("Users.txt"))
            {
                lineNumber++;

                //Email found
                if (line.Contains(Email)) return line;
            }

            //Email not found in the file.
            return null;
        }

        public int SearchForLineInSaveFile(string email)
        {
            int lineNumber = 0;

            foreach (var line in File.ReadLines("Users.txt"))
            {
                lineNumber++;

                //Email found
                if (line.Contains(Email)) return lineNumber;
            }

            //Email not found in the file.
            return -1;
        }

        public void DisplayInfo()
        {
            if(LoggedIn) Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{Email},{Password},{Username}";
        }

        public void SaveToFile()
        {
            File.AppendAllText("Users.txt", ToString() + "\n"); //fiecare user salvat pe o linie separata
        }

        public void DeleteAccountFromFile()
        {
            if(LoggedIn)
            {
                Console.WriteLine("Are you sure you want to delete your account?");
                Console.WriteLine("Press 'Y' for yes or 'N' for no.");

                //Read keys until you press Y or N.
                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // 'true' to not show the key pressed
                while (keyInfo.Key != ConsoleKey.Y && keyInfo.Key != ConsoleKey.N)
                {
                    Console.WriteLine("Invalid key. Press 'Y' for yes or 'N' for no.");
                    keyInfo = Console.ReadKey(true); // Read again
                }

                if (keyInfo.Key == ConsoleKey.Y)
                {
                    ConfirmDeleteAccount();
                }
                else
                {
                    Console.WriteLine("Account Deletion has been cancelled.");
                }
            }
        }
        void ConfirmDeleteAccount()
        {
            int lineIndex = SearchForLineInSaveFile(Email);

            List<string> lines = File.ReadAllLines("Users.txt").ToList();

            //Remove that specific line.
            lines.RemoveAt(lineIndex);

            LoggedIn = false;

            //Log out. Forget all details.
            Username = null;
            Password = null;
            Username = null;

            Console.WriteLine("Account Deletion success.");
        }
    }
}
