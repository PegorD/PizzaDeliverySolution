using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Models
{
    [Owned]
    public class Quantity
    {
        public Quantity(int count)
        {
            if (count < 1)
            {
                throw new ArgumentException("Cannot be less than 1.", nameof(count));
            }
            if (count > 42)
            {
                throw new ArgumentException("Cannot be greater than 42.", nameof(count));
            }
            Count = count;
        }

        public int Count { get; private set; }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var quantity = (Quantity)obj;
            return Count == quantity.Count;
        }
    }
}
