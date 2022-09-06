using ECommerceApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Core.Utilities
{
    public class ProductResponse
    {
        public IQueryable<Product> Products{get; set; }
        public int Pages { get; set; }  
        public int CurrentPage { get; set; }
    }
}
