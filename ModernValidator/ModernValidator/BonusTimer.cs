using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModernValidator
{
    public class BonusTimer:TimerInterface
    {
        private AllCards allCrd;
        public int[] durat;
        public bool[] start_stopBonus = new bool[] { false, false, false };
        public System.Windows.Forms.Timer[] timerBonus;
        private LabBonus[] labBonus;
    
        public BonusTimer(int plasticCnt, LabBonus[] labBonus, AllCards allCrd)
        {
            this.labBonus = labBonus;
            this.allCrd = allCrd;
          
            durat = new int[] { SetTime(), SetTime(), SetTime() };
            Timer(plasticCnt);
            
        }

        //Установка бонусного времени
        private int SetTime()
        {
            int bonTm = allCrd.allCrd[0].bonusTime;
            return bonTm;
        }
        
        //Создание массива таймеров
        public void Timer(int plasticCnt)
        {
            timerBonus = new Timer[plasticCnt];
            for (int i = 0; i < timerBonus.Length; i++)
            {
                timerBonus[i] = new Timer();
                timerBonus[i].Interval = 1000;
                timerBonus[i].Tick += TimerTick;

            }
        }

        //Событие отсчёта таймера
        public void TimerTick(object sender, EventArgs e)
        {
            
            if (start_stopBonus[0])
            {
               
                TimerContent(0);
            }

            if (start_stopBonus[1])
            {
                
                TimerContent(1);
            }
            if (start_stopBonus[2])
            {

                TimerContent(2);
            }
        }

        //Содержание таймера
        public void TimerContent(int id)
        {
            durat[id]--;
            
            if (durat[id] == 0)
            {
                durat[id] = SetTime();
                timerBonus[id].Stop();
                start_stopBonus[id] = false;
            }
            labBonus[id].labBonus.Text = "bonus " + durat[id];
          
        }

        public void FineTimerStop(int item)
        {
            throw new NotImplementedException();
        }
    }
}
