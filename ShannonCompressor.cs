using System;
using System.Collections.Generic;

namespace Encryption_Lab2
{
    class ShannonCompressor//Компрессор, изпользующий алгоритм Шеннона-Фано
    {
        private CodingTable codingTable;//Таблица


        public ShannonCompressor(CodingTable codingTable)//Конструктор, принимающий таблицу
        {
            this.codingTable = codingTable;
            codingTable.SortElements();//Сортируем элементы таблицы по убыванию вероятностей
            codingTable.CreateCiphers();//Создаем для каждого символа свой шифр
            codingTable.Modify();
        }


        public string Compress(string compressedText)//Сжатие
        {
            //if (!IsSymbolsInAlphabet(compressedText))//Если есть элементы не из алфавита, выбрасываем исключение
            //{
            //    throw new Exception("Текст содержит символы, невключенные в алфавит");
            //}



            string[] completedCodewords = new string[compressedText.Length];//Массив шифров

            foreach (var item in codingTable.Elements)
            {
                List<int> replaceIndexes = compressedText.AllIndexesOf(item.Symbol);//Получаем индексы строки, где стоит символ
                for (int i = 0; i < replaceIndexes.Count; i++)//Убираем индексы, если этот символ (набор символов) уже был перекодирован
                {
                    for (int j = 0; j < completedCodewords.Length; j++)
                    {
                        if (completedCodewords[j] != null)
                        {
                            replaceIndexes.Remove(j);
                        }
                    }
                }

                for (int i = 0; i < replaceIndexes.Count; i++)//Добавляем в массив шифров новый
                {
                    int replaceIndex = replaceIndexes[i];

                    completedCodewords[replaceIndex] = item.Cipher;
                    for (int j = replaceIndex + 1; j < replaceIndex + item.Symbol.Length; j++)
                    {
                        completedCodewords[j] = "";
                    }
                }
            }

            compressedText = string.Join("", completedCodewords);//Объединяем массив шифров в одну строку

            return compressedText;

        }
        public string Uncompress(string compressedText)//Расжатие
        {
            string uncompressedText = "";
            int minCipherLength = codingTable.Elements[0].Cipher.Length;//Минимальная длина одного шифра
            int maxCipherLength = codingTable.Elements[codingTable.Elements.Count - 1].Cipher.Length;//Максимальная длина одного шифра

            while (compressedText != "")
            {
                for (int cipherLength = minCipherLength; cipherLength <= maxCipherLength; cipherLength++)//От минимального до макимального
                {
                    if (cipherLength > compressedText.Length)
                        throw new Exception("Ошибка при расжатии файла");

                    string cipher = compressedText.Substring(0, cipherLength);//Шифр
                    foreach (var element in codingTable.Elements)//Если шифр соответсвует, то заменяем его в соответсвтии с таблицей
                    {
                        if (element.Cipher == cipher)
                        {
                            uncompressedText += element.Symbol;
                            compressedText = compressedText.Substring(cipherLength);

                            cipherLength = maxCipherLength;//Переходим на поиск нового шифра
                            break;
                        }
                    }
                }

            }

            return uncompressedText;
        }
        public bool IsSymbolsInAlphabet(string text)//Содержит ли строка символы не из алфавита
        {
            foreach (var item in codingTable.Alphabet)
            {
                text = text.Replace(item, "");
            }

            return text.Length == 0;
        }
    }
}
