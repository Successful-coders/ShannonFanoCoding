using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryption_Lab2
{
    public partial class ShannonFanoForm : Form//Основная форма
    {
        private string alphabet;//алфавит
        private string probabilities;//вероятности
        private ShannonCompressor compressor;//Архиватор


        public ShannonFanoForm()//Конструктор форма
        {
            InitializeComponent();
        }

        private void LoadAlphabetFile_Click(object sender, EventArgs e)//Нажатие на кнопку "Загрузить алфавит"
        {
            if (openAlphabet.ShowDialog() == DialogResult.OK)//Заупуск окно выбора файла
            {
                try
                {
                    var filePath = openAlphabet.FileName;//Путь к файлу
                    using (StreamReader str = new StreamReader(filePath))//Считывание из файла в перменную
                    {
                        alphabet = str.ReadToEnd();

                        infoTextBox.WriteLine("Алфавит = " + alphabet);//Вывод информации
                    }
                }
                catch (SecurityException ex)//Вывод ошибки
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
        private void LoadProbabilityFile_Click(object sender, EventArgs e)//Нажатие на кнопку "Загрузить вероятности"
        {
            if (openProbabilites.ShowDialog() == DialogResult.OK)//Заупуск окно выбора файла
            {
                try
                {
                    var filePath = openProbabilites.FileName;//Путь к файлу
                    using (StreamReader str = new StreamReader(filePath))//Считывание из файла в перменную
                    {
                        probabilities = str.ReadToEnd();

                        infoTextBox.WriteLine("Вероятности = " + probabilities);//Вывод информации
                    }
                }
                catch (SecurityException ex)//Вывод ошибки
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
        private void CompressButton_Click(object sender, EventArgs e)//Нажатие на кнопку "Архивировать"
        {
            string[] symbols = alphabet.Split(new char[] { ',' });//Преобразование в массив символов из алфавита
            string[] symbolProbs = probabilities.Split(new char[] { ',' });//Преобразование в массив вероятностей
            List<Element> elements = new List<Element>();

            for (int i = 0; i < symbols.Length && i < symbolProbs.Length; i++)
            {
                elements.Add(new Element(symbols[i], double.Parse(symbolProbs[i])));//Добавление стоблцов в таблицу
            }
            CodingTable codingTable = new CodingTable(elements);

            if(!codingTable.IsProbabilitySumCorrect)
            {
                MessageBox.Show("Сумма вероятнстей в файле больше единицы");
                return;
            }

            compressor = new ShannonCompressor(codingTable);//Создание архиватора

            PrintCiphers(codingTable);//Вывод символов таблицы и их шифров в информационный бокс
            infoTextBox.WriteLine("Средняя длина код слова = " + codingTable.AverageLength);//Вывод информации о Средней длине код слова
            infoTextBox.WriteLine("Избыточность = " + codingTable.Redundancy);//Вывод информации о Избыточности
            infoTextBox.WriteLine("Неравенство Крафта = " + codingTable.IsCraft);//Вывод информации о Неравенстве Крафта
            try
            {
                string compressedText = compressor.Compress(compressedTextBox.Text);//Сжатый текст
                compressedTextBox.Text = compressedText;
                infoTextBox.WriteLine("Сжатый текст = " + compressedText);//Вывод сжатого текста

                var saveFileDialog = new SaveFileDialog();//Создание диалогового окна для сохранения файла
                saveFileDialog.Filter = "Compressed files (.rar)|*.rar";//Фильтр файла

                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;//Путь файла

                    // Удаляем файл, если такой уже существует
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }

                    // Создаем и записываем файл
                    using (StreamWriter sw = File.CreateText(fileName))
                    {
                        sw.Write(compressedText);
                    }
                }
            }
            catch(Exception exception)//Вывод ошибки
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void UncompressButton_Click(object sender, EventArgs e)//Нажатие на кнопку "Разархивировать"
        {
            var openFileDialog = new OpenFileDialog();//Создание диалогового окна для открытия файла
            openFileDialog.Filter = "Compressed files (.rar)|*.rar";//Фильтр файла

            DialogResult result = openFileDialog.ShowDialog();//После выбора файла
            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;//Имя сжатого файла

                string compressedText = File.ReadAllText(fileName);//Сжатый текст, полученный из файла

                try
                {
                    string uncompressedText = compressor.Uncompress(compressedText);//Расжатый текст
                    compressedTextBox.Text = uncompressedText;
                    infoTextBox.WriteLine("Исходный текст = " + uncompressedText);//выввод исходного текста

                    var saveFileDialog = new SaveFileDialog();//Создание диалогового окна для сохранения файла
                    saveFileDialog.Filter = "Text files (.txt)|*.txt";//Фильтр файла

                    result = saveFileDialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        fileName = saveFileDialog.FileName;

                        // Удаляем файл, если такой уже существует     
                        if (File.Exists(fileName))
                        {
                            File.Delete(fileName);
                        }

                        // Создаем и записываем файл  
                        using (StreamWriter sw = File.CreateText(fileName))
                        {
                            sw.Write(uncompressedText);
                        }
                    }
                }
                catch (Exception exception)//Вывод ошибки
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void PrintCiphers(CodingTable codingTable)//Вывод символов таблицы и их шифров в информационный бокс
        {
            for (int i = 0; i < codingTable.Count; i++)
            {
                int cipherPadding = 8 - codingTable.Elements[i].Symbol.Length;//Количество символов для отступа
                string symbolCipherPair = string.Format("{0, 3}", codingTable.Elements[i].Symbol) + " :" + string.Format("{0, " + cipherPadding + "}", codingTable.Elements[i].Cipher);
                infoTextBox.WriteLine(symbolCipherPair);
            }
        }
    }
}
