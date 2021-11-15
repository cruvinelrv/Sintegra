namespace Multisoft.SistemaSintegra
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.rbTipoImpMFD = new System.Windows.Forms.RadioButton();
            this.rbTipoImpComum = new System.Windows.Forms.RadioButton();
            this.cb75 = new System.Windows.Forms.CheckBox();
            this.cb60 = new System.Windows.Forms.CheckBox();
            this.cb56 = new System.Windows.Forms.CheckBox();
            this.cb55 = new System.Windows.Forms.CheckBox();
            this.cb54 = new System.Windows.Forms.CheckBox();
            this.cb53 = new System.Windows.Forms.CheckBox();
            this.cb51 = new System.Windows.Forms.CheckBox();
            this.cb50 = new System.Windows.Forms.CheckBox();
            this.dt10DATAINICIAL = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGerar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtRelatorio = new System.Windows.Forms.TextBox();
            this.cmbSoftware = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rbTipoImpMFD);
            this.panel1.Controls.Add(this.rbTipoImpComum);
            this.panel1.Controls.Add(this.cb75);
            this.panel1.Controls.Add(this.cb60);
            this.panel1.Controls.Add(this.cb56);
            this.panel1.Controls.Add(this.cb55);
            this.panel1.Controls.Add(this.cb54);
            this.panel1.Controls.Add(this.cb53);
            this.panel1.Controls.Add(this.cb51);
            this.panel1.Controls.Add(this.cb50);
            this.panel1.Controls.Add(this.dt10DATAINICIAL);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnGerar);
            this.panel1.Location = new System.Drawing.Point(16, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 263);
            this.panel1.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Impressora Bematech:";
            // 
            // rbTipoImpMFD
            // 
            this.rbTipoImpMFD.AutoSize = true;
            this.rbTipoImpMFD.Location = new System.Drawing.Point(147, 80);
            this.rbTipoImpMFD.Name = "rbTipoImpMFD";
            this.rbTipoImpMFD.Size = new System.Drawing.Size(63, 17);
            this.rbTipoImpMFD.TabIndex = 35;
            this.rbTipoImpMFD.Text = "Térmica";
            this.rbTipoImpMFD.UseVisualStyleBackColor = true;
            // 
            // rbTipoImpComum
            // 
            this.rbTipoImpComum.AutoSize = true;
            this.rbTipoImpComum.Checked = true;
            this.rbTipoImpComum.Location = new System.Drawing.Point(19, 80);
            this.rbTipoImpComum.Name = "rbTipoImpComum";
            this.rbTipoImpComum.Size = new System.Drawing.Size(64, 17);
            this.rbTipoImpComum.TabIndex = 34;
            this.rbTipoImpComum.TabStop = true;
            this.rbTipoImpComum.Text = "Matricial";
            this.rbTipoImpComum.UseVisualStyleBackColor = true;
            // 
            // cb75
            // 
            this.cb75.AutoSize = true;
            this.cb75.Location = new System.Drawing.Point(147, 149);
            this.cb75.Name = "cb75";
            this.cb75.Size = new System.Drawing.Size(117, 17);
            this.cb75.TabIndex = 33;
            this.cb75.Text = "Gerar Reg. Tipo 75";
            this.cb75.UseVisualStyleBackColor = true;
            // 
            // cb60
            // 
            this.cb60.AutoSize = true;
            this.cb60.Location = new System.Drawing.Point(147, 126);
            this.cb60.Name = "cb60";
            this.cb60.Size = new System.Drawing.Size(117, 17);
            this.cb60.TabIndex = 32;
            this.cb60.Text = "Gerar Reg. Tipo 60";
            this.cb60.UseVisualStyleBackColor = true;
            // 
            // cb56
            // 
            this.cb56.AutoSize = true;
            this.cb56.Location = new System.Drawing.Point(162, 212);
            this.cb56.Name = "cb56";
            this.cb56.Size = new System.Drawing.Size(117, 17);
            this.cb56.TabIndex = 31;
            this.cb56.Text = "Gerar Reg. Tipo 56";
            this.cb56.UseVisualStyleBackColor = true;
            this.cb56.Visible = false;
            // 
            // cb55
            // 
            this.cb55.AutoSize = true;
            this.cb55.Location = new System.Drawing.Point(162, 189);
            this.cb55.Name = "cb55";
            this.cb55.Size = new System.Drawing.Size(117, 17);
            this.cb55.TabIndex = 30;
            this.cb55.Text = "Gerar Reg. Tipo 55";
            this.cb55.UseVisualStyleBackColor = true;
            this.cb55.Visible = false;
            // 
            // cb54
            // 
            this.cb54.AutoSize = true;
            this.cb54.Location = new System.Drawing.Point(147, 103);
            this.cb54.Name = "cb54";
            this.cb54.Size = new System.Drawing.Size(117, 17);
            this.cb54.TabIndex = 29;
            this.cb54.Text = "Gerar Reg. Tipo 54";
            this.cb54.UseVisualStyleBackColor = true;
            // 
            // cb53
            // 
            this.cb53.AutoSize = true;
            this.cb53.Location = new System.Drawing.Point(19, 149);
            this.cb53.Name = "cb53";
            this.cb53.Size = new System.Drawing.Size(117, 17);
            this.cb53.TabIndex = 28;
            this.cb53.Text = "Gerar Reg. Tipo 53";
            this.cb53.UseVisualStyleBackColor = true;
            // 
            // cb51
            // 
            this.cb51.AutoSize = true;
            this.cb51.Location = new System.Drawing.Point(19, 126);
            this.cb51.Name = "cb51";
            this.cb51.Size = new System.Drawing.Size(117, 17);
            this.cb51.TabIndex = 27;
            this.cb51.Text = "Gerar Reg. Tipo 51";
            this.cb51.UseVisualStyleBackColor = true;
            // 
            // cb50
            // 
            this.cb50.AutoSize = true;
            this.cb50.Location = new System.Drawing.Point(19, 103);
            this.cb50.Name = "cb50";
            this.cb50.Size = new System.Drawing.Size(117, 17);
            this.cb50.TabIndex = 26;
            this.cb50.Text = "Gerar Reg. Tipo 50";
            this.cb50.UseVisualStyleBackColor = true;
            // 
            // dt10DATAINICIAL
            // 
            this.dt10DATAINICIAL.Location = new System.Drawing.Point(19, 34);
            this.dt10DATAINICIAL.Name = "dt10DATAINICIAL";
            this.dt10DATAINICIAL.Size = new System.Drawing.Size(260, 20);
            this.dt10DATAINICIAL.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Mês de Referência";
            // 
            // btnGerar
            // 
            this.btnGerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(196)))), ((int)(((byte)(196)))));
            this.btnGerar.Enabled = false;
            this.btnGerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerar.ForeColor = System.Drawing.Color.White;
            this.btnGerar.Location = new System.Drawing.Point(19, 195);
            this.btnGerar.Name = "btnGerar";
            this.btnGerar.Size = new System.Drawing.Size(260, 48);
            this.btnGerar.TabIndex = 21;
            this.btnGerar.Text = "GERAR";
            this.btnGerar.UseVisualStyleBackColor = false;
            this.btnGerar.Click += new System.EventHandler(this.btnGerar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Multisoft.SistemaSintegra.Properties.Resources.topo;
            this.pictureBox1.Location = new System.Drawing.Point(63, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(206, 65);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Multisoft.SistemaSintegra.Properties.Resources.loading_big;
            this.pictureBox2.Location = new System.Drawing.Point(46, 102);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(234, 242);
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // txtRelatorio
            // 
            this.txtRelatorio.Location = new System.Drawing.Point(312, 51);
            this.txtRelatorio.Multiline = true;
            this.txtRelatorio.Name = "txtRelatorio";
            this.txtRelatorio.ReadOnly = true;
            this.txtRelatorio.Size = new System.Drawing.Size(349, 296);
            this.txtRelatorio.TabIndex = 24;
            // 
            // cmbSoftware
            // 
            this.cmbSoftware.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSoftware.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSoftware.FormattingEnabled = true;
            this.cmbSoftware.Items.AddRange(new object[] {
            "Multisoft LOJA",
            "Multisoft SET",
            "Multisoft SDE 2009"});
            this.cmbSoftware.Location = new System.Drawing.Point(418, 12);
            this.cmbSoftware.Name = "cmbSoftware";
            this.cmbSoftware.Size = new System.Drawing.Size(243, 31);
            this.cmbSoftware.TabIndex = 37;
            this.cmbSoftware.SelectedIndexChanged += new System.EventHandler(this.cmbSoftware_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(308, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 23);
            this.label2.TabIndex = 38;
            this.label2.Text = "Software:";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 39;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 40;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(673, 359);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSoftware);
            this.Controls.Add(this.txtRelatorio);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multisoft - Módulo SINTEGRA v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DateTimePicker dt10DATAINICIAL;
        public System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGerar;
        private System.Windows.Forms.CheckBox cb50;
        private System.Windows.Forms.CheckBox cb75;
        private System.Windows.Forms.CheckBox cb60;
        private System.Windows.Forms.CheckBox cb56;
        private System.Windows.Forms.CheckBox cb55;
        private System.Windows.Forms.CheckBox cb54;
        private System.Windows.Forms.CheckBox cb53;
        private System.Windows.Forms.CheckBox cb51;
        private System.Windows.Forms.RadioButton rbTipoImpMFD;
        private System.Windows.Forms.RadioButton rbTipoImpComum;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRelatorio;
        private System.Windows.Forms.ComboBox cmbSoftware;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

