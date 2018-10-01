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
                dbAy + "','" + gunlukKasaEU.ToString() + "','" + gunlukKasaD.ToString() + "','" + gunlukKasaTL.ToString() +"','"+yil+"')";


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


            return degerler ;
        }

    }
}
