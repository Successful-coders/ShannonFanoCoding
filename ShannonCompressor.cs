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
                        for (int j = 0; j < completedCodewords.Length; j++)
                        {
                            if (completedCodewords[j] != null)
                            {
                                replaceIndexes.Remove(j);
                            }
                        }
                    }

                    for (int i = 0; i < replaceIndexes.Count; i++)
                    {
                        int replaceIndex = replaceIndexes[i];

                        completedCodewords[replaceIndex] = item.Cipher;
                        for (int j = replaceIndex + 1; j < replaceIndex + item.Symbol.Length; j++)
                        {
                            completedCodewords[j] = "";
                        }
                    }
                }

                compressedText = string.Join("", completedCodewords);

                return compressedText;
            }
        }
        public string Uncompress(string compressedText)
        {
            string uncompressedText = "";
            int minCipherLength = codingTable.Elements[0].Cipher.Length;
            int maxCipherLength = codingTable.Elements[codingTable.Elements.Count - 1].Cipher.Length;

            while (compressedText != "")
            {
                for (int cipherLength = minCipherLength; cipherLength <= maxCipherLength; cipherLength++)
                {
                    string cipher = compressedText.Substring(0, cipherLength);
                    foreach (var element in codingTable.Elements)
                    {
                        if (element.Cipher == cipher)
                        {
                            uncompressedText += element.Symbol;
                            compressedText = compressedText.Substring(cipherLength);

                            cipherLength = maxCipherLength;
                            break;
                        }
                    }
                }

            }

            return uncompressedText;
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
