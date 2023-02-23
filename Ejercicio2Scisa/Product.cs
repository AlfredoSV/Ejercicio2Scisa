using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2Scisa
{
    public class Product
    {
        private Guid _Id;

        public Guid Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private int _Code;

        public int Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private int _Price;

        public int Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        private int _TotalAvailable;

        public int TotalAvailable
        {
            get { return _TotalAvailable; }
            set { _TotalAvailable = value; }
        }

        private Product(string name, int price, int totalAvailable, int code)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            TotalAvailable = totalAvailable;
            Code = code;
        }


        public static Product Create(Guid id, string name, int price, int totalAvailable, int code)
        {
            return new Product(name, price, totalAvailable, code);
        }


    }

}
