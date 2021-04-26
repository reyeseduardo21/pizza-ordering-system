using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Crust : AComponent
    {


        public Crust()
        {
            Name = "null";
            Price = 0;
            Id = 0;
        }
    }
}