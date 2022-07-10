using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModernValidator
{
    public class AllCards
    {
        public Card[] allCrd;
        private int cardCnt = 3;
        private Random rd;
        public AllCards()
        {
            rd = new Random();
            Cards();

        }

        //Создание случайным  образом суммы на карточке
        private void Cards()
        {
            allCrd = new Card[cardCnt];
            for (int i = 0; i < allCrd.Length; i++)
            {
                allCrd[i] = new Card();
                allCrd[i].id = (i + 1) * 10;
                allCrd[i].balance = rd.Next(30, 50);

            }
        }
    }
}
