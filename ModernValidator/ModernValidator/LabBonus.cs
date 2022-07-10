using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ModernValidator
{
    public class LabBonus:InterfaceCardLabels
    {
        public Label labBonus;
        private const int LOC_X = 155;
        private const int LOC_Y = 65;
        public LabBonus( int bonus)
        {
            AddLab(bonus);
        }

        public void AddLab( int bonus)
        {
           
                labBonus= new Label();
                labBonus.Text = "Bonus " + bonus;
                labBonus.AutoSize = true;
                labBonus.BackColor = Color.Transparent;
                labBonus.Location = new Point(LOC_X, LOC_Y);
                

        }

        public void AddBalance( double balance)
        {
            throw new NotImplementedException();
        }
    }
}
