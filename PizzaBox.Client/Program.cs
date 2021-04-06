using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using System.Collections.Generic;

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
            bool AddMore = false;
            bool CorrectInput = false;
            int OrderLimit = 250;
            var input = "";



            Console.WriteLine("Welcome to PizzaBox");
            DisplayStoreMenu();

            order.Customer = new Customer();
            order.Store = SelectStore();
            order.ListOfPizzas = new List<APizza> { };
            order.ListOfSizes = new List<string> { };
            order.ListOfPrices = new List<double> { };
            order.Cost = 0;

            do
            {
                order.ListOfPizzas.Add(SelectPizza());
                order.ListOfSizes.Add(SelectSize());
                order.Cost = CalculatePrice(order.ListOfPizzas, order.ListOfSizes, order.ListOfPrices);

                Console.WriteLine("Would you like to add more to this order? (Y/N)");
                input = Console.ReadLine();

                do
                {
                    if (input.ToLower() == "n" || input.ToLower() == "no" || input.ToLower() == "y" || input.ToLower() == "yes")
                    {
                        CorrectInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry, please type 'Yes' or 'No' ");
                        input = Console.ReadLine();
                        CorrectInput = false;
                    }


                } while (CorrectInput == false);

                if (input.ToLower() == "n" || input.ToLower() == "no")
                {
                    AddMore = true;
                }

            } while (AddMore == false || !(order.Cost <= OrderLimit));


            DisplayOrder(order.ListOfPizzas, order.ListOfSizes, order.ListOfPrices, order.Cost);


            order.Save();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void DisplayOrder(List<string> ListPizza, List<string> ListSize, List<double> ListPrice, double CurrentPrice)
        {
            Console.WriteLine("\nYour order is: ");
            foreach (string item in ListPizza)
            {
                Console.WriteLine($"\n{ListSize[ListSize.IndexOf(item)]} ");
                Console.Write($"{item} for ${ListPrice[ListSize.IndexOf(item)]}");

            }
            Console.WriteLine($"\nYour total is: {CurrentPrice}");
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
        private static string SelectPizza()
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
                        //check if within index
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
                //check if number was entered
                catch (Exception e)
                {
                    Console.WriteLine("Please enter the correct pizza number.", e);
                    DisplayPizzaMenu();
                    PizzaNumber = Console.ReadLine();
                }

            } while (number == false);

            var pizza = _pizzaSingleton.Pizzas[input - 1];

            pizza.addPrice();

            return pizza.ToString();
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

        private static double CalculatePrice(List<APizza> ListPizza, List<string> ListSize, List<double> ListPrice)
        {
            double BasePrice = 0;
            double FinalPrice = 0;

            foreach (APizza item in ListPizza)
            {
                BasePrice = item.PizzaPrice;
                switch (ListSize[ListPizza.IndexOf(item)])
                {
                    case "Small":
                        FinalPrice = BasePrice;
                        ListPrice.Add(FinalPrice);
                        break;
                    case "Medium":
                        FinalPrice = BasePrice + 3;
                        ListPrice.Add(FinalPrice);
                        break;
                    case "Large":
                        FinalPrice = BasePrice + 5;
                        ListPrice.Add(FinalPrice);
                        break;
                    default:
                        Console.WriteLine("Default case");
                        FinalPrice = BasePrice;
                        break;

                }
            }

            foreach (double Price in ListPrice)
            {
                FinalPrice += Price;
            }

            return FinalPrice;
        }

    }
}