using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateModels
{
    public class Picture
    {
        public int Id { get; set; } //cheia primara in tabel (auto-generata)
        public string Name { get; set; } //numele fisierului cu tot cu extensie: picture2.jpg
        public DateTime CreateDate { get; set; }
        public long Size { get; set; } //dimensiunea fisierului pe disk
    }
}
