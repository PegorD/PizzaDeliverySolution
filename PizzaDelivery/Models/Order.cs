using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Models
{
    public class Order
    {
        public Order(int orderId, Address address, List<OrderItem> orderItems):this(orderId)
        {
            Address = address ?? throw new ArgumentException("Cannot be null.",nameof(address));
            if (orderItems == null || orderItems.Count == 0)
            {
                throw new ArgumentException("Cannot be empty", nameof(orderItems));
            }
            OrderItems = orderItems;

        }
        private Order(int orderId)
        {           
            this.OrderId = orderId;
        }        
       
        public int OrderId { get; private set; }
        public Address Address { get; private set; }
        public List<OrderItem> OrderItems { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var order = (Order)obj;
            return OrderId == order.OrderId
                && Address.Equals(order.Address)
                && OrderItems.All(order.OrderItems.Contains)&& OrderItems.Count==order.OrderItems.Count;
        }

    }
}
