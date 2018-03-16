namespace JuegoCarreras
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gbChat = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.lbltiempo = new System.Windows.Forms.Label();
            this.btnComenzar = new System.Windows.Forms.Button();
            this.btnDetener = new System.Windows.Forms.Button();
            this.imgListBw = new System.Windows.Forms.ImageList(this.components);
            this.pbFondo = new System.Windows.Forms.PictureBox();
            this.mario = new System.Windows.Forms.PictureBox();
            this.imgListMb = new System.Windows.Forms.ImageList(this.components);
            this.bowser = new System.Windows.Forms.PictureBox();
            this.tunel = new System.Windows.Forms.PictureBox();
            this.imgListTunel = new System.Windows.Forms.ImageList(this.components);
            this.vida1 = new System.Windows.Forms.PictureBox();
            this.vida2 = new System.Windows.Forms.PictureBox();
            this.vida3 = new System.Windows.Forms.PictureBox();
            this.imgListHeart = new System.Windows.Forms.ImageList(this.components);
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.txtCoordenadas = new System.Windows.Forms.TextBox();
            this.gbChat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFondo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bowser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tunel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vida1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vida2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vida3)).BeginInit();
            this.SuspendLayout();
            // 
            // gbChat
            // 
            this.gbChat.Controls.Add(this.label2);
            this.gbChat.Controls.Add(this.label1);
            this.gbChat.Controls.Add(this.txtTexto);
            this.gbChat.Controls.Add(this.txtChat);
            this.gbChat.Controls.Add(this.lblPlayer);
            this.gbChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbChat.Location = new System.Drawing.Point(872, 12);
            this.gbChat.Name = "gbChat";
            this.gbChat.Size = new System.Drawing.Size(300, 637);
            this.gbChat.TabIndex = 0;
            this.gbChat.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 519);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 100);
            this.label2.TabIndex = 0;
            this.label2.Text = "El juego se basa en que Mario encuentre\r\nla salida y logre escapar del malvado\r\nB" +
    "owser que trata de atraparlo. El tunel \r\naparecera en diferentes caminos, \r\ntrat" +
    "a de llegar antes de te atrapen!\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 499);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "INSTRUCCIONES:";
            // 
            // txtTexto
            // 
            this.txtTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTexto.Location = new System.Drawing.Point(6, 460);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(288, 24);
            this.txtTexto.TabIndex = 3;
            this.txtTexto.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            this.txtTexto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTexto_KeyPress);
            // 
            // txtChat
            // 
            this.txtChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChat.Location = new System.Drawing.Point(6, 43);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChat.Size = new System.Drawing.Size(288, 400);
            this.txtChat.TabIndex = 2;
            this.txtChat.TextChanged += new System.EventHandler(this.txtChat_TextChanged);
            this.txtChat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChat_KeyPress);
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Location = new System.Drawing.Point(112, 20);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(80, 20);
            this.lblPlayer.TabIndex = 0;
            this.lblPlayer.Text = "Jugador 2";
            // 
            // lbltiempo
            // 
            this.lbltiempo.AutoSize = true;
            this.lbltiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltiempo.Location = new System.Drawing.Point(36, 13);
            this.lbltiempo.Name = "lbltiempo";
            this.lbltiempo.Size = new System.Drawing.Size(46, 18);
            this.lbltiempo.TabIndex = 15;
            this.lbltiempo.Text = "label3";
            // 
            // btnComenzar
            // 
            this.btnComenzar.Location = new System.Drawing.Point(657, 12);
            this.btnComenzar.Name = "btnComenzar";
            this.btnComenzar.Size = new System.Drawing.Size(75, 23);
            this.btnComenzar.TabIndex = 16;
            this.btnComenzar.Text = "Comenzar";
            this.btnComenzar.UseVisualStyleBackColor = true;
            this.btnComenzar.Visible = false;
            this.btnComenzar.Click += new System.EventHandler(this.btnComenzar_Click);
            // 
            // btnDetener
            // 
            this.btnDetener.Location = new System.Drawing.Point(755, 12);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(75, 23);
            this.btnDetener.TabIndex = 17;
            this.btnDetener.Text = "Detener";
            this.btnDetener.UseVisualStyleBackColor = true;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // imgListBw
            // 
            this.imgListBw.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListBw.ImageStream")));
            this.imgListBw.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListBw.Images.SetKeyName(0, "bw1.png");
            this.imgListBw.Images.SetKeyName(1, "bw2.png");
            // 
            // pbFondo
            // 
            this.pbFondo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbFondo.Image = ((System.Drawing.Image)(resources.GetObject("pbFondo.Image")));
            this.pbFondo.Location = new System.Drawing.Point(15, 41);
            this.pbFondo.Name = "pbFondo";
            this.pbFondo.Size = new System.Drawing.Size(815, 600);
            this.pbFondo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFondo.TabIndex = 18;
            this.pbFondo.TabStop = false;
            // 
            // mario
            // 
            this.mario.BackColor = System.Drawing.Color.Transparent;
            this.mario.Location = new System.Drawing.Point(40, 480);
            this.mario.Name = "mario";
            this.mario.Size = new System.Drawing.Size(100, 100);
            this.mario.TabIndex = 19;
            this.mario.TabStop = false;
            // 
            // imgListMb
            // 
            this.imgListMb.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListMb.ImageStream")));
            this.imgListMb.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListMb.Images.SetKeyName(0, "mb1.png");
            this.imgListMb.Images.SetKeyName(1, "mb2.png");
            // 
            // bowser
            // 
            this.bowser.BackColor = System.Drawing.Color.Transparent;
            this.bowser.Location = new System.Drawing.Point(660, 480);
            this.bowser.Name = "bowser";
            this.bowser.Size = new System.Drawing.Size(100, 100);
            this.bowser.TabIndex = 20;
            this.bowser.TabStop = false;
            // 
            // tunel
            // 
            this.tunel.BackColor = System.Drawing.Color.Transparent;
            this.tunel.Location = new System.Drawing.Point(360, 280);
            this.tunel.Name = "tunel";
            this.tunel.Size = new System.Drawing.Size(100, 100);
            this.tunel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tunel.TabIndex = 21;
            this.tunel.TabStop = false;
            // 
            // imgListTunel
            // 
            this.imgListTunel.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListTunel.ImageStream")));
            this.imgListTunel.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListTunel.Images.SetKeyName(0, "pipe.png");
            // 
            // vida1
            // 
            this.vida1.BackColor = System.Drawing.Color.Transparent;
            this.vida1.Location = new System.Drawing.Point(12, 12);
            this.vida1.Name = "vida1";
            this.vida1.Size = new System.Drawing.Size(40, 40);
            this.vida1.TabIndex = 22;
            this.vida1.TabStop = false;
            // 
            // vida2
            // 
            this.vida2.BackColor = System.Drawing.Color.Transparent;
            this.vida2.Location = new System.Drawing.Point(58, 12);
            this.vida2.Name = "vida2";
            this.vida2.Size = new System.Drawing.Size(40, 40);
            this.vida2.TabIndex = 23;
            this.vida2.TabStop = false;
            // 
            // vida3
            // 
            this.vida3.BackColor = System.Drawing.Color.Transparent;
            this.vida3.Location = new System.Drawing.Point(104, 12);
            this.vida3.Name = "vida3";
            this.vida3.Size = new System.Drawing.Size(40, 40);
            this.vida3.TabIndex = 24;
            this.vida3.TabStop = false;
            // 
            // imgListHeart
            // 
            this.imgListHeart.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListHeart.ImageStream")));
            this.imgListHeart.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListHeart.Images.SetKeyName(0, "heart.png");
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Location = new System.Drawing.Point(555, 13);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(96, 23);
            this.btnReiniciar.TabIndex = 26;
            this.btnReiniciar.Text = "Reiniciar Juego";
            this.btnReiniciar.UseVisualStyleBackColor = true;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // txtCoordenadas
            // 
            this.txtCoordenadas.Location = new System.Drawing.Point(449, 15);
            this.txtCoordenadas.Name = "txtCoordenadas";
            this.txtCoordenadas.Size = new System.Drawing.Size(100, 20);
            this.txtCoordenadas.TabIndex = 27;
            this.txtCoordenadas.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.txtCoordenadas);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.vida3);
            this.Controls.Add(this.vida2);
            this.Controls.Add(this.vida1);
            this.Controls.Add(this.tunel);
            this.Controls.Add(this.bowser);
            this.Controls.Add(this.mario);
            this.Controls.Add(this.pbFondo);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.btnComenzar);
            this.Controls.Add(this.lbltiempo);
            this.Controls.Add(this.gbChat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.gbChat.ResumeLayout(false);
            this.gbChat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFondo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bowser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tunel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vida1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vida2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vida3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbChat;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbltiempo;
        private System.Windows.Forms.Button btnComenzar;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.ImageList imgListBw;
        private System.Windows.Forms.PictureBox pbFondo;
        private System.Windows.Forms.PictureBox mario;
        private System.Windows.Forms.ImageList imgListMb;
        private System.Windows.Forms.PictureBox bowser;
        private System.Windows.Forms.PictureBox tunel;
        private System.Windows.Forms.ImageList imgListTunel;
        private System.Windows.Forms.PictureBox vida1;
        private System.Windows.Forms.PictureBox vida2;
        private System.Windows.Forms.PictureBox vida3;
        private System.Windows.Forms.ImageList imgListHeart;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.TextBox txtCoordenadas;
    }
}

