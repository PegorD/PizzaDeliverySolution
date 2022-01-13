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
    public class OrderItemTests
    {
        [Fact]
        public void InvalidOrderItem_AllNull_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                OrderItem o = new OrderItem(0, null, null);
            });
            Assert.Equal("Cannot be null. (Parameter 'pizza')", exception.Message);
        }
        [Fact]
        public void InvalidOrderItem_NullQuantity_ShouldThrowException()
        {
            List<Topping> toppings = new List<Topping>
            {
                new Topping("Beef"),
                new Topping("Chicken")
            };
            Crust c = new Crust("Thin Crust");
            Pizza p = new Pizza( toppings, c);
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                OrderItem o = new OrderItem(0, p, null);
            });
            Assert.Equal("Cannot be null. (Parameter 'quantity')", exception.Message);
        }
        [Fact]
        public void NormalOrderItem_ShouldInitialize()
        {
            List<Topping> toppings = new List<Topping>
            {
                new Topping("Beef"),
                new Topping("Chicken")
            };
            Crust c = new Crust("Thin Crust");
            Pizza p = new Pizza( toppings, c);
            Quantity q = new Quantity(5);
            OrderItem o = new OrderItem(0, p, q);

            Assert.Equal(0, o.OrderItemId);
            Assert.True(o.Pizza.Equals(p));
            Assert.True(o.Quantity.Equals(q));            
        }
    }
}
