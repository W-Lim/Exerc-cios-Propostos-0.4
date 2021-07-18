using System;
using System.Globalization;
using System.Collections.Generic;
using AtividadeHEPO.Entities;

namespace AtividadeHEPO
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            Console.Write("Enter the number of products:");
            int qtd = int.Parse(Console.ReadLine());

            for(int i = 1; i <= qtd; i++)
            {
                Console.WriteLine("Product #" + i + " data:");
                Console.Write("Common, used or imported (c/u/i)? ");
                string op = Console.ReadLine();

                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(op == "u")
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    list.Add(new UsedProduct(name, price, date));
                }
                else if(op == "i")
                {
                    Console.Write("Customs fee: ");
                    double customs = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new ImportProduct(name, price, customs));
                }
                else
                {
                    list.Add(new Product(name, price));
                }
            }

            Console.WriteLine(  );
            Console.WriteLine("PRICE TAGS:");
            foreach (Product pro in list)
            {
                Console.WriteLine(pro.Pricetag());
            }

            
        }
    }
}
