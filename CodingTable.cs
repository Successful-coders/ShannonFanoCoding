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
        public bool IsCraft//Проверка на неравенство Крафта
        {
            get
            {
                double res = 0.0;

                for (int i = 0; i < Count; i++)
                {
                    res += Math.Pow(2, -elements[i].Cipher.Length);
                }

                if (res <= 1.0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public List<Element> Elements => elements;//Список элементов таблицы
        public int Count => elements.Count;//Количество столбцов таблицы
        public List<string> Alphabet => elements.Select(x => x.Symbol).ToList();//Алфавит
    }
}
