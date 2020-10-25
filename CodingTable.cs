using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Lab2
{
    class CodingTable//Таблица сиволов с их вероятностями и кодом
    {
        private List<Element> elements;//Список столбцов таблицы


        public CodingTable(List<Element> elements)//Конструктор класса
        {
            this.elements = elements;
        }


        public void SortElements()//Сортировка по убыванию по вероятности символа
        {
            elements = elements.OrderByDescending(x => x.Probability).ToList();
        }
        public void CreateCiphers()//Создание бинарного кода для каждого символа алфавита
        {
            LowerBranch(elements, "");
        }


        private void LowerBranch(List<Element> elements, string directionCipher)//Рекурсивная функция формирования бинарного дерева
        {
            elements.ForEach(x => x.Cipher += directionCipher);//Добавляем в конец каждого элемента символ шифра

            if (elements.Count > 1)
            {
                int sliceCount = elements.Count / 2;//Количество элементов в левой ветке

                List<Element> leftSide = elements.Take(sliceCount).ToList();//Левая ветка дерева
                List<Element> rightSide = elements.Skip(sliceCount).ToList();//Правая ветка дерева

                LowerBranch(leftSide, "0");
                LowerBranch(rightSide, "1");
            }
        }


        public double AverageLength//Расчёт средней длины кодового слова
        {
            get
            {
                double averageLength = 0.0;
                int length = 0;

                for (int i = 0; i < Count; i++)//Высчитываем среднеарифметическое
                {
                    length += elements[i].Cipher.Length;
                }
                averageLength = (1.0 * length) / Count;

                return averageLength;
            }
        }

        //добавляем символ четность/нечетности в конец каждого кода
        public void Modify()
        {
            int ctr;
            for (int i = 0; i < elements.Count ; i++)
            {
                ctr = 0;
                for (int j = 0; j < elements[i].Cipher.Length; j++)
                {
                    if(elements[i].Cipher[j] == '1')
                    {
                        ctr++;
                    }
                }
                if (ctr%2==0)
                {
                    elements[i].Cipher += "0";
                }
                else
                {
                    elements[i].Cipher += "1";
                }
            }
        }
        public double Redundancy//Подсчёт избыточности
        {
            get
            {
                double redundancy = 0.0;//Избыточность
                double entropy = 0.0;//Энтропия

                //Подсчет энтропии
                for (int i = 0; i < Count; i++)
                {
                    entropy += elements[i].Probability * (elements[i].Probability <= 0 ? 0 : - Math.Log(elements[i].Probability, 2));
                }


                //Подсчет избыточности
                redundancy = 1 - entropy / Math.Log(Count, 2);

                return redundancy;
            }
        }
        public double IsCraft//Проверка на неравенство Крафта
        {
            get
            {
                double res = 0.0;

                for (int i = 0; i < Count; i++)
                {
                    res += Math.Pow(2, -elements[i].Cipher.Length);
                }

                return res;
            }
        }
        public List<Element> Elements => elements;//Список элементов таблицы
        public int Count => elements.Count;//Количество столбцов таблицы
        public List<string> Alphabet => elements.Select(x => x.Symbol).ToList();//Алфавит
        public bool IsProbabilitySumCorrect//Меньше и равна ли 1 сумма частот
        {
            get
            {
                double probabilitySum = 0.0d;

                elements.ForEach(x => probabilitySum += x.Probability);

                return probabilitySum <= 1.0d;
            }
        }
    }
}
