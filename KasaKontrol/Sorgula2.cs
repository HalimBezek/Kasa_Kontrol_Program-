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
    public partial class Sorgula2 : Form
    {
        public Sorgula2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
           
            if ((e.RowIndex == -1) && (e.ColumnIndex > -1))
            {
                Rectangle cellBounds = e.CellBounds;
                /*   Rectangle* rectanglePtr1 = (Rectangle*) ref cellBounds;
                   rectanglePtr1.Y += e.CellBounds.Height / 2;
                   cellBounds.Height = e.CellBounds.Height / 2;*/

                cellBounds.Y += e.CellBounds.Height / 2;
                cellBounds.Height = e.CellBounds.Height / 2;
                e.PaintBackground(cellBounds, true);
                e.PaintContent(cellBounds);
                e.Handled = true;
            }
        
    }

        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            
            Rectangle displayRectangle = this.dataGridView1.DisplayRectangle;
            displayRectangle.Height = this.dataGridView1.ColumnHeadersHeight / 2;
            this.dataGridView1.Invalidate(displayRectangle);
        

    }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            string[] strArray = new string[] { "Günük Satış", "Veresiye Satış", "Veresiye Tahsilat", "K.Kartı Satış", "Kapora" };

            Rectangle rect = new Rectangle();
            Rectangle rectangle2 = new Rectangle();
            rect.Width = 0;
            rect.Height = 0;
            for (int i = 0; i < 15; i += 3)
            {
                rect = this.dataGridView1.GetCellDisplayRectangle(i + 1, -1, true);
                rectangle2 = this.dataGridView1.GetCellDisplayRectangle(i + 1, -1, true);
                int width = rectangle2.Width;
                rect.X += 1;
                rect.Y += 1;
                rect.Width = rect.Width * 5/2 +10 ;
                rect.Height = rect.Height / 2 - 2;

               /* Rectangle*rectanglePtr1 = (Rectangle*)ref rect;
                rectanglePtr1.X++;
                Rectangle*rectanglePtr2 = (Rectangle*) ref rect;
                rectanglePtr2.Y++;
                Rectangle*rectanglePtr3 = (Rectangle*) ref rect;
                rectanglePtr3.Width = ((rect.Width * 2) + width) - 15;
                Rectangle*rectanglePtr4 = (Rectangle*) ref rect;
                rectanglePtr4.Height = (rect.Height / 2) - 1;*/
                e.Graphics.FillRectangle(new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor), rect);
                StringFormat format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(strArray[i / 3], this.dataGridView1.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor), rect, format);
            }
        

    }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle displayRectangle = this.dataGridView1.DisplayRectangle;
            displayRectangle.Height = this.dataGridView1.ColumnHeadersHeight / 2;
            this.dataGridView1.Invalidate(displayRectangle);
       

    }

        private void Sorgula2_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
            dateTimePicker2.Value = DateTime.Now;
            bool tarihBazli = false;
            SayfayıDoldur(tarihBazli);
        }

        private void SayfayıDoldur(bool tarihBazli)
        {
            DatabaseClass database = new DatabaseClass();            

            datagrid1Doldur(database, tarihBazli);
            datagrid2Doldur(database, tarihBazli);
            veresiyeDurumu();
            toplamGoster();
            
            int num = 0;
            while (true)
            {
                if (num >= (this.dataGridView1.Rows.Count - 1))
                {
                    for (int i = 0; i < (this.dataGridView2.Rows.Count - 1); i++)
                    {
                        DataGridViewCellStyle style2 = new DataGridViewCellStyle();
                        if (this.dataGridView2.Rows[i].Cells[0].Value.Equals("TOPLAM :"))
                        {
                            style2.BackColor = Color.LightBlue;
                        }
                        this.dataGridView2.Rows[i].DefaultCellStyle = style2;
                    }
                    return;
                }
                DataGridViewCellStyle style = new DataGridViewCellStyle();
                if (this.dataGridView1.Rows[num].Cells[0].Value.Equals("TOPLAM :"))
                {
                    style.BackColor = Color.LightBlue;
                }
                this.dataGridView1.Rows[num].DefaultCellStyle = style;
                num++;
            }

        }

        private void veresiyeDurumu()
        {
            double num = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            int num4 = 0;
            dataGridView3.Rows.Clear();
            while (true)
            {
                if (num4 >= (this.dataGridView1.Rows.Count - 2))
                {
                    this.dataGridView3.Columns[0].HeaderText = "TARİH";
                    this.dataGridView3.Columns[1].HeaderText = "EURO";
                    this.dataGridView3.Columns[2].HeaderText = "DOLAR";
                    this.dataGridView3.Columns[3].HeaderText = "TL";
                    return;
                }
                DateTime time = Convert.ToDateTime(this.dataGridView1.Rows[num4].Cells[0].Value.ToString());
                string str = time.Date.Year.ToString();
                string str2 = time.Date.Month.ToString();
                DateTime date = time.Date;
                string str3 = date.Day.ToString();
                if (str2.Length <= 1)
                {
                    str2 = "0" + str2;
                }
                if (str3.Length <= 1)
                {
                    str3 = "0" + str3;
                }
                string[] textArray1 = new string[] { str3, "-", str2, "-", str };
                string str4 = string.Concat(textArray1);
                num = Convert.ToDouble(this.dataGridView1.Rows[num4].Cells[4].Value) - Convert.ToDouble(this.dataGridView1.Rows[num4].Cells[7].Value);
                num2 = Convert.ToDouble(this.dataGridView1.Rows[num4].Cells[5].Value) - Convert.ToDouble(this.dataGridView1.Rows[num4].Cells[8].Value);
                num3 = Convert.ToDouble(this.dataGridView1.Rows[num4].Cells[6].Value) - Convert.ToDouble(this.dataGridView1.Rows[num4].Cells[9].Value);
                object[] values = new object[] { str4, num, num2, num3 };
                this.dataGridView3.Rows.Add(values);
                num4++;
            }

        }

        private void toplamGoster()
        {
            double veresiyeToplamE = 0;
            double veresiyeToplamD = 0;
            double veresiyeToplamTl = 0;

            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                veresiyeToplamE += Convert.ToDouble(dataGridView3.Rows[i].Cells[1].Value);
                veresiyeToplamD += Convert.ToDouble(dataGridView3.Rows[i].Cells[2].Value);
                veresiyeToplamTl += Convert.ToDouble(dataGridView3.Rows[i].Cells[3].Value);
            }

            lblToplamE.Text = "€ : " + veresiyeToplamE.ToString();
            lblToplamD.Text = "$ : " + veresiyeToplamD.ToString();
            lblToplamTL.Text = "TL : " + veresiyeToplamTl.ToString();

            double num = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            double num4 = 0.0;
            double num5 = 0.0;
            double num6 = 0.0;
            double num7 = 0.0;
            double num8 = 0.0;
            double num9 = 0.0;
            double num10 = 0.0;
            double num11 = 0.0;
            double num12 = 0.0;
            double num13 = 0.0;
            double num14 = 0.0;
            double num15 = 0.0;
            int num37 = 0;
            while (true)
            {
                if (num37 >= this.dataGridView1.Rows.Count)
                {
                    object[] values = new object[0x10];
                    values[0] = "TOPLAM :";
                    values[1] = num3;
                    values[2] = num2;
                    values[3] = num;
                    values[4] = num6;
                    values[5] = num5;
                    values[6] = num4;
                    values[7] = num9;
                    values[8] = num8;
                    values[9] = num7;
                    values[10] = num12;
                    values[11] = num11;
                    values[12] = num10;
                    values[13] = num15;
                    values[14] = num14;
                    values[15] = num13;
                    this.dataGridView1.Rows.Add(values);
                    int num38 = 0;
                    while (true)
                    {
                        if (num38 >= this.dataGridView1.Rows.Count)
                        {
                            double num16 = 0.0;
                            double num17 = 0.0;
                            double num18 = 0.0;
                            double num19 = 0.0;
                            double num20 = 0.0;
                            double num21 = 0.0;
                            double num22 = 0.0;
                            double num23 = 0.0;
                            double num24 = 0.0;
                            double num25 = 0.0;
                            double num26 = 0.0;
                            double num27 = 0.0;
                            double num28 = 0.0;
                            double num29 = 0.0;
                            double num30 = 0.0;
                            double num31 = 0.0;
                            double num32 = 0.0;
                            double num33 = 0.0;
                            double num34 = 0.0;
                            double num35 = 0.0;
                            double num36 = 0.0;
                            int num39 = 0;
                            while (true)
                            {
                                if (num39 >= this.dataGridView2.Rows.Count)
                                {
                                    object[] objArray2 = new object[0x16];
                                    objArray2[0] = "TOPLAM :";
                                    objArray2[1] = num18;
                                    objArray2[2] = num17;
                                    objArray2[3] = num16;
                                    objArray2[4] = num21;
                                    objArray2[5] = num20;
                                    objArray2[6] = num19;
                                    objArray2[7] = num24;
                                    objArray2[8] = num23;
                                    objArray2[9] = num22;
                                    objArray2[10] = num27;
                                    objArray2[11] = num26;
                                    objArray2[12] = num25;
                                    objArray2[13] = num30;
                                    objArray2[14] = num29;
                                    objArray2[15] = num28;
                                    objArray2[0x10] = num33;
                                    objArray2[0x11] = num32;
                                    objArray2[0x12] = num31;
                                    objArray2[0x13] = num36;
                                    objArray2[20] = num35;
                                    objArray2[0x15] = num34;
                                    this.dataGridView2.Rows.Add(objArray2);
                                    return;
                                }
                                num16 += Convert.ToDouble(this.dataGridView2.Rows[num39].Cells[3].Value);
                                num17 += Convert.ToDouble(this.dataGridView2.Rows[num39].Cells[2].Value);
                                num18 += Convert.ToDouble(this.dataGridView2.Rows[num39].Cells[1].Value);
                                num19 += Convert.ToDouble(this.dataGridView2.Rows[num39].Cells[6].Value);
                                num20 += Convert.ToDouble(this.dataGridView2.Rows[num39].Cells[5].Value);
                                num21 += Convert.ToDouble(this.dataGridView2.Rows[num39].Cells[4].Value);
                                num22 += Convert.ToDouble(this.dataGridView2.Rows[num39].Cells[9].Value);
                                num23 += Convert.ToDouble(this.dataGridView2.Rows[num39].Cells[8].Value);
                                num24 += Convert.ToDouble(this.dataGridView2.Rows[num39].Cells[7].Value);
                                num25 += Convert.ToDouble(this.dataGridView2.Rows[num39].Cells[12].Value);
                                num26 += Convert.ToDouble(this.dataGridView2.Rows[num39].Cells[11].Value);
                                num27 += Convert.ToDouble(this.dataGridView2.Rows[num39].Cells[10].Value);
                                num28 += Convert.ToDouble(this.dataGridView2.Rows[num39].Cells[15].Value);
                                num29 += Convert.ToDouble(this.dataGridView2.Rows[num39].Cells[14].Value);
                                num30 += Convert.ToDouble(this.dataGridView2.Rows[num39].Cells[13].Value);
                                num31 += Convert.ToDouble(this.dataGridView2.Rows[num39].Cells[0x12].Value);
                                num32 += Convert.ToDouble(this.dataGridView2.Rows[num39].Cells[0x11].Value);
                                num33 += Convert.ToDouble(this.dataGridView2.Rows[num39].Cells[0x10].Value);
                                num34 += Convert.ToDouble(this.dataGridView2.Rows[num39].Cells[0x15].Value);
                                num35 += Convert.ToDouble(this.dataGridView2.Rows[num39].Cells[20].Value);
                                num36 += Convert.ToDouble(this.dataGridView2.Rows[num39].Cells[0x13].Value);
                                num39++;
                            }
                        }
                        if (this.dataGridView1.Rows[0].Cells[1].Value.ToString() == "TOPLAM")
                        {
                            this.dataGridView1.BackgroundColor = Color.Red;
                        }
                        num38++;
                    }
                }
                num += Convert.ToDouble(this.dataGridView1.Rows[num37].Cells[3].Value);
                num2 += Convert.ToDouble(this.dataGridView1.Rows[num37].Cells[2].Value);
                num3 += Convert.ToDouble(this.dataGridView1.Rows[num37].Cells[1].Value);
                num4 += Convert.ToDouble(this.dataGridView1.Rows[num37].Cells[6].Value);
                num5 += Convert.ToDouble(this.dataGridView1.Rows[num37].Cells[5].Value);
                num6 += Convert.ToDouble(this.dataGridView1.Rows[num37].Cells[4].Value);
                num7 += Convert.ToDouble(this.dataGridView1.Rows[num37].Cells[9].Value);
                num8 += Convert.ToDouble(this.dataGridView1.Rows[num37].Cells[8].Value);
                num9 += Convert.ToDouble(this.dataGridView1.Rows[num37].Cells[7].Value);
                num10 += Convert.ToDouble(this.dataGridView1.Rows[num37].Cells[12].Value);
                num11 += Convert.ToDouble(this.dataGridView1.Rows[num37].Cells[11].Value);
                num12 += Convert.ToDouble(this.dataGridView1.Rows[num37].Cells[10].Value);
                num13 += Convert.ToDouble(this.dataGridView1.Rows[num37].Cells[15].Value);
                num14 += Convert.ToDouble(this.dataGridView1.Rows[num37].Cells[14].Value);
                num15 += Convert.ToDouble(this.dataGridView1.Rows[num37].Cells[13].Value);
                num37++;
            }
            
            
        }

        private void datagrid2Doldur(DatabaseClass database, bool tarihBazli)
        {
            string sorgu = "";
            string yil, ay, gun, tarih, tarih_2;
            dataGridView2.Rows.Clear();

            DateTime DTIME = dateTimePicker1.Value;
            yil = DTIME.Date.Year.ToString();
            ay = DTIME.Date.Month.ToString();
            gun = DTIME.Date.Day.ToString();

            if (ay.Length <= 1)
            {
                ay = "0" + ay;
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

            tarih_2 = yil + "-" + ay + "-" + gun;

            String tarih1 = tarih;
            String tarih2 = tarih_2;           

            
            if (tarihBazli)
            {
                sorgu = "SELECT `ID`, `TL`, `DOLAR`, `EURO`, `Tarih`, `P_ID` FROM `para_degerleri_giderler` WHERE Tarih between '" + tarih1 + "' and '" + tarih2 + "'";
            }
            else
            {
                sorgu = "Select * FROM `para_degerleri_giderler` ";
            }
                       
            int num = 0;
            foreach (ParaDegerleriGider gider in database.giderDegerleri(sorgu))
            {
                if (gider.P_ID == 1)
                {
                    DateTime time = Convert.ToDateTime(gider.Tarih.ToString());
                    string str2 = time.Date.Year.ToString();
                    string str3 = time.Date.Month.ToString();
                    string str4 = time.Date.Day.ToString();
                    if (str3.Length <= 1)
                    {
                        str3 = "0" + str3;
                    }
                    if (str4.Length <= 1)
                    {
                        str4 = "0" + str4;
                    }
                    string[] textArray1 = new string[] { str4, "-", str3, "-", str2 };
                    string str5 = string.Concat(textArray1);
                    object[] values = new object[] { str5, gider.EURO, gider.DOLAR, gider.TL };
                    this.dataGridView2.Rows.Add(values);
                    continue;
                }
                if (gider.P_ID == 2)
                {
                    this.dataGridView2.Rows[num].Cells[4].Value = gider.EURO;
                    this.dataGridView2.Rows[num].Cells[5].Value = gider.DOLAR;
                    this.dataGridView2.Rows[num].Cells[6].Value = gider.TL;
                    continue;
                }
                if (gider.P_ID == 3)
                {
                    this.dataGridView2.Rows[num].Cells[7].Value = gider.EURO;
                    this.dataGridView2.Rows[num].Cells[8].Value = gider.DOLAR;
                    this.dataGridView2.Rows[num].Cells[9].Value = gider.TL;
                    continue;
                }
                if (gider.P_ID == 4)
                {
                    this.dataGridView2.Rows[num].Cells[10].Value = gider.EURO;
                    this.dataGridView2.Rows[num].Cells[11].Value = gider.DOLAR;
                    this.dataGridView2.Rows[num].Cells[12].Value = gider.TL;
                    continue;
                }
                if (gider.P_ID == 5)
                {
                    this.dataGridView2.Rows[num].Cells[13].Value = gider.EURO;
                    this.dataGridView2.Rows[num].Cells[14].Value = gider.DOLAR;
                    this.dataGridView2.Rows[num].Cells[15].Value = gider.TL;
                    continue;
                }
                if (gider.P_ID == 6)
                {
                    this.dataGridView2.Rows[num].Cells[0x10].Value = gider.EURO;
                    this.dataGridView2.Rows[num].Cells[0x11].Value = gider.DOLAR;
                    this.dataGridView2.Rows[num].Cells[0x12].Value = gider.TL;
                    continue;
                }
                if (gider.P_ID == 7)
                {
                    this.dataGridView2.Rows[num].Cells[0x13].Value = gider.EURO;
                    this.dataGridView2.Rows[num].Cells[20].Value = gider.DOLAR;
                    this.dataGridView2.Rows[num].Cells[0x15].Value = gider.TL;
                    num++;
                }
            }
            this.dataGridView2.Columns[0].HeaderText = "TARİH";
            this.dataGridView2.Columns[1].HeaderText = "EURO";
            this.dataGridView2.Columns[2].HeaderText = "DOLAR";
            this.dataGridView2.Columns[3].HeaderText = "TL";
            this.dataGridView2.Columns[4].HeaderText = "EURO";
            this.dataGridView2.Columns[5].HeaderText = "DOLAR";
            this.dataGridView2.Columns[6].HeaderText = "TL";
            this.dataGridView2.Columns[7].HeaderText = "EURO";
            this.dataGridView2.Columns[8].HeaderText = "DOLAR";
            this.dataGridView2.Columns[9].HeaderText = "TL";
            this.dataGridView2.Columns[10].HeaderText = "EURO";
            this.dataGridView2.Columns[11].HeaderText = "DOLAR";
            this.dataGridView2.Columns[12].HeaderText = "TL";
            this.dataGridView2.Columns[13].HeaderText = "EURO";
            this.dataGridView2.Columns[14].HeaderText = "DOLAR";
            this.dataGridView2.Columns[15].HeaderText = "TL";
            this.dataGridView2.Columns[0x10].HeaderText = "EURO";
            this.dataGridView2.Columns[0x11].HeaderText = "DOLAR";
            this.dataGridView2.Columns[0x12].HeaderText = "TL";
            this.dataGridView2.Columns[0x13].HeaderText = "EURO";
            this.dataGridView2.Columns[20].HeaderText = "DOLAR";
            this.dataGridView2.Columns[0x15].HeaderText = "TL";
            int num3 = 0;
            this.dataGridView2.ColumnHeadersHeight = 24;
            while (true)
            {
                if (num3 >= this.dataGridView2.ColumnCount)
                {
                   this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                   this.dataGridView2.ColumnHeadersHeight *= 2;
                    this.dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                    this.dataGridView2.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView2_CellPainting);
                    this.dataGridView2.Paint += new PaintEventHandler(this.dataGridView2_Paint);
                    this.dataGridView2.Scroll += new ScrollEventHandler(this.dataGridView2_Scroll);
                    this.dataGridView2.ColumnWidthChanged += new DataGridViewColumnEventHandler(this.dataGridView2_ColumnWidthChanged);
                    return;
                }
                this.dataGridView2.Columns[num3].Width = 2;
                

                num3++;
            }

        }

        private void datagrid1Doldur(DatabaseClass database, bool tarihBazli)
        {
            
            string sorgu = "";
            string yil, ay, gun, tarih, tarih_2;
            dataGridView1.Rows.Clear();
            DateTime DTIME = dateTimePicker1.Value;
            yil = DTIME.Date.Year.ToString();
            ay = DTIME.Date.Month.ToString();
            gun = DTIME.Date.Day.ToString();

            if (ay.Length <= 1)
            {
                ay = "0" + ay;
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

            tarih_2 = yil + "-" + ay + "-" + gun;

            String tarih1 = tarih;
            String tarih2 = tarih_2;           
            
            if (tarihBazli)
            {
           sorgu = "SELECT `ID`, `TL`, `DOLAR`, `EURO`, `Tarih`, `P_ID` FROM `para_degerleri` WHERE Tarih between '"+ tarih1 + "' and '"+tarih2+"'";
            }
            else
            {
                sorgu = "Select * FROM `para_degerleri` ";
            } 
            
            int num = 0;
            foreach (ParaDegerleriGelir gelir in database.gelirDegerleri(sorgu))
            {
                if (gelir.P_ID == 1)
                {
                    DateTime time = Convert.ToDateTime(gelir.Tarih.ToString());
                    string str2 = time.Date.Year.ToString();
                    string str3 = time.Date.Month.ToString();
                    string str4 = time.Date.Day.ToString();
                    if (str3.Length <= 1)
                    {
                        str3 = "0" + str3;
                    }
                    if (str4.Length <= 1)
                    {
                        str4 = "0" + str4;
                    }
                    string[] textArray1 = new string[] { str4, "-", str3, "-", str2 };
                    string str5 = string.Concat(textArray1);
                    object[] values = new object[] { str5, gelir.EURO, gelir.DOLAR, gelir.TL };
                    this.dataGridView1.Rows.Add(values);
                    continue;
                }
                if (gelir.P_ID == 2)
                {
                    this.dataGridView1.Rows[num].Cells[4].Value = gelir.EURO;
                    this.dataGridView1.Rows[num].Cells[5].Value = gelir.DOLAR;
                    this.dataGridView1.Rows[num].Cells[6].Value = gelir.TL;
                    continue;
                }
                if (gelir.P_ID == 3)
                {
                    this.dataGridView1.Rows[num].Cells[7].Value = gelir.EURO;
                    this.dataGridView1.Rows[num].Cells[8].Value = gelir.DOLAR;
                    this.dataGridView1.Rows[num].Cells[9].Value = gelir.TL;
                    continue;
                }
                if (gelir.P_ID == 4)
                {
                    this.dataGridView1.Rows[num].Cells[10].Value = gelir.EURO;
                    this.dataGridView1.Rows[num].Cells[11].Value = gelir.DOLAR;
                    this.dataGridView1.Rows[num].Cells[12].Value = gelir.TL;
                    continue;
                }
                if (gelir.P_ID == 5)
                {
                    this.dataGridView1.Rows[num].Cells[13].Value = gelir.EURO;
                    this.dataGridView1.Rows[num].Cells[14].Value = gelir.DOLAR;
                    this.dataGridView1.Rows[num].Cells[15].Value = gelir.TL;
                    num++;
                }
            }
            this.dataGridView1.Columns[0].HeaderText = "TARİH";
            this.dataGridView1.Columns[1].HeaderText = "EURO";
            this.dataGridView1.Columns[2].HeaderText = "DOLAR";
            this.dataGridView1.Columns[3].HeaderText = "TL";
            this.dataGridView1.Columns[4].HeaderText = "EURO";
            this.dataGridView1.Columns[5].HeaderText = "DOLAR";
            this.dataGridView1.Columns[6].HeaderText = "TL";
            this.dataGridView1.Columns[7].HeaderText = "EURO";
            this.dataGridView1.Columns[8].HeaderText = "DOLAR";
            this.dataGridView1.Columns[9].HeaderText = "TL";
            this.dataGridView1.Columns[10].HeaderText = "EURO";
            this.dataGridView1.Columns[11].HeaderText = "DOLAR";
            this.dataGridView1.Columns[12].HeaderText = "TL";
            this.dataGridView1.Columns[13].HeaderText = "EURO";
            this.dataGridView1.Columns[14].HeaderText = "DOLAR";
            this.dataGridView1.Columns[15].HeaderText = "TL";
            int num3 = 0;
            this.dataGridView1.ColumnHeadersHeight = 24;
            while (true)
            {
                if (num3 >= this.dataGridView1.ColumnCount)
                {
                    this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    this.dataGridView1.ColumnHeadersHeight *= 2;
                    this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                    this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
                    this.dataGridView1.Paint += new PaintEventHandler(this.dataGridView1_Paint);
                    this.dataGridView1.Scroll += new ScrollEventHandler(this.dataGridView1_Scroll);
                    this.dataGridView1.ColumnWidthChanged += new DataGridViewColumnEventHandler(this.dataGridView1_ColumnWidthChanged);
                    return;
                }
                this.dataGridView1.Columns[num3].Width = 2;
                num3++;
            }
        

    }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.RowIndex == -1) && (e.ColumnIndex > -1))
            {
                Rectangle cellBounds = e.CellBounds;
                /*   Rectangle* rectanglePtr1 = (Rectangle*) ref cellBounds;
                   rectanglePtr1.Y += e.CellBounds.Height / 2;
                   cellBounds.Height = e.CellBounds.Height / 2;*/

               cellBounds.Y += e.CellBounds.Height / 2;
               cellBounds.Height = e.CellBounds.Height / 2;
                e.PaintBackground(cellBounds, true);
                e.PaintContent(cellBounds);
                e.Handled = true;
            }
            
        }

        private void dataGridView2_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Rectangle displayRectangle = this.dataGridView2.DisplayRectangle;
            displayRectangle.Height = this.dataGridView2.ColumnHeadersHeight / 2;
            this.dataGridView2.Invalidate(displayRectangle);

        }

        private void dataGridView2_Paint(object sender, PaintEventArgs e)
        {
            string[] strArray = new string[] { "Dükkan Giderleri", "İade Alınan", "Firma Ödemeleri", "Peşin Alınan Ödeme", "Resul D. Ödeme", "Eleman 1", "Eleman 2" };
            Rectangle rect = new Rectangle();
            Rectangle rectangle2 = new Rectangle();
            for (int i = 0; i < 21; i += 3)
            {
                
                rect = this.dataGridView2.GetCellDisplayRectangle(i + 1, -1, true);
                rectangle2 = this.dataGridView2.GetCellDisplayRectangle(i + 1, -1, true);
                // int width = rectangle2.Width;
                
                rect.X += 1;
                rect.Y += 1;
                rect.Width = rect.Width * 5 / 2 + 10;
                rect.Height = rect.Height / 2 - 2;

                /* Rectangle*rectanglePtr1 = (Rectangle*)ref rect;
                 rectanglePtr1.X++;
                 Rectangle*rectanglePtr2 = (Rectangle*) ref rect;
                 rectanglePtr2.Y++;
                 Rectangle*rectanglePtr3 = (Rectangle*) ref rect;
                 rectanglePtr3.Width = ((rect.Width * 2) + width) - 15;
                 Rectangle*rectanglePtr4 = (Rectangle*) ref rect;
                 rectanglePtr4.Height = (rect.Height / 2) - 1;*/
                e.Graphics.FillRectangle(new SolidBrush(this.dataGridView2.ColumnHeadersDefaultCellStyle.BackColor), rect);
                StringFormat format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(strArray[i / 3], this.dataGridView2.ColumnHeadersDefaultCellStyle.Font, new SolidBrush(this.dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor), rect, format);
                
            }


        }

        private void dataGridView2_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle displayRectangle = this.dataGridView2.DisplayRectangle;
            displayRectangle.Height = this.dataGridView2.ColumnHeadersHeight / 2;
            this.dataGridView2.Invalidate(displayRectangle);

        }

        private void dataGridView3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((e.Value != null) && (Convert.ToDouble(e.Value.ToString()) < 0.0))
                {
                    e.CellStyle.BackColor = Color.Red;
                    //e.CellStyle.SelectionBackColor = Color.Yellow;
                    //e.CellStyle.SelectionForeColor = Color.Black;
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

        private void button2_Click(object sender, EventArgs e)
        {
            bool tarihBazli = true;
            SayfayıDoldur(tarihBazli);
        }
    }
}
