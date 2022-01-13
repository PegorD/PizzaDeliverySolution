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
    public class AddressTests
    {
        [Fact]
        public void InvalidAddress_AllNull_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Address a = new Address(null, null, null, null);
            });
            Assert.Equal("Cannot be empty. (Parameter 'streetAddress')", exception.Message);
        }

        [Fact]
        public void InvalidAddress_Empty_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Address a = new Address("", null, null, null);
            });
            Assert.Equal("Cannot be empty. (Parameter 'streetAddress')", exception.Message);
        }
        [Fact]
        public void InvalidAddress_WhiteSpace_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Address a = new Address(" ", null, null, null);
            });
            Assert.Equal("Cannot be empty. (Parameter 'streetAddress')", exception.Message);
        }

        [Fact]
        public void InvalidAddress_StreetNotNull_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Address a = new Address("Bloor", null, null, null);
            });
            Assert.Equal("Cannot be empty. (Parameter 'city')", exception.Message);
        }

        [Fact]
        public void InvalidAddress_StreetCityNotNull_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Address a = new Address("Bloor", "Toronto", null, null);
            });
            Assert.Equal("Cannot be empty. (Parameter 'province')", exception.Message);
        }
        [Fact]
        public void InvalidAddress_StreetCityProvinceNotNull_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Address a = new Address("Bloor", "Toronto", "Ontario", null);
            });
            Assert.Equal("Cannot be null. (Parameter 'postalCode')", exception.Message);
        }

        [Fact]
        public void NormalAddress_ShouldInitialize()
        {
            PostalCode p = new PostalCode("A1B1F5");
            Address a = new Address("Bloor", "Toronto", "Ontario", p);
            Assert.Equal("Bloor", a.StreetAddress);
            Assert.Equal("Toronto", a.City);
            Assert.Equal("Ontario", a.Province);
            Assert.True(p.Equals(a.PostalCode));            
        }

        [Fact]
        public void InvalidAddress_LongStreet_ShouldThrowException()
        {
            PostalCode p = new PostalCode("A1B1F5");
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Address a = new Address(new string('A',101), "Toronto", "Ontario", p);
            });
            Assert.Equal("Too Long. (Parameter 'streetAddress')", exception.Message);
        }

        [Fact]
        public void InvalidAddress_LongCity_ShouldThrowException()
        {
            PostalCode p = new PostalCode("A1B1F5");
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Address a = new Address("Bloor", new string('A', 51), "Ontario", p);
            });
            Assert.Equal("Too Long. (Parameter 'city')", exception.Message);
        }
        [Fact]
        public void InvalidAddress_LongProvince_ShouldThrowException()
        {
            PostalCode p = new PostalCode("A1B1F5");
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Address a = new Address("Bloor", "Toronto", new string('A', 51), p);
            });
            Assert.Equal("Too Long. (Parameter 'province')", exception.Message);
        }

        [Fact]
        public void InvalidAddress_InvalidPostalCode_ShouldThrowException()
        {            
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                Address a = new Address("Bloor", "Toronto", "Ontario", new PostalCode("A1B1F5g"));
            });
            Assert.Equal("Incorrect lenght (Parameter 'code')", exception.Message);
        }
    }
}
