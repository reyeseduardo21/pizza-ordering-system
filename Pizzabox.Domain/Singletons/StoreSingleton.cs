using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Singletons
{
    public class StoreSingleton
    {
        private static StoreSingleton _instance;

        public static List<AStore> Stores { get; set; } = new List<AStore>()
            {
                new NewYorkStore(),
                new ChicagoStore()
            };

        //public static StoreSingleton Instance

        private StoreSingleton()
        {
            Stores = new List<AStore>
                {
                    new NewYorkStore(),
                    new ChicagoStore()
                };
        }

        public void WriteToFile()
        {
            // access to path
            string path = @"store.xml"; //@ causes it to be read as a literal string
            // open file
            StreamWriter writer = new StreamWriter(path);
            // access to object
            var stores = Stores;
            // Class definition (structure)
            XmlSerializer xml = new XmlSerializer(typeof(List<AStore>));
            // serialize (convert to markup) to xml
            xml.Serialize(writer, stores);
            //write to file
            // close file

        }

        public static StoreSingleton Instance()
        {
            if (_instance == null)
            {
                _instance = new StoreSingleton();
            }

            return _instance;
        }
    }
}