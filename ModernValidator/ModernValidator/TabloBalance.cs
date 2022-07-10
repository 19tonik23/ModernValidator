using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ModernValidator
{
    public class TabloBalance:Interface_Tablo
    {
        public Label tabloBalance;
        public void CreatTableLabel(System.Windows.Forms.Panel pan,Image img)
        {
            tabloBalance = new Label();
            tabloBalance.Text = "Приложите карточку";
            tabloBalance.ForeColor = Color.White;
            tabloBalance.Font = new Font("", 20);
            tabloBalance.BackColor = Color.Transparent;
            tabloBalance.AutoSize = true;
            tabloBalance.Location = new Point(pan.Left + 60, pan.Top + 120);

            pan.Controls.Add(tabloBalance);
        }
    }
}
