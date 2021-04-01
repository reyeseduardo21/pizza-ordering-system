using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Size : AComponent
    {
        public static implicit operator Size(string v)
        {
            throw new NotImplementedException();
        }
    }
}