namespace RavaSandwich
{
    partial class InventarioU
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventarioU));
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnIngreso = new System.Windows.Forms.Button();
            this.btnConsumo = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.tablaInventario = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMenu
            // 
            this.btnMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMenu.BackColor = System.Drawing.Color.YellowGreen;
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMenu.ForeColor = System.Drawing.SystemColors.Window;
            this.btnMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnMenu.Image")));
            this.btnMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu.Location = new System.Drawing.Point(647, 12);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(211, 62);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Text = "Volver a menú principal";
            this.btnMenu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnIngreso
            // 
            this.btnIngreso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIngreso.BackColor = System.Drawing.Color.YellowGreen;
            this.btnIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIngreso.ForeColor = System.Drawing.SystemColors.Window;
            this.btnIngreso.Image = ((System.Drawing.Image)(resources.GetObject("btnIngreso.Image")));
            this.btnIngreso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngreso.Location = new System.Drawing.Point(701, 120);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Size = new System.Drawing.Size(157, 66);
            this.btnIngreso.TabIndex = 3;
            this.btnIngreso.Text = "Ingreso";
            this.btnIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIngreso.UseVisualStyleBackColor = false;
            this.btnIngreso.Click += new System.EventHandler(this.btnIngreso_Click);
            // 
            // btnConsumo
            // 
            this.btnConsumo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConsumo.BackColor = System.Drawing.Color.YellowGreen;
            this.btnConsumo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConsumo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConsumo.ForeColor = System.Drawing.SystemColors.Window;
            this.btnConsumo.Image = ((System.Drawing.Image)(resources.GetObject("btnConsumo.Image")));
            this.btnConsumo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsumo.Location = new System.Drawing.Point(701, 244);
            this.btnConsumo.Name = "btnConsumo";
            this.btnConsumo.Size = new System.Drawing.Size(157, 71);
            this.btnConsumo.TabIndex = 4;
            this.btnConsumo.Text = "Consumo";
            this.btnConsumo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsumo.UseVisualStyleBackColor = false;
            this.btnConsumo.Click += new System.EventHandler(this.btnConsumo_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.Crimson;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCerrarSesion.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCerrarSesion.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarSesion.Image")));
            this.btnCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.Location = new System.Drawing.Point(701, 377);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(157, 67);
            this.btnCerrarSesion.TabIndex = 5;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // tablaInventario
            // 
            this.tablaInventario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tablaInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaInventario.Location = new System.Drawing.Point(9, 95);
            this.tablaInventario.Name = "tablaInventario";
            this.tablaInventario.Size = new System.Drawing.Size(660, 349);
            this.tablaInventario.TabIndex = 0;
            this.tablaInventario.Text = "dataGridView1";
            this.tablaInventario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.Green;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnActualizar.ForeColor = System.Drawing.SystemColors.Window;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.Location = new System.Drawing.Point(448, 12);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(175, 61);
            this.btnActualizar.TabIndex = 6;
            this.btnActualizar.Text = "Actualizar Tabla";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // InventarioU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.ClientSize = new System.Drawing.Size(877, 544);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnConsumo);
            this.Controls.Add(this.btnIngreso);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.tablaInventario);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InventarioU";
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.Inventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaInventario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaInventario;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnIngreso;
        private System.Windows.Forms.Button btnConsumo;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnActualizar;
    }
}