using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ModernValidator
{
    public class CheckCard:Interface_Tablo
    {
        public Panel panCheck = new Panel();
        public CheckCard(System.Windows.Forms.Panel panTerminal, Image img)
        {
            CreatTableLabel(panTerminal, img);
        }
       
        // Создание иконки вход-выход
        public void CreatTableLabel(System.Windows.Forms.Panel panTerminal,Image img)
        {
            
            panCheck.Size = new Size(80, 80);
            panCheck.BackgroundImage = img;
            panCheck.BackgroundImageLayout = ImageLayout.Stretch;
            panCheck.Location = new Point(panTerminal.Left + panTerminal.Width/3, panTerminal.Height*4/14);
            panCheck.Visible = false;
            panTerminal.Controls.Add(panCheck);
        }

        //иконка нет входа
        public void NotEnt()
        {
            panCheck.BackgroundImage = Properties.Resources.not_ent;
        }
    }
}
