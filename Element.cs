using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Lab2
{
    class Element
    {
        private string symbol;
        private double probability;
        private string cipher;


        public Element(string symbol, double probability)
        {
            this.symbol = symbol;
            this.probability = probability;
        }


        public string Symbol => symbol;
        public double Probability => probability;
        public string Cipher { get => cipher; set => cipher = value; }
    }
}
