using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Models
{
    [Owned]
    public class Topping
    {
        private readonly List<string> ValidToppings = new() { "Pepperoni", "Beef", "Chicken","Vegetables","Four Cheese" };
        public Topping(string toppingType)
        {            
            if (string.IsNullOrWhiteSpace(toppingType))
            {
                throw new ArgumentException("Cannot be empty.", nameof(toppingType));
            }
            if (!ValidToppings.Contains(toppingType))
            {
                throw new ArgumentException("Invalid Value", nameof(toppingType));
            }
            
            ToppingType = toppingType;
        }       
        public string ToppingType{ get; private set; }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var topping = (Topping)obj;
            return ToppingType == topping.ToppingType;
        }
    }
}
