using System;
using System.Collections.Generic;
using System.Linq;
using UserModel;
using System.IO;
using Newtonsoft.Json;
using AppLogging.Internal;
using AppLogging;

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

    public class JsonAccountObject
    {
        public User User { get; set; }
    }

    public class User
    {
        private ConsoleLogging ConsoleLogging { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool LoggedIn { get; set; }

        public void RegisterAccountToJSON(UserList list)
        {
            Console.WriteLine("REGISTER YOUR ACCOUNT:");
            Console.Write("Email: ");
            Email = Console.ReadLine();

            Console.Write("Password: ");
            Password = Console.ReadLine();

            Console.Write("Username: ");
            Username = Console.ReadLine();

            list.Users.Add(new User { Username = Username, Email = Email, Password = Password });

            SaveToJSONFile(Email, Password, Username);
            Console.WriteLine('\n');
        }

        private void SaveLogToDatabase(string message)
        {
            // Create a log model
            var log = new LogModel
            {
                Message = message,
                Level = (int)LogLevel.Info,
                Output = (int)LogOuput.Database
            };

            // Get the logging instance from the factory (will use DatabaseLogging by default)
            var logger = LogFactory.Instance;
            logger.Log(log);
        }

        public void Login()
        {
            Console.WriteLine("What is your Username?");
            Username = Console.ReadLine();

            JsonAccountObject account;
            while (!File.Exists(Username + ".json"))
            {
                string message = $"User `{Username}` not found! Search again:";
                Console.WriteLine(message);

                //(1) Log info cand apare exceptia: email gresit.
                SaveLogToDatabase(message);

                Username = Console.ReadLine();

            }

            account = JsonConvert.DeserializeObject<JsonAccountObject>(File.ReadAllText(Username + ".json"));
            Console.WriteLine("Username found!");
            Console.WriteLine("...");
            Console.WriteLine("But what's your Password?");

            Password = Console.ReadLine();
            while (Password != account.User.Password)
            {
                string message = $"WRONG Password! Try again.";
                Console.WriteLine(message);

                SaveLogToDatabase(message);

                Password = Console.ReadLine();
            }

            Console.WriteLine("Login Success!");
            Email = account.User.Email;


            Console.WriteLine($"Your email is: {Email}");

            LoggedIn = true;

            Console.WriteLine('\n');

        }


        public void DisplayInfo()
        {
            if (LoggedIn) Console.WriteLine(ToString());
        }


        public void SaveToJSONFile(string email, string password, string username)
        {
            var jsonOjectMenu = new JsonAccountObject()
            {
                User = new User
                {
                    Email = email,
                    Password = password,
                    Username = username,
                }
            };

            string jsonValues = JsonConvert.SerializeObject(jsonOjectMenu);
            File.AppendAllText("Users.txt", ToString() + "\n"); //fiecare user salvat pe o linie separata

            File.WriteAllText(Username + ".json", jsonValues);


            Console.WriteLine("Successfully registered account!");
        }

        public void DeleteAccountJsonFile()
        {
            if (LoggedIn)
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
            File.Delete(Username + ".json");

            LoggedIn = false;

            //Log out. Forget all details.
            Username = null;
            Password = null;
            Username = null;

            Console.WriteLine("Account Deletion success.");
        }
    }
}
