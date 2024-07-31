namespace CapaVisual
{
    partial class frmPagosMatricula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagosMatricula));
            Matriculatxt = new TextBox();
            Anotxt = new TextBox();
            Modelotxt = new TextBox();
            Colortxt = new TextBox();
            Deudatxt = new TextBox();
            Buscarbtn = new Button();
            Pagarbtn = new Button();
            lblEstadoPago = new Label();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // Matriculatxt
            // 
            Matriculatxt.Location = new Point(259, 24);
            Matriculatxt.Name = "Matriculatxt";
            Matriculatxt.Size = new Size(126, 23);
            Matriculatxt.TabIndex = 0;
            Matriculatxt.KeyPress += Matriculatxt_KeyPress;
            // 
            // Anotxt
            // 
            Anotxt.Location = new Point(80, 76);
            Anotxt.Name = "Anotxt";
            Anotxt.ReadOnly = true;
            Anotxt.Size = new Size(125, 24);
            Anotxt.TabIndex = 1;
            // 
            // Modelotxt
            // 
            Modelotxt.Location = new Point(80, 32);
            Modelotxt.Name = "Modelotxt";
            Modelotxt.ReadOnly = true;
            Modelotxt.Size = new Size(125, 24);
            Modelotxt.TabIndex = 2;
            // 
            // Colortxt
            // 
            Colortxt.Location = new Point(80, 120);
            Colortxt.Name = "Colortxt";
            Colortxt.ReadOnly = true;
            Colortxt.Size = new Size(125, 24);
            Colortxt.TabIndex = 3;
            // 
            // Deudatxt
            // 
            Deudatxt.Location = new Point(83, 46);
            Deudatxt.Name = "Deudatxt";
            Deudatxt.ReadOnly = true;
            Deudatxt.Size = new Size(125, 24);
            Deudatxt.TabIndex = 4;
            // 
            // Buscarbtn
            // 
            Buscarbtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Buscarbtn.Location = new Point(404, 20);
            Buscarbtn.Name = "Buscarbtn";
            Buscarbtn.Size = new Size(100, 31);
            Buscarbtn.TabIndex = 5;
            Buscarbtn.Text = "Buscar";
            Buscarbtn.UseVisualStyleBackColor = true;
            Buscarbtn.Click += Buscarbtn_Click;
            // 
            // Pagarbtn
            // 
            Pagarbtn.Enabled = false;
            Pagarbtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Pagarbtn.Location = new Point(236, 365);
            Pagarbtn.Name = "Pagarbtn";
            Pagarbtn.Size = new Size(137, 55);
            Pagarbtn.TabIndex = 6;
            Pagarbtn.Text = "Realizar Pago";
            Pagarbtn.UseVisualStyleBackColor = true;
            Pagarbtn.Click += Pagarbtn_Click_1;
            // 
            // lblEstadoPago
            // 
            lblEstadoPago.BorderStyle = BorderStyle.FixedSingle;
            lblEstadoPago.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblEstadoPago.Location = new Point(457, 93);
            lblEstadoPago.Name = "lblEstadoPago";
            lblEstadoPago.Size = new Size(112, 36);
            lblEstadoPago.TabIndex = 7;
            lblEstadoPago.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.PagoIcon;
            pictureBox2.Location = new Point(389, 155);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(195, 162);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.RetrocerderIcon;
            pictureBox3.Location = new Point(12, 9);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(41, 37);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 10;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(170, 27);
            label1.Name = "label1";
            label1.Size = new Size(87, 15);
            label1.TabIndex = 22;
            label1.Text = "Ingresar Placa:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(14, 35);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 12;
            label2.Text = "Modelo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(14, 79);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 13;
            label3.Text = "Año:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(14, 123);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 14;
            label4.Text = "Color:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(17, 49);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 15;
            label5.Text = "Total:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(406, 105);
            label6.Name = "label6";
            label6.Size = new Size(45, 15);
            label6.TabIndex = 16;
            label6.Text = "Estado:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(Colortxt);
            groupBox1.Controls.Add(Modelotxt);
            groupBox1.Controls.Add(Anotxt);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            groupBox1.Location = new Point(49, 70);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(305, 171);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos del Vehículo";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(Deudatxt);
            groupBox2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            groupBox2.Location = new Point(49, 247);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(305, 91);
            groupBox2.TabIndex = 24;
            groupBox2.TabStop = false;
            groupBox2.Text = "Deuda Matricular";
            // 
            // frmPagosMatricula
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(627, 432);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label6);
            Controls.Add(label1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(lblEstadoPago);
            Controls.Add(Pagarbtn);
            Controls.Add(Buscarbtn);
            Controls.Add(Matriculatxt);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmPagosMatricula";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmPagosMatricula";
            FormClosing += frmPagosMatricula_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Matriculatxt;
        private TextBox Anotxt;
        private TextBox Modelotxt;
        private TextBox Colortxt;
        private TextBox Deudatxt;
        private Button Buscarbtn;
        private Button Pagarbtn;
        private Label lblEstadoPago;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}