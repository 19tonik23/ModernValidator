using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ModernValidator
{
    public class LabPenal:InterfaceCardLabels
    {
        public Label labPenal;
        private const int LOC_X = 100;
        private const int LOC_Y = 65;
        public LabPenal(int penal)
        {
            AddLab(penal);
        }

       
        public void AddLab( int penal)
        {
            
            
                labPenal = new Label();
                labPenal.Text = "Pnl " + penal;
                labPenal.AutoSize = true;
                labPenal.BackColor = Color.Transparent;
                labPenal.Location = new Point(LOC_X, LOC_Y);
               

            
        }

        public void AddBalance(double balance)
        {
            throw new NotImplementedException();
        }
    }
}
