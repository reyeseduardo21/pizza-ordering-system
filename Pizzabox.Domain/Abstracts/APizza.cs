using System.Collections.Generic;
using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    /// <summary>
    /// 
    /// </summary>
    [XmlInclude(typeof(CheesePizza))]
    [XmlInclude(typeof(MeatPizza))]
    [XmlInclude(typeof(PepperoniPizza))]
    [XmlInclude(typeof(VeganPizza))]

    public abstract class APizza
    {
        //XmlIgnoreAttribute();
        public string Crust { get; set; }
        public string Size { get; set; }
        public string Toppings { get; set; }

        public string Name { get; set; }

        public decimal PizzaPrice { get; set; }

        protected APizza()
        {
            Factory();
        }

        private void Factory()
        {
            // Toppings = new List<Toppings>();

            // AddCrust();
            // AddSize();
            // AddToppings();
        }

        public virtual void AddCrust(string CrustType)
        {
            Crust = CrustType;
        }

        public virtual void AddSize()
        {
            Size = null;
        }

        public abstract void AddToppings();

        public abstract void addPrice();

        public override string ToString()
        {
            return $"{Name}";
        }

    }
}