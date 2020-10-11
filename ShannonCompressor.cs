using System;
using System.Collections.Generic;

namespace Encryption_Lab2
{
    class ShannonCompressor
    {
        CodingTable codingTable;


        public ShannonCompressor(CodingTable codingTable)
        {
            this.codingTable = codingTable;
            codingTable.SortElements();
            codingTable.CreateCodewords();
        }

        
        public string Compress(string compressedText)
        {
            if (!IsSymbolsInAlphabet(compressedText))
            {
                throw new Exception("Текст содержит символы, невключенные в алфавит");
            }
            else
            {
                string[] completedCodewords = new string[compressedText.Length];

                foreach (var item in codingTable.Elements)
                {
                    List<int> replaceIndexes = compressedText.AllIndexesOf(item.Symbol);

                    for (int i = 0; i < replaceIndexes.Count; i++)
                    {
                        int replaceIndex = replaceIndexes[i];

                        completedCodewords[replaceIndex] = item.Codeword;

                        compressedText = compressedText.Replace(item.Symbol, "");
                    }
                }

                compressedText = string.Join("", completedCodewords);

                return compressedText;
            }
        }
        public bool IsSymbolsInAlphabet(string text)
        {
            foreach (var item in codingTable.Alphabet)
            {
                text = text.Replace(item, "");
            }

            return text.Length == 0;
        }
    }
}
