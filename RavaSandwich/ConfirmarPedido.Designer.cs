
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
            this.textBoxNombreCliente = new System.Windows.Forms.TextBox();
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
            this.buttonAtras = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // labelTotalAPAgar
            // 
            this.labelTotalAPAgar.AutoSize = true;
            this.labelTotalAPAgar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTotalAPAgar.Location = new System.Drawing.Point(28, 75);
            this.labelTotalAPAgar.Name = "labelTotalAPAgar";
            this.labelTotalAPAgar.Size = new System.Drawing.Size(85, 17);
            this.labelTotalAPAgar.TabIndex = 0;
            this.labelTotalAPAgar.Text = "Total a Pagar";
            // 
            // textBoxTotalAPagar
            // 
            this.textBoxTotalAPagar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxTotalAPagar.Location = new System.Drawing.Point(125, 62);
            this.textBoxTotalAPagar.Multiline = true;
            this.textBoxTotalAPagar.Name = "textBoxTotalAPagar";
            this.textBoxTotalAPagar.ReadOnly = true;
            this.textBoxTotalAPagar.Size = new System.Drawing.Size(143, 57);
            this.textBoxTotalAPagar.TabIndex = 1;
            // 
            // labelNombreC
            // 
            this.labelNombreC.AutoSize = true;
            this.labelNombreC.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelNombreC.Location = new System.Drawing.Point(12, 147);
            this.labelNombreC.Name = "labelNombreC";
            this.labelNombreC.Size = new System.Drawing.Size(103, 17);
            this.labelNombreC.TabIndex = 2;
            this.labelNombreC.Text = "Nombre Cliente:";
            // 
            // textBoxNombreCliente
            // 
            this.textBoxNombreCliente.Location = new System.Drawing.Point(125, 144);
            this.textBoxNombreCliente.Name = "textBoxNombreCliente";
            this.textBoxNombreCliente.Size = new System.Drawing.Size(143, 25);
            this.textBoxNombreCliente.TabIndex = 3;
            // 
            // labelCajero
            // 
            this.labelCajero.AutoSize = true;
            this.labelCajero.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelCajero.Location = new System.Drawing.Point(12, 20);
            this.labelCajero.Name = "labelCajero";
            this.labelCajero.Size = new System.Drawing.Size(80, 25);
            this.labelCajero.TabIndex = 4;
            this.labelCajero.Text = "Cajer@:";
            // 
            // labelNombreCajero
            // 
            this.labelNombreCajero.AutoSize = true;
            this.labelNombreCajero.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelNombreCajero.Location = new System.Drawing.Point(98, 20);
            this.labelNombreCajero.Name = "labelNombreCajero";
            this.labelNombreCajero.Size = new System.Drawing.Size(148, 25);
            this.labelNombreCajero.TabIndex = 5;
            this.labelNombreCajero.Text = "Nombre cajer@";
            // 
            // labelPedido
            // 
            this.labelPedido.AutoSize = true;
            this.labelPedido.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPedido.Location = new System.Drawing.Point(365, 29);
            this.labelPedido.Name = "labelPedido";
            this.labelPedido.Size = new System.Drawing.Size(52, 17);
            this.labelPedido.TabIndex = 7;
            this.labelPedido.Text = "Pedido:";
            // 
            // btnPagar
            // 
            this.btnPagar.BackColor = System.Drawing.Color.Crimson;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPagar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPagar.Location = new System.Drawing.Point(479, 412);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(232, 69);
            this.btnPagar.TabIndex = 8;
            this.btnPagar.Text = "Finalizar Pedido";
            this.btnPagar.UseVisualStyleBackColor = false;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // labelMetod
            // 
            this.labelMetod.AutoSize = true;
            this.labelMetod.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelMetod.Location = new System.Drawing.Point(12, 186);
            this.labelMetod.Name = "labelMetod";
            this.labelMetod.Size = new System.Drawing.Size(109, 17);
            this.labelMetod.TabIndex = 9;
            this.labelMetod.Text = "Método de pago";
            // 
            // checkBoxEfectivo
            // 
            this.checkBoxEfectivo.AutoSize = true;
            this.checkBoxEfectivo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxEfectivo.Location = new System.Drawing.Point(122, 196);
            this.checkBoxEfectivo.Name = "checkBoxEfectivo";
            this.checkBoxEfectivo.Size = new System.Drawing.Size(72, 21);
            this.checkBoxEfectivo.TabIndex = 10;
            this.checkBoxEfectivo.Text = "Efectivo";
            this.checkBoxEfectivo.UseVisualStyleBackColor = true;
            this.checkBoxEfectivo.CheckedChanged += new System.EventHandler(this.checkBoxEfectivo_CheckedChanged);
            // 
            // checkBoxTansbank
            // 
            this.checkBoxTansbank.AutoSize = true;
            this.checkBoxTansbank.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxTansbank.Location = new System.Drawing.Point(122, 224);
            this.checkBoxTansbank.Name = "checkBoxTansbank";
            this.checkBoxTansbank.Size = new System.Drawing.Size(85, 21);
            this.checkBoxTansbank.TabIndex = 11;
            this.checkBoxTansbank.Text = "TransBank";
            this.checkBoxTansbank.UseVisualStyleBackColor = true;
            this.checkBoxTansbank.CheckedChanged += new System.EventHandler(this.checkBoxTansbank_CheckedChanged);
            // 
            // checkBoxConsumoLocal
            // 
            this.checkBoxConsumoLocal.AutoSize = true;
            this.checkBoxConsumoLocal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxConsumoLocal.Location = new System.Drawing.Point(122, 253);
            this.checkBoxConsumoLocal.Name = "checkBoxConsumoLocal";
            this.checkBoxConsumoLocal.Size = new System.Drawing.Size(116, 21);
            this.checkBoxConsumoLocal.TabIndex = 12;
            this.checkBoxConsumoLocal.Text = "Consumo Local";
            this.checkBoxConsumoLocal.UseVisualStyleBackColor = true;
            this.checkBoxConsumoLocal.CheckedChanged += new System.EventHandler(this.checkBoxConsumoLocal_CheckedChanged);
            // 
            // checkBoxPedidosYa
            // 
            this.checkBoxPedidosYa.AutoSize = true;
            this.checkBoxPedidosYa.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxPedidosYa.Location = new System.Drawing.Point(122, 281);
            this.checkBoxPedidosYa.Name = "checkBoxPedidosYa";
            this.checkBoxPedidosYa.Size = new System.Drawing.Size(91, 21);
            this.checkBoxPedidosYa.TabIndex = 13;
            this.checkBoxPedidosYa.Text = "Pedidos Ya";
            this.checkBoxPedidosYa.UseVisualStyleBackColor = true;
            this.checkBoxPedidosYa.CheckedChanged += new System.EventHandler(this.checkBoxPedidosYa_CheckedChanged);
            // 
            // checkBoxPYEfectivo
            // 
            this.checkBoxPYEfectivo.AutoSize = true;
            this.checkBoxPYEfectivo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxPYEfectivo.Location = new System.Drawing.Point(160, 311);
            this.checkBoxPYEfectivo.Name = "checkBoxPYEfectivo";
            this.checkBoxPYEfectivo.Size = new System.Drawing.Size(72, 21);
            this.checkBoxPYEfectivo.TabIndex = 14;
            this.checkBoxPYEfectivo.Text = "Efectivo";
            this.checkBoxPYEfectivo.UseVisualStyleBackColor = true;
            this.checkBoxPYEfectivo.CheckedChanged += new System.EventHandler(this.checkBoxPYEfectivo_CheckedChanged);
            // 
            // checkBoxPYDescuentos
            // 
            this.checkBoxPYDescuentos.AutoSize = true;
            this.checkBoxPYDescuentos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxPYDescuentos.Location = new System.Drawing.Point(160, 339);
            this.checkBoxPYDescuentos.Name = "checkBoxPYDescuentos";
            this.checkBoxPYDescuentos.Size = new System.Drawing.Size(94, 21);
            this.checkBoxPYDescuentos.TabIndex = 15;
            this.checkBoxPYDescuentos.Text = "Descuentos";
            this.checkBoxPYDescuentos.UseVisualStyleBackColor = true;
            this.checkBoxPYDescuentos.CheckedChanged += new System.EventHandler(this.checkBoxPYDescuentos_CheckedChanged);
            // 
            // checkBoxPYOnline
            // 
            this.checkBoxPYOnline.AutoSize = true;
            this.checkBoxPYOnline.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxPYOnline.Location = new System.Drawing.Point(160, 367);
            this.checkBoxPYOnline.Name = "checkBoxPYOnline";
            this.checkBoxPYOnline.Size = new System.Drawing.Size(64, 21);
            this.checkBoxPYOnline.TabIndex = 16;
            this.checkBoxPYOnline.Text = "Online";
            this.checkBoxPYOnline.UseVisualStyleBackColor = true;
            this.checkBoxPYOnline.CheckedChanged += new System.EventHandler(this.checkBoxPYOnline_CheckedChanged);
            // 
            // textBoxDescuento
            // 
            this.textBoxDescuento.Location = new System.Drawing.Point(266, 337);
            this.textBoxDescuento.Name = "textBoxDescuento";
            this.textBoxDescuento.Size = new System.Drawing.Size(143, 25);
            this.textBoxDescuento.TabIndex = 17;
            // 
            // labelIndicarDescto
            // 
            this.labelIndicarDescto.AutoSize = true;
            this.labelIndicarDescto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelIndicarDescto.Location = new System.Drawing.Point(271, 313);
            this.labelIndicarDescto.Name = "labelIndicarDescto";
            this.labelIndicarDescto.Size = new System.Drawing.Size(112, 17);
            this.labelIndicarDescto.TabIndex = 18;
            this.labelIndicarDescto.Text = "Indicar Descuento";
            // 
            // listBoxPedido
            // 
            this.listBoxPedido.FormattingEnabled = true;
            this.listBoxPedido.ItemHeight = 17;
            this.listBoxPedido.Location = new System.Drawing.Point(365, 54);
            this.listBoxPedido.Name = "listBoxPedido";
            this.listBoxPedido.Size = new System.Drawing.Size(346, 225);
            this.listBoxPedido.TabIndex = 20;
            // 
            // buttonAtras
            // 
            this.buttonAtras.BackColor = System.Drawing.Color.Green;
            this.buttonAtras.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAtras.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAtras.Location = new System.Drawing.Point(28, 423);
            this.buttonAtras.Name = "buttonAtras";
            this.buttonAtras.Size = new System.Drawing.Size(138, 51);
            this.buttonAtras.TabIndex = 21;
            this.buttonAtras.Text = "Atras";
            this.buttonAtras.UseVisualStyleBackColor = false;
            this.buttonAtras.Click += new System.EventHandler(this.buttonAtras_Click);
            // 
            // ConfirmarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(772, 498);
            this.Controls.Add(this.buttonAtras);
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
            this.Controls.Add(this.textBoxNombreCliente);
            this.Controls.Add(this.labelNombreC);
            this.Controls.Add(this.textBoxTotalAPagar);
            this.Controls.Add(this.labelTotalAPAgar);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "ConfirmarPedido";
            this.Text = "ConfirmarPedido";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTotalAPAgar;
        private System.Windows.Forms.TextBox textBoxTotalAPagar;
        private System.Windows.Forms.Label labelNombreC;
        private System.Windows.Forms.TextBox textBoxNombreCliente;
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
        private System.Windows.Forms.Button buttonAtras;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}