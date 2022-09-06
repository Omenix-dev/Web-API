using ECommerceApp.Core.Interface;
using ECommerceApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Infrastructure.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailsRepository
    {
        public OrderDetailRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
