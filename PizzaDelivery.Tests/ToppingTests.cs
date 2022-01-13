using PizzaDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PizzaDelivery.Tests
{
    public class ToppingTests
    {
        [Fact]
        public void InvalidTopping_Null_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Topping t = new Topping(null);
            });
            Assert.Equal("Cannot be empty. (Parameter 'toppingType')", exception.Message);
        }
        [Fact]
        public void InvalidTopping_Empty_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Topping t = new Topping("");
            });
            Assert.Equal("Cannot be empty. (Parameter 'toppingType')", exception.Message);
        }
        [Fact]
        public void InvalidTopping_White_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Topping t = new Topping("   ");
            });
            Assert.Equal("Cannot be empty. (Parameter 'toppingType')", exception.Message);
        }

        [Fact]
        public void InvalidTopping_WrongType_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Topping t = new Topping("Sausage");
            });
            Assert.Equal("Invalid Value (Parameter 'toppingType')", exception.Message);
        }

        [Fact]
        public void NormalTopping_ShouldInitialize()
        {
            Topping t = new Topping("Pepperoni");

            Assert.Equal("Pepperoni", t.ToppingType);
        }
    }
}

