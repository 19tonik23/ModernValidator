using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ModernValidator
{
    public class LabBalance:InterfaceCardLabels
    {
        public Label labBalance=new Label();
        private const int LOC_X = 155;
        private const int LOC_Y = 40;
        public LabBalance( double balance)
        {
            AddBalance( balance);
            
        }


        public void AddLab( int id)
        {
            throw new NotImplementedException();
        }

        // лейбл баланс на карточке
        public void AddBalance(double balance)
        {
            labBalance.Text = "Balance " + balance;
            labBalance.AutoSize = true;
            labBalance.BackColor = Color.Transparent;
            labBalance.Location = new Point(LOC_X, LOC_Y);
           
        }

    }
}
