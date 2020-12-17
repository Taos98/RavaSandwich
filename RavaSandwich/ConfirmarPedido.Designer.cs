
namespace RavaSandwich
{
    partial class ConfirmarPedido
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
            this.labelTotalAPAgar = new System.Windows.Forms.Label();
            this.textBoxTotalAPagar = new System.Windows.Forms.TextBox();
            this.labelNombreC = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelCajero = new System.Windows.Forms.Label();
            this.labelNombreCajero = new System.Windows.Forms.Label();
            this.labelPedido = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.labelMetod = new System.Windows.Forms.Label();
            this.checkBoxEfectivo = new System.Windows.Forms.CheckBox();
            this.checkBoxTansbank = new System.Windows.Forms.CheckBox();
            this.checkBoxConsumoLocal = new System.Windows.Forms.CheckBox();
            this.checkBoxPedidosYa = new System.Windows.Forms.CheckBox();
            this.checkBoxPYEfectivo = new System.Windows.Forms.CheckBox();
            this.checkBoxPYDescuentos = new System.Windows.Forms.CheckBox();
            this.checkBoxPYOnline = new System.Windows.Forms.CheckBox();
            this.textBoxDescuento = new System.Windows.Forms.TextBox();
            this.labelIndicarDescto = new System.Windows.Forms.Label();
            this.listBoxPedido = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labelTotalAPAgar
            // 
            this.labelTotalAPAgar.AutoSize = true;
            this.labelTotalAPAgar.Location = new System.Drawing.Point(28, 81);
            this.labelTotalAPAgar.Name = "labelTotalAPAgar";
            this.labelTotalAPAgar.Size = new System.Drawing.Size(74, 15);
            this.labelTotalAPAgar.TabIndex = 0;
            this.labelTotalAPAgar.Text = "Total a Pagar";
            // 
            // textBoxTotalAPagar
            // 
            this.textBoxTotalAPagar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxTotalAPagar.Location = new System.Drawing.Point(125, 70);
            this.textBoxTotalAPagar.Multiline = true;
            this.textBoxTotalAPagar.Name = "textBoxTotalAPagar";
            this.textBoxTotalAPagar.ReadOnly = true;
            this.textBoxTotalAPagar.Size = new System.Drawing.Size(143, 51);
            this.textBoxTotalAPagar.TabIndex = 1;
            // 
            // labelNombreC
            // 
            this.labelNombreC.AutoSize = true;
            this.labelNombreC.Location = new System.Drawing.Point(12, 145);
            this.labelNombreC.Name = "labelNombreC";
            this.labelNombreC.Size = new System.Drawing.Size(94, 15);
            this.labelNombreC.TabIndex = 2;
            this.labelNombreC.Text = "Nombre Cliente:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(125, 142);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(143, 23);
            this.textBox1.TabIndex = 3;
            // 
            // labelCajero
            // 
            this.labelCajero.AutoSize = true;
            this.labelCajero.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelCajero.Location = new System.Drawing.Point(12, 18);
            this.labelCajero.Name = "labelCajero";
            this.labelCajero.Size = new System.Drawing.Size(80, 25);
            this.labelCajero.TabIndex = 4;
            this.labelCajero.Text = "Cajer@:";
            // 
            // labelNombreCajero
            // 
            this.labelNombreCajero.AutoSize = true;
            this.labelNombreCajero.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelNombreCajero.Location = new System.Drawing.Point(98, 18);
            this.labelNombreCajero.Name = "labelNombreCajero";
            this.labelNombreCajero.Size = new System.Drawing.Size(148, 25);
            this.labelNombreCajero.TabIndex = 5;
            this.labelNombreCajero.Text = "Nombre cajer@";
            // 
            // labelPedido
            // 
            this.labelPedido.AutoSize = true;
            this.labelPedido.Location = new System.Drawing.Point(365, 26);
            this.labelPedido.Name = "labelPedido";
            this.labelPedido.Size = new System.Drawing.Size(47, 15);
            this.labelPedido.TabIndex = 7;
            this.labelPedido.Text = "Pedido:";
            // 
            // btnPagar
            // 
            this.btnPagar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPagar.Location = new System.Drawing.Point(479, 412);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(232, 61);
            this.btnPagar.TabIndex = 8;
            this.btnPagar.Text = "Finalizar Pedido";
            this.btnPagar.UseVisualStyleBackColor = true;
            // 
            // labelMetod
            // 
            this.labelMetod.AutoSize = true;
            this.labelMetod.Location = new System.Drawing.Point(15, 202);
            this.labelMetod.Name = "labelMetod";
            this.labelMetod.Size = new System.Drawing.Size(95, 15);
            this.labelMetod.TabIndex = 9;
            this.labelMetod.Text = "Método de pago";
            // 
            // checkBoxEfectivo
            // 
            this.checkBoxEfectivo.AutoSize = true;
            this.checkBoxEfectivo.Location = new System.Drawing.Point(125, 211);
            this.checkBoxEfectivo.Name = "checkBoxEfectivo";
            this.checkBoxEfectivo.Size = new System.Drawing.Size(68, 19);
            this.checkBoxEfectivo.TabIndex = 10;
            this.checkBoxEfectivo.Text = "Efectivo";
            this.checkBoxEfectivo.UseVisualStyleBackColor = true;
            // 
            // checkBoxTansbank
            // 
            this.checkBoxTansbank.AutoSize = true;
            this.checkBoxTansbank.Location = new System.Drawing.Point(125, 236);
            this.checkBoxTansbank.Name = "checkBoxTansbank";
            this.checkBoxTansbank.Size = new System.Drawing.Size(79, 19);
            this.checkBoxTansbank.TabIndex = 11;
            this.checkBoxTansbank.Text = "TransBank";
            this.checkBoxTansbank.UseVisualStyleBackColor = true;
            // 
            // checkBoxConsumoLocal
            // 
            this.checkBoxConsumoLocal.AutoSize = true;
            this.checkBoxConsumoLocal.Location = new System.Drawing.Point(125, 261);
            this.checkBoxConsumoLocal.Name = "checkBoxConsumoLocal";
            this.checkBoxConsumoLocal.Size = new System.Drawing.Size(109, 19);
            this.checkBoxConsumoLocal.TabIndex = 12;
            this.checkBoxConsumoLocal.Text = "Consumo Local";
            this.checkBoxConsumoLocal.UseVisualStyleBackColor = true;
            // 
            // checkBoxPedidosYa
            // 
            this.checkBoxPedidosYa.AutoSize = true;
            this.checkBoxPedidosYa.Location = new System.Drawing.Point(125, 286);
            this.checkBoxPedidosYa.Name = "checkBoxPedidosYa";
            this.checkBoxPedidosYa.Size = new System.Drawing.Size(83, 19);
            this.checkBoxPedidosYa.TabIndex = 13;
            this.checkBoxPedidosYa.Text = "Pedidos Ya";
            this.checkBoxPedidosYa.UseVisualStyleBackColor = true;
            this.checkBoxPedidosYa.CheckedChanged += new System.EventHandler(this.checkBoxPedidosYa_CheckedChanged);
            // 
            // checkBoxPYEfectivo
            // 
            this.checkBoxPYEfectivo.AutoSize = true;
            this.checkBoxPYEfectivo.Location = new System.Drawing.Point(163, 312);
            this.checkBoxPYEfectivo.Name = "checkBoxPYEfectivo";
            this.checkBoxPYEfectivo.Size = new System.Drawing.Size(68, 19);
            this.checkBoxPYEfectivo.TabIndex = 14;
            this.checkBoxPYEfectivo.Text = "Efectivo";
            this.checkBoxPYEfectivo.UseVisualStyleBackColor = true;
            // 
            // checkBoxPYDescuentos
            // 
            this.checkBoxPYDescuentos.AutoSize = true;
            this.checkBoxPYDescuentos.Location = new System.Drawing.Point(163, 337);
            this.checkBoxPYDescuentos.Name = "checkBoxPYDescuentos";
            this.checkBoxPYDescuentos.Size = new System.Drawing.Size(87, 19);
            this.checkBoxPYDescuentos.TabIndex = 15;
            this.checkBoxPYDescuentos.Text = "Descuentos";
            this.checkBoxPYDescuentos.UseVisualStyleBackColor = true;
            this.checkBoxPYDescuentos.CheckedChanged += new System.EventHandler(this.checkBoxPYDescuentos_CheckedChanged);
            // 
            // checkBoxPYOnline
            // 
            this.checkBoxPYOnline.AutoSize = true;
            this.checkBoxPYOnline.Location = new System.Drawing.Point(163, 362);
            this.checkBoxPYOnline.Name = "checkBoxPYOnline";
            this.checkBoxPYOnline.Size = new System.Drawing.Size(61, 19);
            this.checkBoxPYOnline.TabIndex = 16;
            this.checkBoxPYOnline.Text = "Online";
            this.checkBoxPYOnline.UseVisualStyleBackColor = true;
            // 
            // textBoxDescuento
            // 
            this.textBoxDescuento.Location = new System.Drawing.Point(269, 335);
            this.textBoxDescuento.Name = "textBoxDescuento";
            this.textBoxDescuento.Size = new System.Drawing.Size(143, 23);
            this.textBoxDescuento.TabIndex = 17;
            // 
            // labelIndicarDescto
            // 
            this.labelIndicarDescto.AutoSize = true;
            this.labelIndicarDescto.Location = new System.Drawing.Point(274, 314);
            this.labelIndicarDescto.Name = "labelIndicarDescto";
            this.labelIndicarDescto.Size = new System.Drawing.Size(102, 15);
            this.labelIndicarDescto.TabIndex = 18;
            this.labelIndicarDescto.Text = "Indicar Descuento";
            // 
            // listBoxPedido
            // 
            this.listBoxPedido.FormattingEnabled = true;
            this.listBoxPedido.ItemHeight = 15;
            this.listBoxPedido.Location = new System.Drawing.Point(365, 63);
            this.listBoxPedido.Name = "listBoxPedido";
            this.listBoxPedido.Size = new System.Drawing.Size(346, 199);
            this.listBoxPedido.TabIndex = 20;
            // 
            // ConfirmarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 498);
            this.Controls.Add(this.listBoxPedido);
            this.Controls.Add(this.labelIndicarDescto);
            this.Controls.Add(this.textBoxDescuento);
            this.Controls.Add(this.checkBoxPYOnline);
            this.Controls.Add(this.checkBoxPYDescuentos);
            this.Controls.Add(this.checkBoxPYEfectivo);
            this.Controls.Add(this.checkBoxPedidosYa);
            this.Controls.Add(this.checkBoxConsumoLocal);
            this.Controls.Add(this.checkBoxTansbank);
            this.Controls.Add(this.checkBoxEfectivo);
            this.Controls.Add(this.labelMetod);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.labelPedido);
            this.Controls.Add(this.labelNombreCajero);
            this.Controls.Add(this.labelCajero);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelNombreC);
            this.Controls.Add(this.textBoxTotalAPagar);
            this.Controls.Add(this.labelTotalAPAgar);
            this.Name = "ConfirmarPedido";
            this.Text = "ConfirmarPedido";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTotalAPAgar;
        private System.Windows.Forms.TextBox textBoxTotalAPagar;
        private System.Windows.Forms.Label labelNombreC;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelCajero;
        private System.Windows.Forms.Label labelNombreCajero;
        private System.Windows.Forms.Label labelPedido;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.Label labelMetod;
        private System.Windows.Forms.CheckBox checkBoxEfectivo;
        private System.Windows.Forms.CheckBox checkBoxTansbank;
        private System.Windows.Forms.CheckBox checkBoxConsumoLocal;
        private System.Windows.Forms.CheckBox checkBoxPedidosYa;
        private System.Windows.Forms.CheckBox checkBoxPYEfectivo;
        private System.Windows.Forms.CheckBox checkBoxPYDescuentos;
        private System.Windows.Forms.CheckBox checkBoxPYOnline;
        private System.Windows.Forms.TextBox textBoxDescuento;
        private System.Windows.Forms.Label labelIndicarDescto;
        private System.Windows.Forms.ListBox listBoxPedido;
    }
}