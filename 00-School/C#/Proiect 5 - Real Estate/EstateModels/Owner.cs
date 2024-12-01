using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateModels
{
    public class Owner
    {
        public int Id { get; set; } //cheia primara din tabel (auto-generata)
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cnp { get; set; }
    }
}
