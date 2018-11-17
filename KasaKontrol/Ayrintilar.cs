using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KasaKontrol
{
    public partial class Ayrintilar : Form
    {
        public Ayrintilar()
        {
            InitializeComponent();
        }

        private void Ayrintilar_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void Ayrintilar_Load(object sender, EventArgs e)
        {
            DatabaseClass database = new DatabaseClass();

            string sql = "select HANGI_YIL, SUM(Euro) as EuroT, SUM(Dolar) as DolarT, SUM(TL) as TLT FROM `günlük_kasa` GROUP BY HANGI_YIL";

            datagridYillikKasa.DataSource = database.ListData(sql);

            datagridYillikKasa.Columns[0].HeaderText = "HANGİ YIL?";
            datagridYillikKasa.Columns[1].HeaderText = "EURO";
            datagridYillikKasa.Columns[2].HeaderText = "DOLAR";
            datagridYillikKasa.Columns[3].HeaderText = "TL";



            string sqlay = "select aylar, SUM(Euro) as EuroT, SUM(Dolar) as DolarT, SUM(TL) as TLT FROM `günlük_kasa` GROUP BY aylar";

            dtgridaylikkasa.DataSource = database.ListData(sqlay);

            dtgridaylikkasa.Columns[0].HeaderText = "HANGİ AY?";
            dtgridaylikkasa.Columns[1].HeaderText = "EURO";
            dtgridaylikkasa.Columns[2].HeaderText = "DOLAR";
            dtgridaylikkasa.Columns[3].HeaderText = "TL";
       
        }

        private void dtgridaylikkasa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgridaylikkasa.ColumnCount > 0)
                {
                    dtgridaylikayrintlikasa.Columns.Clear();

                    string secili_ay = dtgridaylikkasa.CurrentRow.Cells[0].Value.ToString();

                    DatabaseClass database = new DatabaseClass();

                    string sorgu = "Select * FROM `günlük_kasa` WHERE aylar = '" + secili_ay + "'";

                    dtgridaylikayrintlikasa.DataSource = database.ListData(sorgu);

                    dtgridaylikayrintlikasa.Columns[0].HeaderText = "TARİH";
                    dtgridaylikayrintlikasa.Columns[1].HeaderText = "AYLAR";
                    dtgridaylikayrintlikasa.Columns[2].HeaderText = "EURO";
                    dtgridaylikayrintlikasa.Columns[3].HeaderText = "DOLAR";
                    dtgridaylikayrintlikasa.Columns[4].HeaderText = "TL";
                    dtgridaylikayrintlikasa.Columns[5].HeaderText = "Hangi Yıl";
                }

            }
            catch (Exception)
            {
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void datagridYillikKasa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DatabaseClass database = new DatabaseClass();
            try
            {
                if (datagridYillikKasa.ColumnCount > 0)
                {
                    dtgridaylikkasa.Columns.Clear();

                    string secili_yil = datagridYillikKasa.CurrentRow.Cells[0].Value.ToString();

                    string sqlay = "select aylar, SUM(Euro) as EuroT, SUM(Dolar) as DolarT, SUM(TL) as TLT FROM `günlük_kasa` WHERE HANGI_YIL = '" + secili_yil + "' GROUP BY aylar";

                    dtgridaylikkasa.DataSource = database.ListData(sqlay);

                    dtgridaylikkasa.Columns[0].HeaderText = "HANGİ AY?";
                    dtgridaylikkasa.Columns[1].HeaderText = "EURO";
                    dtgridaylikkasa.Columns[2].HeaderText = "DOLAR";
                    dtgridaylikkasa.Columns[3].HeaderText = "TL";
                }


            }
            catch (Exception)
            {
            }
            
               
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            Sorgula2 s = new Sorgula2();

            s.Show();
        }
    }
}
