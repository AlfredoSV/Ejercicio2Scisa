using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio2Scisa
{
    class Program
    {

        static void Main(string[] args)
        {

            try
            {
                var machine = new MachineExp();

                do
                {
                    Console.WriteLine("Please enter the product code(Press 0 to exit):");
                    string codeProduct = Console.ReadLine();

                    if (codeProduct.Equals("0"))
                        throw new Exception("Close system");

                    Console.WriteLine("Please enter the total number of products to buy(Press 0 to exit):");
                    string totalProducts = Console.ReadLine();


                    if (totalProducts.Equals("0"))
                        throw new Exception("Close system");
                    Console.WriteLine("Please enter money and coins, separated by spaces(Press 0 to exit):");
                    string moneysAdnCoins = Console.ReadLine();
                    var moneysAdnCoinsArrStr = moneysAdnCoins.Split(' ');
                    var correctNomenclature =  moneysAdnCoinsArrStr.All(m => Regex.IsMatch(m.Trim(), "^\\d+$"));
                    if (codeProduct.Equals("0") || totalProducts.Equals("0"))
                        throw new Exception("Close system");

                    var moneysAdnCoinsArrInt = new List<int>();
                    if (correctNomenclature)
                        moneysAdnCoinsArrInt = Array.ConvertAll(moneysAdnCoinsArrStr, numInt => Int32.Parse(numInt)).ToList();

                    if (correctNomenclature)
                    {
                       
                        machine.ListProducts();

                        machine.BuyProduct(Int32.Parse(codeProduct),  moneysAdnCoinsArrInt, Int32.Parse(totalProducts));
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong input, please try.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("To buy another product, please press enter or Press 0 to exit.");
                    Console.ForegroundColor = ConsoleColor.White;
                                
                    string response  = Console.ReadLine();
                    if (totalProducts.Equals("0"))
                        throw new Exception("Close system");

                    Console.Clear();

                } while (true);

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.Read();
            }

        }



    }


 
   

}
