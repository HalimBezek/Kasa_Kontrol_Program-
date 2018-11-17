using MySql.Data.MySqlClient;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btn_ekle_Click(object sender, EventArgs e)
        {
            string yil, ay, gun, tarih;
            ////////GELİRLER
            double gunluksatisEU = Convert.ToDouble(tb_gunluksE.Text);
            double gunluksatisDolar = Convert.ToDouble(tb_gunluksD.Text);
            double gunluksatisTL = Convert.ToDouble(tb_gunluksTL.Text);

            double veresiyeSatisEU = Convert.ToDouble(tb_veresiyesE.Text); //dahil edilmedi
            double veresiyeSatisDolar = Convert.ToDouble(tb_veresiyesD.Text);
            double veresiyeSatisTL = Convert.ToDouble(tb_veresiyesTL.Text);

            double veresiyeTahsilatEU = Convert.ToDouble(tb_veresiyetahE.Text);
            double veresiyeTahsilatDolar = Convert.ToDouble(tb_veresiyetahD.Text);
            double veresiyeTahsilatTL = Convert.ToDouble(tb_veresiyetahTL.Text);

            double k_kartiSatisEU = Convert.ToDouble(tb_kksatisE.Text); //dahil edilmedi
            double k_kartiSatisDolar = Convert.ToDouble(tb_kksatisD.Text);
            double k_kartiSatisTL = Convert.ToDouble(tb_kksatisTL.Text);

            double kaporaEU = Convert.ToDouble(tbkaporaE.Text);
            double kaporaDolar = Convert.ToDouble(tbkaporaD.Text);
            double kaporaTL = Convert.ToDouble(tbkaporaTL.Text);

            double toplamGelirEU = gunluksatisEU + veresiyeTahsilatEU + kaporaEU;
            double toplamGelirDolar = gunluksatisDolar + veresiyeTahsilatDolar + kaporaDolar;
            double toplamGelirTL = gunluksatisTL + veresiyeTahsilatTL + kaporaTL;


            lbl_toplamgelir.Text = "Günlük Toplam Gelir=  €:"+toplamGelirEU + "  $:"+toplamGelirDolar + "  TL:"+toplamGelirTL ;


            ////////GİDERLER

            double dukkangiderleriEU = Convert.ToDouble(tb_dukkangiderE.Text);
            double dukkangiderleriDolar = Convert.ToDouble(tb_dukkangiderD.Text);
            double dukkangiderleriTL = Convert.ToDouble(tb_dukkangiderTL.Text);

            double iadealinanEU = Convert.ToDouble(tb_iadealinanE.Text);
            double iadealinanDolar = Convert.ToDouble(tb_iadealinanD.Text);
            double iadealinanTL = Convert.ToDouble(tb_iadealinanTL.Text);

            double firmaödemeleriEU = Convert.ToDouble(tb_firmaödE.Text);
            double firmaödemeleriDolar = Convert.ToDouble(tb_firmaödD.Text);
            double firmaödemeleriTL = Convert.ToDouble(tb_firmaödTL.Text);

            double pesinalinanödemeEU = Convert.ToDouble(tb_pesinalinanE.Text);
            double pesinalinanödemeDolar = Convert.ToDouble(tb_pesinalinanD.Text);
            double pesinalinanödemeTL = Convert.ToDouble(tb_pesinalinanTL.Text);

            double resuldödemeEU = Convert.ToDouble(tb_ResulDödemeE.Text);
            double resuldödemeDolar = Convert.ToDouble(tb_ResulDödemeD.Text);
            double resuldödemeTL = Convert.ToDouble(tb_ResulDödemeTL.Text);

            double eleman1EU = Convert.ToDouble(tb_eleman1E.Text);
            double eleman1Dolar = Convert.ToDouble(tb_eleman1D.Text);
            double eleman1TL = Convert.ToDouble(tb_eleman1TL.Text);

            double eleman2EU = Convert.ToDouble(tb_eleman2E.Text);
            double eleman2Dolar = Convert.ToDouble(tb_eleman2D.Text);
            double eleman2TL = Convert.ToDouble(tb_eleman2TL.Text);

            double toplamGiderEU = dukkangiderleriEU + iadealinanEU + firmaödemeleriEU + pesinalinanödemeEU +
                resuldödemeEU + eleman1EU + eleman2EU;

            double toplamGiderDolar = dukkangiderleriDolar + iadealinanDolar + firmaödemeleriDolar + pesinalinanödemeDolar +
                resuldödemeDolar + eleman1Dolar + eleman2Dolar;

            double toplamGiderTL = dukkangiderleriTL + iadealinanTL + firmaödemeleriTL + pesinalinanödemeTL +
                resuldödemeTL + eleman1TL + eleman2TL;

            lbl_toplamGidergoster.Text = "Günlük Toplam Gider= €:" + toplamGiderEU + "  $:" + toplamGiderDolar +
                "  TL:" + toplamGiderTL;

            double gunlukKasaEU = toplamGelirEU - toplamGiderEU;
            double gunlukKasaD = toplamGelirDolar - toplamGiderDolar;
            double gunlukKasaTL = toplamGelirTL - toplamGiderTL;


            lbltoplamGoster.Text = "***********Günlük Kasa : €:" + gunlukKasaEU + "  $:" + gunlukKasaD +
                "  TL:" + gunlukKasaTL + "  ************";

            
            
            
            

            DateTime DTIME = Convert.ToDateTime(datetpislemtarihi.Text);
            yil = DTIME.Date.Year.ToString();
            ay = DTIME.Date.Month.ToString();
            gun = DTIME.Date.Day.ToString();

            if (ay.Length <= 1)
            {
                ay = "0" + ay;
            }

            tarih = yil + "-" + ay + "-" + gun;
            string dbAy = ay + "/" + yil;
            
            DatabaseClass database = new DatabaseClass();
            try
            {

             //TOPLAM VE ORTALAMA DEĞERLERİN KAYDEDİLDİĞİ METOT
            database.kayitEkle(tarih, dbAy, gunlukKasaEU, gunlukKasaD, gunlukKasaTL,yil);

            //GİDERLERİN KAYDEDİLMESİ
            string mesaj11 = database.kayitEkleDGiderleri(tarih, dukkangiderleriEU, dukkangiderleriDolar, dukkangiderleriTL, 1);
            string mesaj12 = database.kayitEkleIAlinan(tarih, iadealinanEU, iadealinanDolar, iadealinanTL, 2);
            string mesaj13 = database.kayitEkleFOdemeleri(tarih, firmaödemeleriEU, firmaödemeleriDolar, firmaödemeleriTL, 3);
            string mesaj14 = database.kayitEklePAlinanO(tarih, pesinalinanödemeEU, pesinalinanödemeDolar, pesinalinanödemeTL, 4);
            string mesaj15 = database.kayitEkleR_D_Odemeler(tarih, resuldödemeEU, resuldödemeDolar, resuldödemeTL, 5);
            string mesaj16 = database.kayitEkleEleman1(tarih, eleman1EU, eleman1Dolar, eleman1TL, 6);
            string mesaj17 = database.kayitEkleEleman2(tarih, eleman2EU, eleman2Dolar, eleman2TL, 7);


            //GELİRLERİN KAYDEDİLMESİ
            string mesaj1 = database.kayitEkleGSatis(tarih, gunluksatisEU, gunluksatisDolar, gunluksatisTL,1);
            string mesaj2 = database.kayitEkleVSatis(tarih, veresiyeSatisEU, veresiyeSatisDolar, veresiyeSatisTL,2);
            string mesaj3 = database.kayitEkleVTahsilat(tarih, veresiyeTahsilatEU, veresiyeTahsilatDolar, veresiyeTahsilatTL,3);
            string mesaj4 = database.kayitEkleKKSatis(tarih, k_kartiSatisEU, k_kartiSatisDolar, k_kartiSatisTL,4);
            string mesaj5 = database.kayitEkleKapora(tarih, kaporaEU, kaporaDolar, kaporaTL,5);

            MessageBox.Show("Kayıt Başarılı", "Bilgilendirme");
            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu. Aynı tarihte kayıt olmadığından emin olun.", "Bilgilendirme");
         
            }




           


        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            string yil, ay, gun;
            dataGridgKasa.Columns.Clear();
            
            DatabaseClass database = new DatabaseClass();

            yil = DateTime.Now.Date.Year.ToString();
            ay = DateTime.Now.Date.Month.ToString();
            gun = DateTime.Now.Date.Day.ToString();

            string secili_gun, secili_gunt; // henuz kullanılmıyor.
            if (gun.Length > 1)
            {
                secili_gun = (Convert.ToDouble(gun) - 1).ToString();
                secili_gunt = secili_gun + "/" + ay + "/" + yil;
            }
            else
            {
                secili_gun = "0";
                secili_gunt = gun + "/" + ay + "/" + yil;
            }

            string secili_ay;
            if (ay.Length > 1)
            {
                secili_ay =ay + "/" + yil;
            }
            else secili_ay = "0" + ay + "/" + yil;

            string sql = "Select `Tarih`, `aylar`, `Euro`, `Dolar`, `TL` from günlük_kasa WHERE aylar = '" + secili_ay + "'";
            
            dataGridgKasa.DataSource = database.ListData(sql);

            dataGridgKasa.Columns[0].HeaderText = "TARİH";
            dataGridgKasa.Columns[1].HeaderText = "AYLAR";
            dataGridgKasa.Columns[2].HeaderText = "EURO";
            dataGridgKasa.Columns[3].HeaderText = "DOLAR";
            dataGridgKasa.Columns[4].HeaderText = "TL";

            // dataGridgKasa.Columns[0].Visible = false;
            if (dataGridgKasa.RowCount > 1)
            {
                List<string> topalmdegerler = database.ListDatatab(secili_ay);
                lblEuro.Text = " € : " + topalmdegerler[0];
                lblDolar.Text = " $ : " + topalmdegerler[1];
                lblTL.Text = " TL : " + topalmdegerler[2];
            }
            else
            {
                lblEuro.Text = " € : 0";
                lblDolar.Text = " $ : 0";
                lblTL.Text = " TL : 0";
            }
           
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            tb_dukkangiderE.Text = "0"; tb_dukkangiderD.Text = "0"; tb_dukkangiderTL.Text = "0";
            tb_iadealinanE.Text = "0"; tb_iadealinanD.Text = "0"; tb_iadealinanTL.Text = "0";
            tb_firmaödE.Text = "0"; tb_firmaödD.Text = "0"; tb_firmaödTL.Text = "0";
            tb_pesinalinanE.Text = "0"; tb_pesinalinanD.Text = "0"; tb_pesinalinanTL.Text = "0";
            tb_ResulDödemeE.Text = "0"; tb_ResulDödemeD.Text = "0"; tb_ResulDödemeTL.Text = "0";
            tb_eleman1E.Text = "0"; tb_eleman1D.Text = "0"; tb_eleman1TL.Text = "0";
            tb_eleman1E.Text = "0"; tb_eleman2D.Text = "0"; tb_eleman2TL.Text = "0";

            tb_gunluksE.Text = "0"; tb_gunluksD.Text = "0"; tb_gunluksTL.Text = "0";
            tb_veresiyetahE.Text = "0"; tb_veresiyetahD.Text = "0"; tb_veresiyetahTL.Text = "0";
            tb_veresiyesE.Text = "0"; tb_veresiyesD.Text = "0"; tb_veresiyesTL.Text = "0";
            tb_kksatisE.Text = "0"; tb_kksatisD.Text = "0"; tb_kksatisTL.Text = "0";
            tbkaporaE.Text = "0"; tbkaporaD.Text = "0"; tbkaporaTL.Text = "0";



        }

        private void btn_ayrintilikasa_Click(object sender, EventArgs e)
        {
            Ayrintilar ayrintiekrani = new Ayrintilar();
            ayrintiekrani.Show();
        }

        private void tb_gunluksE_TextChanged(object sender, EventArgs e)
        {
        

        }

        private void tb_gunluksE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar!=44)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
            
          
        }

        private void Sil_Click(object sender, EventArgs e)
        {
            if (dataGridgKasa.Rows[0].Cells[0].Value != null) 
            {
                string yil, ay, gun;
                string secili_gun = dataGridgKasa.CurrentRow.Cells[0].Value.ToString();
                string[] kesim1 = secili_gun.Split(' ');
                string[] kesim2 = kesim1[0].Split('.');

                yil = kesim2[2];
                ay = kesim2[1];
                gun = kesim2[0];
                string del_tarih = yil + "-" + ay + "-" + gun;

                DatabaseClass database = new DatabaseClass();

                string sorgu = "Delete  FROM `günlük_kasa` WHERE tarih = '" + del_tarih + "'";

                string sorgugelir = "Delete  FROM `para_degerleri` WHERE tarih = '" + del_tarih + "'";

                string sorgugider = "Delete  FROM `para_degerleri_giderler` WHERE tarih = '" + del_tarih + "'";

                database.deleteData(sorgu);
                database.deleteData(sorgugelir);
                database.deleteData(sorgugider);

                btn_listele_Click(sender, e);
            }
            else { MessageBox.Show("Stunlar boş olduğundan işlem yapılamaz", "Uyarı"); }
           
        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //datetpislemtarihi.MaxDate = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Month , 0, 0, 0, 0);
          //  datetpislemtarihi.MinDate = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month,1, 0, 0, 0, 0);

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
