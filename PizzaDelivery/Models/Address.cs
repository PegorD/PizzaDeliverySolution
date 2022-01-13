using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Models
{
    [Owned]
    public class Address
    {
        public Address(string streetAddress, string city, string province, PostalCode postalCode):this (streetAddress, city,province)
        {
            PostalCode = postalCode ?? throw new ArgumentException("Cannot be null.", nameof(postalCode));
        }

        private Address(string streetAddress, string city, string province)
        {
            if (string.IsNullOrWhiteSpace(streetAddress))
            {
                throw new ArgumentException("Cannot be empty.",nameof(streetAddress));
            }
            if (streetAddress.Length > 100)
            {
                throw new ArgumentException("Too Long.", nameof(streetAddress));
            }
            StreetAddress = streetAddress;

            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException("Cannot be empty.", nameof(city));
            }
            if (city.Length > 50)
            {
                throw new ArgumentException("Too Long.", nameof(city));
            }
            City = city;

            if (string.IsNullOrWhiteSpace(province))
            {
                throw new ArgumentException("Cannot be empty.", nameof(province));
            }
            if (province.Length > 50)
            {
                throw new ArgumentException("Too Long.", nameof(province));
            }
            Province = province;
        }

        public string StreetAddress { get; private set; }
        public string City { get; private set; }
        public string Province { get; private set; }
        public PostalCode PostalCode { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var address = (Address)obj;
            return StreetAddress == address.StreetAddress 
                && City==address.City 
                && Province==address.Province 
                && PostalCode.Equals(address.PostalCode);
        }
    }
}
