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
        public Size Size { get; set; }
        public List<Toppings> Toppings { get; set; }

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
            Size = new Size();
        }

        public abstract void AddToppings();
    }
}