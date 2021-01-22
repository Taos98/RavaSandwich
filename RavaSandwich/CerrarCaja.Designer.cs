
namespace RavaSandwich
{
    partial class CerrarCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CerrarCaja));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDineroFisico = new System.Windows.Forms.TextBox();
            this.txtDineroCaja = new System.Windows.Forms.TextBox();
            this.txtCuadre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(125, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cuadre de caja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total dinero físico";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Total dinero en caja";
            // 
            // txtDineroFisico
            // 
            this.txtDineroFisico.Location = new System.Drawing.Point(32, 132);
            this.txtDineroFisico.Name = "txtDineroFisico";
            this.txtDineroFisico.ReadOnly = true;
            this.txtDineroFisico.Size = new System.Drawing.Size(113, 23);
            this.txtDineroFisico.TabIndex = 3;
            // 
            // txtDineroCaja
            // 
            this.txtDineroCaja.Location = new System.Drawing.Point(264, 132);
            this.txtDineroCaja.Name = "txtDineroCaja";
            this.txtDineroCaja.ReadOnly = true;
            this.txtDineroCaja.Size = new System.Drawing.Size(110, 23);
            this.txtDineroCaja.TabIndex = 4;
            // 
            // txtCuadre
            // 
            this.txtCuadre.Location = new System.Drawing.Point(175, 235);
            this.txtCuadre.Name = "txtCuadre";
            this.txtCuadre.ReadOnly = true;
            this.txtCuadre.Size = new System.Drawing.Size(101, 23);
            this.txtCuadre.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cuadre =";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.Info;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(93, 304);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(231, 55);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.Yellow;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnVolver.Image")));
            this.btnVolver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVolver.Location = new System.Drawing.Point(134, 376);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(142, 45);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Volver a Caja";
            this.btnVolver.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // CerrarCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(430, 463);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCuadre);
            this.Controls.Add(this.txtDineroCaja);
            this.Controls.Add(this.txtDineroFisico);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CerrarCaja";
            this.Text = "CerrarTurno";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDineroFisico;
        private System.Windows.Forms.TextBox txtDineroCaja;
        private System.Windows.Forms.TextBox txtCuadre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnVolver;
    }
}