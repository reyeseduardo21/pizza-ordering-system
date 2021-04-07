using System.Collections.Generic;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Singletons
{
    /// <summary>
    /// 
    /// </summary>
    public class CrustSingleton
    {
        private static CrustSingleton _instance;

        private static readonly FileRepository _fileRepository = new FileRepository();
        private const string _path = @"Crusts.xml";

        public List<string> Crust { get; set; }
        public static CrustSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CrustSingleton();
                }

                return _instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private CrustSingleton()
        {
            // Crust = new List<string>()
            // {
            //     "HandTossed",
            //     "DeepDish",
            //     "ThinCrust"
            // };

            // _fileRepository.WriteToCrustFile(Crust);
            Crust = _fileRepository.ReadFromFile<string>(_path);
        }
    }
}