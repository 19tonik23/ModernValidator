using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModernValidator
{
    interface TimerInterface
    {
        
        void Timer(int plasticCnt);
        void TimerTick(object sender, EventArgs e);
        void TimerContent(int id);
        void FineTimerStop(int item);
    }
}
