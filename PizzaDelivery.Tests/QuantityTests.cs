using PizzaDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PizzaDelivery.Tests
{
    public class QuantityTests
    {
        [Fact]
        public void NegativeQuantity_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Quantity q = new Quantity(-1);
            });
            Assert.Equal("Cannot be less than 1. (Parameter 'count')", exception.Message);
        }
        [Fact]
        public void TooLargeQuantity_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Quantity q = new Quantity(43);
            });
            Assert.Equal("Cannot be greater than 42. (Parameter 'count')", exception.Message);
        }
        [Fact]
        public void NormalQuantity_ShouldInitialize()
        {
            Quantity q = new Quantity(42);
            Assert.Equal(42, q.Count);
        }
    }
}
