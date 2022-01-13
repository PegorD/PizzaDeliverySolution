using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDelivery.Models
{
    [Owned]
    public class PostalCode
    {
        public PostalCode(string code)
        {
            code = code.Trim();
            code = code.ToUpper();
            if (code.Length != 6)
            {
                throw new ArgumentException("Incorrect lenght", nameof(code));
            }
            if (!IsValidPostalCode(code))
            {
                throw new ArgumentException("Invalid Postal Code", nameof(code));
            }
                Code = code;
        }
        private static bool IsValidPostalCode(string postalCode)
        {
            return char.IsLetter(postalCode[0]) && char.IsDigit(postalCode[1]) && char.IsLetter(postalCode[2])
                && char.IsDigit(postalCode[3]) && char.IsLetter(postalCode[4]) && char.IsDigit(postalCode[5]);
        }
        public string Code { get; private set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false; 
            var postalCode = (PostalCode)obj;
            return Code==postalCode.Code;
        }
    }
}
