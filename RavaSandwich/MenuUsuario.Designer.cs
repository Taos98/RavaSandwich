namespace RavaSandwich
{
    partial class MenuUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuUsuario));
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnCaja = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInventario
            // 
            this.btnInventario.BackColor = System.Drawing.Color.YellowGreen;
            this.btnInventario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInventario.ForeColor = System.Drawing.SystemColors.Window;
            this.btnInventario.Location = new System.Drawing.Point(21, 124);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(225, 109);
            this.btnInventario.TabIndex = 0;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.UseVisualStyleBackColor = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.BackColor = System.Drawing.Color.YellowGreen;
            this.btnVentas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnVentas.ForeColor = System.Drawing.SystemColors.Window;
            this.btnVentas.Location = new System.Drawing.Point(283, 124);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(225, 109);
            this.btnVentas.TabIndex = 1;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.UseVisualStyleBackColor = false;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnCaja
            // 
            this.btnCaja.BackColor = System.Drawing.Color.YellowGreen;
            this.btnCaja.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCaja.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCaja.Location = new System.Drawing.Point(549, 124);
            this.btnCaja.Name = "btnCaja";
            this.btnCaja.Size = new System.Drawing.Size(225, 108);
            this.btnCaja.TabIndex = 2;
            this.btnCaja.Text = "Caja";
            this.btnCaja.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.YellowGreen;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(606, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 37);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cerrar Sesión";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MenuUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCaja);
            this.Controls.Add(this.btnVentas);
            this.Controls.Add(this.btnInventario);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuUsuario";
            this.Text = "Menú del Usuari@";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnCaja;
        private System.Windows.Forms.Button button1;
    }
}