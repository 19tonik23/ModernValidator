using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Media;
using WMPLib;
using System.IO;
using System.Threading.Tasks;

namespace ModernValidator
{
    public class Terminal
    {
       
        public Button[,] stopBt;
        private BonusTimer bnsTimer;
        private FineTimer fineTimer;
        private CheckCard checkCard;
        private int col = 6;
        private int row = 2;
        private int SIZE = 33;
        public Panel panTerminal = new Panel();
        private Plastics plastics;
        private int[] entr;
        private int[] exit;
        public TabloLabel tabloLab;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private WindowsMediaPlayer mPlayer = new WindowsMediaPlayer();
      
        public Terminal(Form form)
        {
          
            PanelTerminal(form);
            Stop( row);
            plastics = new Plastics(form,stopBt);
            PanelTerminal(form);
        
            entr = new int[plastics.plasticCnt];
            exit = new int[plastics.plasticCnt];
            tabloLab = new TabloLabel();
            tabloLab.CreatTableLabel(panTerminal,null);
            string path= Path.GetDirectoryName(Application.ExecutablePath) + "file.mp3";
            File.WriteAllBytes(path, Properties.Resources.sign);
            mPlayer.URL = path;
            timer.Interval = 10;
         
            checkCard = new CheckCard(panTerminal, CheckImg()[0]);
            bnsTimer = new BonusTimer(plastics.plasticCnt,plastics.labBonus,plastics.allCards);
            fineTimer = new FineTimer(plastics.plasticCnt,plastics.labPenal,plastics.labBalance,
                plastics.allCards,bnsTimer);
            
            
        }

        private void NotMoneSound()
        {
            SoundPlayer player = new SoundPlayer();
            player.Stream = Properties.Resources.notSign1;
            player.Play();
        }

        // Создаём панель валидатора
        public void PanelTerminal(Form form)
        {
            panTerminal.Size = new Size(form.Width/2, form.Height*9/10);
            panTerminal.AutoSize = true;
            panTerminal.Location = new Point(20, 10);
            panTerminal.BackgroundImage = Properties.Resources.valid;
            panTerminal.BackgroundImageLayout = ImageLayout.Stretch;
            form.Controls.Add(panTerminal);
        }

