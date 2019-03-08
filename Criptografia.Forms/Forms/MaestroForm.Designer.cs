namespace Criptografia.Maestro
{
    partial class MaestroForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaestroForm));
            this.LblTitle = new System.Windows.Forms.Label();
            this.CloseImage = new System.Windows.Forms.PictureBox();
            this.BtnGenerateRSA = new System.Windows.Forms.Button();
            this.LblPublicClave = new System.Windows.Forms.Label();
            this.LblPrivClave = new System.Windows.Forms.Label();
            this.BtnImportRSA = new System.Windows.Forms.Button();
            this.LblClavePublicaEsclavo = new System.Windows.Forms.Label();
            this.LblClaveTDES = new System.Windows.Forms.Label();
            this.BtnGenerateTDES = new System.Windows.Forms.Button();
            this.BtnEncryptTDES = new System.Windows.Forms.Button();
            this.LblTDESEncrypted = new System.Windows.Forms.Label();
            this.BtnExportTDESEncrypted = new System.Windows.Forms.Button();
            this.BtnImportMssg = new System.Windows.Forms.Button();
            this.LblEncryptedMssg = new System.Windows.Forms.Label();
            this.BtnDecryptMssg = new System.Windows.Forms.Button();
            this.LblDecryptedMssg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CloseImage)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblTitle.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitle.ForeColor = System.Drawing.Color.SteelBlue;
            this.LblTitle.Location = new System.Drawing.Point(190, 50);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(109, 31);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "Maestro";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CloseImage
            // 
            this.CloseImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseImage.Image = ((System.Drawing.Image)(resources.GetObject("CloseImage.Image")));
            this.CloseImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("CloseImage.InitialImage")));
            this.CloseImage.Location = new System.Drawing.Point(418, 12);
            this.CloseImage.Name = "CloseImage";
            this.CloseImage.Size = new System.Drawing.Size(70, 50);
            this.CloseImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.CloseImage.TabIndex = 2;
            this.CloseImage.TabStop = false;
            this.CloseImage.Click += new System.EventHandler(this.CloseImage_Click);
            // 
            // BtnGenerateRSA
            // 
            this.BtnGenerateRSA.Location = new System.Drawing.Point(59, 118);
            this.BtnGenerateRSA.Name = "BtnGenerateRSA";
            this.BtnGenerateRSA.Size = new System.Drawing.Size(119, 40);
            this.BtnGenerateRSA.TabIndex = 3;
            this.BtnGenerateRSA.Text = "Generar claves RSA";
            this.BtnGenerateRSA.UseVisualStyleBackColor = true;
            this.BtnGenerateRSA.Click += new System.EventHandler(this.BtnGenerateRSA_Click);
            // 
            // LblPublicClave
            // 
            this.LblPublicClave.AutoSize = true;
            this.LblPublicClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPublicClave.Location = new System.Drawing.Point(208, 118);
            this.LblPublicClave.Name = "LblPublicClave";
            this.LblPublicClave.Size = new System.Drawing.Size(108, 16);
            this.LblPublicClave.TabIndex = 4;
            this.LblPublicClave.Text = "Clave Pública:";
            // 
            // LblPrivClave
            // 
            this.LblPrivClave.AutoSize = true;
            this.LblPrivClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPrivClave.Location = new System.Drawing.Point(207, 144);
            this.LblPrivClave.Name = "LblPrivClave";
            this.LblPrivClave.Size = new System.Drawing.Size(110, 16);
            this.LblPrivClave.TabIndex = 5;
            this.LblPrivClave.Text = "Clave Privada:";
            // 
            // BtnImportRSA
            // 
            this.BtnImportRSA.Location = new System.Drawing.Point(59, 209);
            this.BtnImportRSA.Name = "BtnImportRSA";
            this.BtnImportRSA.Size = new System.Drawing.Size(127, 35);
            this.BtnImportRSA.TabIndex = 8;
            this.BtnImportRSA.Text = "Importar clave pública RSA Esclavo";
            this.BtnImportRSA.UseVisualStyleBackColor = true;
            this.BtnImportRSA.Click += new System.EventHandler(this.BtnImportRSA_Click);
            // 
            // LblClavePublicaEsclavo
            // 
            this.LblClavePublicaEsclavo.AutoSize = true;
            this.LblClavePublicaEsclavo.Location = new System.Drawing.Point(218, 220);
            this.LblClavePublicaEsclavo.Name = "LblClavePublicaEsclavo";
            this.LblClavePublicaEsclavo.Size = new System.Drawing.Size(0, 13);
            this.LblClavePublicaEsclavo.TabIndex = 9;
            this.LblClavePublicaEsclavo.Click += new System.EventHandler(this.LblClavePublicaEsclavo_Click);
            // 
            // LblClaveTDES
            // 
            this.LblClaveTDES.AutoSize = true;
            this.LblClaveTDES.Location = new System.Drawing.Point(218, 282);
            this.LblClaveTDES.Name = "LblClaveTDES";
            this.LblClaveTDES.Size = new System.Drawing.Size(0, 13);
            this.LblClaveTDES.TabIndex = 11;
            this.LblClaveTDES.Click += new System.EventHandler(this.LblClaveTDES_Click);
            // 
            // BtnGenerateTDES
            // 
            this.BtnGenerateTDES.Location = new System.Drawing.Point(59, 273);
            this.BtnGenerateTDES.Name = "BtnGenerateTDES";
            this.BtnGenerateTDES.Size = new System.Drawing.Size(127, 30);
            this.BtnGenerateTDES.TabIndex = 13;
            this.BtnGenerateTDES.Text = "Generar clave TDES";
            this.BtnGenerateTDES.UseVisualStyleBackColor = true;
            this.BtnGenerateTDES.Click += new System.EventHandler(this.BtnGenerateTDES_Click);
            // 
            // BtnEncryptTDES
            // 
            this.BtnEncryptTDES.Location = new System.Drawing.Point(59, 337);
            this.BtnEncryptTDES.Name = "BtnEncryptTDES";
            this.BtnEncryptTDES.Size = new System.Drawing.Size(161, 58);
            this.BtnEncryptTDES.TabIndex = 14;
            this.BtnEncryptTDES.Text = "Encriptar clave TDES con RSA y clave pública esclavo";
            this.BtnEncryptTDES.UseVisualStyleBackColor = true;
            this.BtnEncryptTDES.Click += new System.EventHandler(this.BtnEncryptTDES_Click);
            // 
            // LblTDESEncrypted
            // 
            this.LblTDESEncrypted.AutoSize = true;
            this.LblTDESEncrypted.Location = new System.Drawing.Point(347, 360);
            this.LblTDESEncrypted.Name = "LblTDESEncrypted";
            this.LblTDESEncrypted.Size = new System.Drawing.Size(0, 13);
            this.LblTDESEncrypted.TabIndex = 16;
            this.LblTDESEncrypted.Click += new System.EventHandler(this.LblTDESEncrypted_Click);
            // 
            // BtnExportTDESEncrypted
            // 
            this.BtnExportTDESEncrypted.Location = new System.Drawing.Point(258, 337);
            this.BtnExportTDESEncrypted.Name = "BtnExportTDESEncrypted";
            this.BtnExportTDESEncrypted.Size = new System.Drawing.Size(81, 58);
            this.BtnExportTDESEncrypted.TabIndex = 17;
            this.BtnExportTDESEncrypted.Text = "Exportar a XML TDES Encriptada";
            this.BtnExportTDESEncrypted.UseVisualStyleBackColor = true;
            this.BtnExportTDESEncrypted.Click += new System.EventHandler(this.BtnExportTDESEncrypted_Click);
            // 
            // BtnImportMssg
            // 
            this.BtnImportMssg.Location = new System.Drawing.Point(59, 443);
            this.BtnImportMssg.Name = "BtnImportMssg";
            this.BtnImportMssg.Size = new System.Drawing.Size(161, 25);
            this.BtnImportMssg.TabIndex = 18;
            this.BtnImportMssg.Text = "Importar mensaje desde XML";
            this.BtnImportMssg.UseVisualStyleBackColor = true;
            // 
            // LblEncryptedMssg
            // 
            this.LblEncryptedMssg.AutoSize = true;
            this.LblEncryptedMssg.Location = new System.Drawing.Point(252, 449);
            this.LblEncryptedMssg.Name = "LblEncryptedMssg";
            this.LblEncryptedMssg.Size = new System.Drawing.Size(35, 13);
            this.LblEncryptedMssg.TabIndex = 20;
            this.LblEncryptedMssg.Text = "label2";
            // 
            // BtnDecryptMssg
            // 
            this.BtnDecryptMssg.Location = new System.Drawing.Point(59, 506);
            this.BtnDecryptMssg.Name = "BtnDecryptMssg";
            this.BtnDecryptMssg.Size = new System.Drawing.Size(161, 44);
            this.BtnDecryptMssg.TabIndex = 21;
            this.BtnDecryptMssg.Text = "Desencriptar texto con TDES y clave TDES creada";
            this.BtnDecryptMssg.UseVisualStyleBackColor = true;
            // 
            // LblDecryptedMssg
            // 
            this.LblDecryptedMssg.AutoSize = true;
            this.LblDecryptedMssg.Location = new System.Drawing.Point(252, 521);
            this.LblDecryptedMssg.Name = "LblDecryptedMssg";
            this.LblDecryptedMssg.Size = new System.Drawing.Size(35, 13);
            this.LblDecryptedMssg.TabIndex = 22;
            this.LblDecryptedMssg.Text = "label2";
            // 
            // MaestroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.LblDecryptedMssg);
            this.Controls.Add(this.BtnDecryptMssg);
            this.Controls.Add(this.LblEncryptedMssg);
            this.Controls.Add(this.BtnImportMssg);
            this.Controls.Add(this.BtnExportTDESEncrypted);
            this.Controls.Add(this.LblTDESEncrypted);
            this.Controls.Add(this.BtnEncryptTDES);
            this.Controls.Add(this.BtnGenerateTDES);
            this.Controls.Add(this.LblClaveTDES);
            this.Controls.Add(this.LblClavePublicaEsclavo);
            this.Controls.Add(this.BtnImportRSA);
            this.Controls.Add(this.LblPrivClave);
            this.Controls.Add(this.LblPublicClave);
            this.Controls.Add(this.BtnGenerateRSA);
            this.Controls.Add(this.CloseImage);
            this.Controls.Add(this.LblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(220, 160);
            this.Name = "MaestroForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Master";
            ((System.ComponentModel.ISupportInitialize)(this.CloseImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.PictureBox CloseImage;
        private System.Windows.Forms.Button BtnGenerateRSA;
        private System.Windows.Forms.Label LblPublicClave;
        private System.Windows.Forms.Label LblPrivClave;
        private System.Windows.Forms.Button BtnImportRSA;
        private System.Windows.Forms.Label LblClavePublicaEsclavo;
        private System.Windows.Forms.Label LblClaveTDES;
        private System.Windows.Forms.Button BtnGenerateTDES;
        private System.Windows.Forms.Button BtnEncryptTDES;
        private System.Windows.Forms.Label LblTDESEncrypted;
        private System.Windows.Forms.Button BtnExportTDESEncrypted;
        private System.Windows.Forms.Button BtnImportMssg;
        private System.Windows.Forms.Label LblEncryptedMssg;
        private System.Windows.Forms.Button BtnDecryptMssg;
        private System.Windows.Forms.Label LblDecryptedMssg;
    }
}

