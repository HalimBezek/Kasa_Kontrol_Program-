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
       // public string isUpdatedate = "";
        private string isUpdateDate ="";
       // private object isUpdatedate;

        public Form1()
        {
            InitializeComponent();
        }


        private void btn_ekle_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show(datetpislemtarihi.Text + " Tarihine kayıt eklenecek" + "\n" + "Devam etmek istiyor musunuz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek == DialogResult.Yes)
            {
                ekleveGüncelle("");
                btn_listele_Click(sender, e);
            }
            else { }
        }
        private void ekleveGüncelle(String isUpdatedate2)
        {  
            string yil, ay, gun, tarih;
             isUpdateDate = isUpdatedate2;
            if (!isUpdateDate.ToString().Equals(""))
            {
                DateTime DTIME2 = Convert.ToDateTime(isUpdateDate.ToString());
                yil = DTIME2.Date.Year.ToString();
                ay = DTIME2.Date.Month.ToString();
                gun = DTIME2.Date.Day.ToString();

               // isUpdateDate = isUpdatedate2;
                if (ay.Length <= 1)
                {
                    ay = "0" + ay;
                }
                if (gun.Length <= 1)
                {
                    gun = "0" + gun;
                }
                isUpdateDate = yil + "-" + ay + "-" + gun;
            }
            else
            {
                isUpdateDate = "";
            }
            ////////GELİRLER
            double gunluksatisEU;
            double.TryParse(tb_gunluksE.Text, out gunluksatisEU);
            //= Convert.ToDouble(tb_gunluksE.Text);
            double gunluksatisDolar; double.TryParse(tb_gunluksD.Text, out gunluksatisDolar);// = Convert.ToDouble(tb_gunluksD.Text);
            double gunluksatisTL; double.TryParse(tb_gunluksTL.Text, out gunluksatisTL);// = Convert.ToDouble(tb_gunluksTL.Text);

            double veresiyeSatisEU; double.TryParse(tb_veresiyesE.Text, out veresiyeSatisEU);// = Convert.ToDouble(tb_veresiyesE.Text); //dahil edilmedi
            double veresiyeSatisDolar; double.TryParse(tb_veresiyesD.Text, out veresiyeSatisDolar);// = Convert.ToDouble(tb_veresiyesD.Text);
            double veresiyeSatisTL; double.TryParse(tb_veresiyesTL.Text, out veresiyeSatisTL);// = Convert.ToDouble(tb_veresiyesTL.Text);

            double veresiyeTahsilatEU; double.TryParse(tb_veresiyetahE.Text, out veresiyeTahsilatEU);// = Convert.ToDouble(tb_veresiyetahE.Text);
            double veresiyeTahsilatDolar; double.TryParse(tb_veresiyetahD.Text, out veresiyeTahsilatDolar);// = Convert.ToDouble(tb_veresiyetahD.Text);
            double veresiyeTahsilatTL; double.TryParse(tb_veresiyetahTL.Text, out veresiyeTahsilatTL);// = Convert.ToDouble(tb_veresiyetahTL.Text);

            double k_kartiSatisEU; double.TryParse(tb_kksatisE.Text, out k_kartiSatisEU);// = Convert.ToDouble(tb_kksatisE.Text); //dahil edilmedi//dahil edilecek
            double k_kartiSatisDolar; double.TryParse(tb_kksatisD.Text, out k_kartiSatisDolar);// = Convert.ToDouble(tb_kksatisD.Text);
            double k_kartiSatisTL; double.TryParse(tb_kksatisTL.Text, out k_kartiSatisTL);// = Convert.ToDouble(tb_kksatisTL.Text);

            double kaporaEU; double.TryParse(tbkaporaE.Text, out kaporaEU);// = Convert.ToDouble(tbkaporaE.Text);
            double kaporaDolar; double.TryParse(tbkaporaD.Text, out kaporaDolar);// = Convert.ToDouble(tbkaporaD.Text);
            double kaporaTL; double.TryParse(tbkaporaTL.Text, out kaporaTL);// = Convert.ToDouble(tbkaporaTL.Text);

            double toplamGelirEU = gunluksatisEU + veresiyeTahsilatEU + kaporaEU + k_kartiSatisEU; //k-kartı satış sonradan eklendi
            double toplamGelirDolar= gunluksatisDolar + veresiyeTahsilatDolar + kaporaDolar + k_kartiSatisDolar;
            double toplamGelirTL  = gunluksatisTL + veresiyeTahsilatTL + kaporaTL + k_kartiSatisTL;
            
            lbl_toplamgelir.Text = "Günlük Toplam Gelir=  €:"+toplamGelirEU + "  $:"+toplamGelirDolar + "  TL:"+toplamGelirTL ;
                        
            ////////GİDERLER

            double dukkangiderleriEU; double.TryParse(tb_dukkangiderE.Text, out dukkangiderleriEU);// = Convert.ToDouble(tb_dukkangiderE.Text);
            double dukkangiderleriDolar; double.TryParse(tb_dukkangiderD.Text, out dukkangiderleriDolar);// = Convert.ToDouble(tb_dukkangiderD.Text);
            double dukkangiderleriTL; double.TryParse(tb_dukkangiderTL.Text, out dukkangiderleriTL);// = Convert.ToDouble(tb_dukkangiderTL.Text);

            double iadealinanEU; double.TryParse(tb_iadealinanE.Text, out iadealinanEU);// = Convert.ToDouble(tb_iadealinanE.Text);
            double iadealinanDolar; double.TryParse(tb_iadealinanD.Text, out iadealinanDolar);// = Convert.ToDouble(tb_iadealinanD.Text);
            double iadealinanTL; double.TryParse(tb_iadealinanTL.Text, out iadealinanTL);// = Convert.ToDouble(tb_iadealinanTL.Text);

            double firmaödemeleriEU; double.TryParse(tb_firmaödE.Text, out firmaödemeleriEU);// = Convert.ToDouble(tb_firmaödE.Text);             
            double firmaödemeleriDolar; double.TryParse(tb_firmaödD.Text, out firmaödemeleriDolar);// = Convert.ToDouble(tb_firmaödD.Text);             
            double firmaödemeleriTL; double.TryParse(tb_firmaödTL.Text, out firmaödemeleriTL);// = Convert.ToDouble(tb_firmaödTL.Text);             

            double pesinalinanödemeEU; double.TryParse(tb_pesinalinanE.Text, out pesinalinanödemeEU);// = Convert.ToDouble(tb_pesinalinanE.Text);
            double pesinalinanödemeDolar; double.TryParse(tb_pesinalinanD.Text, out pesinalinanödemeDolar);// = Convert.ToDouble(tb_pesinalinanD.Text);
            double pesinalinanödemeTL; double.TryParse(tb_pesinalinanTL.Text, out pesinalinanödemeTL);// = Convert.ToDouble(tb_pesinalinanTL.Text);

            double resuldödemeEU; double.TryParse(tb_ResulDödemeE.Text, out resuldödemeEU);// = Convert.ToDouble(tb_ResulDödemeE.Text);
            double resuldödemeDolar; double.TryParse(tb_ResulDödemeD.Text, out resuldödemeDolar);// = Convert.ToDouble(tb_ResulDödemeD.Text);
            double resuldödemeTL; double.TryParse(tb_ResulDödemeTL.Text, out resuldödemeTL);// = Convert.ToDouble(tb_ResulDödemeTL.Text);

            double eleman1EU; double.TryParse(tb_eleman1E.Text, out eleman1EU);// = Convert.ToDouble(tb_eleman1E.Text);
            double eleman1Dolar; double.TryParse(tb_eleman1D.Text, out eleman1Dolar);// = Convert.ToDouble(tb_eleman1D.Text);
            double eleman1TL; double.TryParse(tb_eleman1TL.Text, out eleman1TL);// = Convert.ToDouble(tb_eleman1TL.Text);

            double eleman2EU; double.TryParse(tb_eleman2E.Text, out eleman2EU);// = Convert.ToDouble(tb_eleman2E.Text);
            double eleman2Dolar; double.TryParse(tb_eleman2D.Text, out eleman2Dolar);// = Convert.ToDouble(tb_eleman2D.Text);
            double eleman2TL; double.TryParse(tb_eleman2TL.Text, out eleman2TL);// = Convert.ToDouble(tb_eleman2TL.Text);

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


            //lbltoplamGoster.Text = "***********Günlük Kasa : €:" + gunlukKasaEU + "  $:" + gunlukKasaD +
            //    "  TL:" + gunlukKasaTL + "  ************";
            

            DateTime DTIME = Convert.ToDateTime(datetpislemtarihi.Text);
            yil = DTIME.Date.Year.ToString();
            ay = DTIME.Date.Month.ToString();
            gun = DTIME.Date.Day.ToString();

            if (ay.Length <= 1)
            {
                ay = "0" + ay;
            }
            if (gun.Length <= 1)
            {
                gun = "0" + gun;
            }

            tarih = yil + "-" + ay + "-" + gun;
            string dbAy = ay + "/" + yil;
            
            DatabaseClass database = new DatabaseClass();
            try
            {

             //TOPLAM VE ORTALAMA DEĞERLERİN KAYDEDİLDİĞİ METOT
            String kayit = database.kayitEkle(tarih, dbAy, gunlukKasaEU, gunlukKasaD, gunlukKasaTL,yil, isUpdateDate);

            if (kayit.Equals("Kayıt başarılı"))
            {
                //GİDERLERİN KAYDEDİLMESİ
                string mesaj11 = database.kayitEkleDGiderleri(tarih, dukkangiderleriEU, dukkangiderleriDolar, dukkangiderleriTL, 1, isUpdateDate);
                string mesaj12 = database.kayitEkleIAlinan(tarih, iadealinanEU, iadealinanDolar, iadealinanTL, 2, isUpdateDate);
                string mesaj13 = database.kayitEkleFOdemeleri(tarih, firmaödemeleriEU, firmaödemeleriDolar, firmaödemeleriTL, 3, isUpdateDate);
                string mesaj14 = database.kayitEklePAlinanO(tarih, pesinalinanödemeEU, pesinalinanödemeDolar, pesinalinanödemeTL, 4, isUpdateDate);
                string mesaj15 = database.kayitEkleR_D_Odemeler(tarih, resuldödemeEU, resuldödemeDolar, resuldödemeTL, 5, isUpdateDate);
                string mesaj16 = database.kayitEkleEleman1(tarih, eleman1EU, eleman1Dolar, eleman1TL, 6, isUpdateDate);
                string mesaj17 = database.kayitEkleEleman2(tarih, eleman2EU, eleman2Dolar, eleman2TL, 7, isUpdateDate);


                //GELİRLERİN KAYDEDİLMESİ
                string mesaj1 = database.kayitEkleGSatis(tarih, gunluksatisEU, gunluksatisDolar, gunluksatisTL, 1, isUpdateDate);
                string mesaj2 = database.kayitEkleVSatis(tarih, veresiyeSatisEU, veresiyeSatisDolar, veresiyeSatisTL, 2, isUpdateDate);
                string mesaj3 = database.kayitEkleVTahsilat(tarih, veresiyeTahsilatEU, veresiyeTahsilatDolar, veresiyeTahsilatTL, 3, isUpdateDate);
                string mesaj4 = database.kayitEkleKKSatis(tarih, k_kartiSatisEU, k_kartiSatisDolar, k_kartiSatisTL, 4, isUpdateDate);
                string mesaj5 = database.kayitEkleKapora(tarih, kaporaEU, kaporaDolar, kaporaTL, 5, isUpdateDate);

                //KASA DEVİR KAYDEDİLDİ
                String kayitkd = database.kayitEkleKD(tarih, dbAy, gunlukKasaEU, gunlukKasaD, gunlukKasaTL, yil, isUpdateDate);

                MessageBox.Show("Kayıt Başarılı", "Bilgilendirme");
            }
            else
            {
                MessageBox.Show("Hata oluştu. Aynı tarihte kayıt olmadığından emin olun.", "Bilgilendirme");
            }
           
            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu. Aynı tarihte kayıt olmadığından emin olun.", "Bilgilendirme");
         
            }
        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void listele()
        {
            string yil, ay, gun, tarih, tarih_2;

            dataGridgKasa.Columns.Clear();

            DatabaseClass database = new DatabaseClass();
            //
            DateTime DTIME = dateTimePicker1.Value;
            yil = DTIME.Date.Year.ToString();
            ay = DTIME.Date.Month.ToString();
            gun = DTIME.Date.Day.ToString();

            if (ay.Length <= 1)
            {
                ay = "0" + ay;
            }
            if (gun.Length <= 1)
            {
                gun = "0" + gun;
            }

            tarih = yil + "-" + ay + "-" + gun;
            DateTime DTIME2 = dateTimePicker2.Value;
            yil = DTIME2.Date.Year.ToString();
            ay = DTIME2.Date.Month.ToString();
            gun = DTIME2.Date.Day.ToString();

            if (ay.Length <= 1)
            {
                ay = "0" + ay;
            }
            if (gun.Length <= 1)
            {
                gun = "0" + gun;
            }


            tarih_2 = yil + "-" + ay + "-" + gun;

            String tarih1 = tarih;
            String tarih2 = tarih_2;
            //
            /* TARİH BAZLIYA DÖNÜŞTÜRÜLDÜ
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
            else secili_ay = "0" + ay + "/" + yil;*/

            string sql = "Select `Tarih`, `TL`, `Euro`, `Dolar` from günlük_kasa WHERE Tarih between '" + tarih1 + "' and '" + tarih2 + "' ORDER BY Tarih"; ;

            dataGridgKasa.DataSource = database.ListData(sql);

            dataGridgKasa.Columns[0].HeaderText = "TARİH";
         
            dataGridgKasa.Columns[1].HeaderText = "TL";
            dataGridgKasa.Columns[2].HeaderText = "EURO";
            dataGridgKasa.Columns[3].HeaderText = "DOLAR";


            // dataGridgKasa.Columns[0].Visible = false;
            if (dataGridgKasa.RowCount > 1)
            {
                double veresiyeToplamE = 0;
                double veresiyeToplamD = 0;
                double veresiyeToplamTl = 0;


                for (int i = 0; i < dataGridgKasa.Rows.Count; i++)
                {
                    veresiyeToplamTl += Convert.ToDouble(dataGridgKasa.Rows[i].Cells[1].Value);
                    veresiyeToplamE += Convert.ToDouble(dataGridgKasa.Rows[i].Cells[2].Value);
                    veresiyeToplamD += Convert.ToDouble(dataGridgKasa.Rows[i].Cells[3].Value);

                }

                lblEuro.Text = "€ : " + veresiyeToplamE.ToString();
                lblDolar.Text = "$ : " + veresiyeToplamD.ToString();
                lblTL.Text = "TL : " + veresiyeToplamTl.ToString();
                /*List<string> topalmdegerler = database.ListDatatab(secili_ay);
                lblEuro.Text = " € : " + topalmdegerler[0];
                lblDolar.Text = " $ : " + topalmdegerler[1];
                lblTL.Text = " TL : " + topalmdegerler[2];*/

                dataGridgKasa.ClearSelection();
                // dataGridgKasa.Rows[dataGridgKasa.RowCount - 2].Selected = true;
                
                int nRowIndex = dataGridgKasa.Rows.Count - 1;
                int nColumnIndex = 2;

                dataGridgKasa.Rows[nRowIndex].Selected = true;
                dataGridgKasa.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;
                dataGridgKasa.CurrentCell = dataGridgKasa.Rows[nRowIndex].Cells[nColumnIndex];
                //In case if you want to scroll down as well.
                //  dataGridgKasa.FirstDisplayedScrollingRowIndex = nRowIndex;
                kasadevirHesapla();
                veresiyeHesapla();
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
            degerleri_temizle();
        }

        private void btn_ayrintilikasa_Click(object sender, EventArgs e)
        {
            Sorgula2 s = new Sorgula2();

            s.Show();
            //Ayrintilar ayrintiekrani = new Ayrintilar();
            //ayrintiekrani.Show();
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
            DialogResult secenek = MessageBox.Show("Kaydı silmek istiyor musunuz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek == DialogResult.Yes)
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

                    if (ay.Length <= 1)
                    {
                        ay = "0" + ay;
                    }
                    if (gun.Length <= 1)
                    {
                        gun = "0" + gun;
                    }

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
            else if (secenek == DialogResult.No)
            {
                //Hayır seçeneğine tıklandığında çalıştırılacak kodlar
            }            
           
        }

        private void label55_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            dateTimePicker2.Value = DateTime.Now;
            //datetpislemtarihi.MaxDate = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Month , 0, 0, 0, 0);
            //  datetpislemtarihi.MinDate = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month,1, 0, 0, 0, 0);
            listele();
            foreach (DataGridViewColumn column in dataGridgKasa.Columns)// header a tıklandığında sıralamasını değiştirmesin
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
      
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Programı kapatmak istiyor musunuz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

           
                if (dataGridgKasa.Rows[0].Cells[0].Value != null)
                {
                    string yil, ay, gun;
                    string secili_gun = datetpislemtarihi.Text;
                    string[] kesim1 = secili_gun.Split(' ');
                    string[] kesim2 = kesim1[0].Split('.');

                    yil = kesim2[2];
                    ay = kesim2[1];
                    gun = kesim2[0];
                    string tarih = yil + "-" + ay + "-" + gun;
                    string tarih2 = gun + "." + ay + "." +yil;

                DialogResult secenek = MessageBox.Show( datetpislemtarihi.Text + " Tarihindeki kayıt güncellenecek"+"\n"+"Devam etmek istiyor musunuz?", "Bilgilendirme Penceresi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (secenek == DialogResult.Yes)
                        {
                            string isUpdateDate = tarih;

                            ekleveGüncelle(isUpdateDate);
                            btn_listele_Click(sender, e);
                        }
                        else if (secenek == DialogResult.No)
                        {
                            //Hayır seçeneğine tıklandığında çalıştırılacak kodlar
                        }

               }
                else { MessageBox.Show("Stunlar boş olduğundan işlem yapılamaz", "Uyarı"); }
            
        }

        private void dataGridgKasa_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {           

            kasadevirHesapla();
            veresiyeHesapla();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridgKasa_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void datetpislemtarihi_ValueChanged(object sender, EventArgs e)
        {

            string yil, ay, gun, tarih;
            try
            {
                
                DateTime DTIME = Convert.ToDateTime(datetpislemtarihi.Text);
                yil = DTIME.Date.Year.ToString();
                ay = DTIME.Date.Month.ToString();
                gun = DTIME.Date.Day.ToString();

                if (ay.Length <= 1)
                {
                    ay = "0" + ay;
                }
                if (gun.Length <= 1)
                {
                    gun = "0" + gun;
                }

                tarih = yil + "-" + ay + "-" + gun;

                DatabaseClass database = new DatabaseClass();
                string sorgu = "SELECT `ID`, `TL`, `DOLAR`, `EURO`, `Tarih`, `P_ID` FROM `para_degerleri` WHERE Tarih = '" + tarih + "'";
                List<ParaDegerleriGelir> gelirler = database.gelirDegerleri(sorgu);

                if (gelirler.Count > 0)
                {
                    foreach (ParaDegerleriGelir gelir in gelirler)
                    {
                        if (gelir.P_ID == 1)
                        {
                            tb_gunluksTL.Text = gelir.TL.ToString();
                            tb_gunluksE.Text = gelir.EURO.ToString();
                            tb_gunluksD.Text = gelir.DOLAR.ToString();
                            continue;
                        }
                        if (gelir.P_ID == 2)
                        {
                            tb_veresiyesTL.Text = gelir.TL.ToString();
                            tb_veresiyesE.Text = gelir.EURO.ToString();
                            tb_veresiyesD.Text = gelir.DOLAR.ToString();
                            continue;
                        }
                        if (gelir.P_ID == 3)
                        {
                            tb_veresiyetahTL.Text = gelir.TL.ToString();
                            tb_veresiyetahE.Text = gelir.EURO.ToString();
                            tb_veresiyetahD.Text = gelir.DOLAR.ToString();
                            continue;
                        }
                        if (gelir.P_ID == 4)
                        {
                            tb_kksatisTL.Text = gelir.TL.ToString();
                            tb_kksatisE.Text = gelir.EURO.ToString();
                            tb_kksatisD.Text = gelir.DOLAR.ToString();
                            continue;
                        }
                        if (gelir.P_ID == 5)
                        {
                            tbkaporaTL.Text = gelir.TL.ToString();
                            tbkaporaE.Text = gelir.EURO.ToString();
                            tbkaporaD.Text = gelir.DOLAR.ToString();
                            continue;
                        }
                    }

                    //gridviewde select yapsın
                    /* dataGridgKasa.ClearSelection();
                      int rowIndex = -1;
                      string aranacakDeger = datetpislemtarihi.Text;

                      DataGridViewRow row = dataGridgKasa.Rows
                          .Cast<DataGridViewRow>()
                          .First(r => r.Cells[0].Value.ToString().Equals(aranacakDeger));

                      rowIndex = row.Index;

                      dataGridgKasa.Rows[rowIndex].Selected = true;*/
                  
                }
                else
                {
                    degerleri_temizle();
                }

                string sorgu2 = "SELECT `ID`, `TL`, `DOLAR`, `EURO`, `Tarih`, `P_ID` FROM `para_degerleri_giderler` WHERE Tarih = '" + tarih + "'";
                List < ParaDegerleriGider > giderler = database.giderDegerleri(sorgu2);

                if (giderler.Count > 0) {
                    foreach (ParaDegerleriGider gider in giderler)
                    {
                        if (gider.P_ID == 1)
                        {
                            tb_dukkangiderTL.Text = gider.TL.ToString();
                            tb_dukkangiderE.Text = gider.EURO.ToString();
                            tb_dukkangiderD.Text = gider.DOLAR.ToString();
                            continue;
                        }
                        if (gider.P_ID == 2)
                        {
                            tb_iadealinanTL.Text = gider.TL.ToString();
                            tb_iadealinanE.Text = gider.EURO.ToString();
                            tb_iadealinanD.Text = gider.DOLAR.ToString();
                            continue;
                        }
                        if (gider.P_ID == 3)
                        {
                            tb_firmaödTL.Text = gider.TL.ToString();
                            tb_firmaödE.Text = gider.EURO.ToString();
                            tb_firmaödD.Text = gider.DOLAR.ToString();
                            continue;
                        }
                        if (gider.P_ID == 4)
                        {
                            tb_pesinalinanTL.Text = gider.TL.ToString();
                            tb_pesinalinanE.Text = gider.EURO.ToString();
                            tb_pesinalinanD.Text = gider.DOLAR.ToString();
                            continue;
                        }
                        if (gider.P_ID == 5)
                        {
                            tb_ResulDödemeTL.Text = gider.TL.ToString();
                            tb_ResulDödemeE.Text = gider.EURO.ToString();
                            tb_ResulDödemeD.Text = gider.DOLAR.ToString();
                            continue;
                        }
                        if (gider.P_ID == 6)
                        {
                            tb_eleman1TL.Text = gider.TL.ToString();
                            tb_eleman1E.Text = gider.EURO.ToString();
                            tb_eleman1D.Text = gider.DOLAR.ToString();
                            continue;
                        }
                        if (gider.P_ID == 7)
                        {
                            tb_eleman2TL.Text = gider.TL.ToString();
                            tb_eleman2E.Text = gider.EURO.ToString();
                            tb_eleman2D.Text = gider.DOLAR.ToString();
                            continue;
                        }
                    }
                }
                else
                {
                    degerleri_temizle();
                }

        

            }
            catch (Exception e21)
            {
                Console.Write(e21);
            }
        }

        private void degerleri_temizle()
        {

            tb_dukkangiderE.Text = ""; tb_dukkangiderD.Text = ""; tb_dukkangiderTL.Text = "";
            tb_iadealinanE.Text = ""; tb_iadealinanD.Text = ""; tb_iadealinanTL.Text = "";
            tb_firmaödE.Text = ""; tb_firmaödD.Text = ""; tb_firmaödTL.Text = "";
            tb_pesinalinanE.Text = ""; tb_pesinalinanD.Text = ""; tb_pesinalinanTL.Text = "";
            tb_ResulDödemeE.Text = ""; tb_ResulDödemeD.Text = ""; tb_ResulDödemeTL.Text = "";
            tb_eleman1E.Text = ""; tb_eleman1D.Text = ""; tb_eleman1TL.Text = "";
            tb_eleman2E.Text = ""; tb_eleman2D.Text = ""; tb_eleman2TL.Text = "";

            tb_gunluksE.Text = ""; tb_gunluksD.Text = ""; tb_gunluksTL.Text = "";
            tb_veresiyetahE.Text = ""; tb_veresiyetahD.Text = ""; tb_veresiyetahTL.Text = "";
            tb_veresiyesE.Text = ""; tb_veresiyesD.Text = ""; tb_veresiyesTL.Text = "";
            tb_kksatisE.Text = ""; tb_kksatisD.Text = ""; tb_kksatisTL.Text = "";
            tbkaporaE.Text = ""; tbkaporaD.Text = ""; tbkaporaTL.Text = "";
            
        }
        private void dataGridgKasa_SelectionChanged(object sender, EventArgs e)
        {
          
        }

        private void veresiyeHesapla()
        {

            string tarih, yil, ay, gun;
            try
            {

                if (dataGridgKasa.ColumnCount > 0)
                {
                    // dataGridgKasa_CellClick(sender,e);
                    string secili_tarih = dataGridgKasa.CurrentRow.Cells[0].Value.ToString();

                    DateTime DTIME = Convert.ToDateTime(secili_tarih);
                    yil = DTIME.Date.Year.ToString();
                    ay = DTIME.Date.Month.ToString();
                    gun = DTIME.Date.Day.ToString();

                    if (ay.Length <= 1)
                    {
                        ay = "0" + ay;
                    }
                    if (gun.Length <= 1)
                    {
                        gun = "0" + gun;
                    }

                    tarih = yil + "-" + ay + "-" + gun;

                    DatabaseClass database = new DatabaseClass();

                    string sorgu =
                        "select"+
                        " SUM(CAST(REPLACE(TL, ',', '.') as DECIMAL(9, 2))) as TLT, " +
                        " SUM(CAST(REPLACE(Euro, ',', '.') as DECIMAL(9,2))) EuroT, " +
                         "SUM(CAST(REPLACE(Dolar, ',', '.') as DECIMAL(9, 2))) as DolarT " +
                        
                        "FROM günlük_kasa WHERE Tarih <= '" + tarih + "'";

                    dataGVKasaDevir.Columns.Clear();
                    dataGVKasaDevir.DataSource = database.ListData(sorgu);

                    dataGVKasaDevir.Columns[0].HeaderText = "TL";
                    dataGVKasaDevir.Columns[1].HeaderText = "EURO";
                    dataGVKasaDevir.Columns[2].HeaderText = "DOLAR";
                    

                    string sorguveresiye = "SELECT  " +
                        "((SELECT SUM(CAST(REPLACE(TL, ',', '.') as DECIMAL(9, 2))) as tl2 FROM `para_degerleri` " +

                            "WHERE P_ID = 2 AND Tarih <= '" + tarih +
                        "') - " +
                        "(SELECT SUM(CAST(REPLACE(TL, ',', '.') as DECIMAL(9, 2))) as tl2 FROM `para_degerleri` " +

                            "WHERE P_ID = 3 AND Tarih <= '" + tarih +
                        "') ) as tl, " +
                        "((SELECT SUM(CAST(REPLACE(EURO, ',', '.') as DECIMAL(9, 2))) as tl2 FROM `para_degerleri` " +

                            "WHERE P_ID = 2 AND Tarih <= '" + tarih +
                        "')- " +
                        "(SELECT SUM(CAST(REPLACE(EURO, ',', '.') as DECIMAL(9, 2))) as tl2 FROM `para_degerleri` " +

                           " WHERE P_ID = 3 AND Tarih <= '" + tarih +
                       "' ) ) as E, " +
                        "((SELECT SUM(CAST(REPLACE(DOLAR, ',', '.') as DECIMAL(9, 2))) as tl2 FROM `para_degerleri` " +

                           " WHERE P_ID = 2 AND Tarih <= '" + tarih +
                       "' )- " +
                        "(SELECT SUM(CAST(REPLACE(DOLAR, ',', '.') as DECIMAL(9, 2))) as tl2 FROM `para_degerleri` " +

                         "   WHERE P_ID = 3 AND Tarih <= '" + tarih +
                       "' ) ) as D " +

                        "FROM para_degerleri WHERE Tarih = '" + tarih + "' GROUP BY Tarih";

                    dataGridVeresiye.Columns.Clear();
                    dataGridVeresiye.DataSource = database.ListData(sorguveresiye);

                    dataGridVeresiye.Columns[0].HeaderText = " TL";
                    dataGridVeresiye.Columns[1].HeaderText = "EURO";
                    dataGridVeresiye.Columns[2].HeaderText = "DOLAR";

                    lblTarih.Text = "-" + Convert.ToDateTime(secili_tarih).ToShortDateString() + "-";

                    datetpislemtarihi.Text = dataGridgKasa.CurrentRow.Cells[0].Value.ToString();

                }

            }
            catch (Exception)
            {
            }

        }

        private void kasadevirHesapla()
        {

            string tarih, yil, ay, gun;
            try
            {

                if (dataGridgKasa.ColumnCount > 0)
                {

                    string secili_tarih = dataGridgKasa.CurrentRow.Cells[0].Value.ToString();
                    //dataGridgKasa_CellClick(sender, e);
                    DateTime DTIME = Convert.ToDateTime(secili_tarih);
                    yil = DTIME.Date.Year.ToString();
                    ay = DTIME.Date.Month.ToString();
                    gun = DTIME.Date.Day.ToString();

                    if (ay.Length <= 1)
                    {
                        ay = "0" + ay;
                    }
                    if (gun.Length <= 1)
                    {
                        gun = "0" + gun;
                    }


                    tarih = yil + "-" + ay + "-" + gun;

                    DatabaseClass database = new DatabaseClass();  

                    string sorgu =
                        "select "+
                        " SUM(CAST(REPLACE(TL, ',', '.') as DECIMAL(9, 2))) as TLT, " + 
                        " SUM(CAST(REPLACE(Euro, ',', '.') as DECIMAL(9,2))) EuroT,"+
                         "SUM(CAST(REPLACE(Dolar, ',', '.') as DECIMAL(9, 2))) as DolarT "+
                        
                        "FROM günlük_kasa WHERE Tarih <= '" + tarih + "'";

                    dataGVKasaDevir.Columns.Clear();
                    dataGVKasaDevir.DataSource = database.ListData(sorgu);

                    dataGVKasaDevir.Columns[0].HeaderText = "TL";
                    dataGVKasaDevir.Columns[1].HeaderText = "EURO";
                    dataGVKasaDevir.Columns[2].HeaderText = "DOLAR";
                    

                    lblTarih.Text = "-" + Convert.ToDateTime(secili_tarih).ToShortDateString() + "-";
                    datetpislemtarihi.Text = dataGridgKasa.CurrentRow.Cells[0].Value.ToString();
                    
                }

            }
            catch (Exception)
            {
            }

        }

        private void dataGridgKasa_ControlAdded(object sender, ControlEventArgs e)
        {
 
        }
    }
}
