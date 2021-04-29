using System.Collections.Generic;


namespace MVCFront.Models
{
    public class CustomPizza 
    {
        public string Crust { get; set; }
        public byte CrustId { get; set; }
        public string Size { get; set; }
        public byte SizeId { get; set; }
        public List<Toppings> Toppings { get; set; }

        public string Name { get; set; }

        public decimal PizzaPrice { get; set; }

        public int PizzaId { get; set; }

        public int OrderId { get; set; }

    }
}