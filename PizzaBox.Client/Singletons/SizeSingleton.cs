using System.Collections.Generic;

namespace PizzaBox.Client.Singletons
{
    /// <summary>
    /// 
    /// </summary>
    public class SizeSingleton
    {
        private static SizeSingleton _instance;

        public List<string> Size { get; set; }
        public static SizeSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SizeSingleton();
                }

                return _instance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private SizeSingleton()
        {
            Size = new List<string>()
      {
        "Small",
        "Medium",
        "Large"
      };
        }
    }
}