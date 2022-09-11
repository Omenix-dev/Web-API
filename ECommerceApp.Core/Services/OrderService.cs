using AutoMapper;
using ECommerceApp.Core.DTO;
using ECommerceApp.Core.Interface;
using ECommerceApp.Domain.Enum;
using ECommerceApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool AddOrderAsync(List<OrderDetailsDTO> orderDetails, string userId)
        {
            try
            {
                List<OrderDetail> orderDetailsList = new List<OrderDetail>();
                foreach (var orderDetail in orderDetails)
                {
                    var orderDetailsModel = _mapper.Map<OrderDetail>(orderDetail);
                    orderDetailsList.Add(orderDetailsModel);
                }
                Order orders = new Order()
                {
                    UserId = userId,
                    OrderDetails = orderDetailsList
                };

                _unitOfWork.OrderRepository.InsertAsync(orders);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteOrderDetailsAsync(string orderDetailsId)
        {
            try
            {
                _unitOfWork.OrderRepository.DeleteAsync(orderDetailsId);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteOrderById(string orderId)
        {
            try
            {
                _unitOfWork.OrderRepository.DeleteAsync(orderId);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Order> GetOrdersByUserIdAsync(string UserId)
        {
            return _unitOfWork.OrderRepository.GetAllAsync().Where(order => order.UserId.Equals(UserId)).ToList();
        }
        public IQueryable<Order> GetAllSuccessfullOrderAsync(string UserId)
        {
            return _unitOfWork.OrderRepository.GetAllAsync().Where(order => order.UserId.Equals(UserId) && ((OrderStatus)order.Status).Equals((OrderStatus)4));
        }
    }
}
