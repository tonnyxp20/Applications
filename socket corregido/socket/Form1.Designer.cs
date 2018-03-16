namespace socket
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtus = new System.Windows.Forms.TextBox();
            this.btncon = new System.Windows.Forms.Button();
            this.txtchat = new System.Windows.Forms.TextBox();
            this.txttexto = new System.Windows.Forms.TextBox();
            this.btnenviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtus
            // 
            this.txtus.Location = new System.Drawing.Point(32, 24);
            this.txtus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtus.Name = "txtus";
            this.txtus.Size = new System.Drawing.Size(254, 20);
            this.txtus.TabIndex = 0;
            // 
            // btncon
            // 
            this.btncon.Location = new System.Drawing.Point(32, 67);
            this.btncon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btncon.Name = "btncon";
            this.btncon.Size = new System.Drawing.Size(112, 38);
            this.btncon.TabIndex = 1;
            this.btncon.Text = "Conectar";
            this.btncon.UseVisualStyleBackColor = true;
            this.btncon.Click += new System.EventHandler(this.btncon_Click);
            // 
            // txtchat
            // 
            this.txtchat.Location = new System.Drawing.Point(30, 141);
            this.txtchat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtchat.Multiline = true;
            this.txtchat.Name = "txtchat";
            this.txtchat.Size = new System.Drawing.Size(308, 183);
            this.txtchat.TabIndex = 2;
            // 
            // txttexto
            // 
            this.txttexto.Location = new System.Drawing.Point(35, 343);
            this.txttexto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txttexto.Name = "txttexto";
            this.txttexto.Size = new System.Drawing.Size(302, 20);
            this.txttexto.TabIndex = 3;
            // 
            // btnenviar
            // 
            this.btnenviar.Location = new System.Drawing.Point(229, 405);
            this.btnenviar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnenviar.Name = "btnenviar";
            this.btnenviar.Size = new System.Drawing.Size(119, 19);
            this.btnenviar.TabIndex = 4;
            this.btnenviar.Text = "Enviar";
            this.btnenviar.UseVisualStyleBackColor = true;
            this.btnenviar.Click += new System.EventHandler(this.btnenviar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 457);
            this.Controls.Add(this.btnenviar);
            this.Controls.Add(this.txttexto);
            this.Controls.Add(this.txtchat);
            this.Controls.Add(this.btncon);
            this.Controls.Add(this.txtus);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtus;
        private System.Windows.Forms.Button btncon;
        private System.Windows.Forms.TextBox txtchat;
        private System.Windows.Forms.TextBox txttexto;
        private System.Windows.Forms.Button btnenviar;
    }
}

