using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ModernValidator
{
     public class StopsPanel:Interface_Tablo
    {
         public Panel stopsPan;
         public StopsPanel(Panel panTerminal, Image img)
         {
             CreatTableLabel(panTerminal,img);
         }
         public void CreatTableLabel(Panel panTerminal, System.Drawing.Image img)
            {
                stopsPan = new Panel();
                stopsPan.Size = new Size(panTerminal.Height /2, panTerminal.Height / 8);
                stopsPan.Location = new Point(panTerminal.Left+stopsPan.Width/9
                , panTerminal.Bottom-stopsPan.Height*11/5);
                panTerminal.Controls.Add(stopsPan);
            }
    }
}
