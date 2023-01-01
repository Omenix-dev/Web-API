﻿using ECommerceApp.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApp.Domain.Model
{
    public class Order : BaseEntity
    {
        public OrderStatus Status { get; set; } = OrderStatus.Processing;
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string UserId { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
