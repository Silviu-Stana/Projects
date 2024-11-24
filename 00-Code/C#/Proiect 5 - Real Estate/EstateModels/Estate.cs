using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateModels
{
    public enum EstateType
    {
        Apartment = 1, House = 2, Land = 3, Office = 4
    }

    //obtinem repository din app config
    public class Estate
    {
        [ColumnName("EstateId")]
        public int Id { get; set; } //cheia primara in tabelul Estate (auto-generata)
        public string Name { get; set; }
        public string Address { get; set; }
        //No OwnerId, e de preferat o relatie de MANY-TO-MANY intre Estate si Owner. (care o vem avea deja cu tabelul EstateOwner)
        //Deci nu mai are sens sa avem un OwnerId aici.
        public double Price { get; set; }
        public int Type { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Picture> Pictures { get; set; } //lista de poze atasata proprietatii

        public Estate()
        {
            Pictures = new List<Picture>();
        }
    }
}
