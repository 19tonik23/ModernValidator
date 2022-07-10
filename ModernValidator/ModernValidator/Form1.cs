using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ModernValidator
{
    public partial class Form1 : Form
    {
     // private Terminal terminal;
        public Form1()
        {
            InitializeComponent();
         
            this.BackColor = ColorTranslator.FromHtml("#494949");
            Terminal terminal = new Terminal(this);
         
        }
    }
}
