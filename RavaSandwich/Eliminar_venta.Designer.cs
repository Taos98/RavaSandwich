
namespace RavaSandwich
{
    partial class Eliminar_venta
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
            this.labelSeleccioneC = new System.Windows.Forms.Label();
            this.cbNombreCliente = new System.Windows.Forms.ComboBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.listBoxPedido = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSeleccioneC
            // 
            this.labelSeleccioneC.AutoSize = true;
            this.labelSeleccioneC.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSeleccioneC.Location = new System.Drawing.Point(80, 34);
            this.labelSeleccioneC.Name = "labelSeleccioneC";
            this.labelSeleccioneC.Size = new System.Drawing.Size(230, 20);
            this.labelSeleccioneC.TabIndex = 0;
            this.labelSeleccioneC.Text = "Seleccione el Nombre del Cliente";
            // 
            // cbNombreCliente
            // 
            this.cbNombreCliente.FormattingEnabled = true;
            this.cbNombreCliente.Location = new System.Drawing.Point(80, 74);
            this.cbNombreCliente.Name = "cbNombreCliente";
            this.cbNombreCliente.Size = new System.Drawing.Size(230, 23);
            this.cbNombreCliente.TabIndex = 1;
            this.cbNombreCliente.SelectedIndexChanged += new System.EventHandler(this.cbNombreCliente_SelectedIndexChanged);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Crimson;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEliminar.Location = new System.Drawing.Point(133, 374);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(125, 31);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar Venta";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // listBoxPedido
            // 
            this.listBoxPedido.FormattingEnabled = true;
            this.listBoxPedido.ItemHeight = 15;
            this.listBoxPedido.Location = new System.Drawing.Point(26, 163);
            this.listBoxPedido.Name = "listBoxPedido";
            this.listBoxPedido.Size = new System.Drawing.Size(347, 139);
            this.listBoxPedido.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(70, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccione una venta para eliminar";
            // 
            // Eliminar_venta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(395, 525);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxPedido);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.cbNombreCliente);
            this.Controls.Add(this.labelSeleccioneC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Eliminar_venta";
            this.Text = "Eliminar venta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSeleccioneC;
        private System.Windows.Forms.ComboBox cbNombreCliente;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.ListBox listBoxPedido;
        private System.Windows.Forms.Label label1;
    }
}