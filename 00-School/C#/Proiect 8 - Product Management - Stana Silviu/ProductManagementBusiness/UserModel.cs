using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductManagement.BusinessModel
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
