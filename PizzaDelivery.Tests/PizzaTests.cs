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
    public class PizzaTests
    {
        [Fact]
        public void InvalidPizza_AllNull_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Pizza p = new Pizza(null,null);
            });
            Assert.Equal("Cannot be empty (Parameter 'toppings')", exception.Message);
        }

        [Fact]
        public void InvalidPizza_EmptyToppings_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Pizza p = new Pizza(new List<Topping>(), null);
            });
            Assert.Equal("Cannot be empty (Parameter 'toppings')", exception.Message);
        }
        [Fact]
        public void InvalidPizza_NullCrust_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Pizza p = new Pizza( new List<Topping> { new Topping("Beef")}, null);
            });
            Assert.Equal("Cannot be null (Parameter 'crust')", exception.Message);
        }
        [Fact]
        public void InvalidPizza_InvalidCrust_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Pizza p = new Pizza( new List<Topping> { new Topping("Beef") }, new Crust("Thick"));
            });
            Assert.Equal("Invalid Value (Parameter 'crustType')", exception.Message);
        }
        [Fact]
        public void InvalidPizza_InvalidToppings_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Pizza p = new Pizza( new List<Topping> { new Topping("Pineapple") }, null);
            });
            Assert.Equal("Invalid Value (Parameter 'toppingType')", exception.Message);
        }

        [Fact]
        public void NormalPizza_ShouldInitialize()
        {
            List<Topping> toppings = new List<Topping>
            {
                new Topping("Beef"),
                new Topping("Chicken")
            };
            Crust c = new Crust("Thin Crust");
            Pizza p = new Pizza( toppings,c);
            
            Assert.True(p.Toppings.Equals(toppings));
            Assert.True(p.Crust.Equals(c));
        }
    }
}
