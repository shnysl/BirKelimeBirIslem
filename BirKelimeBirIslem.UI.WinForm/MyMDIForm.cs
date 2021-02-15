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
    public partial class MyMDIForm : Form
    {
        public MyMDIForm()
        {
            InitializeComponent();
        }

        void ChildForm(Form _ChildForm)
        {
            foreach (Form item in this.MdiChildren)
            {
                item.Close();
            }
            this.Width = _ChildForm.Width + 20;
            this.Height = _ChildForm.Height + 70;
            _ChildForm.MdiParent = this;
            _ChildForm.Dock = DockStyle.Fill;
            _ChildForm.Show();
        }

        private void iŞLEMOYUNUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm(new IslemForm());
        }

        private void kELİMEOYUNUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm(new KelimeForm());
        }

        private void hAKKIMIZDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm(new HakkimizdaForm());
        }
    }
}
