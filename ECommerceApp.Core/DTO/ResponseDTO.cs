using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Core.DTO
{
    class ResponseDTO
    {
        [Required]
        [DataType(DataType.Text)]
        public string StatusCode { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Status { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Data { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Error { get; set; }
        
    }
}
