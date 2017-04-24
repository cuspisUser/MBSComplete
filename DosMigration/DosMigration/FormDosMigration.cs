using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.SmartParts;

namespace DosMigration
{
    [SmartPart]
    public partial class FormDosMigracija : Form
    {
        public FormDosMigracija()
        {
            InitializeComponent();
            importData();
        }

        void importData()
        {
            Dbf dbf = new Dbf();

            String path = dbf.getPath();

            if (path != String.Empty)
            {
                toolStripStatusLabel.Text = path;

                Dictionary<string, int> columns = new Dictionary<string, int>();

                // Key-Value-Pair (DJELAT.DBF)
                columns.Add("SIFRA", 1);
                columns.Add("NAZIV", 2);
                columns.Add("SPOL", 3);
                columns.Add("OPCINA_1", 6);
                columns.Add("KOEF", 10);
                columns.Add("FOND_SATI", 11);
                columns.Add("MBO", 12);
                columns.Add("JMBG", 13);
                columns.Add("DAT_STAZ", 17);
                columns.Add("DAT_PREST", 18);
                columns.Add("GODINA_1", 19);
                columns.Add("MJESEC_1", 20);
                columns.Add("DANI_1", 21);
                columns.Add("RAD_RADI", 29);
                columns.Add("MJESTO_D", 33);
                columns.Add("ULICA1_D", 34);
                columns.Add("KBR_D", 36);
                columns.Add("HRVI_POST", 40);
                columns.Add("PK2", 41);
                columns.Add("C_OIB", 43);

                if (dbf.getDataGrid(dataGridView1, toolStripStatusLabel.Text, columns))
                {
                    migracijaToolStripMenuItem.Enabled = true;
                    this.Show();
                }

                columns.Clear();
                columns.Add("SIFRA_D", 1);
                columns.Add("NAZIV_D", 2);
                columns.Add("SIFRA_O", 3);
                columns.Add("PRIMALAC_O", 4);
                columns.Add("UPLACENO", 5);
                columns.Add("POZ_BR_O", 6);

                //String path = toolStripStatusLabel.Text;
                String[] pathElements = path.Split('\\');
                path = "";

                for (int i = 0; i < pathElements.Count() - 1; i++)
                {
                    path += pathElements[i] + "\\";
                }

                dbf.getDataGrid(dataGridView2, path + "ISPLATE.DBF", columns);

                columns.Clear();
                columns.Add("SIFRA", 1);
                columns.Add("NAZIV", 2);
                dbf.getDataGrid(dataGridView4, path + "OPCINE.DBF", columns);

                for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
                {
                    toolStripComboBox1.Items.Add(dataGridView4[0, i].Value.ToString() + " " + dataGridView4[1, i].Value.ToString());
                }

                columns.Clear();
                columns.Add("SIFRA", 1);
                columns.Add("SIFRA_OP", 2);
                columns.Add("ISP_PRIMAC", 11);
                columns.Add("OPC_PRIMAC", 12);
                columns.Add("ZIP_PRIMAC", 13);

                dbf.getDataGrid(dataGridView5, path + "ID_OBR.DBF", columns);

                Mdf mdf = new Mdf();
                mdf.getDataGrid(dataGridView3, "BANKE");
            }
        }

        private void migracijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PutMipsedDB putMipsedDB = new PutMipsedDB();

            bool imeRadnika = true;

            if (prezimeImeToolStripMenuItem.Checked)
            {
                imeRadnika = true;
            }
            else if (imePrezimeToolStripMenuItem.Checked)
            {
                imeRadnika = false;
            }

            putMipsedDB.putDB(dataGridView1, dataGridView2, dataGridView3, dataGridView5, toolStripComboBox1, imeRadnika);
            //migracijaToolStripMenuItem.Enabled = false;
            this.Show();
        }

        private void prezimeImeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prezimeImeToolStripMenuItem.Checked = true;
            imePrezimeToolStripMenuItem.Checked = false;
        }

        private void imePrezimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prezimeImeToolStripMenuItem.Checked = false;
            imePrezimeToolStripMenuItem.Checked = true;
        }
    }
}
