using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Models
{
    public class OrderItem
    {
        public OrderItem(int orderItemId,Pizza pizza,Quantity quantity) : this(orderItemId)
        {
            Pizza=pizza ?? throw new ArgumentException("Cannot be null.", nameof(pizza));
            Quantity=quantity?? throw new ArgumentException("Cannot be null.", nameof(quantity));
        }
        private OrderItem(int orderItemId)
        {
            OrderItemId = orderItemId;
        }

        public int OrderItemId { get; private set; }
        public Pizza Pizza { get; private set; }
        public Quantity Quantity { get; private set; }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var orderItem = (OrderItem)obj;
            return OrderItemId==orderItem.OrderItemId 
                && Pizza.Equals(orderItem.Pizza)  
                && Quantity.Equals(orderItem.Quantity);
        }
    }
}
