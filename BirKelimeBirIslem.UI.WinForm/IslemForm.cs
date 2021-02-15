using BirKelimeBirIslem.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirKelimeBirIslemYeni
{
    public partial class IslemForm : Form
    {
        public IslemForm()
        {
            InitializeComponent();
            btnSayiUret.Click += btnSayiUret_Click;
            btnCoz.Click += btnCoz_Click;
            cbSayiGirisi.Click += cbSayiGirisi_CheckedChanged;
        }
        Oyun oyun = new Oyun();
        private DateTime _startTime = DateTime.Now;
        private TimeSpan _timeSpan = new TimeSpan(0, 1, 0);
        System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();

        private void VeriKontrol()
        {
            if (string.IsNullOrEmpty(tbSayi1.Text)) tbSayi1.Text = "1";
            if (string.IsNullOrEmpty(tbSayi2.Text)) tbSayi2.Text = "1";
            if (string.IsNullOrEmpty(tbSayi3.Text)) tbSayi3.Text = "1";
            if (string.IsNullOrEmpty(tbSayi4.Text)) tbSayi4.Text = "1";
            if (string.IsNullOrEmpty(tbSayi5.Text)) tbSayi5.Text = "1";
            if (string.IsNullOrEmpty(tbSayi6.Text)) tbSayi6.Text = "10";
            if (string.IsNullOrEmpty(tbHedefSayi.Text)) tbHedefSayi.Text = "100";
        }
        private void IslemForm_Load(object sender, EventArgs e)
        {
            mtbSure.Text = "00:00";
        }
        private void cbSayiGirisi_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSayiGirisi.Checked)
            {
                foreach (Control item in gbSayilar.Controls)
                {
                    if (item is MaskedTextBox)
                    {
                        MaskedTextBox textBox = (MaskedTextBox)item;
                        textBox.ReadOnly = false;
                    }
                }
            }
            else
            {
                foreach (Control item in gbSayilar.Controls)
                {
                    if (item is MaskedTextBox)
                    {
                        MaskedTextBox textBox = (MaskedTextBox)item;
                        textBox.ReadOnly = true;
                    }
                }
            }
        }

        private void tbSayi1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnSayiUret_Click(object sender, EventArgs e)
        {
            try
            {
                oyun = new Oyun();

                //tbCozum.Text = "";

                tbSayi1.Text = oyun.TekBasamakli[0].ToString();
                tbSayi2.Text = oyun.TekBasamakli[1].ToString();
                tbSayi3.Text = oyun.TekBasamakli[2].ToString();
                tbSayi4.Text = oyun.TekBasamakli[3].ToString();
                tbSayi5.Text = oyun.TekBasamakli[4].ToString();
                tbSayi6.Text = oyun.CiftBasamakli.ToString();
                tbHedefSayi.Text = oyun.HedefSayi.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCoz_Click(object sender, EventArgs e)
        {
            try
            {
                VeriKontrol();
                tbCozum.Text = "";

                oyun.TekBasamakli[0] = Convert.ToInt32(tbSayi1.Text);
                oyun.TekBasamakli[1] = Convert.ToInt32(tbSayi2.Text);
                oyun.TekBasamakli[2] = Convert.ToInt32(tbSayi3.Text);
                oyun.TekBasamakli[3] = Convert.ToInt32(tbSayi4.Text);
                oyun.TekBasamakli[4] = Convert.ToInt32(tbSayi5.Text);
                oyun.CiftBasamakli = Convert.ToInt32(tbSayi6.Text);
                oyun.HedefSayi = Convert.ToInt32(tbHedefSayi.Text);

                st.Start();
                var ifd = oyun.Basla();
                st.Stop();
                mtbSure.Text = st.Elapsed.Seconds + ":" + st.Elapsed.Milliseconds;
                tbCozum.Text = ifd.ToString();
                //lstCozum.Items.Add(ifd.ToString());
                tbPuan.Text = ifd.puan.ToString();

                st.Reset();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
