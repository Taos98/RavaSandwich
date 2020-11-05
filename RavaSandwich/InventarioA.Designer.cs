namespace RavaSandwich
{
    partial class InventarioA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventarioA));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnConsumo = new System.Windows.Forms.Button();
            this.btnIngreso = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnAgregarIngrediente = new System.Windows.Forms.Button();
            this.btnEliminarIngrediente = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(764, 400);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Text = "dataGridView1";
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnConsumo
            // 
            this.btnConsumo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConsumo.BackColor = System.Drawing.Color.YellowGreen;
            this.btnConsumo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsumo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConsumo.ForeColor = System.Drawing.SystemColors.Window;
            this.btnConsumo.Location = new System.Drawing.Point(814, 199);
            this.btnConsumo.Name = "btnConsumo";
            this.btnConsumo.Size = new System.Drawing.Size(113, 54);
            this.btnConsumo.TabIndex = 4;
            this.btnConsumo.Text = "Consumo";
            this.btnConsumo.UseVisualStyleBackColor = false;
            // 
            // btnIngreso
            // 
            this.btnIngreso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIngreso.BackColor = System.Drawing.Color.YellowGreen;
            this.btnIngreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngreso.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIngreso.ForeColor = System.Drawing.SystemColors.Window;
            this.btnIngreso.Location = new System.Drawing.Point(814, 123);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Size = new System.Drawing.Size(114, 50);
            this.btnIngreso.TabIndex = 3;
            this.btnIngreso.Text = "Ingreso";
            this.btnIngreso.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.BackColor = System.Drawing.Color.YellowGreen;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button5.ForeColor = System.Drawing.SystemColors.Window;
            this.button5.Location = new System.Drawing.Point(813, 467);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(114, 43);
            this.button5.TabIndex = 5;
            this.button5.Text = "Cerrar Sesión";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnAgregarIngrediente
            // 
            this.btnAgregarIngrediente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregarIngrediente.BackColor = System.Drawing.Color.YellowGreen;
            this.btnAgregarIngrediente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarIngrediente.ForeColor = System.Drawing.SystemColors.Window;
            this.btnAgregarIngrediente.Location = new System.Drawing.Point(814, 272);
            this.btnAgregarIngrediente.Name = "btnAgregarIngrediente";
            this.btnAgregarIngrediente.Size = new System.Drawing.Size(113, 49);
            this.btnAgregarIngrediente.TabIndex = 6;
            this.btnAgregarIngrediente.Text = "Agregar Ingrediente";
            this.btnAgregarIngrediente.UseVisualStyleBackColor = false;
            // 
            // btnEliminarIngrediente
            // 
            this.btnEliminarIngrediente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEliminarIngrediente.BackColor = System.Drawing.Color.YellowGreen;
            this.btnEliminarIngrediente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarIngrediente.ForeColor = System.Drawing.SystemColors.Window;
            this.btnEliminarIngrediente.Location = new System.Drawing.Point(814, 340);
            this.btnEliminarIngrediente.Name = "btnEliminarIngrediente";
            this.btnEliminarIngrediente.Size = new System.Drawing.Size(112, 48);
            this.btnEliminarIngrediente.TabIndex = 7;
            this.btnEliminarIngrediente.Text = "Eliminar ingrediente";
            this.btnEliminarIngrediente.UseVisualStyleBackColor = false;
            // 
            // btnMenu
            // 
            this.btnMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMenu.BackColor = System.Drawing.Color.YellowGreen;
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMenu.ForeColor = System.Drawing.SystemColors.Window;
            this.btnMenu.Location = new System.Drawing.Point(679, 44);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(247, 48);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Text = "Volver al menú principal";
            this.btnMenu.UseVisualStyleBackColor = false;
            // 
            // InventarioA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.ClientSize = new System.Drawing.Size(943, 522);
            this.Controls.Add(this.btnEliminarIngrediente);
            this.Controls.Add(this.btnAgregarIngrediente);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnIngreso);
            this.Controls.Add(this.btnConsumo);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InventarioA";
            this.Text = "Inventario";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnConsumo;
        private System.Windows.Forms.Button btnIngreso;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnAgregarIngrediente;
        private System.Windows.Forms.Button btnEliminarIngrediente;
        private System.Windows.Forms.Button btnMenu;
    }
}