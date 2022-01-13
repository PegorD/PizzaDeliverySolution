using PizzaDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PizzaDelivery.Tests
{
    public class CrustTests
    {
        [Fact]
        public void InvalidCrust_Null_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Crust c = new Crust(null);
            });
            Assert.Equal("Cannot be empty. (Parameter 'crustType')", exception.Message);
        }
        [Fact]
        public void InvalidCrust_Empty_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Crust c = new Crust("");
            });
            Assert.Equal("Cannot be empty. (Parameter 'crustType')", exception.Message);
        }
        [Fact]
        public void InvalidCrust_White_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Crust c = new Crust("  ");
            });
            Assert.Equal("Cannot be empty. (Parameter 'crustType')", exception.Message);
        }

        [Fact]
        public void InvalidCrust_WrongType_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Crust c = new Crust("Extra Thick");
            });
            Assert.Equal("Invalid Value (Parameter 'crustType')", exception.Message);
        }

        [Fact]
        public void NormalCrust_ShouldInitialize()
        {
            Crust c = new Crust("Normal");

            Assert.Equal("Normal", c.CrustType);
        }
    }
}
