using System;
using System.Collections.Generic;
using System.Text;
using static BirKelimeBirIslem.BLL.Operator;

namespace BirKelimeBirIslem.BLL
{
    public class Islem:Oyun
    {
        private List<int> SiradakiSayi { get; set; }

        private List<Operator_List> Operatorler { get; set; }

        public int DegerHesapla
        {

            get
            {
                int deger = SiradakiSayi[0];
                for (int i = 1; i < SiradakiSayi.Count; i++)
                {
                    switch (Operatorler[i - 1])
                    {
                        case Operator_List.Topla:
                            deger += SiradakiSayi[i];
                            break;
                        case Operator_List.Cikar:
                            deger -= SiradakiSayi[i];
                            break;
                        case Operator_List.Carp:
                            deger *= SiradakiSayi[i];
                            break;
                        case Operator_List.Bol:
                            deger /= SiradakiSayi[i];
                            break;
                    }
                }
                return deger;
            }
        }
        public Islem(int _siradaki_sayi)
        {
            this.SiradakiSayi = new List<int>() { _siradaki_sayi };
            this.Operatorler = new List<Operator_List>();
        }

        public Islem(Islem _denklembaslangici, Operator_List _islem, int _siradakisayi)
        {
            this.SiradakiSayi = new List<int>((int[])_denklembaslangici.SiradakiSayi.ToArray().Clone());
            this.SiradakiSayi.Add(_siradakisayi);
            this.Operatorler = new List<Operator_List>((Operator_List[])_denklembaslangici.Operatorler.ToArray().Clone());
            this.Operatorler.Add(_islem);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int siradaki = SiradakiSayi[0];
            int _siradakideger = -1;
            for (int i = 1; i < SiradakiSayi.Count; i++)
            {
                string satir = YeniIslemSatiriOlustur(siradaki, i, ref _siradakideger);
                sb.Append(satir);
                sb.Append(Environment.NewLine);
                siradaki = _siradakideger;
            }
            return sb.ToString();
        }

        private string YeniIslemSatiriOlustur(int _simdikisayi, int _kartsirasi, ref int _siradakideger)
        {
            int siradaki_sayi = SiradakiSayi[_kartsirasi];
            Operator_List islem = (Operator_List)Operatorler[_kartsirasi - 1];
            string islemsembol = IslemSembolEkle(islem);
            _siradakideger = YeniDegerHesapla(_simdikisayi, siradaki_sayi, islem);
            return string.Format("{0} {1} {2} = {3}", _simdikisayi, islemsembol, siradaki_sayi, _siradakideger);
        }

        private string IslemSembolEkle(Operator_List Operator)
        {
            switch (Operator)
            {
                case Operator_List.Topla:
                    return "+";
                case Operator_List.Cikar:
                    return "-";
                case Operator_List.Carp:
                    return "*";
                case Operator_List.Bol:
                    return "/";
                default:
                    return null;
            }
        }

        private int YeniDegerHesapla(int _sayi1, int _sayi2, Operator_List _islem)
        {
            switch (_islem)
            {
                case Operator_List.Topla:
                    return _sayi1 + _sayi2;
                case Operator_List.Cikar:
                    return _sayi1 - _sayi2;
                case Operator_List.Carp:
                    return _sayi1 * _sayi2;
                case Operator_List.Bol:
                    return _sayi1 / _sayi2;
                default:
                    return -1;
            }
        }
    }
}
