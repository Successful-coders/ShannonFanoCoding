using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Lab2
{
    class CodingTable
    {
        private List<Element> elements;


        public CodingTable(List<Element> elements)
        {
            this.elements = elements;
        }


        public void SortElements()
        {
            elements.Sort(SortByProbDescending);
        }
        public void CreateCodewords()
        {
            DownBranch(elements, "");
        }

        private int SortByProbDescending(Element elem1, Element elem2)
        {
            return elem2.Probability.CompareTo(elem1.Probability);
        }
        private void DownBranch(List<Element> elements, string directionCodeword)
        {
            elements.ForEach(x => x.Codeword += directionCodeword);

            if (elements.Count > 1)
            {
                int sliceCount = elements.Count / 2;

                List<Element> leftSide = elements.Take(sliceCount).ToList();
                List<Element> rightSide = elements.Skip(sliceCount).ToList();

                DownBranch(leftSide, "0");
                DownBranch(rightSide, "1");
            }
        }


        public List<Element> Elements => elements;
    }
}
