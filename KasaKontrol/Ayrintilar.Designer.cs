namespace KasaKontrol
{
    partial class Ayrintilar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgridaylikkasa = new System.Windows.Forms.DataGridView();
            this.dtgridaylikayrintlikasa = new System.Windows.Forms.DataGridView();
            this.TARİH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AYLAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EURO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOLAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.datagridYillikKasa = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridaylikkasa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridaylikayrintlikasa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridYillikKasa)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgridaylikkasa
            // 
            this.dtgridaylikkasa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgridaylikkasa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgridaylikkasa.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgridaylikkasa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgridaylikkasa.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtgridaylikkasa.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtgridaylikkasa.Location = new System.Drawing.Point(12, 117);
            this.dtgridaylikkasa.Name = "dtgridaylikkasa";
            this.dtgridaylikkasa.Size = new System.Drawing.Size(1203, 155);
            this.dtgridaylikkasa.TabIndex = 0;
            this.dtgridaylikkasa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgridaylikkasa_CellClick);
            this.dtgridaylikkasa.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgridaylikkasa_CellClick);
            // 
            // dtgridaylikayrintlikasa
            // 
            this.dtgridaylikayrintlikasa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgridaylikayrintlikasa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgridaylikayrintlikasa.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgridaylikayrintlikasa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgridaylikayrintlikasa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TARİH,
            this.AYLAR,
            this.EURO,
            this.DOLAR,
            this.TL});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgridaylikayrintlikasa.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgridaylikayrintlikasa.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtgridaylikayrintlikasa.Location = new System.Drawing.Point(12, 312);
            this.dtgridaylikayrintlikasa.Name = "dtgridaylikayrintlikasa";
            this.dtgridaylikayrintlikasa.Size = new System.Drawing.Size(1203, 294);
            this.dtgridaylikayrintlikasa.TabIndex = 1;
            // 
            // TARİH
            // 
            this.TARİH.HeaderText = "TARİH";
            this.TARİH.Name = "TARİH";
            // 
            // AYLAR
            // 
            this.AYLAR.HeaderText = "AYLAR";
            this.AYLAR.Name = "AYLAR";
            // 
            // EURO
            // 
            this.EURO.HeaderText = "EURO";
            this.EURO.Name = "EURO";
            // 
            // DOLAR
            // 
            this.DOLAR.HeaderText = "DOLAR";
            this.DOLAR.Name = "DOLAR";
            // 
            // TL
            // 
            this.TL.HeaderText = "TL";
            this.TL.Name = "TL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "AYLIK KASALAR :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "AYRINTILAR :";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(1127, 634);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "Kapat";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // datagridYillikKasa
            // 
            this.datagridYillikKasa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridYillikKasa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridYillikKasa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridYillikKasa.DefaultCellStyle = dataGridViewCellStyle3;
            this.datagridYillikKasa.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.datagridYillikKasa.Location = new System.Drawing.Point(12, 25);
            this.datagridYillikKasa.Name = "datagridYillikKasa";
            this.datagridYillikKasa.Size = new System.Drawing.Size(1203, 63);
            this.datagridYillikKasa.TabIndex = 5;
            this.datagridYillikKasa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridYillikKasa_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "YILLIK KASALAR :";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(12, 641);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(206, 33);
            this.button2.TabIndex = 82;
            this.button2.Text = "Ayrıntılı Rapor Göster";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Ayrintilar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1231, 677);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.datagridYillikKasa);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgridaylikayrintlikasa);
            this.Controls.Add(this.dtgridaylikkasa);
            this.Name = "Ayrintilar";
            this.Text = "Ayrıntılar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Ayrintilar_FormClosed);
            this.Load += new System.EventHandler(this.Ayrintilar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgridaylikkasa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgridaylikayrintlikasa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridYillikKasa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgridaylikkasa;
        private System.Windows.Forms.DataGridView dtgridaylikayrintlikasa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TARİH;
        private System.Windows.Forms.DataGridViewTextBoxColumn AYLAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn EURO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOLAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn TL;
        private System.Windows.Forms.DataGridView datagridYillikKasa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
    }
}