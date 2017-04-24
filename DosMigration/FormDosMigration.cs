using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DosMigration
{
    public partial class FormDosMigracija : Form
    {
        public FormDosMigracija()
        {
            InitializeComponent();
            OpenDbf();
        }

        void OpenDbf()
        {
            OpenDbf openDbf = new OpenDbf();
            toolStripStatusLabel.Text = openDbf.getPath();

            if (openDbf.getDataGrid(dataGridViewDosMigracija, toolStripStatusLabel.Text))
            {
                migracijaToolStripMenuItem.Enabled = true;
                this.Show();
            }
        }

        private void migracijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PutMipsedDB putMipsedDB = new PutMipsedDB();
            putMipsedDB.putDB(dataGridViewDosMigracija);
            migracijaToolStripMenuItem.Enabled = false;
            this.Show();
        }
    }
}
