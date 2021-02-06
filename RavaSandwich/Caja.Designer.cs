
namespace RavaSandwich
{
    partial class Caja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Caja));
            this.btnMenu = new System.Windows.Forms.Button();
            this.txtVtasEfec = new System.Windows.Forms.TextBox();
            this.txtVtasTransbank = new System.Windows.Forms.TextBox();
            this.txtVtasCredito = new System.Windows.Forms.TextBox();
            this.txtGastosSueldos = new System.Windows.Forms.TextBox();
            this.txtVtasPedidosYa = new System.Windows.Forms.TextBox();
            this.txtDescuentos = new System.Windows.Forms.TextBox();
            this.txtSobre = new System.Windows.Forms.TextBox();
            this.btnDinero = new System.Windows.Forms.Button();
            this.btnSueldos = new System.Windows.Forms.Button();
            this.btnGastos = new System.Windows.Forms.Button();
            this.btnCerrarTurno = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listVentas = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.Green;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMenu.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMenu.Image")));
            this.btnMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu.Location = new System.Drawing.Point(568, 50);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(149, 47);
            this.btnMenu.TabIndex = 0;
            this.btnMenu.Text = "Menú principal";
            this.btnMenu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // txtVtasEfec
            // 
            this.txtVtasEfec.Location = new System.Drawing.Point(172, 63);
            this.txtVtasEfec.Name = "txtVtasEfec";
            this.txtVtasEfec.Size = new System.Drawing.Size(141, 23);
            this.txtVtasEfec.TabIndex = 1;
            // 
            // txtVtasTransbank
            // 
            this.txtVtasTransbank.Location = new System.Drawing.Point(172, 92);
            this.txtVtasTransbank.Name = "txtVtasTransbank";
            this.txtVtasTransbank.Size = new System.Drawing.Size(142, 23);
            this.txtVtasTransbank.TabIndex = 2;
            // 
            // txtVtasCredito
            // 
            this.txtVtasCredito.Location = new System.Drawing.Point(173, 121);
            this.txtVtasCredito.Name = "txtVtasCredito";
            this.txtVtasCredito.Size = new System.Drawing.Size(141, 23);
            this.txtVtasCredito.TabIndex = 3;
            // 
            // txtGastosSueldos
            // 
            this.txtGastosSueldos.Location = new System.Drawing.Point(173, 150);
            this.txtGastosSueldos.Name = "txtGastosSueldos";
            this.txtGastosSueldos.Size = new System.Drawing.Size(141, 23);
            this.txtGastosSueldos.TabIndex = 4;
            // 
            // txtVtasPedidosYa
            // 
            this.txtVtasPedidosYa.Location = new System.Drawing.Point(173, 179);
            this.txtVtasPedidosYa.Name = "txtVtasPedidosYa";
            this.txtVtasPedidosYa.Size = new System.Drawing.Size(141, 23);
            this.txtVtasPedidosYa.TabIndex = 5;
            // 
            // txtDescuentos
            // 
            this.txtDescuentos.Location = new System.Drawing.Point(173, 208);
            this.txtDescuentos.Name = "txtDescuentos";
            this.txtDescuentos.Size = new System.Drawing.Size(141, 23);
            this.txtDescuentos.TabIndex = 6;
            // 
            // txtSobre
            // 
            this.txtSobre.Location = new System.Drawing.Point(172, 237);
            this.txtSobre.Name = "txtSobre";
            this.txtSobre.Size = new System.Drawing.Size(142, 23);
            this.txtSobre.TabIndex = 7;
            // 
            // btnDinero
            // 
            this.btnDinero.BackColor = System.Drawing.Color.GreenYellow;
            this.btnDinero.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDinero.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDinero.Image = ((System.Drawing.Image)(resources.GetObject("btnDinero.Image")));
            this.btnDinero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDinero.Location = new System.Drawing.Point(32, 301);
            this.btnDinero.Name = "btnDinero";
            this.btnDinero.Size = new System.Drawing.Size(109, 46);
            this.btnDinero.TabIndex = 8;
            this.btnDinero.Text = "Dinero";
            this.btnDinero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDinero.UseVisualStyleBackColor = false;
            this.btnDinero.Click += new System.EventHandler(this.btnBillete_Click);
            // 
            // btnSueldos
            // 
            this.btnSueldos.BackColor = System.Drawing.Color.GreenYellow;
            this.btnSueldos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSueldos.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSueldos.Image = ((System.Drawing.Image)(resources.GetObject("btnSueldos.Image")));
            this.btnSueldos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSueldos.Location = new System.Drawing.Point(160, 302);
            this.btnSueldos.Name = "btnSueldos";
            this.btnSueldos.Size = new System.Drawing.Size(106, 45);
            this.btnSueldos.TabIndex = 9;
            this.btnSueldos.Text = "Sueldos";
            this.btnSueldos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSueldos.UseVisualStyleBackColor = false;
            this.btnSueldos.Click += new System.EventHandler(this.btnSueldos_Click);
            // 
            // btnGastos
            // 
            this.btnGastos.BackColor = System.Drawing.Color.GreenYellow;
            this.btnGastos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGastos.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGastos.Image = ((System.Drawing.Image)(resources.GetObject("btnGastos.Image")));
            this.btnGastos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGastos.Location = new System.Drawing.Point(290, 304);
            this.btnGastos.Name = "btnGastos";
            this.btnGastos.Size = new System.Drawing.Size(109, 43);
            this.btnGastos.TabIndex = 10;
            this.btnGastos.Text = "Gastos";
            this.btnGastos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGastos.UseVisualStyleBackColor = false;
            this.btnGastos.Click += new System.EventHandler(this.btnGastos_Click);
            // 
            // btnCerrarTurno
            // 
            this.btnCerrarTurno.BackColor = System.Drawing.Color.DarkOrange;
            this.btnCerrarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrarTurno.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCerrarTurno.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarTurno.Image")));
            this.btnCerrarTurno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarTurno.Location = new System.Drawing.Point(553, 284);
            this.btnCerrarTurno.Name = "btnCerrarTurno";
            this.btnCerrarTurno.Size = new System.Drawing.Size(164, 75);
            this.btnCerrarTurno.TabIndex = 11;
            this.btnCerrarTurno.Text = "Cerrar Caja";
            this.btnCerrarTurno.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrarTurno.UseVisualStyleBackColor = false;
            this.btnCerrarTurno.Click += new System.EventHandler(this.btnCerrarTurno_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Ventas Efectivo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Ventas Transbank";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Ventas Créditos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Gastos y sueldos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Ventas Pedidos Ya";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "Descuentos";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(63, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 19;
            this.label7.Text = "Sobre";
            // 
            // listVentas
            // 
            this.listVentas.FormattingEnabled = true;
            this.listVentas.ItemHeight = 15;
            this.listVentas.Location = new System.Drawing.Point(480, 108);
            this.listVentas.Name = "listVentas";
            this.listVentas.Size = new System.Drawing.Size(254, 154);
            this.listVentas.TabIndex = 20;
            // 
            // Caja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(746, 437);
            this.Controls.Add(this.listVentas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCerrarTurno);
            this.Controls.Add(this.btnGastos);
            this.Controls.Add(this.btnSueldos);
            this.Controls.Add(this.btnDinero);
            this.Controls.Add(this.txtSobre);
            this.Controls.Add(this.txtDescuentos);
            this.Controls.Add(this.txtVtasPedidosYa);
            this.Controls.Add(this.txtGastosSueldos);
            this.Controls.Add(this.txtVtasCredito);
            this.Controls.Add(this.txtVtasTransbank);
            this.Controls.Add(this.txtVtasEfec);
            this.Controls.Add(this.btnMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Caja";
            this.Text = "Caja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.TextBox txtVtasEfec;
        private System.Windows.Forms.TextBox txtVtasTransbank;
        private System.Windows.Forms.TextBox txtVtasCredito;
        private System.Windows.Forms.TextBox txtGastosSueldos;
        private System.Windows.Forms.TextBox txtVtasPedidosYa;
        private System.Windows.Forms.TextBox txtDescuentos;
        private System.Windows.Forms.TextBox txtSobre;
        private System.Windows.Forms.Button btnDinero;
        private System.Windows.Forms.Button btnSueldos;
        private System.Windows.Forms.Button btnGastos;
        private System.Windows.Forms.Button btnCerrarTurno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listVentas;
    }
}