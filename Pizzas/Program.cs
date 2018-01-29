using System;
using System.IO;
using System.Linq;

namespace Pizzas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pizzaList = new Pizza();

            var fileName = Path.Combine(Path.GetTempPath(), "pizzatest.json");

            //here go get the file
            if (pizzaList.DownloadFile(fileName))
            {
                //here load the file
                var orders = pizzaList.LoadJson(fileName);

                //here show the top 20 toppings
                var query = orders.SelectMany(x => x.toppings)
                    .GroupBy(s => s)
                    .Select(g => new {Name = g.Key, Count = g.Count()})
                    .OrderByDescending(d => d.Count)
                    .Take(20);

                foreach (var result in query)
                {
                    Console.WriteLine("Topping: {0}, Count: {1}", result.Name, result.Count);
                }
            }
            else
            {
                Console.WriteLine("Errors downloading the file!");
            }

            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }
    }
}
