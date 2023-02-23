using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2Scisa
{
    public class Purchase
    {
        private Product _Prod;

        public Product Prod
        {
            get { return _Prod; }
            set { _Prod = value; }
        }

        private int _DeposeMoney;

        public int DeposeMoney
        {
            get { return _DeposeMoney; }
            set { _DeposeMoney = value; }
        }

        private int _ExChMoney;

        public int ExChMoney
        {
            get { return _ExChMoney; }
            set { _ExChMoney = value; }
        }

        private Purchase(Product prod, int deposeMoney, int exChMoney)
        {
            _Prod = prod;
            _DeposeMoney = deposeMoney;
            _ExChMoney = exChMoney;
        }

        public static Purchase Create(Product prod, int deposeMoney, int exChMoney)
        {
            return new Purchase(prod, deposeMoney, exChMoney);
        }
    }

}
