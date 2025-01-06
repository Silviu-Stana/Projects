using System;
using System.Collections.Generic;

namespace ProductManagement.BusinessModel
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public override string ToString()
        {
            return this.CategoryName;
        }
    }
}
