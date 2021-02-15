using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BirKelimeBirIslem.BLL;
using BirKelimeBirIslem.Model;
using ClassLibrary1;
using LinqToExcel;

namespace BirKelimeBirIslemYeni
{
    public partial class KelimeForm : Form
    {
        public KelimeForm()
        {
            InitializeComponent();
            btnHarfUret.Click += btnHarfUret_Click;
        }
        KelimeController _kelimeController = new KelimeController();
        Random rnd = new Random();
        List<string> Harfler;

        private DateTime _startTime = DateTime.Now;
        private TimeSpan _timeSpan = new TimeSpan(0, 1, 0);
        System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();
        private List<string> HarflerOlustur()
        {
            List<string> karakterListesi = new List<string>() { "A", "B", "C", "Ç", "D", "E", "F", "G", "Ğ", "H", "I", "İ", "J", "K", "L", "M", "N", "O", "Ö", "P", "R", "S", "Ş", "T", "U", "Ü", "V", "Y", "Z" };

            List<string> harfler = new List<string>();
            for (int i = 0; i < 8; i++)
            {
                harfler.Add(karakterListesi[rnd.Next(1, karakterListesi.Count)]);
            }
            return harfler;
        }
        private bool VeriKontrol()
        {
            if (_kelimeController == null)
            {
                return false;
            }
            else
            {
                if (string.IsNullOrEmpty(tbHarf1.Text)) tbHarf1.Text = "A";
                if (string.IsNullOrEmpty(tbHarf2.Text)) tbHarf2.Text = "A";
                if (string.IsNullOrEmpty(tbHarf3.Text)) tbHarf3.Text = "A";
                if (string.IsNullOrEmpty(tbHarf4.Text)) tbHarf4.Text = "A";
                if (string.IsNullOrEmpty(tbHarf5.Text)) tbHarf5.Text = "A";
                if (string.IsNullOrEmpty(tbHarf6.Text)) tbHarf6.Text = "A";
                if (string.IsNullOrEmpty(tbHarf7.Text)) tbHarf7.Text = "A";
                if (string.IsNullOrEmpty(tbHarf8.Text)) tbHarf8.Text = "A";
                if (string.IsNullOrEmpty(tbJokerHarf.Text)) tbJokerHarf.Text = "A-Z";
                return true;
            }
        }
        private void cbHarfGirisi_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHarfGirisi.Checked)
            {
                foreach (Control item in gbHarfler.Controls)
                {
                    if (item is TextBox)
                    {
                        TextBox textBox = (TextBox)item;
                        textBox.ReadOnly = false;
                    }
                }
            }
            else
            {
                foreach (Control item in gbHarfler.Controls)
                {
                    if (item is TextBox)
                    {
                        TextBox textBox = (TextBox)item;
                        textBox.ReadOnly = true;
                    }
                }
            }
        }
        
        private void tbHarf1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int a = e.KeyChar;
            if (a == 120 || a == 88 || a == 113 || a == 81 || a == 119 || a == 87)
            {
                e.Handled = true;
            }
            else if (a >= 97 && a <= 104 || a >=106 && a<= 122)
            {
                e.KeyChar = (char)((int)(e.KeyChar - 32));
            }
            if (a == 231)
            {
                e.KeyChar = (char)((int)(199));
            }
            else if (a == 305)
            {
                e.KeyChar = (char)((int)(73));
            }
            else if (a == 287)
            {
                e.KeyChar = (char)((int)(286));
            }
            else if (a == 246)
            {
                e.KeyChar = (char)((int)(214));
            }
            else if (a == 351)
            {
                e.KeyChar = (char)((int)(350));
            }
            else if (a == 252)
            {
                e.KeyChar = (char)((int)(220));
            }
            else if (a == 105)
            {
                e.KeyChar = (char)((int)(304));
            }
        }

        private void btnHarfUret_Click(object sender, EventArgs e)
        {
             Harfler = HarflerOlustur();
            try
            {
                if (VeriKontrol())
                {
                    tbCozum.Text = "";

                    tbHarf1.Text = Harfler[0].ToString();
                    tbHarf2.Text = Harfler[1].ToString();
                    tbHarf3.Text = Harfler[2].ToString();
                    tbHarf4.Text = Harfler[3].ToString();
                    tbHarf5.Text = Harfler[4].ToString();
                    tbHarf6.Text = Harfler[5].ToString();
                    tbHarf7.Text = Harfler[6].ToString();
                    tbHarf8.Text = Harfler[7].ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void KelimeForm_Load(object sender, EventArgs e)
        {
            VeriKontrol();
        }

        private void btnCoz_Click(object sender, EventArgs e)
        {
            st.Start();
            var ifd = new KelimeAra(_kelimeController.GetKelimeList(), Harfler);
            st.Stop();
            mtbSure.Text = st.Elapsed.Seconds + ":" + st.Elapsed.Milliseconds;
            tbCozum.Text = ifd.ToString();
            tbPuan.Text = ifd.puan.ToString();
            st.Reset();
        }
    }
}
