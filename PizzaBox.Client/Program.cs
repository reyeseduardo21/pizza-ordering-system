using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using System.Collections.Generic;
using PizzaBox.Data.Entity;
using System.Linq;

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

        private static readonly CrustSingleton _crustSingleton = CrustSingleton.Instance;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            //IRepository repository = Dependencies.CreateRpository();

            Console.WriteLine("Getting list of pizzas and price");
            var PizzaList = getPizzaOrder();
            foreach (var order in PizzaList)
            {
                Console.WriteLine($"{order.Pizza} {order.Price}");
            }

            //Run();
        }

        static List<PizzaType> getPizzaOrder()
        {
            // this will create a session between db and the .net app
            PizzaBoxInformationContext context = new PizzaBoxInformationContext();
            var Pizza_order = context.PizzaTypes.ToList();
            return Pizza_order;

        }

        /// <summary>
        /// 
        /// </summary>
        private static void Run()
        {
            var order = new Order();
            bool AddMore = false;
            bool CorrectInput = false;
            var input = "";
            int PizzaCount = 0;



            Console.WriteLine("Welcome to PizzaBox");
            DisplayStoreMenu();

            order.Customer = new Customer();
            order.Store = SelectStore();
            order.ListOfPizzas = new List<APizza> { };
            order.ListOfSizes = new List<string> { };
            order.ListOfPrices = new List<double> { };
            order.ListOfCrusts = new List<string> { };
            order.Cost = 0;

            do
            {
                order.ListOfPizzas.Add(SelectPizza());
                order.ListOfCrusts.Add(SelectCrust());
                order.ListOfSizes.Add(SelectSize());




                //Console.WriteLine("Pizza and price saved");
                // foreach (APizza item in order.ListOfPizzas)
                // {
                //     Console.WriteLine($"{item}");
                // }

                // foreach (string item in order.ListOfSizes)
                // {
                //     Console.WriteLine($"{item}");
                // }

                // foreach (double item in order.ListOfPrices)
                // {
                //     Console.WriteLine($"{item}");
                // }

                //Console.WriteLine(order.Cost);

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

                PizzaCount += 1;
                if (PizzaCount == 50)
                {
                    Console.WriteLine("Order limit has been reached. You cannot place any more orders.");
                }

            } while (AddMore == false && PizzaCount != 50);

            order.Cost = CalculatePrice(order.ListOfPizzas, order.ListOfSizes, order.ListOfPrices);

            if (order.Cost > 250)
            {
                Console.WriteLine("The limit of price is greater than 250, removing the items that were added last until order is $250 or less");
                do
                {
                    order.ListOfPizzas.RemoveAt(order.ListOfPizzas.Count - 1);
                    order.Cost = CalculatePrice(order.ListOfPizzas, order.ListOfSizes, order.ListOfPrices);

                } while (order.Cost > 250);


            }

            //order.Cost = CalculatePrice(order.ListOfPizzas, order.ListOfSizes, order.ListOfPrices);


            DisplayOrder(order.ListOfPizzas, order.ListOfSizes, order.ListOfPrices, order.Cost, order.ListOfCrusts);


            order.Save();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void DisplayOrder(List<APizza> ListPizza, List<string> ListSize, List<double> ListPrice, double CurrentPrice, List<string> ListCrust)
        {
            Console.WriteLine("\nYour order is: ");
            int i = 0;
            foreach (APizza item in ListPizza)
            {
                Console.WriteLine($"\n{ListSize[i]} {ListCrust[i]} {item} for ${ListPrice[i]}");
                i++;

            }
            Console.WriteLine($"\nYour total is: ${CurrentPrice}");
        }

        private static void DisplayCrustTypes()
        {
            var index = 0;

            foreach (var item in _crustSingleton.Crust)
            {
                Console.WriteLine($"{++index} - {item}");
            }
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

            return pizza;
        }

        private static string SelectCrust()
        {
            DisplayCrustTypes();

            int input = 1;

            int LastIndex = _crustSingleton.Crust.Count;
            Boolean number = false;
            var CrustNumber = "null";

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
                            Console.WriteLine("Please enter the correct Crust number.");
                            DisplayPizzaMenu();
                            CrustNumber = Console.ReadLine();
                            input = int.Parse(CrustNumber);
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
                    Console.WriteLine("Please enter the correct crust number.", e);
                    DisplayPizzaMenu();
                    CrustNumber = Console.ReadLine();
                }

            } while (number == false);

            var crust = _crustSingleton.Crust[input - 1];

            return crust;
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
                            if (input <= LastIndex && input > 0)
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
            double CostPrice = 0;
            int i = 0;

            foreach (APizza item in ListPizza)
            {
                BasePrice = item.PizzaPrice;
                switch (ListSize[i])
                {
                    case "Small":
                        FinalPrice = BasePrice;
                        //Console.WriteLine(FinalPrice);
                        ListPrice.Add(FinalPrice);
                        break;
                    case "Medium":
                        FinalPrice = BasePrice + 3;
                        //Console.WriteLine(FinalPrice);
                        ListPrice.Add(FinalPrice);
                        break;
                    case "Large":
                        FinalPrice = BasePrice + 5;
                        //Console.WriteLine(FinalPrice);
                        ListPrice.Add(FinalPrice);
                        break;
                    default:
                        //Console.WriteLine("Default case");
                        FinalPrice = BasePrice;
                        break;
                }
                i++;
            }

            foreach (double price in ListPrice)
            {
                CostPrice += price;
            }

            return CostPrice;

        }
    }
}

