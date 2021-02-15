using BirKelimeBirIslem.Model;
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirKelimeBirIslem.BLL
{

    public class KelimeAra
    {
        private List<int> harfmiktar { get; set; }

        public int puan;

        private int max { get; set; }

        internal List<KelimeModel> bulunankelimeler { get; private set; }

        public KelimeAra(List<KelimeModel> _liste, List<string> _harfler)
        {
            int adet = 0;
            int sira = -1;
            max = 0;

            harfmiktar = new List<int>();
            bulunankelimeler = new List<KelimeModel>();
            List<KelimeModel> aramasonuc = new List<KelimeModel>();

            foreach (var item in _liste)
            {
                string kelime = item.Kelime.ToUpper().Trim().ToString();
                adet = 0;
                foreach (var item2 in _harfler)
                {
                    if (kelime.Count() == 0) break;
                    sira = kelime.IndexOf(item2);
                    if (sira != -1)
                    {
                        adet++;
                        kelime = kelime.Remove(sira, 1);
                        sira = -1;
                    }
                }
                if (kelime.Count() <= 1)
                {
                    if (kelime.Count() == 1) adet++;
                    if (adet > max) max = adet;
                    harfmiktar.Add(adet);
                    aramasonuc.Add(new KelimeModel { KelimeID = item.KelimeID, Kelime = item.Kelime, KelimeAnlam = item.KelimeAnlam });
                }
            }
            VerileriIsle(aramasonuc);
        }
        private void VerileriIsle(List<KelimeModel> _liste)
        {
            foreach (var item in _liste.Select((value, i) => new { i, value }))
            {
                if (harfmiktar[item.i] == max)
                {
                    bulunankelimeler.Add(new KelimeModel { KelimeID = item.value.KelimeID, Kelime = item.value.Kelime, KelimeAnlam = item.value.KelimeAnlam });
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in bulunankelimeler)
            {
                sb.AppendLine(item.Kelime + " --> " + item.KelimeAnlam);
            }
            string ifade;
            switch (max)
            {
                case 9:
                    puan = 15;
                    ifade = "Alınan Puan: 15" + Environment.NewLine + "( " + max + " Harf Eşleşti.)";
                    break;
                case 8:
                    puan = 11;
                    ifade = "Alınan Puan: 11" + Environment.NewLine + "( " + max + " Harf Eşleşti.)";
                    break;
                case 7:
                    puan = 9;
                    ifade = "Alınan Puan: 9" + Environment.NewLine + "( " + max + " Harf Eşleşti.)";
                    break;
                case 6:
                    puan = 7;
                    ifade = "Alınan Puan: 7" + Environment.NewLine + "( " + max + " Harf Eşleşti.)";
                    break;
                case 5:
                    puan = 5;
                    ifade = "Alınan Puan: 5" + Environment.NewLine + "( " + max + " Harf Eşleşti.)";
                    break;
                case 4:
                    puan = 4;
                    ifade = "Alınan Puan: 4" + Environment.NewLine + "( " + max + " Harf Eşleşti.)";
                    break;
                case 3:
                    puan = 3;
                    ifade = "Alınan Puan: 3" + Environment.NewLine + "( " + max + " Harf Eşleşti.)";
                    break;
                case 2:
                    puan = 1;
                    ifade = "Alınan Puan: 1" + Environment.NewLine + "( " + max + " Harf Eşleşti.)";
                    break;
                default:
                    puan = 0;
                    ifade = "Alınan Puan: 0" + Environment.NewLine + "( " + max + " Harf Eşleşti.)";
                    break;
            }
            sb.Append(ifade);
            return sb.ToString();
        }
    }
}
