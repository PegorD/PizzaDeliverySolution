using PizzaDelivery.Models;
using System;
using Xunit;

namespace PizzaDelivery.Tests
{
    public class PostalCodeTests
    {
        [Fact]
        public void InvalidCode_ShortCode_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
              {
                  PostalCode p = new PostalCode("1");
              });
            Assert.Equal("Incorrect lenght (Parameter 'code')", exception.Message);
        }
        [Fact]
        public void InvalidCode_LongCode_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                PostalCode p = new PostalCode("1234567");
            });
            Assert.Equal("Incorrect lenght (Parameter 'code')", exception.Message);
        }
        [Fact]
        public void InvalidCode_AllNumeric_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                PostalCode p = new PostalCode("123456");
            });
            Assert.Equal("Invalid Postal Code (Parameter 'code')", exception.Message);
        }

        [Fact]
        public void InvalidCode_AllCharacters_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                PostalCode p = new PostalCode("ABCDEF");
            });
            Assert.Equal("Invalid Postal Code (Parameter 'code')", exception.Message);
        }
        [Fact]
        public void InvalidCode_IncludeSymbol_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                PostalCode p = new PostalCode("AB-DEF");
            });
            Assert.Equal("Invalid Postal Code (Parameter 'code')", exception.Message);
        }

        [Fact]
        public void InvalidCode_NegativeNumber_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                PostalCode p = new PostalCode("A-1B1F5");
            });
            Assert.Equal("Incorrect lenght (Parameter 'code')", exception.Message);
        }

        [Fact]
        public void LowercaseCode_ShouldInitialize()
        {
            PostalCode p = new PostalCode("a1b1f5");

            Assert.Equal("A1B1F5", p.Code);
        }

        [Fact]
        public void MixedcaseCode_ShouldInitialize()
        {
            PostalCode p = new PostalCode("a1B1F5");

            Assert.Equal("A1B1F5", p.Code);
        }

        [Fact]
        public void NormalCode_ShouldInitialize()
        {
            PostalCode p = new PostalCode("A1B1F5");

            Assert.Equal("A1B1F5", p.Code);
        }
    }
}
