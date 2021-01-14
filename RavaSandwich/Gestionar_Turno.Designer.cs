
namespace RavaSandwich
{
    partial class Gestionar_Turno
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
            this.btnIniciarTurno = new System.Windows.Forms.Button();
            this.btnCerrarTurno = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIniciarTurno
            // 
            this.btnIniciarTurno.Location = new System.Drawing.Point(36, 344);
            this.btnIniciarTurno.Name = "btnIniciarTurno";
            this.btnIniciarTurno.Size = new System.Drawing.Size(155, 46);
            this.btnIniciarTurno.TabIndex = 0;
            this.btnIniciarTurno.Text = "Iniciar un Turno";
            this.btnIniciarTurno.UseVisualStyleBackColor = true;
            this.btnIniciarTurno.Click += new System.EventHandler(this.btnIniciarTurno_Click);
            // 
            // btnCerrarTurno
            // 
            this.btnCerrarTurno.Location = new System.Drawing.Point(343, 344);
            this.btnCerrarTurno.Name = "btnCerrarTurno";
            this.btnCerrarTurno.Size = new System.Drawing.Size(154, 46);
            this.btnCerrarTurno.TabIndex = 1;
            this.btnCerrarTurno.Text = "Terminar un turno";
            this.btnCerrarTurno.UseVisualStyleBackColor = true;
            this.btnCerrarTurno.Click += new System.EventHandler(this.btnCerrarTurno_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(172, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gestión de turno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(351, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Por favor, gestione su turno como cajero y el de su planchero acá";
            // 
            // Gestionar_Turno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(548, 452);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCerrarTurno);
            this.Controls.Add(this.btnIniciarTurno);
            this.Name = "Gestionar_Turno";
            this.Text = "Gestionar_Turno";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIniciarTurno;
        private System.Windows.Forms.Button btnCerrarTurno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}