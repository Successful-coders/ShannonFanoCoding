using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption_Lab2
{
    class Coder
    {
        private List<Element> elements;


        public Coder(List<Element> elements)
        {
            this.elements = elements;
        }


        public List<Element> Elements => elements;
    }
}
