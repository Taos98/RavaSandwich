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
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelBienvenido = new System.Windows.Forms.Label();
            this.btnGestionarTurno = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInventario
            // 
            this.btnInventario.BackColor = System.Drawing.Color.YellowGreen;
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInventario.ForeColor = System.Drawing.SystemColors.Window;
            this.btnInventario.Image = ((System.Drawing.Image)(resources.GetObject("btnInventario.Image")));
            this.btnInventario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventario.Location = new System.Drawing.Point(61, 133);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(171, 67);
            this.btnInventario.TabIndex = 0;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInventario.UseVisualStyleBackColor = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.BackColor = System.Drawing.Color.YellowGreen;
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnVentas.ForeColor = System.Drawing.SystemColors.Window;
            this.btnVentas.Image = ((System.Drawing.Image)(resources.GetObject("btnVentas.Image")));
            this.btnVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.Location = new System.Drawing.Point(253, 133);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(171, 67);
            this.btnVentas.TabIndex = 1;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVentas.UseVisualStyleBackColor = false;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnCaja
            // 
            this.btnCaja.BackColor = System.Drawing.Color.YellowGreen;
            this.btnCaja.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCaja.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCaja.Image = ((System.Drawing.Image)(resources.GetObject("btnCaja.Image")));
            this.btnCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaja.Location = new System.Drawing.Point(450, 133);
            this.btnCaja.Name = "btnCaja";
            this.btnCaja.Size = new System.Drawing.Size(171, 67);
            this.btnCaja.TabIndex = 2;
            this.btnCaja.Text = "Caja";
            this.btnCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCaja.UseVisualStyleBackColor = false;
            this.btnCaja.Click += new System.EventHandler(this.btnCaja_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Crimson;
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(369, 284);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(252, 75);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cerrar Sesión";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelNombre.ForeColor = System.Drawing.SystemColors.Info;
            this.labelNombre.Location = new System.Drawing.Point(132, 18);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(21, 30);
            this.labelNombre.TabIndex = 9;
            this.labelNombre.Text = "-";
            // 
            // labelBienvenido
            // 
            this.labelBienvenido.AutoSize = true;
            this.labelBienvenido.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelBienvenido.ForeColor = System.Drawing.SystemColors.Info;
            this.labelBienvenido.Location = new System.Drawing.Point(61, 18);
            this.labelBienvenido.Name = "labelBienvenido";
            this.labelBienvenido.Size = new System.Drawing.Size(65, 30);
            this.labelBienvenido.TabIndex = 8;
            this.labelBienvenido.Text = "Hola!";
            // 
            // btnGestionarTurno
            // 
            this.btnGestionarTurno.BackColor = System.Drawing.Color.Yellow;
            this.btnGestionarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGestionarTurno.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGestionarTurno.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnGestionarTurno.Image = ((System.Drawing.Image)(resources.GetObject("btnGestionarTurno.Image")));
            this.btnGestionarTurno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionarTurno.Location = new System.Drawing.Point(61, 284);
            this.btnGestionarTurno.Name = "btnGestionarTurno";
            this.btnGestionarTurno.Size = new System.Drawing.Size(250, 75);
            this.btnGestionarTurno.TabIndex = 10;
            this.btnGestionarTurno.Text = "Gestionar turno";
            this.btnGestionarTurno.UseVisualStyleBackColor = false;
            this.btnGestionarTurno.Click += new System.EventHandler(this.btnGestionarTurno_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(24, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 36);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // MenuUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumBlue;
            this.ClientSize = new System.Drawing.Size(691, 504);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnGestionarTurno);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.labelBienvenido);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCaja);
            this.Controls.Add(this.btnVentas);
            this.Controls.Add(this.btnInventario);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuUsuario";
            this.Text = "Menú del Usuari@";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnCaja;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelBienvenido;
        private System.Windows.Forms.Button btnGestionarTurno;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}