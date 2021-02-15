using System;
using System.Collections.Generic;
using System.Text;

namespace BirKelimeBirIslem.BLL
{
   public class Oyun
    {
        Random rnd { get; set; }

        public int CiftBasamakli { get; set; }

        public List<int> TekBasamakli { get; private set; }

        public int HedefSayi { get; set; }

        CozumBul Cozum { get; set; }

        public Oyun()
        {
            rnd = new Random();
            if (TekBasamakli != null) TekBasamakli.Clear();
            CiftBasamakli = IkiBasamakliOlustur();
            TekBasamakli = TekBasamakliOlustur();
            HedefSayi = HedefSayiOlustur();
        }
        public CozumBul Basla()
        {
            this.Cozum = new CozumBul(HedefSayi, TekBasamakli, CiftBasamakli);
            return Cozum;
        }

        private int IkiBasamakliOlustur()
        {
            List<int> sayilar = new List<int>() { 10, 20, 30, 40, 50, 60, 70, 80, 90 };
            return sayilar[rnd.Next(0, sayilar.Count)];
        }

        private List<int> TekBasamakliOlustur()
        {
            List<int> sayilar = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                sayilar.Add(rnd.Next(1, 9));
            }
            return sayilar;
        }

        private int HedefSayiOlustur()
        {
            return rnd.Next(100, 1000);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Cozum);
            return sb.ToString();
        }
    }
}
