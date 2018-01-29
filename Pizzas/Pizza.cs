using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Pizzas
{
    public class Pizza
    {
        public bool DownloadFile(string fileName)
        {
            try
            {                
                using (var client = new WebClient())
                {
                    client.DownloadFile("http://files.olo.com/pizzas.json", fileName);
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public List<Order> LoadJson(string file)
        {
            var orders = new List<Order>();

            using (StreamReader r = File.OpenText(file))
            {
                string json = r.ReadToEnd();
                orders = JsonConvert.DeserializeObject<List<Order>>(json);
            }

            return orders;
        }          
    }

    public class Order
    {
        public string[] toppings;
    }
}
