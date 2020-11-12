namespace RavaSandwich
{
    partial class ConsumirProd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsumirProd));
            this.comboProductos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnConsumir = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // comboProductos
            // 
            this.comboProductos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboProductos.FormattingEnabled = true;
            this.comboProductos.Location = new System.Drawing.Point(47, 91);
            this.comboProductos.Name = "comboProductos";
            this.comboProductos.Size = new System.Drawing.Size(213, 23);
            this.comboProductos.TabIndex = 0;
            this.comboProductos.SelectedIndexChanged += new System.EventHandler(this.comboProductos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Qué producto desea consumir?";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Que cantidad desea consumir?";
            // 
            // numericCantidad
            // 
            this.numericCantidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericCantidad.Location = new System.Drawing.Point(187, 196);
            this.numericCantidad.Name = "numericCantidad";
            this.numericCantidad.Size = new System.Drawing.Size(73, 23);
            this.numericCantidad.TabIndex = 3;
            // 
            // btnConsumir
            // 
            this.btnConsumir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConsumir.BackColor = System.Drawing.Color.Green;
            this.btnConsumir.ForeColor = System.Drawing.SystemColors.Window;
            this.btnConsumir.Location = new System.Drawing.Point(29, 377);
            this.btnConsumir.Name = "btnConsumir";
            this.btnConsumir.Size = new System.Drawing.Size(109, 36);
            this.btnConsumir.TabIndex = 4;
            this.btnConsumir.Text = "Consumir";
            this.btnConsumir.UseVisualStyleBackColor = false;
            this.btnConsumir.Click += new System.EventHandler(this.btnConsumir_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCerrar.BackColor = System.Drawing.Color.Red;
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCerrar.Location = new System.Drawing.Point(172, 377);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(109, 35);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // ConsumirProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(312, 477);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnConsumir);
            this.Controls.Add(this.numericCantidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConsumirProd";
            this.Text = "Consumir Producto";
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboProductos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericCantidad;
        private System.Windows.Forms.Button btnConsumir;
        private System.Windows.Forms.Button btnCerrar;
    }
}