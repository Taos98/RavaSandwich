
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gestionar_Turno));
            this.btnIniciarTurno = new System.Windows.Forms.Button();
            this.btnCerrarTurno = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelPuesto = new System.Windows.Forms.Label();
            this.labelCajero = new System.Windows.Forms.Label();
            this.labelPlanchero = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelNombreCajero = new System.Windows.Forms.Label();
            this.labelNombrePlanchero = new System.Windows.Forms.Label();
            this.labelHora = new System.Windows.Forms.Label();
            this.labelHoraCajero = new System.Windows.Forms.Label();
            this.labelHoraPlanchero = new System.Windows.Forms.Label();
            this.labelDisponible = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIniciarTurno
            // 
            this.btnIniciarTurno.BackColor = System.Drawing.Color.Lime;
            this.btnIniciarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIniciarTurno.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIniciarTurno.Image = ((System.Drawing.Image)(resources.GetObject("btnIniciarTurno.Image")));
            this.btnIniciarTurno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciarTurno.Location = new System.Drawing.Point(36, 365);
            this.btnIniciarTurno.Name = "btnIniciarTurno";
            this.btnIniciarTurno.Size = new System.Drawing.Size(155, 46);
            this.btnIniciarTurno.TabIndex = 0;
            this.btnIniciarTurno.Text = "Iniciar un Turno";
            this.btnIniciarTurno.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIniciarTurno.UseVisualStyleBackColor = false;
            this.btnIniciarTurno.Click += new System.EventHandler(this.btnIniciarTurno_Click);
            // 
            // btnCerrarTurno
            // 
            this.btnCerrarTurno.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnCerrarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrarTurno.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCerrarTurno.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCerrarTurno.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarTurno.Image")));
            this.btnCerrarTurno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarTurno.Location = new System.Drawing.Point(333, 365);
            this.btnCerrarTurno.Name = "btnCerrarTurno";
            this.btnCerrarTurno.Size = new System.Drawing.Size(164, 46);
            this.btnCerrarTurno.TabIndex = 1;
            this.btnCerrarTurno.Text = "Terminar un turno";
            this.btnCerrarTurno.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrarTurno.UseVisualStyleBackColor = false;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(194, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Turnos en curso:";
            // 
            // labelPuesto
            // 
            this.labelPuesto.AutoSize = true;
            this.labelPuesto.Location = new System.Drawing.Point(105, 125);
            this.labelPuesto.Name = "labelPuesto";
            this.labelPuesto.Size = new System.Drawing.Size(43, 15);
            this.labelPuesto.TabIndex = 5;
            this.labelPuesto.Text = "Puesto";
            // 
            // labelCajero
            // 
            this.labelCajero.AutoSize = true;
            this.labelCajero.Location = new System.Drawing.Point(105, 172);
            this.labelCajero.Name = "labelCajero";
            this.labelCajero.Size = new System.Drawing.Size(41, 15);
            this.labelCajero.TabIndex = 6;
            this.labelCajero.Text = "Cajero";
            // 
            // labelPlanchero
            // 
            this.labelPlanchero.AutoSize = true;
            this.labelPlanchero.Location = new System.Drawing.Point(105, 221);
            this.labelPlanchero.Name = "labelPlanchero";
            this.labelPlanchero.Size = new System.Drawing.Size(60, 15);
            this.labelPlanchero.TabIndex = 7;
            this.labelPlanchero.Text = "Planchero";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(194, 125);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(51, 15);
            this.labelNombre.TabIndex = 8;
            this.labelNombre.Text = "Nombre";
            // 
            // labelNombreCajero
            // 
            this.labelNombreCajero.AutoSize = true;
            this.labelNombreCajero.Location = new System.Drawing.Point(194, 172);
            this.labelNombreCajero.Name = "labelNombreCajero";
            this.labelNombreCajero.Size = new System.Drawing.Size(130, 15);
            this.labelNombreCajero.TabIndex = 9;
            this.labelNombreCajero.Text = "No hay Cajero en turno";
            // 
            // labelNombrePlanchero
            // 
            this.labelNombrePlanchero.AutoSize = true;
            this.labelNombrePlanchero.Location = new System.Drawing.Point(194, 221);
            this.labelNombrePlanchero.Name = "labelNombrePlanchero";
            this.labelNombrePlanchero.Size = new System.Drawing.Size(149, 15);
            this.labelNombrePlanchero.TabIndex = 10;
            this.labelNombrePlanchero.Text = "No hay Planchero en turno";
            // 
            // labelHora
            // 
            this.labelHora.AutoSize = true;
            this.labelHora.Location = new System.Drawing.Point(365, 125);
            this.labelHora.Name = "labelHora";
            this.labelHora.Size = new System.Drawing.Size(65, 15);
            this.labelHora.TabIndex = 11;
            this.labelHora.Text = "Hora inicio";
            // 
            // labelHoraCajero
            // 
            this.labelHoraCajero.AutoSize = true;
            this.labelHoraCajero.Location = new System.Drawing.Point(365, 172);
            this.labelHoraCajero.Name = "labelHoraCajero";
            this.labelHoraCajero.Size = new System.Drawing.Size(105, 15);
            this.labelHoraCajero.TabIndex = 12;
            this.labelHoraCajero.Text = "Hora no registrada";
            // 
            // labelHoraPlanchero
            // 
            this.labelHoraPlanchero.AutoSize = true;
            this.labelHoraPlanchero.Location = new System.Drawing.Point(365, 221);
            this.labelHoraPlanchero.Name = "labelHoraPlanchero";
            this.labelHoraPlanchero.Size = new System.Drawing.Size(105, 15);
            this.labelHoraPlanchero.TabIndex = 13;
            this.labelHoraPlanchero.Text = "Hora no registrada";
            // 
            // labelDisponible
            // 
            this.labelDisponible.AutoSize = true;
            this.labelDisponible.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDisponible.Location = new System.Drawing.Point(34, 187);
            this.labelDisponible.Name = "labelDisponible";
            this.labelDisponible.Size = new System.Drawing.Size(494, 25);
            this.labelDisponible.TabIndex = 14;
            this.labelDisponible.Text = "No hay personas en turno, por favor, registre su turno";
            // 
            // Gestionar_Turno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(551, 458);
            this.Controls.Add(this.labelDisponible);
            this.Controls.Add(this.labelHoraPlanchero);
            this.Controls.Add(this.labelHoraCajero);
            this.Controls.Add(this.labelHora);
            this.Controls.Add(this.labelNombrePlanchero);
            this.Controls.Add(this.labelNombreCajero);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.labelPlanchero);
            this.Controls.Add(this.labelCajero);
            this.Controls.Add(this.labelPuesto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCerrarTurno);
            this.Controls.Add(this.btnIniciarTurno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelPuesto;
        private System.Windows.Forms.Label labelCajero;
        private System.Windows.Forms.Label labelPlanchero;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelNombreCajero;
        private System.Windows.Forms.Label labelNombrePlanchero;
        private System.Windows.Forms.Label labelHora;
        private System.Windows.Forms.Label labelHoraCajero;
        private System.Windows.Forms.Label labelHoraPlanchero;
        private System.Windows.Forms.Label labelDisponible;
    }
}