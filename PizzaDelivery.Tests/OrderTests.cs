using FluentAssertions;
using PizzaDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PizzaDelivery.Tests
{
    public class OrderTests
    {
        [Fact]
        public void InvalidOrder_AllNull_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Order o = new Order(0, null, null);
            });
            Assert.Equal("Cannot be null. (Parameter 'address')", exception.Message);
        }
        [Fact]
        public void InvalidOrder_NullOrderItem_ShouldThrowException()
        {
            PostalCode p = new PostalCode("A1B1F5");
            Address a = new Address("Bloor", "Toronto", "Ontario", p);
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Order o = new Order(0, a, null);
            });
            Assert.Equal("Cannot be empty (Parameter 'orderItems')", exception.Message);
        }
        [Fact]
        public void NormalOrder_ShouldInitialize()
        {
            PostalCode pp = new PostalCode("A1B1F5");
            Address a = new Address("Bloor", "Toronto", "Ontario", pp);
            List<Topping> toppings = new List<Topping>
            {
                new Topping("Beef"),
                new Topping("Chicken")
            };
            Crust c = new Crust("Thin Crust");
            Pizza p = new Pizza( toppings, c);
            Quantity q = new Quantity(5);            
            List<OrderItem> orderItems = new List<OrderItem> {
                new OrderItem(0,p,q),
                new OrderItem(1,p,q)
            };
            Order o = new Order(0, a, orderItems);
            Assert.Equal(0, o.OrderId);
            Assert.True(o.OrderItems.Equals(orderItems));
            Assert.True(o.Address.Equals(a));            
        }
    }
}
