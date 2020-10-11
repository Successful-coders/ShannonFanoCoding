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
        private ShannonCompressor compressor;


        public ShannonFano()
        {
            InitializeComponent();
        }

        private void LoadAlphabetFile_Click(object sender, EventArgs e)
        {
            if (openAlphabet.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openAlphabet.FileName;
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
            if (openProbabilites.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openProbabilites.FileName;
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
            string[] symbols = alphabet.Split(new char[] { ',' });
            string[] symbolProbs = probabilities.Split(new char[] { ',' });
            List<Element> elements = new List<Element>();

            for (int i = 0; i < symbols.Length && i < symbolProbs.Length; i++)
            {
                elements.Add(new Element(symbols[i], double.Parse(symbolProbs[i])));
            }
            CodingTable codingTable = new CodingTable(elements);

            compressor = new ShannonCompressor(codingTable);
            try
            {
                string compressedText = compressor.Compress(compressedTextBox.Text);
                compressedTextBox.Text = compressedText;
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void UncompressButton_Click(object sender, EventArgs e)
        {

        }
    }
}
