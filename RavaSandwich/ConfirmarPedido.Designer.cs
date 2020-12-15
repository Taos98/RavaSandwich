
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
            this.SuspendLayout();
            // 
            // labelTotalAPAgar
            // 
            this.labelTotalAPAgar.AutoSize = true;
            this.labelTotalAPAgar.Location = new System.Drawing.Point(12, 38);
            this.labelTotalAPAgar.Name = "labelTotalAPAgar";
            this.labelTotalAPAgar.Size = new System.Drawing.Size(74, 15);
            this.labelTotalAPAgar.TabIndex = 0;
            this.labelTotalAPAgar.Text = "Total a Pagar";
            // 
            // textBoxTotalAPagar
            // 
            this.textBoxTotalAPagar.Location = new System.Drawing.Point(92, 24);
            this.textBoxTotalAPagar.Multiline = true;
            this.textBoxTotalAPagar.Name = "textBoxTotalAPagar";
            this.textBoxTotalAPagar.Size = new System.Drawing.Size(143, 51);
            this.textBoxTotalAPagar.TabIndex = 1;
            // 
            // labelNombreC
            // 
            this.labelNombreC.AutoSize = true;
            this.labelNombreC.Location = new System.Drawing.Point(260, 38);
            this.labelNombreC.Name = "labelNombreC";
            this.labelNombreC.Size = new System.Drawing.Size(94, 15);
            this.labelNombreC.TabIndex = 2;
            this.labelNombreC.Text = "Nombre Cliente:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(377, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(239, 23);
            this.textBox1.TabIndex = 3;
            // 
            // ConfirmarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 498);
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
    }
}