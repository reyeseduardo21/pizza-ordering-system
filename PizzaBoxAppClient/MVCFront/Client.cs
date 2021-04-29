using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MVCFront.Models;

namespace MVCFront
{
    public class Client
    {
        MOrder GetAllOrders(string url)
        {
            //https://localhost:44365/api/PizzaBox
            using var client = new HttpClient();
            return null;
        }
    }
}
