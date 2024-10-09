using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using UserModel;

namespace UserApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserList list = new UserList();

            //Create 3 users, add them to a "list" of users, and save them to a file on disk called: "Users.txt"
            User user1 = new User();
            user1.RegisterAccount(list);

            User user2 = new User();
            user2.RegisterAccount(list);

            User user3 = new User();
            user3.RegisterAccount(list);

            //Log In and get Username of the account!
            User logIn = new User();
            logIn.LoadAccount();

            //Try to delete account.
            logIn.DeleteAccountFromFile();


            logIn.DisplayInfo();

            //Prevent console exit.
            Console.ReadKey();
        }
    }
}
