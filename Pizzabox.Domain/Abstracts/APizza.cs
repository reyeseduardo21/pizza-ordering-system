using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class APizza
    {
        public Crust Crust { get; set; }
        public string Size { get; set; }
        public List<Toppings> Toppings { get; set; }

        public Price PizzaPrice { get; set; }

        protected APizza()
        {
            Factory();
        }

        private void Factory()
        {
            Toppings = new List<Toppings>();

            AddCrust();
            AddSize();
            AddToppings();
        }

        public virtual void AddCrust()
        {
            Crust = new Crust();
        }

        public virtual void AddSize()
        {
            Size = null;
        }

        public abstract void AddToppings();

        public abstract void addPrice();

    }
}