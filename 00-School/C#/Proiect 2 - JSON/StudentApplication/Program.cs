using System;
using System.Linq;
using System.Text;
using UserModel;

namespace UserApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserList list = new UserList();

            //Create 1 user, add them to a "list" of users, and save them to a file on disk called: "Users.txt"
            User user1 = new User();
            user1.RegisterAccountToJSON(list);

            //Log In and get Username of the account!
            User logIn = new User();
            logIn.Login();

            //Try to delete account.
            logIn.DeleteAccountJsonFile();


            logIn.DisplayInfo();

            //Prevent console exit.
            Console.ReadKey();
        }
    }
}
