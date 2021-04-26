using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Size : AComponent
    {
        public Size()
        {
            Name = "null";
            Price = 0;
            Id = 0;
        }
    }
}