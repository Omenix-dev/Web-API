using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Core.DTO
{
    class OrderDetailsDTO
    {
        [Required]
        [DataType(DataType.Text)]
        public string Status { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public decimal price { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public int Quantity { get; set; }
    }
}
