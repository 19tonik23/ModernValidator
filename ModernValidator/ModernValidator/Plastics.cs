using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ModernValidator
{
    public class Plastics
    {
        public Panel[] panPlastic;
        public int plasticCnt = 3;
        public AllCards allCards;
        private LabId[] labId;
        public LabBalance[] labBalance;
        public LabPenal[] labPenal;
        public LabBonus[] labBonus;
        private Form form;
        public Button[,] stops;
       
        public Plastics(Form form,Button[,] stops)
        {
            this.form = form;
            this.stops=stops;
            allCards = new AllCards();
            AllLabelArray();
            AllPlast(form);
  
        }

        //создание лейблов  баланс,ID,бонусное время,штрафное время
        //(иммитирует вышел,но не приложил карточку)

        private void AllLabelArray()
        {
            labBalance = new LabBalance[plasticCnt];
            labId = new LabId[plasticCnt];
            labPenal = new LabPenal[plasticCnt];
            labBonus = new LabBonus[plasticCnt];
        }
        private void AllLabelAdd(int i)
        {
            labBalance[i] = new LabBalance(allCards.allCrd[i].balance);
            panPlastic[i].Controls.Add(labBalance[i].labBalance);
            labId[i] = new LabId(allCards.allCrd[i].id);
            panPlastic[i].Controls.Add(labId[i].labId);
            labPenal[i] = new LabPenal(allCards.allCrd[i].penalTime);
            panPlastic[i].Controls.Add(labPenal[i].labPenal);
            labBonus[i] = new LabBonus(allCards.allCrd[i].bonusTime);
            panPlastic[i].Controls.Add(labBonus[i].labBonus);
        }

        // создание пластик карт
        private void AllPlast(Form form)
        {
            panPlastic = new Panel[plasticCnt];

           
            for (int i = 0; i < panPlastic.Length; i++)
            {

                PlasticCard(i);
            
            }
        }

        // создание пластик карт
        private void PlasticCard(int i)
        {
            panPlastic[i] = new Panel();
            panPlastic[i].BackgroundImage = Properties.Resources.card;
            panPlastic[i].BackgroundImageLayout = ImageLayout.Stretch;
          
            panPlastic[i].Size = new Size(250, 150);
            panPlastic[i].Font = new Font("", 10);
            panPlastic[i].ForeColor = Color.White;
            panPlastic[i].Tag = (i + 1) * 10;
            panPlastic[i].TabIndex = i;
            
            panPlastic[i].Cursor = Cursors.Hand;
      
            AllLabelAdd(i);
        
            panPlastic[i].Location = new
              Point(form.Right - panPlastic[i].Width * 3 / 2,
              form.Top + panPlastic[i].Height /3 + panPlastic[i].Height * i * 6 / 5);
            form.Controls.Add(panPlastic[i]);
            panPlastic[i].Click += PlasicClick;
          
        }

        //событие выбора карточки
        public int cardIndex;
        public void PlasicClick(object sender, EventArgs e)
        {

            Panel pan = (Panel)sender;
            cardIndex = pan.TabIndex;
            allCards.allCrd[cardIndex].ent_exit = !allCards.allCrd[cardIndex].ent_exit;
            panPlastic[cardIndex].BorderStyle = BorderStyle.Fixed3D;
            StopsEnabled();

        }

        //разблокирование кнопок остановок
        public void StopsEnabled()
        {
            foreach (Button bt in stops)
                bt.Enabled = true;
        }
    }
}
