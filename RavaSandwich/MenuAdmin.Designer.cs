namespace RavaSandwich
{
    partial class MenuAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuAdmin));
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnCaja = new System.Windows.Forms.Button();
            this.btnAgregarPersonal = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.labelBienvenido = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnInventario
            // 
            this.btnInventario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnInventario.AutoSize = true;
            this.btnInventario.BackColor = System.Drawing.Color.YellowGreen;
            this.btnInventario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInventario.ForeColor = System.Drawing.SystemColors.Window;
            this.btnInventario.Location = new System.Drawing.Point(65, 67);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Size = new System.Drawing.Size(177, 86);
            this.btnInventario.TabIndex = 0;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.UseVisualStyleBackColor = false;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVentas.AutoSize = true;
            this.btnVentas.BackColor = System.Drawing.Color.YellowGreen;
            this.btnVentas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnVentas.ForeColor = System.Drawing.SystemColors.Window;
            this.btnVentas.Location = new System.Drawing.Point(314, 67);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(177, 86);
            this.btnVentas.TabIndex = 1;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.UseVisualStyleBackColor = false;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnCaja
            // 
            this.btnCaja.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCaja.AutoSize = true;
            this.btnCaja.BackColor = System.Drawing.Color.YellowGreen;
            this.btnCaja.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCaja.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCaja.Location = new System.Drawing.Point(560, 68);
            this.btnCaja.Name = "btnCaja";
            this.btnCaja.Size = new System.Drawing.Size(177, 85);
            this.btnCaja.TabIndex = 2;
            this.btnCaja.Text = "Caja";
            this.btnCaja.UseVisualStyleBackColor = false;
            // 
            // btnAgregarPersonal
            // 
            this.btnAgregarPersonal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregarPersonal.AutoSize = true;
            this.btnAgregarPersonal.BackColor = System.Drawing.Color.YellowGreen;
            this.btnAgregarPersonal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAgregarPersonal.ForeColor = System.Drawing.SystemColors.Window;
            this.btnAgregarPersonal.Location = new System.Drawing.Point(65, 233);
            this.btnAgregarPersonal.Name = "btnAgregarPersonal";
            this.btnAgregarPersonal.Size = new System.Drawing.Size(177, 86);
            this.btnAgregarPersonal.TabIndex = 3;
            this.btnAgregarPersonal.Text = "Gestionar Personal";
            this.btnAgregarPersonal.UseVisualStyleBackColor = false;
            this.btnAgregarPersonal.Click += new System.EventHandler(this.btnAgregarPersonal_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCerrarSesion.AutoSize = true;
            this.btnCerrarSesion.BackColor = System.Drawing.Color.YellowGreen;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCerrarSesion.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCerrarSesion.Location = new System.Drawing.Point(560, 233);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(176, 85);
            this.btnCerrarSesion.TabIndex = 5;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // labelBienvenido
            // 
            this.labelBienvenido.AutoSize = true;
            this.labelBienvenido.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelBienvenido.ForeColor = System.Drawing.SystemColors.Info;
            this.labelBienvenido.Location = new System.Drawing.Point(21, 25);
            this.labelBienvenido.Name = "labelBienvenido";
            this.labelBienvenido.Size = new System.Drawing.Size(127, 30);
            this.labelBienvenido.TabIndex = 6;
            this.labelBienvenido.Text = "Bienvenid@";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.labelNombre.ForeColor = System.Drawing.SystemColors.Info;
            this.labelNombre.Location = new System.Drawing.Point(180, 25);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(21, 30);
            this.labelNombre.TabIndex = 7;
            this.labelNombre.Text = "-";
            // 
            // MenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.ClientSize = new System.Drawing.Size(811, 473);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.labelBienvenido);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnAgregarPersonal);
            this.Controls.Add(this.btnCaja);
            this.Controls.Add(this.btnVentas);
            this.Controls.Add(this.btnInventario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuAdmin";
            this.Text = "Menú del Administrador";
            this.Load += new System.EventHandler(this.MenuAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnCaja;
        private System.Windows.Forms.Button btnAgregarPersonal;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Label labelBienvenido;
        private System.Windows.Forms.Label labelNombre;
    }
}