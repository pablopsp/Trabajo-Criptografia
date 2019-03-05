namespace Criptografia.Maestro.Forms
{
    partial class EsclavoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EsclavoForm));
            this.LblTitle = new System.Windows.Forms.Label();
            this.CloseImage = new System.Windows.Forms.PictureBox();
            this.BtnGenerateRSA = new System.Windows.Forms.Button();
            this.LblPrivClave = new System.Windows.Forms.Label();
            this.LblPublicClave = new System.Windows.Forms.Label();
            this.LblClavePriValue = new System.Windows.Forms.Label();
            this.LblClavePublicValue = new System.Windows.Forms.Label();
            this.BtnExportRSA = new System.Windows.Forms.Button();
            this.BtnImportTDES = new System.Windows.Forms.Button();
            this.LblTDESEncrypted = new System.Windows.Forms.Label();
            this.BtnDecryptTDES = new System.Windows.Forms.Button();
            this.LblTDESDecrypted = new System.Windows.Forms.Label();
            this.MssgToEncrypt = new System.Windows.Forms.TextBox();
            this.BtnMssgEncrypt = new System.Windows.Forms.Button();
            this.LblMssgEncrypted = new System.Windows.Forms.Label();
            this.BtnExportToXML = new System.Windows.Forms.Button();
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
            this.LblTitle.Size = new System.Drawing.Size(107, 31);
            this.LblTitle.TabIndex = 1;
            this.LblTitle.Text = "Esclavo";
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
            this.CloseImage.TabIndex = 3;
            this.CloseImage.TabStop = false;
            this.CloseImage.Click += new System.EventHandler(this.CloseImage_Click);
            // 
            // BtnGenerateRSA
            // 
            this.BtnGenerateRSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGenerateRSA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnGenerateRSA.Location = new System.Drawing.Point(59, 118);
            this.BtnGenerateRSA.Name = "BtnGenerateRSA";
            this.BtnGenerateRSA.Size = new System.Drawing.Size(119, 40);
            this.BtnGenerateRSA.TabIndex = 4;
            this.BtnGenerateRSA.Text = "Generar claves RSA";
            this.BtnGenerateRSA.UseVisualStyleBackColor = true;
            // 
            // LblPrivClave
            // 
            this.LblPrivClave.AutoSize = true;
            this.LblPrivClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPrivClave.Location = new System.Drawing.Point(229, 144);
            this.LblPrivClave.Name = "LblPrivClave";
            this.LblPrivClave.Size = new System.Drawing.Size(110, 16);
            this.LblPrivClave.TabIndex = 9;
            this.LblPrivClave.Text = "Clave Privada:";
            // 
            // LblPublicClave
            // 
            this.LblPublicClave.AutoSize = true;
            this.LblPublicClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPublicClave.Location = new System.Drawing.Point(230, 118);
            this.LblPublicClave.Name = "LblPublicClave";
            this.LblPublicClave.Size = new System.Drawing.Size(108, 16);
            this.LblPublicClave.TabIndex = 8;
            this.LblPublicClave.Text = "Clave Pública:";
            // 
            // LblClavePriValue
            // 
            this.LblClavePriValue.AutoSize = true;
            this.LblClavePriValue.Location = new System.Drawing.Point(357, 144);
            this.LblClavePriValue.Name = "LblClavePriValue";
            this.LblClavePriValue.Size = new System.Drawing.Size(35, 13);
            this.LblClavePriValue.TabIndex = 13;
            this.LblClavePriValue.Text = "label2";
            // 
            // LblClavePublicValue
            // 
            this.LblClavePublicValue.AutoSize = true;
            this.LblClavePublicValue.Location = new System.Drawing.Point(357, 118);
            this.LblClavePublicValue.Name = "LblClavePublicValue";
            this.LblClavePublicValue.Size = new System.Drawing.Size(35, 13);
            this.LblClavePublicValue.TabIndex = 12;
            this.LblClavePublicValue.Text = "label1";
            // 
            // BtnExportRSA
            // 
            this.BtnExportRSA.Location = new System.Drawing.Point(190, 189);
            this.BtnExportRSA.Name = "BtnExportRSA";
            this.BtnExportRSA.Size = new System.Drawing.Size(107, 40);
            this.BtnExportRSA.TabIndex = 14;
            this.BtnExportRSA.Text = "Exportar a XML clave pública";
            this.BtnExportRSA.UseVisualStyleBackColor = true;
            // 
            // BtnImportTDES
            // 
            this.BtnImportTDES.Location = new System.Drawing.Point(59, 279);
            this.BtnImportTDES.Name = "BtnImportTDES";
            this.BtnImportTDES.Size = new System.Drawing.Size(119, 38);
            this.BtnImportTDES.TabIndex = 15;
            this.BtnImportTDES.Text = "Importar clave TDES de fichero XML";
            this.BtnImportTDES.UseVisualStyleBackColor = true;
            // 
            // LblTDESEncrypted
            // 
            this.LblTDESEncrypted.AutoSize = true;
            this.LblTDESEncrypted.Location = new System.Drawing.Point(248, 292);
            this.LblTDESEncrypted.Name = "LblTDESEncrypted";
            this.LblTDESEncrypted.Size = new System.Drawing.Size(35, 13);
            this.LblTDESEncrypted.TabIndex = 16;
            this.LblTDESEncrypted.Text = "label1";
            // 
            // BtnDecryptTDES
            // 
            this.BtnDecryptTDES.Location = new System.Drawing.Point(59, 343);
            this.BtnDecryptTDES.Name = "BtnDecryptTDES";
            this.BtnDecryptTDES.Size = new System.Drawing.Size(119, 37);
            this.BtnDecryptTDES.TabIndex = 17;
            this.BtnDecryptTDES.Text = "Desencriptar clave TDES";
            this.BtnDecryptTDES.UseVisualStyleBackColor = true;
            // 
            // LblTDESDecrypted
            // 
            this.LblTDESDecrypted.AutoSize = true;
            this.LblTDESDecrypted.Location = new System.Drawing.Point(248, 355);
            this.LblTDESDecrypted.Name = "LblTDESDecrypted";
            this.LblTDESDecrypted.Size = new System.Drawing.Size(35, 13);
            this.LblTDESDecrypted.TabIndex = 18;
            this.LblTDESDecrypted.Text = "label1";
            // 
            // MssgToEncrypt
            // 
            this.MssgToEncrypt.Location = new System.Drawing.Point(89, 412);
            this.MssgToEncrypt.Name = "MssgToEncrypt";
            this.MssgToEncrypt.Size = new System.Drawing.Size(314, 20);
            this.MssgToEncrypt.TabIndex = 19;
            this.MssgToEncrypt.GotFocus += new System.EventHandler(this.RemovePlaceholder);
            this.MssgToEncrypt.LostFocus += new System.EventHandler(this.AddPlaceholder);
            // 
            // BtnMssgEncrypt
            // 
            this.BtnMssgEncrypt.Location = new System.Drawing.Point(89, 449);
            this.BtnMssgEncrypt.Name = "BtnMssgEncrypt";
            this.BtnMssgEncrypt.Size = new System.Drawing.Size(314, 32);
            this.BtnMssgEncrypt.TabIndex = 20;
            this.BtnMssgEncrypt.Text = "Encriptar texto TDES y claves TDES desencriptadas";
            this.BtnMssgEncrypt.UseVisualStyleBackColor = true;
            // 
            // LblMssgEncrypted
            // 
            this.LblMssgEncrypted.AutoSize = true;
            this.LblMssgEncrypted.Location = new System.Drawing.Point(229, 500);
            this.LblMssgEncrypted.Name = "LblMssgEncrypted";
            this.LblMssgEncrypted.Size = new System.Drawing.Size(35, 13);
            this.LblMssgEncrypted.TabIndex = 21;
            this.LblMssgEncrypted.Text = "label1";
            // 
            // BtnExportToXML
            // 
            this.BtnExportToXML.Location = new System.Drawing.Point(171, 529);
            this.BtnExportToXML.Name = "BtnExportToXML";
            this.BtnExportToXML.Size = new System.Drawing.Size(157, 34);
            this.BtnExportToXML.TabIndex = 22;
            this.BtnExportToXML.Text = "Exporta mensaje a XML";
            this.BtnExportToXML.UseVisualStyleBackColor = true;
            // 
            // EsclavoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.BtnExportToXML);
            this.Controls.Add(this.LblMssgEncrypted);
            this.Controls.Add(this.BtnMssgEncrypt);
            this.Controls.Add(this.MssgToEncrypt);
            this.Controls.Add(this.LblTDESDecrypted);
            this.Controls.Add(this.BtnDecryptTDES);
            this.Controls.Add(this.LblTDESEncrypted);
            this.Controls.Add(this.BtnImportTDES);
            this.Controls.Add(this.BtnExportRSA);
            this.Controls.Add(this.LblClavePriValue);
            this.Controls.Add(this.LblClavePublicValue);
            this.Controls.Add(this.LblPrivClave);
            this.Controls.Add(this.LblPublicClave);
            this.Controls.Add(this.BtnGenerateRSA);
            this.Controls.Add(this.CloseImage);
            this.Controls.Add(this.LblTitle);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(850, 160);
            this.Name = "EsclavoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Esclavo";
            ((System.ComponentModel.ISupportInitialize)(this.CloseImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.PictureBox CloseImage;
        private System.Windows.Forms.Button BtnGenerateRSA;
        private System.Windows.Forms.Label LblPrivClave;
        private System.Windows.Forms.Label LblPublicClave;
        private System.Windows.Forms.Label LblClavePriValue;
        private System.Windows.Forms.Label LblClavePublicValue;
        private System.Windows.Forms.Button BtnExportRSA;
        private System.Windows.Forms.Button BtnImportTDES;
        private System.Windows.Forms.Label LblTDESEncrypted;
        private System.Windows.Forms.Button BtnDecryptTDES;
        private System.Windows.Forms.Label LblTDESDecrypted;
        private System.Windows.Forms.TextBox MssgToEncrypt;
        private System.Windows.Forms.Button BtnMssgEncrypt;
        private System.Windows.Forms.Label LblMssgEncrypted;
        private System.Windows.Forms.Button BtnExportToXML;
    }
}