using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryption_Lab2
{
    static class TextBoxExt//Расширение для класса TextBox
    {
        public static void WriteLine(this TextBox textBox, string line)//Печатает line на строке и делает переход на новую
        {
            textBox.Text += line + Environment.NewLine;
        }
    }
}
