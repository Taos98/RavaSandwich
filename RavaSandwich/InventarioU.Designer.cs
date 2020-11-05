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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.tablaInventario = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tablaInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMenu
            // 
            this.btnMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMenu.BackColor = System.Drawing.Color.YellowGreen;
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMenu.ForeColor = System.Drawing.SystemColors.Window;
            this.btnMenu.Location = new System.Drawing.Point(612, 24);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(249, 48);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Text = "Volver a menú principal";
            this.btnMenu.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.YellowGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(747, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 50);
            this.button1.TabIndex = 3;
            this.button1.Text = "Ingreso de Producto";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.YellowGreen;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.SystemColors.Window;
            this.button2.Location = new System.Drawing.Point(747, 333);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 54);
            this.button2.TabIndex = 4;
            this.button2.Text = "Consumo de producto";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.YellowGreen;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCerrarSesion.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCerrarSesion.Location = new System.Drawing.Point(726, 477);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(145, 43);
            this.btnCerrarSesion.TabIndex = 5;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // tablaInventario
            // 
            this.tablaInventario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tablaInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaInventario.Location = new System.Drawing.Point(12, 93);
            this.tablaInventario.Name = "tablaInventario";
            this.tablaInventario.Size = new System.Drawing.Size(660, 349);
            this.tablaInventario.TabIndex = 0;
            this.tablaInventario.Text = "dataGridView1";
            this.tablaInventario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // InventarioU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.ClientSize = new System.Drawing.Size(883, 541);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}