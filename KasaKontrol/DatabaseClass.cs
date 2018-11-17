using MySql.Data.MySqlClient;
using MySql.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KasaKontrol
{
    class DatabaseClass
    {
        MySqlConnection baglanti;
        String DataListesi;
        // DateTimePicker dtp;
        String OTipi;

        public void ConnectSql()
        {

            String bag;
            MySqlConnectionStringBuilder build = new MySqlConnectionStringBuilder();

            build.Server = "127.0.0.1";//	localhost
            build.UserID = "root";
            build.Password = "root";
            build.Database = "kasatakip";
            build.Port = 3306;
            build.SslMode = MySqlSslMode.None;
            build.PersistSecurityInfo = true;

            bag = build.ToString();
            baglanti = new MySqlConnection(bag);

        }


        public DataTable ListData(string sql)
        {

            ConnectSql();

            //if (DataGridList.Name == "dtgridSalesList")
            //    sql = sql + " ORDER BY  SALE_CODE";
            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand();

            command.CommandText = sql;
            command.Connection = baglanti;
            adapter.SelectCommand = command;

            baglanti.Open();
            adapter.Fill(dt);

            // DataGridList.DataSource = dt;
            baglanti.Close();
            return dt;

        }

        public string kayitEkle(String dbYil, String dbAy, double gunlukKasaEU, double gunlukKasaD, double gunlukKasaTL, string yil)
        {

            ConnectSql();
            baglanti.Open();

            string sql = "INSERT INTO günlük_kasa (Tarih, aylar, Euro, Dolar, TL, HANGI_YIL) VALUES ('" + dbYil + "','" +
                dbAy + "','" + gunlukKasaEU.ToString() + "','" + gunlukKasaD.ToString() + "','" + gunlukKasaTL.ToString() + "','" + yil + "')";


            MySqlCommand komut = new MySqlCommand(sql, baglanti);

            try
            {
                komut.ExecuteNonQuery();
                baglanti.Close();

                return "Kayıt başarılı";
            }
            catch (Exception)
            {
                return "Bir hata oluştu, aynı tarihte kayıt olmadığına dikkat edin. ";
            }



        }

        public void deleteData(string sorgu)
        {
            ConnectSql();
            baglanti.Open();

            string sql = sorgu;


            MySqlCommand komut = new MySqlCommand(sql, baglanti);


            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public List<string> ListDatatab(string secili_ay)
        {
            List<string> degerler = new List<string>();
            try
            {

                ConnectSql();
                baglanti.Open();

                string sqlToplamEur = "Select SUM(Euro) as EuroT" +
                            " FROM `günlük_kasa` WHERE aylar LIKE '" + secili_ay + "' GROUP BY aylar";
                MySqlCommand komut = new MySqlCommand(sqlToplamEur, baglanti);
                string valueEU = komut.ExecuteScalar().ToString();


                string sqlToplamdolar = "Select SUM(Dolar) as DolarT " +
                            " FROM `günlük_kasa` WHERE aylar LIKE '" + secili_ay + "' GROUP BY aylar";
                MySqlCommand komut2 = new MySqlCommand(sqlToplamdolar, baglanti);
                string valueDL = komut2.ExecuteScalar().ToString();

                string sqlToplamTL = "Select SUM(TL) as TLT FROM `günlük_kasa` WHERE aylar LIKE '" + secili_ay + "' GROUP BY aylar";
                MySqlCommand komut3 = new MySqlCommand(sqlToplamTL, baglanti);
                string valueTL = komut3.ExecuteScalar().ToString();


                degerler.Add(valueEU);
                degerler.Add(valueDL);
                degerler.Add(valueTL);


            }
            catch (Exception)
            {

            }


            return degerler;
        }

        internal List<ParaDegerleriGider> giderDegerleri(string sorgu)
        {
            List<ParaDegerleriGider> degerler = new List<ParaDegerleriGider>();
            try
            {

                ConnectSql();
                baglanti.Open();
                

                string sql = sorgu;
                MySqlCommand komut = new MySqlCommand(sql, baglanti);
                
                MySqlDataReader dataReader = komut.ExecuteReader();

                while (dataReader.Read())
                {
                    ParaDegerleriGider giderler = new ParaDegerleriGider();

                    giderler.Tarih = Convert.ToDateTime(dataReader["Tarih"]);
                    giderler.EURO = Convert.ToDouble(dataReader["EURO"]);
                    giderler.DOLAR = Convert.ToDouble(dataReader["DOLAR"]);
                    giderler.TL = Convert.ToDouble(dataReader["TL"]);

                    giderler.P_ID = Convert.ToInt32(dataReader["P_ID"]);
                    giderler.Id = Convert.ToInt32(dataReader["ID"]);

                    degerler.Add(giderler);

                    
                }
                dataReader.Close();
            }
             
            catch (Exception)
            {

            }


            return degerler;
        }

        internal string kayitEkleDGiderleri(string tarih, double dukkangiderleriEU, double dukkangiderleriDolar, double dukkangiderleriTL, int v)
        {
            ConnectSql();
            baglanti.Open();

            string sql = "INSERT INTO para_degerleri_giderler (Tarih,Euro, Dolar, TL, P_ID) VALUES ('" + tarih + "',"+dukkangiderleriEU+dukkangiderleriDolar+dukkangiderleriTL+v + "')";


            MySqlCommand komut = new MySqlCommand(sql, baglanti);

            try
            {
                komut.ExecuteNonQuery();
                baglanti.Close();

                return "Kayıt başarılı";
            }
            catch (Exception)
            {
                return "Bir hata oluştu, aynı tarihte kayıt olmadığına dikkat edin. ";
            }
            
        }

        internal string kayitEkleIAlinan(string tarih, double iadealinanEU, double iadealinanDolar, double iadealinanTL, int v)
        {
            ConnectSql();
            baglanti.Open();

            string sql = "INSERT INTO para_degerleri_giderler (Tarih,Euro, Dolar, TL, P_ID) VALUES ('" + tarih + "'," + iadealinanEU + iadealinanDolar + iadealinanTL + v + "')";


            MySqlCommand komut = new MySqlCommand(sql, baglanti);

            try
            {
                komut.ExecuteNonQuery();
                baglanti.Close();

                return "Kayıt başarılı";
            }
            catch (Exception)
            {
                return "Bir hata oluştu, aynı tarihte kayıt olmadığına dikkat edin. ";
            }
        }

      
        internal string kayitEkleFOdemeleri(string tarih, double firmaödemeleriEU, double firmaödemeleriDolar, double firmaödemeleriTL, int v)
        {
            ConnectSql();
            baglanti.Open();

            string sql = "INSERT INTO para_degerleri_giderler (Tarih,Euro, Dolar, TL, P_ID) VALUES ('" + tarih + "'," + firmaödemeleriEU + firmaödemeleriDolar + firmaödemeleriTL + v + "')";


            MySqlCommand komut = new MySqlCommand(sql, baglanti);

            try
            {
                komut.ExecuteNonQuery();
                baglanti.Close();

                return "Kayıt başarılı";
            }
            catch (Exception)
            {
                return "Bir hata oluştu, aynı tarihte kayıt olmadığına dikkat edin. ";
            }
        }

        internal string kayitEkleVSatis(string tarih, double veresiyeSatisEU, double veresiyeSatisDolar, double veresiyeSatisTL, int v)
        {
            ConnectSql();
            baglanti.Open();

            string sql = "INSERT INTO para_degerleri (Tarih,Euro, Dolar, TL, P_ID) VALUES ('" + tarih + "'," + veresiyeSatisEU + veresiyeSatisDolar + veresiyeSatisTL + v + "')";


            MySqlCommand komut = new MySqlCommand(sql, baglanti);

            try
            {
                komut.ExecuteNonQuery();
                baglanti.Close();

                return "Kayıt başarılı";
            }
            catch (Exception)
            {
                return "Bir hata oluştu, aynı tarihte kayıt olmadığına dikkat edin. ";
            }
        }

        internal string kayitEkleKKSatis(string tarih, double k_kartiSatisEU, double k_kartiSatisDolar, double k_kartiSatisTL, int v)
        {
            ConnectSql();
            baglanti.Open();

            string sql = "INSERT INTO para_degerleri (Tarih,Euro, Dolar, TL, P_ID) VALUES ('" + tarih + "'," + k_kartiSatisEU + k_kartiSatisDolar + k_kartiSatisTL + v + "')";


            MySqlCommand komut = new MySqlCommand(sql, baglanti);

            try
            {
                komut.ExecuteNonQuery();
                baglanti.Close();

                return "Kayıt başarılı";
            }
            catch (Exception)
            {
                return "Bir hata oluştu, aynı tarihte kayıt olmadığına dikkat edin. ";
            }
        }

        internal List<ParaDegerleriGelir> gelirDegerleri(string sorgu)
        {

            List<ParaDegerleriGelir> degerler2 = new List<ParaDegerleriGelir>();
            try
            {
                ConnectSql();
                baglanti.Open();
                               
                string sql = sorgu;
                MySqlCommand komut = new MySqlCommand(sql, baglanti);

                MySqlDataReader dataReader = komut.ExecuteReader();

                while (dataReader.Read() )
                {
                    ParaDegerleriGelir gelirler = new ParaDegerleriGelir();

                    gelirler.Tarih = Convert.ToDateTime(dataReader["Tarih"]);
                    gelirler.EURO = Convert.ToDouble(dataReader["EURO"]);
                    gelirler.DOLAR = Convert.ToDouble(dataReader["DOLAR"]);
                    gelirler.TL = Convert.ToDouble(dataReader["TL"]);

                    gelirler.P_ID = Convert.ToInt32(dataReader["P_ID"]);
                    gelirler.Id = Convert.ToInt32(dataReader["ID"]);

                    degerler2.Add(gelirler);
                }
                dataReader.Close();
            }
            catch (Exception)
            {

            }
            
            return degerler2;
        }

        internal string kayitEkleKapora(string tarih, double kaporaEU, double kaporaDolar, double kaporaTL, int v)
        {
            ConnectSql();
            baglanti.Open();

            string sql = "INSERT INTO para_degerleri (Tarih,Euro, Dolar, TL, P_ID) VALUES ('" + tarih + "'," + kaporaEU + kaporaDolar + kaporaTL + v + "')";


            MySqlCommand komut = new MySqlCommand(sql, baglanti);

            try
            {
                komut.ExecuteNonQuery();
                baglanti.Close();

                return "Kayıt başarılı";
            }
            catch (Exception)
            {
                return "Bir hata oluştu, aynı tarihte kayıt olmadığına dikkat edin. ";
            }
        }

        internal string kayitEkleVTahsilat(string tarih, double veresiyeTahsilatEU, double veresiyeTahsilatDolar, double veresiyeTahsilatTL, int v)
        {
            ConnectSql();
            baglanti.Open();

            string sql = "INSERT INTO para_degerleri (Tarih,Euro, Dolar, TL, P_ID) VALUES ('" + tarih + "'," + veresiyeTahsilatEU + veresiyeTahsilatDolar + veresiyeTahsilatTL + v + "')";


            MySqlCommand komut = new MySqlCommand(sql, baglanti);

            try
            {
                komut.ExecuteNonQuery();
                baglanti.Close();

                return "Kayıt başarılı";
            }
            catch (Exception)
            {
                return "Bir hata oluştu, aynı tarihte kayıt olmadığına dikkat edin. ";
            }
        }

        internal string kayitEkleGSatis(string tarih, double gunluksatisEU, double gunluksatisDolar, double gunluksatisTL, int v)
        {
            ConnectSql();
            baglanti.Open();

            string sql = "INSERT INTO para_degerleri (Tarih,Euro, Dolar, TL, P_ID) VALUES ('" + tarih + "'," + gunluksatisEU + gunluksatisDolar + gunluksatisTL + v + "')";


            MySqlCommand komut = new MySqlCommand(sql, baglanti);

            try
            {
                komut.ExecuteNonQuery();
                baglanti.Close();

                return "Kayıt başarılı";
            }
            catch (Exception)
            {
                return "Bir hata oluştu, aynı tarihte kayıt olmadığına dikkat edin. ";
            }
        }

        internal string kayitEklePAlinanO(string tarih, double pesinalinanödemeEU, double pesinalinanödemeDolar, double pesinalinanödemeTL, int v)
        {
            ConnectSql();
            baglanti.Open();

            string sql = "INSERT INTO para_degerleri_giderler (Tarih,Euro, Dolar, TL, P_ID) VALUES ('" + tarih + "'," + pesinalinanödemeEU + pesinalinanödemeDolar + pesinalinanödemeTL + v + "')";


            MySqlCommand komut = new MySqlCommand(sql, baglanti);

            try
            {
                komut.ExecuteNonQuery();
                baglanti.Close();

                return "Kayıt başarılı";
            }
            catch (Exception)
            {
                return "Bir hata oluştu, aynı tarihte kayıt olmadığına dikkat edin. ";
            }
        }

        internal string kayitEkleEleman1(string tarih, double eleman1EU, double eleman1Dolar, double eleman1TL, int v)
        {
            ConnectSql();
            baglanti.Open();

            string sql = "INSERT INTO para_degerleri_giderler (Tarih,Euro, Dolar, TL, P_ID) VALUES ('" + tarih + "'," + eleman1EU + eleman1Dolar + eleman1TL + v + "')";


            MySqlCommand komut = new MySqlCommand(sql, baglanti);

            try
            {
                komut.ExecuteNonQuery();
                baglanti.Close();

                return "Kayıt başarılı";
            }
            catch (Exception)
            {
                return "Bir hata oluştu, aynı tarihte kayıt olmadığına dikkat edin. ";
            }
        }

        internal string kayitEkleEleman2(string tarih, double eleman2EU, double eleman2Dolar, double eleman2TL, int v)
        {
            ConnectSql();
            baglanti.Open();

            string sql = "INSERT INTO para_degerleri_giderler (Tarih,Euro, Dolar, TL, P_ID) VALUES ('" + tarih + "'," + eleman2EU + eleman2Dolar + eleman2TL + v + "')";


            MySqlCommand komut = new MySqlCommand(sql, baglanti);

            try
            {
                komut.ExecuteNonQuery();
                baglanti.Close();

                return "Kayıt başarılı";
            }
            catch (Exception)
            {
                return "Bir hata oluştu, aynı tarihte kayıt olmadığına dikkat edin. ";
            }
        }

        internal string kayitEkleR_D_Odemeler(string tarih, double resuldödemeEU, double resuldödemeDolar, double resuldödemeTL, int v)
        {
            ConnectSql();
            baglanti.Open();

            string sql = "INSERT INTO para_degerleri_giderler (Tarih,Euro, Dolar, TL, P_ID) VALUES ('" + tarih + "'," + resuldödemeEU + resuldödemeDolar + resuldödemeTL + v + "')";


            MySqlCommand komut = new MySqlCommand(sql, baglanti);

            try
            {
                komut.ExecuteNonQuery();
                baglanti.Close();

                return "Kayıt başarılı";
            }
            catch (Exception)
            {
                return "Bir hata oluştu, aynı tarihte kayıt olmadığına dikkat edin. ";
            }
        }
    }
}