        //Создаём массив остановок
        private void Stop( int row)
        {
            panTerminal.Controls.Clear();


            stopBt = new Button[row, col];

            int tag = 0;
            for (int i = 0; i < row; i++)
            {

                for (int j = 0; j < col; j++)
                {
                    tag++;
                    stopBt[i, j] = new Button();
                    stopBt[i, j].Size = new Size(SIZE, SIZE);
                   stopBt[i, j].MaximumSize = new Size(SIZE, SIZE);
                    stopBt[i, j].AutoSize = true;
                    stopBt[i, j].Tag = tag;
                    stopBt[i, j].Text = tag.ToString();
                    stopBt[i, j].BackgroundImage = Properties.Resources.stop2;
                    stopBt[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    // stopBt[i, j].BackColor = ColorTranslator.FromHtml("#4B704A");
                    stopBt[i, j].Cursor = Cursors.Hand;
                    stopBt[i, j].FlatStyle = FlatStyle.Flat;
                    stopBt[i, j].FlatAppearance.BorderSize = 0;
                    stopBt[i, j].ForeColor = ColorTranslator.FromHtml("#4B704A");
                    stopBt[i, j].Font = new Font("", 10);
                    stopBt[i, j].Enabled = false;
                    panTerminal.Controls.Add(stopBt[i, j]);
                    stopBt[i, j].Location = new Point
                        (SIZE*2  + SIZE * 3 / 2 * j, panTerminal.Height*3/4 + SIZE * 5/ 4 * i);
                    stopBt[i, j].Click += BtnStopClick;
                }


            }
        }

        
        //Событие выбора остановки
        public void BtnStopClick(object sender, EventArgs e)
        {
             currentBtnClick=(Button)sender;
         
             ChekIndication();
         
             ReturnCard();
        }

        //индикатор вход выход на табло
        private Button currentBtnClick;
        private void ChekIndication()
        {
            int index = plastics.cardIndex;
            if (plastics.allCards.allCrd[index].ent_exit)
            {
                checkCard.panCheck.Visible = true;
               
                fineTimer.start_stopFine[index] = true;
                fineTimer.timerFine[index].Start();
                if (plastics.allCards.allCrd[index].balance > MinSum())
                    checkCard.panCheck.BackgroundImage = CheckImg()[0];
                else
                    checkCard.NotEnt();
               
            }
            else
            {
                checkCard.panCheck.Visible = true;
                checkCard.panCheck.BackgroundImage = CheckImg()[1];
               
            }
        }

        //иконки вход выход на табло
        private Image[] CheckImg()
        {
            Image [] img = new Image[] {Properties.Resources.pasEnt ,Properties.Resources.pasExit};
            return img;
        }

        //возврат карты на место
        private void ReturnCard()
        {
            if (plastics.allCards.allCrd[plastics.cardIndex].balance > MinSum())
                mPlayer.controls.play();
            else
            {
                NotMoneSound();
            }
            Point pnt = new Point(plastics.panPlastic[plastics.cardIndex].Location.X, plastics.panPlastic[plastics.cardIndex].Location.Y);

            plastics.panPlastic[plastics.cardIndex].Location = new Point(panTerminal.Width * 3 / 12
                , panTerminal.Height / 2);

            
            Thread.Sleep(500);
            plastics.panPlastic[plastics.cardIndex].Location = new Point(pnt.X, pnt.Y);
            plastics.panPlastic[plastics.cardIndex].BorderStyle = BorderStyle.None;
            plastics.panPlastic[plastics.cardIndex].Refresh();
            StopsEnabled();
            checkCard.panCheck.Visible = false;
            Balance(currentBtnClick);
        }

        //подсчёт баланса карточки
        private void Balance(Button but)
        {
            int index = plastics.cardIndex;
            
            if (index == plastics.cardIndex)
            {
                if (plastics.allCards.allCrd[index].ent_exit)
                {
                    entr[index] = int.Parse(but.Text);
                    BonusTimerStop(index);
                    NullBalance(index);
                }
                else
                {
                    EventSecondTouchCard(index);

                }
            }
        }

        //событие прикладывания карточки при выходе
        private void EventSecondTouchCard(int index)
        {
            GetBalance(index);
            TabloBalanceText(index);
            BonusTimerStart(index);
            ReturnTabloText();
        }

        //Подсчёт баланса и отправка на карточку
        private void GetBalance(int index)
        {
            exit[index] = int.Parse(currentBtnClick.Text);
            fineTimer.FineTimerStop(index);
            double delta;
            double taxa = 0.5;
            if (bnsTimer.durat[index] == plastics.allCards.allCrd[index].bonusTime)
                delta = Math.Abs(entr[index] - exit[index]) + taxa;
            else
            {
                delta = Math.Abs(entr[index] - exit[index]);
            }
            plastics.allCards.allCrd[index].balance = plastics.allCards.allCrd[index].balance - delta;
            plastics.labBalance[index].labBalance.Text = "Balance " + plastics.allCards.allCrd[index].balance;
            plastics.labBalance[index].labBalance.Refresh();
            
        }

        //Отправка баланса на табло
        private void TabloBalanceText(int index)
        {
            tabloLab.tabloLab.Text = "На счету осталось " + plastics.allCards.allCrd[index].balance;
            tabloLab.tabloLab.ForeColor = Color.Red;
            tabloLab.tabloLab.Refresh();
        }

        //Старт таймера бонусного времени
        private void BonusTimerStart(int index)
        {
            bnsTimer.durat[index] = plastics.allCards.allCrd[index].bonusTime;
            bnsTimer.start_stopBonus[index] = true;
            bnsTimer.timerBonus[index].Start();
        }

        //Стоп таймера бонусного времени
        private void BonusTimerStop(int index)
        {
            bnsTimer.start_stopBonus[index] = false;
            bnsTimer.timerBonus[index].Stop();
            plastics.labBonus[index].labBonus.Text = "Bonus " + plastics.allCards.allCrd[index].bonusTime;
        }

        //Возврат первоначальной надписи на табло
        private void ReturnTabloText()
        {
            Thread.Sleep(1500);
            tabloLab.tabloLab.Text = "Приложите карточку ";
            tabloLab.tabloLab.ForeColor = Color.White;
        }

        //Кнопки остановки выключены
        private void StopsEnabled()
        {
            foreach (Button bt in stopBt)
                bt.Enabled = false;
        }

        //Минимум средств на карточке
        private double MinSum()
        {
            return 1.5;
        }
        
        // Нет средств на карточке
        private void NullBalance(int index)
        {
            if (plastics.allCards.allCrd[index].balance <= MinSum())
            {
                plastics.panPlastic[index].Enabled = false;
                plastics.panPlastic[index].BackgroundImage = Properties.Resources.not_money;
                plastics.panPlastic[index].Refresh();
                fineTimer.timerFine[index].Stop();
                bnsTimer.timerBonus[index].Stop();
                tabloLab.tabloLab.Text = "На счету нет средств ";
                tabloLab.tabloLab.ForeColor = Color.Red;
                tabloLab.tabloLab.Refresh();
                ReturnTabloText();
            }
        }
 
    }
}
