using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductManagement.BusinessModel
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public DateTime FabricationDate { get; set; }
        public List<PictureModel> Pictures { get; set; } = new List<PictureModel>();
        public bool IsDisabled { get; set; }
    }
}
