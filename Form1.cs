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
    public partial class ShannonFano : Form
    {
        private string alphabet;
        private string probabilities;
        private Coder coder;
        private List<string> compressedSymbols;


        public ShannonFano()
        {
            InitializeComponent();

            openFileDialog1 = new OpenFileDialog()
            {
                FileName = "Select a text file",
                Filter = "Text files (*.txt)|*.txt",
                Title = "Open text file"
            };
        }

        private void LoadAlphabetFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog1.FileName;
                    using (StreamReader str = new StreamReader(filePath))
                    {
                        alphabet = str.ReadToEnd();
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
        private void LoadProbabilityFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog1.FileName;
                    using (StreamReader str = new StreamReader(filePath))
                    {
                        probabilities = str.ReadToEnd();
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void CompressButton_Click(object sender, EventArgs e)
        {
            string[] symbols = alphabet.Split(new char[] { ','});
            string[] symbolProbs = probabilities.Split(new char[] { ','});
            List<Element> elements = new List<Element>();

            for (int i = 0; i < symbols.Length && i < symbolProbs.Length; i++)
            {
                elements.Add(new Element(symbols[i], double.Parse(symbolProbs[i])));
            }

            coder = new Coder(elements);

            string compressedText = compressedTextBox.Text;
        }
    }
}
