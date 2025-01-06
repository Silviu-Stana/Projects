using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.BusinessModel
{
    public class PictureModel
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public ProductModel Product { get; set; }
    }
}
