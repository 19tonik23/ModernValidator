using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModernValidator
{
    public class FineTimer:TimerInterface
    {
        public System.Windows.Forms.Timer[] timerFine;
        
        public LabPenal[] labFine;
        public int[] duratFine;
        public bool[] start_stopFine = new bool[] { false, false, false };
        public LabBalance[] labBalance;
        public AllCards cards;
        public BonusTimer bnsTimer;
        public FineTimer(int plasticCnt, LabPenal [] labFine, LabBalance[] labBalance,
            AllCards cards, BonusTimer bnsTimer)
        {
            this.bnsTimer = bnsTimer;
            this.labFine = labFine;
            this.labBalance = labBalance;
            this.cards = cards;
            Timer(plasticCnt);
            duratFine = new int[] { SetTime(), SetTime(), SetTime() };
        }


        //Установка начального времени
        private int SetTime()
        {
            int fineTime = cards.allCrd[0].penalTime;
            return fineTime;
        }

        //Создание массива таймеров
        public void Timer(int plasticCnt)
        {
            timerFine = new Timer[plasticCnt];
            for (int i = 0; i < timerFine.Length; i++)
            {
                timerFine[i] = new Timer();
                timerFine[i].Interval = 1000;
                timerFine[i].Tick += TimerTick;

            }
        }

        //Событие отсчёта таймера
        public void TimerTick(object sender, EventArgs e)
        {
            if (start_stopFine[0])
            {

                TimerContent(0);
            }

            if (start_stopFine[1])
            {

                TimerContent(1);
            }
            if (start_stopFine[2])
            {

                TimerContent(2);
            }
        }

       //Штрафная сумма
        private  int PenalSum(){
            return 11;
        }    
        
        //Содержание таймера
        public void TimerContent(int id)
        {
            duratFine[id]--;

            if (duratFine[id] == 0)
            {

                timerFine[id].Stop();
                start_stopFine[id] = false;
                bnsTimer.durat[id] = SetTime();
                cards.allCrd[id].balance = cards.allCrd[id].balance - PenalSum();

                labBalance[id].labBalance.Text = "Balance " + cards.allCrd[id].balance;
                duratFine[id] = SetTime();
                cards.allCrd[id].ent_exit = !cards.allCrd[id].ent_exit;
                
            }

            labFine[id].labPenal.Text = "Fine " + duratFine[id];
        }

        //останов таймера
        public void FineTimerStop(int item)
        {
            duratFine[item] = SetTime();
            timerFine[item].Stop();
            start_stopFine[item] = false;
            labFine[item].labPenal.Text = "Fine " + SetTime();

        }

       
    }
}
