using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;

namespace PizzaBox.Client
{
    /// <summary>
    /// 
    /// </summary>
    internal class Program
    {
        private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
        private static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;

        private static readonly SizeSingleton _sizeSingleton = SizeSingleton.Instance;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            Run();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void Run()
        {
            var order = new Order();

            Console.WriteLine("Welcome to PizzaBox");
            DisplayStoreMenu();

            order.Customer = new Customer();
            order.Store = SelectStore();
            order.Pizza = SelectPizza();
            order.Pizza.Size = SelectSize();
            order.Pizza.PizzaPrice = CalculatePrice(order.Pizza, order.Pizza.Size);


            DisplayOrder(order.Pizza, order.Pizza.Size, order.Pizza.PizzaPrice);


            order.Save();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void DisplayOrder(APizza pizza, string size, double CurrentPrice)
        {
            Console.WriteLine($"Your order is: {size} {pizza} and the total is {CurrentPrice}");
        }

        /// <summary>
        /// 
        /// </summary>
        private static void DisplayPizzaMenu()
        {
            var index = 0;

            foreach (var item in _pizzaSingleton.Pizzas)
            {
                Console.WriteLine($"{++index} - {item}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void DisplayStoreMenu()
        {
            var index = 0;

            foreach (var item in _storeSingleton.Stores)
            {
                Console.WriteLine($"{++index} - {item}");
            }
        }

        private static void DisplayPizzaSize()
        {
            var index = 0;

            foreach (var item in _sizeSingleton.Size)
            {
                Console.WriteLine($"{++index} - {item}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static AStore SelectStore()
        {
            Boolean number = false;
            var PizzaStoreNumber = Console.ReadLine();
            int input = 2;
            int LastIndex = _storeSingleton.Stores.Count;
            do
            {
                try
                {
                    input = int.Parse(PizzaStoreNumber); // be careful (think execpetion/error handling)
                    do
                    {
                        if (input <= LastIndex)
                        {
                            number = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter the number of the store.");
                            PizzaStoreNumber = Console.ReadLine();
                            input = int.Parse(PizzaStoreNumber);
                            if (input <= LastIndex)
                            {
                                number = true;
                            }
                            number = false;
                        }
                    } while (number == false);


                }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter the number of the store.", e);
                    PizzaStoreNumber = Console.ReadLine();
                }

            } while (number == false);




            return _storeSingleton.Stores[input - 1];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static APizza SelectPizza()
        {
            DisplayPizzaMenu();

            int input = 1;

            int LastIndex = _pizzaSingleton.Pizzas.Count;
            Boolean number = false;
            var PizzaNumber = "null";

            do
            {
                try
                {
                    input = int.Parse(Console.ReadLine()); // be careful (think execpetion/error handling)
                    do
                    {
                        if (input <= LastIndex)
                        {
                            number = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter the correct pizza number.");
                            DisplayPizzaMenu();
                            PizzaNumber = Console.ReadLine();
                            input = int.Parse(PizzaNumber);
                            if (input <= LastIndex)
                            {
                                number = true;
                            }
                            number = false;
                        }
                    } while (number == false);


                }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter the correct pizza number.", e);
                    DisplayPizzaMenu();
                    PizzaNumber = Console.ReadLine();
                }

            } while (number == false);

            var pizza = _pizzaSingleton.Pizzas[input - 1];

            pizza.addPrice();

            return pizza;
        }

        private static string SelectSize()
        {
            DisplayPizzaSize();
            int input = 1;

            int LastIndex = _sizeSingleton.Size.Count;
            Boolean number = false;
            var SizeNumber = "null";

            do
            {
                try
                {
                    input = int.Parse(Console.ReadLine()); // be careful (think execpetion/error handling)
                    do
                    {
                        if (input <= LastIndex)
                        {
                            number = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter the correct size number.");
                            DisplayPizzaSize();
                            SizeNumber = Console.ReadLine();
                            input = int.Parse(SizeNumber);
                            if (input <= LastIndex)
                            {
                                number = true;
                            }
                            number = false;
                        }
                    } while (number == false);


                }
                catch (Exception e)
                {
                    Console.WriteLine("Please enter the correct size number.", e);
                    DisplayPizzaSize();
                    SizeNumber = Console.ReadLine();
                }

            } while (number == false);



            var size = _sizeSingleton.Size[input - 1];


            return size;

        }

        private static double CalculatePrice(APizza pizza, string size)
        {
            double BasePrice = pizza.PizzaPrice;
            double FinalPrice;
            switch (size)
            {
                case "Small":
                    FinalPrice = BasePrice;
                    break;
                case "Medium":
                    FinalPrice = BasePrice + 3;
                    break;
                case "Large":
                    FinalPrice = BasePrice + 5;
                    break;
                default:
                    Console.WriteLine("Default case");
                    FinalPrice = 5.99;
                    break;

            }

            return FinalPrice;
        }

    }
}