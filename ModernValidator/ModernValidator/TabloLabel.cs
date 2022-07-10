using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ModernValidator
{
    public class TabloLabel:Interface_Tablo

    {
        public Label tabloLab;
        public void CreatTableLabel(System.Windows.Forms.Panel pan,Image img)
        {
            tabloLab = new Label();
            tabloLab.Text = "Приложите карточку";
            tabloLab.ForeColor = Color.White;
            tabloLab.Font = new Font("",20);
            tabloLab.BackColor = Color.Transparent;
            tabloLab.AutoSize = true;
            tabloLab.Location = new Point(pan.Left + pan.Width/8, pan.Top + pan.Height/5);
            pan.Controls.Add(tabloLab);

        }
    }
}
