namespace login
{
    partial class Usuarios
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
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.ListaDeUsuarios = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RegistarUsuario = new System.Windows.Forms.PictureBox();
            this.pnlContenido.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListaDeUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegistarUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.Color.White;
            this.pnlContenido.Controls.Add(this.pictureBox3);
            this.pnlContenido.Controls.Add(this.label4);
            this.pnlContenido.Controls.Add(this.ListaDeUsuarios);
            this.pnlContenido.Controls.Add(this.pictureBox1);
            this.pnlContenido.Controls.Add(this.RegistarUsuario);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlContenido.Location = new System.Drawing.Point(520, 0);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(554, 794);
            this.pnlContenido.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(135, 136);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(297, 41);
            this.label4.TabIndex = 24;
            this.label4.Text = "Gestión de Usuarios";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(520, 794);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::login.Properties.Resources.fondo;
            this.pictureBox2.Location = new System.Drawing.Point(12, -2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(594, 793);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = global::login.Properties.Resources.HistorialDeReservas;
            this.pictureBox3.Location = new System.Drawing.Point(297, 411);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(232, 180);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 25;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // ListaDeUsuarios
            // 
            this.ListaDeUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ListaDeUsuarios.Image = global::login.Properties.Resources.ListaDeUsuarios;
            this.ListaDeUsuarios.Location = new System.Drawing.Point(39, 411);
            this.ListaDeUsuarios.Name = "ListaDeUsuarios";
            this.ListaDeUsuarios.Size = new System.Drawing.Size(232, 180);
            this.ListaDeUsuarios.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ListaDeUsuarios.TabIndex = 2;
            this.ListaDeUsuarios.TabStop = false;
            this.ListaDeUsuarios.Click += new System.EventHandler(this.ListaDeUsuarios_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::login.Properties.Resources.EditarInformacion;
            this.pictureBox1.Location = new System.Drawing.Point(286, 216);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(243, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // RegistarUsuario
            // 
            this.RegistarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegistarUsuario.Image = global::login.Properties.Resources.RegistarUsuario;
            this.RegistarUsuario.Location = new System.Drawing.Point(39, 216);
            this.RegistarUsuario.Name = "RegistarUsuario";
            this.RegistarUsuario.Size = new System.Drawing.Size(232, 180);
            this.RegistarUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.RegistarUsuario.TabIndex = 0;
            this.RegistarUsuario.TabStop = false;
            this.RegistarUsuario.Click += new System.EventHandler(this.RegistarUsuario_Click);
            // 
            // Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 794);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlContenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Usuarios";
            this.Text = "Usuarios";
            this.pnlContenido.ResumeLayout(false);
            this.pnlContenido.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListaDeUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegistarUsuario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.PictureBox RegistarUsuario;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox ListaDeUsuarios;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}