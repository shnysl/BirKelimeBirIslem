namespace BirKelimeBirIslemYeni
{
    partial class MyMDIForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.iŞLEMOYUNUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kELİMEOYUNUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hAKKIMIZDAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iŞLEMOYUNUToolStripMenuItem,
            this.kELİMEOYUNUToolStripMenuItem,
            this.hAKKIMIZDAToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(851, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // iŞLEMOYUNUToolStripMenuItem
            // 
            this.iŞLEMOYUNUToolStripMenuItem.Name = "iŞLEMOYUNUToolStripMenuItem";
            this.iŞLEMOYUNUToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.iŞLEMOYUNUToolStripMenuItem.Text = "İŞLEM OYUNU";
            this.iŞLEMOYUNUToolStripMenuItem.Click += new System.EventHandler(this.iŞLEMOYUNUToolStripMenuItem_Click);
            // 
            // kELİMEOYUNUToolStripMenuItem
            // 
            this.kELİMEOYUNUToolStripMenuItem.Name = "kELİMEOYUNUToolStripMenuItem";
            this.kELİMEOYUNUToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.kELİMEOYUNUToolStripMenuItem.Text = "KELİME OYUNU";
            this.kELİMEOYUNUToolStripMenuItem.Click += new System.EventHandler(this.kELİMEOYUNUToolStripMenuItem_Click);
            // 
            // hAKKIMIZDAToolStripMenuItem
            // 
            this.hAKKIMIZDAToolStripMenuItem.Name = "hAKKIMIZDAToolStripMenuItem";
            this.hAKKIMIZDAToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.hAKKIMIZDAToolStripMenuItem.Text = "HAKKIMIZDA";
            this.hAKKIMIZDAToolStripMenuItem.Click += new System.EventHandler(this.hAKKIMIZDAToolStripMenuItem_Click);
            // 
            // MyMDIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 533);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "MyMDIForm";
            this.Text = "BİR KELİME BİR İŞLEM";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iŞLEMOYUNUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kELİMEOYUNUToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hAKKIMIZDAToolStripMenuItem;
    }
}