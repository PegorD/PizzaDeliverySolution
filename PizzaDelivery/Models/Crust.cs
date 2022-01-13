using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Models
{
    [Owned]
    public class Crust
    {
        private readonly List<string> ValidCrusts = new() { "Normal", "Thin Crust", "Cheese Stuffed" };
        public Crust(string crustType)
        {
            //CrustId = crustId;
            if (string.IsNullOrWhiteSpace(crustType))
            {
                throw new ArgumentException("Cannot be empty.", nameof(crustType));
            }
            if (!ValidCrusts.Contains(crustType))
            {
                throw new ArgumentException("Invalid Value", nameof(crustType));
            }
            CrustType = crustType;
        }
       
        public string CrustType { get; private set; }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var crust = (Crust)obj;
            return CrustType == crust.CrustType;
        }
    }
}
