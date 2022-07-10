using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ModernValidator
{
    public class LabId:InterfaceCardLabels
    {
        public Label labId;
        private const int LOC_X = 100;
        private const int LOC_Y = 40;
        public LabId( int id)
        {
            AddLab( id);
        }

  
        public void AddLab( int id)
        {
           
                labId = new Label();
                labId.Text = "Id " + id;
                labId.AutoSize = true;
                labId.BackColor = Color.Transparent;
                labId.Location = new Point(LOC_X, LOC_Y);
               

        }

        public void AddBalance( double balance)
        {
            throw new NotImplementedException();
        }
    }
}
