using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Models
{
    [Owned]
    public class Pizza
    {      
        public Pizza(List<Topping> toppings, Crust crust):this()
        {
            if (toppings == null || toppings.Count == 0)
            {
                throw new ArgumentException("Cannot be empty", nameof(toppings));
            }

            Toppings = toppings;
            Crust = crust ?? throw new ArgumentException("Cannot be null", nameof(crust));
        }
        private Pizza()
        {

        }        

        public List<Topping> Toppings { get; private set; }
        public Crust Crust { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var pizza = (Pizza)obj;
            return Crust.Equals(pizza.Crust) && Toppings.All(pizza.Toppings.Contains) && Toppings.Count == pizza.Toppings.Count;
        }
    }
}
