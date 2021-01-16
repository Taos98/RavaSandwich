
namespace RavaSandwich
{
    partial class CerrarTurno
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
            this.comboRut = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtPuesto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHoraS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimeFecha = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.ctnCerrarTurno = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboRut
            // 
            this.comboRut.FormattingEnabled = true;
            this.comboRut.Location = new System.Drawing.Point(201, 29);
            this.comboRut.Name = "comboRut";
            this.comboRut.Size = new System.Drawing.Size(176, 23);
            this.comboRut.TabIndex = 0;
            this.comboRut.SelectedIndexChanged += new System.EventHandler(this.comboRut_SelectedIndexChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(201, 72);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(176, 23);
            this.txtNombre.TabIndex = 1;
            // 
            // txtPuesto
            // 
            this.txtPuesto.Location = new System.Drawing.Point(201, 118);
            this.txtPuesto.Name = "txtPuesto";
            this.txtPuesto.ReadOnly = true;
            this.txtPuesto.Size = new System.Drawing.Size(176, 23);
            this.txtPuesto.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seleccione el RUT del personal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre del personal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Puesto actual";
            // 
            // txtHoraS
            // 
            this.txtHoraS.Location = new System.Drawing.Point(202, 166);
            this.txtHoraS.Name = "txtHoraS";
            this.txtHoraS.Size = new System.Drawing.Size(174, 23);
            this.txtHoraS.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ingrese la hora de salida";
            // 
            // dateTimeFecha
            // 
            this.dateTimeFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFecha.Location = new System.Drawing.Point(201, 218);
            this.dateTimeFecha.Name = "dateTimeFecha";
            this.dateTimeFecha.Size = new System.Drawing.Size(176, 23);
            this.dateTimeFecha.TabIndex = 8;
            this.dateTimeFecha.ValueChanged += new System.EventHandler(this.dateTimeFecha_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Seleccione fecha de cierre";
            // 
            // ctnCerrarTurno
            // 
            this.ctnCerrarTurno.BackColor = System.Drawing.Color.Crimson;
            this.ctnCerrarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ctnCerrarTurno.Location = new System.Drawing.Point(37, 377);
            this.ctnCerrarTurno.Name = "ctnCerrarTurno";
            this.ctnCerrarTurno.Size = new System.Drawing.Size(157, 45);
            this.ctnCerrarTurno.TabIndex = 10;
            this.ctnCerrarTurno.Text = "Cerrar Turno";
            this.ctnCerrarTurno.UseVisualStyleBackColor = false;
            this.ctnCerrarTurno.Click += new System.EventHandler(this.ctnCerrarTurno_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.Gold;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAtras.Location = new System.Drawing.Point(220, 377);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(157, 45);
            this.btnAtras.TabIndex = 11;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // CerrarTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Orange;
            this.ClientSize = new System.Drawing.Size(423, 460);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.ctnCerrarTurno);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimeFecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHoraS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPuesto);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.comboRut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CerrarTurno";
            this.Text = "CerrarTurno";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboRut;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtPuesto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHoraS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimeFecha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button ctnCerrarTurno;
        private System.Windows.Forms.Button btnAtras;
    }
}