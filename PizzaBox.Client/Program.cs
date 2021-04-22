using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using System.Collections.Generic;
using PizzaBox.Data.Entity;
using System.Linq;
using PizzaBox.Data;
using Microsoft.EntityFrameworkCore;

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

            Run();
        }



        /// <summary>
        /// 
        /// </summary>
        private static void Run()
        {


            IRepository repository = Dependencies.CreateRepository();
            MCustomer CurrentCustomer;
            MOrder PizzaOrder = new MOrder();
            Console.WriteLine("Welcome to PizzaBox!");

            Console.WriteLine("Are you a new or returning customer?\n1 - New customer (create new login)\n2 - Returning (sign in)\n3 - Sign in as Guest");
            var LoginInput = Console.ReadLine();
            if (Int32.Parse(LoginInput) == 1)
            {
                CurrentCustomer = CreateNewCustomer();
                var customers = repository.GetCustomers();
                int TotalCustomers = customers.Count();
                CurrentCustomer.CustomerID = TotalCustomers;
                repository.AddCustomer(CurrentCustomer);
                Console.WriteLine("You're account has successfully been created!");
                //AddCustomer(repository, CurrentCustomer);

            }
            else if (Int32.Parse(LoginInput) == 2)
            {

                PizzaOrder.Customer.username = UserLogin();
            }
            else
            {
                CurrentCustomer = GuestLogin();
            }




            Console.WriteLine($"{PizzaOrder.Customer.username} is logged in!");

            SelectStore(PizzaOrder);
            SelectPizza(PizzaOrder);
            DisplayOrder(PizzaOrder);

            int orderCount = repository.GetOrderCount();

            PizzaOrder.OrderID = orderCount + 1;

            repository.AddOrder(PizzaOrder);


        }

        public static MCustomer GuestLogin()
        {
            bool check = false;
            Console.WriteLine("Enter your address, city, state (seperated by a comma)");
            var TempAddress = Console.ReadLine();
            Console.WriteLine("Enter your credit card number: ");
            var TempCardNumber = Console.ReadLine();
            decimal TempCard = 5555555555555555;
            do
            {
                check = false;
                try
                {
                    TempCard = decimal.Parse(TempCardNumber);
                    if (TempCardNumber.Length == 15 || TempCardNumber.Length == 16)
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;
                    }

                }
                catch
                {
                    Console.WriteLine("Invalid credit card number. Try again: ");
                    Console.WriteLine("Enter your credit card number: ");
                    TempCardNumber = Console.ReadLine();
                }

            } while (check == false);

            Console.WriteLine("Enter the experation date (MMYY)");
            var TempExpDate = Console.ReadLine();
            Console.WriteLine("Enter the security code: ");
            short TempExp = 0294;
            do
            {
                check = false;
                try
                {
                    TempExp = short.Parse(TempExpDate);
                    check = true;
                }
                catch
                {
                    Console.WriteLine("Invalid security number. Try again: ");
                    Console.WriteLine("Enter your credit card's security number: ");
                    TempExpDate = Console.ReadLine();
                }

            } while (check == false);
            var TempCvv = Console.ReadLine();
            short TempCode = 123;
            do
            {
                check = false;
                try
                {
                    TempCode = short.Parse(TempCvv);
                    check = true;
                }
                catch
                {
                    Console.WriteLine("Invalid security number. Try again: ");
                    Console.WriteLine("Enter your credit card's security number: ");
                    TempCvv = Console.ReadLine();
                }

            } while (check == false);

            return new MCustomer
            {
                username = "Guest",
                password = "null",
                FirstName = "Guest",
                LastName = "Guest",
                PhoneNumber = 2223334444,
                Address = "null",
                CardNumber = TempCard,
                CardExpDate = TempExp,
                CardCode = TempCode

            };
        }

        public static MCustomer CreateNewCustomer()
        {
            bool check = false;
            Console.WriteLine("Enter a username:");
            var TempUsername = Console.ReadLine();
            Console.WriteLine("Enter a password: ");
            var TempPassword = Console.ReadLine();
            Console.WriteLine("Enter your first name: ");
            var TempFirstName = Console.ReadLine();
            Console.WriteLine("Enter your last name: ");
            var TempLastName = Console.ReadLine();
            Console.WriteLine("Enter your phone number: ");
            var TempNumber = Console.ReadLine();
            decimal TempPhoneNumber = 1111111111;
            do
            {
                check = false;
                try
                {
                    TempPhoneNumber = decimal.Parse(TempNumber);
                    check = true;
                }
                catch
                {
                    Console.WriteLine("Invalid phone number. Try again: ");
                    Console.WriteLine("Enter your phone number: ");
                    TempNumber = Console.ReadLine();
                }

            } while (check == false);

            Console.WriteLine("Enter your address, city, state (seperated by a comma)");
            var TempAddress = Console.ReadLine();
            Console.WriteLine("Enter your credit card number: ");
            var TempCardNumber = Console.ReadLine();
            decimal TempCard = 5555555555555555;
            do
            {
                check = false;
                try
                {
                    TempCard = decimal.Parse(TempCardNumber);
                    if (TempCardNumber.Length == 15 || TempCardNumber.Length == 16)
                    {
                        check = true;
                    }
                    else
                    {
                        check = false;
                    }

                }
                catch
                {
                    Console.WriteLine("Invalid credit card number. Try again: ");
                    Console.WriteLine("Enter your credit card number: ");
                    TempCardNumber = Console.ReadLine();
                }

            } while (check == false);

            Console.WriteLine("Enter the experation date (MMYY)");
            var TempExpDate = Console.ReadLine();
            Console.WriteLine("Enter the security code: ");
            short TempExp = 0294;
            do
            {
                check = false;
                try
                {
                    TempExp = short.Parse(TempExpDate);
                    check = true;
                }
                catch
                {
                    Console.WriteLine("Invalid security number. Try again: ");
                    Console.WriteLine("Enter your credit card's security number: ");
                    TempExpDate = Console.ReadLine();
                }

            } while (check == false);
            var TempCvv = Console.ReadLine();
            short TempCode = 123;
            do
            {
                check = false;
                try
                {
                    TempCode = short.Parse(TempCvv);
                    check = true;
                }
                catch
                {
                    Console.WriteLine("Invalid security number. Try again: ");
                    Console.WriteLine("Enter your credit card's security number: ");
                    TempCvv = Console.ReadLine();
                }

            } while (check == false);


            return new MCustomer
            {
                username = TempUsername,
                password = TempPassword,
                FirstName = TempFirstName,
                LastName = TempLastName,
                PhoneNumber = TempPhoneNumber,
                Address = TempAddress,
                CardNumber = TempCard,
                CardExpDate = TempExp,
                CardCode = TempCode

            };
        }

        // private static void AddCustomer(IRepository repository, MCustomer customer)
        // {
        //     var customers = repository.GetCustomers();

        //     repository.AddCustomer(customer);
        //     Console.WriteLine("You're account has successfully been created!");

        // }

        private static void UploadToDb(MOrder order)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        private static string UserLogin()
        {
            Console.WriteLine("To login please enter your username:");
            var user = Console.ReadLine();

            Console.WriteLine("\nEnter your Password:");

            var password = Console.ReadLine();

            Boolean foundID = false;

            IRepository repository = Dependencies.CreateRepository();

            Console.WriteLine("\nVeryifying login credientials...");
            var LoginInfo = repository.GetUserAndPass();
            foreach (var item in LoginInfo)
            {
                //Console.WriteLine($"{item.username} {item.password}");
                if (item.username == user && item.password == password)
                {
                    Console.WriteLine("You have successfully logged in!");
                    foundID = true;
                    break;
                }
            }

            if (foundID == false)
            {
                do
                {
                    Console.WriteLine("Login failed, please enter username and password correctly. Enter Username:");
                    user = Console.ReadLine();
                    Console.WriteLine("Enter password:");
                    password = Console.ReadLine();

                    foreach (var item in LoginInfo)

                        //Console.WriteLine($"{item.username} {item.password}");
                        if (item.username == user && item.password == password)
                        {
                            Console.WriteLine("You have successfully logged in!");

                            foundID = true;
                            break;
                        }
                } while (foundID == false);
            }

            return user;
        }
        private static void DisplayOrder(MOrder order)
        {
            Console.WriteLine("\nYour order is: ");
            int i = 0;
            foreach (CustomPizza item in order.ListOfPizzas)
            {
                Console.Write($"\n{item.Size} ");
                foreach (Toppings topping in item.Toppings)
                {
                    Console.Write($"{topping.Name} ");
                }
                Console.Write($"{item.Crust} crust {item.Name} ");
                i++;

            }
            Console.WriteLine($"\nYour total is: ${order.Cost}");
        }

        private static void DisplayCrustTypes()
        {
            IRepository repository = Dependencies.CreateRepository();
            Console.WriteLine("\nPlease select a Crust:");

            var crusts = repository.GetPizzaCrusts();

            foreach (var item in crusts)
            {
                Console.WriteLine($"{item.Id} - {item.Name}  ${item.Price}");

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void DisplayPizzaMenu()
        {
            IRepository repository = Dependencies.CreateRepository();
            Console.WriteLine("\nPlease select a Pizza:");

            var pizzas = repository.GetAllPizzas();
            int count = 0;
            foreach (var item in pizzas)
            {
                Console.WriteLine($"{item.PizzaId} - {item.Name}  ${item.PizzaPrice}");
                count++;
            }
            Console.WriteLine($"{count + 1} - CustomPizza $5.99");
        }

        /// <summary>
        /// 
        /// </summary>
        private static void DisplayStoreMenu()
        {
            IRepository repository = Dependencies.CreateRepository();
            Console.WriteLine("\nPlease select a store:");

            var StoreLocation = repository.GetStores();
            foreach (var item in StoreLocation)
            {
                Console.WriteLine($"{item.StoreID} - {item.StoreLocation}");

            }





        }
        static List<Pizza> getPizzaOrder()
        {
            // this will create a session between db and the .net app
            PizzaBoxInformationContext context = new PizzaBoxInformationContext();
            var Pizza_order = context.Pizzas.ToList();
            return Pizza_order;

        }
        private static void DisplayPizzaSize()
        {
            IRepository repository = Dependencies.CreateRepository();
            Console.WriteLine("\nPlease select a size:");

            var sizes = repository.GetSizes();

            foreach (var item in sizes)
            {
                Console.WriteLine($"{item.Id} - {item.Name}, ${item.Price}");

            }
        }
        private static void DisplayToppings()
        {
            IRepository repository = Dependencies.CreateRepository();
            Console.WriteLine("\nPlease select a topping:");

            var topping = repository.GetToppings();

            foreach (var item in topping)
            {
                Console.WriteLine($"{item.Id} - {item.Name}, {item.Price}");

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static void SelectStore(MOrder order)
        {
            DisplayStoreMenu();
            var StoreLocation = Console.ReadLine();
            IRepository repository = Dependencies.CreateRepository();
            var holder = repository.GetStoreByIndex(int.Parse(StoreLocation));

            order.Store.StoreLocation = holder.StoreLocation;
            order.Store.StoreID = holder.StoreID;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static void SelectPizza(MOrder order)
        {

            Boolean MorePizza = false;
            int count = 0;


            do
            {
                CustomPizza Pizza = new CustomPizza();
                DisplayPizzaMenu();
                var PizzaSelect = Console.ReadLine();
                IRepository repository = Dependencies.CreateRepository();
                var holder = repository.GetPizzaByIndex(int.Parse(PizzaSelect));
                holder.OrderId = count;
                //Pizza = repository.GetPizzaByIndex(int.Parse(PizzaSelect));
                Pizza.Name = holder.Name;
                Pizza.OrderId = count;
                Toppings topping;

                switch (holder.PizzaId)
                {
                    case 1:
                        break;
                    case 2:
                        topping = new Toppings
                        {
                            Name = "Pepperoni",
                            Price = 1,
                            Id = 4
                        };
                        Pizza.Toppings.Add(topping);
                        topping = new Toppings
                        {
                            Name = "Sausage",
                            Price = 1,
                            Id = 6
                        };
                        Pizza.Toppings.Add(topping);
                        topping = new Toppings
                        {
                            Name = "Chicken",
                            Price = 1,
                            Id = 3
                        };
                        Pizza.Toppings.Add(topping);

                        break;
                    case 3:
                        topping = new Toppings
                        {
                            Name = "Pepperoni",
                            Price = 0,
                            Id = 1
                        };
                        Pizza.Toppings.Add(topping);
                        break;
                    case 4:

                        topping = new Toppings
                        {
                            Name = "Broccoli",
                            Price = 0.75M,
                            Id = 20
                        };
                        Pizza.Toppings.Add(topping);
                        topping = new Toppings
                        {
                            Name = "Olives",
                            Price = 0.75M,
                            Id = 12
                        };
                        Pizza.Toppings.Add(topping);

                        topping = new Toppings
                        {
                            Name = "Tomato",
                            Price = 0.75M,
                            Id = 18
                        };
                        Pizza.Toppings.Add(topping);
                        break;
                    default:
                        break;

                }

                Pizza.PizzaPrice += holder.PizzaPrice;

                //order.Cost += holder.PizzaPrice;

                SelectCrust(order, Pizza);
                SelectSize(order, Pizza);
                SelectToppings(order, Pizza);


                Console.WriteLine($"How many of this {Pizza.Name} would you like?");
                var number = Console.ReadLine();
                for (int i = 0; i < int.Parse(number); i++)
                {

                    if (order.Cost <= 250 && count != 50)
                    {
                        count++;
                        Pizza.OrderId = count;
                        order.ListOfPizzas.Add(Pizza);
                        order.Cost += Pizza.PizzaPrice;
                    }
                    if (order.Cost >= 250)
                    {
                        do
                        {
                            //decimal placeholder = order.Cost;
                            order.ListOfPizzas.RemoveAt(count - 1);
                            order.Cost -= Pizza.PizzaPrice;

                        } while (order.Cost >= 250);

                        Console.WriteLine("You have exceeded the $250 order limit. We have removed the last entered pizzas from your order.");

                        break;

                    }
                    else if (count == 50)
                    {
                        Console.WriteLine("You have reached the item limit of 50 and cannot place anymore orders");
                        break;
                    }
                }

                Console.WriteLine("Would you like to add more to your order? (Y/N)");
                var input = Console.ReadLine();

                if (input.ToLower() == "n")
                {
                    MorePizza = true;
                }

                count++;
            } while (MorePizza == false);



            // foreach (var item in order.ListOfPizzas)
            // {
            //     Console.WriteLine($"{item.Name} {item.PizzaPrice}");
            // }

        }

        private static void SelectToppings(MOrder order, CustomPizza pizza)
        {

            //Boolean MoreToppings = false;
            Console.WriteLine("Do you want to add more toppings? (Y/N)");
            var input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                DisplayToppings();

                var ToppingSelect = Console.ReadLine();
                IRepository repository = Dependencies.CreateRepository();
                var holder = repository.GetToppingByIndex(int.Parse(ToppingSelect));
                Toppings topping = new Toppings
                {
                    Name = holder.Name,
                    Price = holder.Price,

                    Id = holder.Id
                };
                pizza.AddToppings(topping);
                pizza.PizzaPrice += topping.Price;
                //order.ListOfToppings.Add(holder);
                //order.Cost += holder.Price;
            }




            // foreach (var item in order.ListOfCrusts)
            // {
            //     Console.WriteLine($"{item.Name} {item.Price}");
            // }
        }



        private static void SelectCrust(MOrder order, CustomPizza pizza)
        {
            DisplayCrustTypes();

            var CrustSelect = Console.ReadLine();
            IRepository repository = Dependencies.CreateRepository();
            var holder = repository.GetCrustByIndex(int.Parse(CrustSelect));

            pizza.Crust = holder.Name;
            pizza.PizzaPrice += holder.Price;


            //order.Cost += holder.Price;





            // foreach (var item in order.ListOfCrusts)
            // {
            //     Console.WriteLine($"{item.Name} {item.Price}");
            // }


        }

        private static void SelectSize(MOrder order, CustomPizza pizza)
        {
            DisplayPizzaSize();
            var SizeSelect = Console.ReadLine();
            IRepository repository = Dependencies.CreateRepository();
            var holder = repository.GetSizeByIndex(int.Parse(SizeSelect));

            pizza.Size = holder.Name;
            pizza.PizzaPrice += holder.Price;

            // foreach (var item in order.ListOfSizes)
            // {
            //     Console.WriteLine($"{item.Name} {item.Price}");
            // }
            //order.Cost += holder.Price;



        }

        private static double CalculatePrice(List<APizza> ListPizza, List<string> ListSize, List<decimal> ListPrice)
        {
            decimal BasePrice = 0;
            decimal FinalPrice = 0;
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