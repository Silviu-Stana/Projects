using System;
using System.Collections.Generic;

namespace ProductManagement.BusinessModel
{
    public class ProductEvaluation
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Value { get; set; } //1 to 5
    }
}
