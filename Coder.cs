using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryption_Lab2
{
    class Coder
    {
        public int N { set; get; }
        // Дискретный ансамбль
        public List<Element> table { get; set; }
        public List<string> syndromeTable = new List<string>();

        public Coder()
        {
            table = new List<Element>();
            this.syndromeTable = new List<string>();
        }
        public void clearTable()
        {
            table.Clear();
        }
        public void add(string code, double prob)
        {
            Element elem = new Element(code, prob);
            table.Add(elem);
        }
        int MODIFY_CODE_LENGTH = 9;
        int CODE_LENGTH = 5;
        int[,] H = new int[4, 9] {
            { 0, 0, 0, 1, 0, 1, 0, 0, 0 },
            { 1, 1, 0, 0, 1, 0, 1, 0, 0 },
            { 1, 1, 1, 1, 0, 0, 0, 1, 0 },
            { 0, 1, 1, 0, 1, 0, 0, 0, 1 } };

        int[,] G = new int[5, 9] {
            { 1, 0, 0, 0, 0, 0, 1, 1, 0 },
            { 0, 1, 0, 0, 0, 0, 1, 1, 1 },
            { 0, 0, 1, 0, 0, 0, 0, 1, 1 },
            { 0, 0, 0, 1, 0, 1, 0, 1, 0 },
            { 0, 0, 0, 0, 1, 0, 1, 0, 1 } };


        public string Mul_H(string code) // синдром для полученного кода code
        {

            string res = "";
            for (int i = 0; i < sizeSindrom; i++)
            {
                int sum = 0;
                for (int j = 0; j < MODIFY_CODE_LENGTH; j++)
                {
                    sum += (Convert.ToInt32(code[j]) - 48) * H[i, j];
                }
                res += sum % 2;
            }
            return res;
        }

        private string binaryTranslation(int num)
        {
            char[] numStr = new char[CODE_LENGTH];

            for (int i = 0; i < CODE_LENGTH; i++)
            {
                if (num % 2 == 1)
                {
                    numStr[i] = '1';
                }
                else
                {
                    numStr[i] = '0';
                }
                num /= 2;
            }
            Array.Reverse(numStr);

            return new String(numStr);
        }
        const int sizeSindrom = 4;
        public void hammingAlgorithm()
        {
            for (int i = 0; i < MODIFY_CODE_LENGTH; i++)
            {
                string code = "";
                for (int j = 0; j < sizeSindrom; j++)
                    code += H[j, i].ToString();
                syndromeTable.Add(code);
            }

            for (int i = 0; i < table.Count; i++)
            {
                // переводим в двоичную систему, т.е. получаем информационный код
                table[i].Cipher = binaryTranslation(i);
                // умножаем полученный код на матрицу G для полученяи зашифрованного кода
                table[i].Cipher = Mul_G(table[i].Cipher);
                table[i].Symbol = i.ToString();
            }
        }
        // Получаем шифр из текста
        public string Encryption(string data)
        {
            if (table.Count == 0)
            {
                string message = "Список кодов пуст";
                string caption = "Ошибка";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }

            string cipher = "";

            for (int i = 0; i < data.Length; i++)
            {
                try
                {
                    cipher += table.Find(x => x.Symbol == data[i].ToString()).Cipher;
                }
                catch
                {
                    string message = "Присутствуют символы, которые не входят в исходный алфавит!";
                    string caption = "Ошибка";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                }
            }
            return cipher;
        }

        public string Mul_G(string code) // кодовое слово для символа с кодом code
        {
            if (code.Length != CODE_LENGTH) // необходимо 5 символов для данного алфавита
                throw new Exception("Неправильное использование функции Mul_G..");

            string res = "";

            for (int j = 0; j < MODIFY_CODE_LENGTH; j++)
            {
                int sum = 0;
                for (int i = 0; i < CODE_LENGTH; i++)
                {
                    sum += (Convert.ToInt32(code[i]) - 48) * G[i, j];
                }

                res += sum % 2; // сумма по модулю 2, запись в строку res            
            }
            return res;
        }
        
        // Получаем текст изoutputFile шифра
        public string Decryption(string cipher)
        {
            string text = "";
            string code;
            string symbol;
            string syndrome;

            if (table.Count == 0)
            {
                throw new Exception("Ошибка!");
            }

            for (int i = 0; i < cipher.Length; i++)
            {
                code = "";

                // Формируем очередное кодовое слово
                while (code.Length < MODIFY_CODE_LENGTH)
                {
                    code += cipher[i];
                    i++;
                }

                // Получаем синдром для кодового слова
                syndrome = Mul_H(code);

                //Если синдром ненулевой, исправляем код
                if (Convert.ToInt32(syndrome, 2) > 0)
                {
                    int symdromeIndex = syndromeTable.FindIndex(x => x == syndrome);
                    //if (symdromeIndex > 0)
                    //{


                        if (code[symdromeIndex] == '1')
                        {
                            code = code.Remove(symdromeIndex, 1).Insert(symdromeIndex, "0");
                        }
                        else
                        {
                            code = code.Remove(symdromeIndex, 1).Insert(symdromeIndex, "1");
                        }

                        using (StreamWriter outputFile = new StreamWriter("error.txt"))
                        {
                            outputFile.WriteLine("Испровлена ошибка в символе №" + i / 9);
                        }
                    //}
                }

                // Ищем символ по коду
                try
                {
                    symbol = table.Find(x => x.Cipher == code).Symbol;
                }
                catch
                {
                    symbol = "?";
                }

                text += symbol;
                text += ' ';
                i--;
            }

            // Удаляем последний символ пробела
            text = text.Substring(0, text.Length - 1);

            return text;

        }
    }
}
