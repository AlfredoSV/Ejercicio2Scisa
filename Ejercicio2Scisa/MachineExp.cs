using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2Scisa
{
    public class MachineExp
    {
        private int MoneyAvailable = 300;
        private int[] _MoneyPer = { 5, 10, 50, 100, 200 };
        private Purchase _Purch;
        private List<Product> _Products = new List<Product>();

        public MachineExp()
        {
            this._Products.Add(Product.Create(Guid.NewGuid(), "Coca Cola 500 ml", 20, 15, 1));
            this._Products.Add(Product.Create(Guid.NewGuid(), "Pepsi 500 ml", 15, 20, 2));
            this._Products.Add(Product.Create(Guid.NewGuid(), "Gansito", 16, 20, 3));
        }

        public void BuyProduct(int code, List<int> money, int totalProducts)
        {

            int disPosMoney = money.Sum(mon => mon);

            var returnMonney = false;


            var product = this._Products.Where(pro => pro.Code == code).FirstOrDefault();

            if (product is null)
            {
                Console.WriteLine("The product not exist.");
                returnMonney = true;

                ReturnMoney(returnMonney,money);
            }
            else
            {

                if (disPosMoney < product.Price * totalProducts)
                {
                    Console.WriteLine("Please enter the correct amount of money.");
                    returnMonney = true;
                    
                }


                if (product.TotalAvailable < totalProducts)
                {
                    Console.WriteLine($"Currently the machine does not have this amount of products:{totalProducts}");
                    returnMonney = true;
                    
                }

                ReturnMoney(returnMonney,money);

                if (MoneyAvailable == 0)
                {
                    Console.WriteLine("No money aviliable in machine");
                    throw new Exception("Close system");
                }


                foreach (var mone in money)
                {
                    if (!this._MoneyPer.Any(M => M == mone))
                    {
                        Console.WriteLine("This machine only accepts these denominations.[5, 10 , 50, 100, 200]");
                        throw new Exception("Close system");

                    }
                }

                this._Purch = Purchase.Create(product, disPosMoney, disPosMoney - (product.Price * totalProducts));

                Console.WriteLine($"Product name:{product.Name}");
                Console.WriteLine($"Product code:{product.Code}");
                Console.WriteLine($"Please, collect your money:{_Purch.ExChMoney}");

                UpdateInventaryProducts(product.Id, totalProducts);
                UpdateMoneyMachine(((product.Price * totalProducts)));

                ListProducts();


            }


        }

        public void ListProducts()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\n\n\n-------------Products-------------");
            this._Products.ForEach(p => {

                Console.WriteLine($"Product name:{p.Name}");
                Console.WriteLine($"Product code:{p.Code}");
                Console.WriteLine($"Product total avliliable:{p.TotalAvailable}");

            });
            Console.WriteLine("-------------Products-------------\n\n\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void UpdateInventaryProducts(Guid Id, int totalDesc)
        {
            this._Products.Where(p => p.Id == Id).FirstOrDefault().TotalAvailable -= totalDesc;

        }

        private void UpdateMoneyMachine(int totalDesc)
        {
            this.MoneyAvailable += totalDesc;

        }

        private void ReturnMoney(bool returnMonney,List<int> money)
        {

            if (returnMonney)
            {
                Console.WriteLine("Please take your money");

                foreach (var mon in money)
                {
                    Console.WriteLine($"\n{mon} ");
                }

                throw new Exception("Close system");
            }
        }


    }

}
