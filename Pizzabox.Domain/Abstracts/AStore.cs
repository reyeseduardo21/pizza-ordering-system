using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    [XmlInclude(typeof(ChicagoStore))]
    [XmlInclude(typeof(NewYorkStore))]
    public abstract class AStore
    {
        //field
        //public string Name;
        public string Name { get; set; }

    }
}