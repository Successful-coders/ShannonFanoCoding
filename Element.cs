using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Lab2
{
    class Element//Столбец таблицы
    {
        private string symbol;//Символ из алфавита
        private double probability;//Вероятность
        private string cipher;//Шифр / код


        public Element(string symbol, double probability)//Конструктор
        {
            this.symbol = symbol;
            this.probability = probability;
        }


        public string Symbol { get => symbol; set => symbol = value; }//Символ из алфавита
        public double Probability => probability;//Вероятность
        public string Cipher { get => cipher; set => cipher = value; }//Шифр / код
    }
}
