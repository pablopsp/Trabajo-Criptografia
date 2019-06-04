using Criptografia.Services.Crypt;
using Criptografia.Services.Util;
using Criptografia.Services.XML;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Criptografia.Maestro.Forms
{
    public partial class EsclavoForm : Form
    {
        public static Label LblClavePriValue;
        public static Label LblClavePublicValue;
        private void InitializeSharedLbl()
        {
            LblClavePriValue = new Label();
            LblClavePublicValue = new Label();
            // 
            // LblClavePriValue
            // 
            LblClavePriValue.AutoSize = true;
            LblClavePriValue.Location = new Point(320, 144);
            LblClavePriValue.Name = "LblClavePriValue";
            LblClavePriValue.Size = new Size(0, 13);
            LblClavePriValue.TabIndex = 13;
            LblClavePriValue.Click += new EventHandler(this.LblClavePriValue_Click);
            // 
            // LblClavePublicValue
            // 
            LblClavePublicValue.AutoSize = true;
            LblClavePublicValue.Location = new Point(320, 118);
            LblClavePublicValue.Name = "LblClavePublicValue";
            LblClavePublicValue.Size = new Size(0, 13);
            LblClavePublicValue.TabIndex = 12;
            LblClavePublicValue.Click += new EventHandler(this.LblClavePublicValue_Click);

            Controls.Add(LblClavePriValue);
            Controls.Add(LblClavePublicValue);
        }
        public EsclavoForm()
        {
            InitializeComponent();
            InitializeSharedLbl();
        }

        private void CloseImage_Click(object sender, EventArgs e) => this.Close();

        private void AddPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MssgToEncrypt.Text))
                MssgToEncrypt.Text = "Text to encrypt";
        }
        private void RemovePlaceholder(object sender, EventArgs e) => MssgToEncrypt.Text = "";

        private void BtnGenerateRSA_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LblClavePriValue.Text) &&
                string.IsNullOrWhiteSpace(LblClavePriValue.Text))
                GenerateRSA();
            else
            {
                DialogResult dg = MessageBox.Show("¿Esta segur@ de que desea generar otra clave privada y publica?",
                                                    "Comprobación de generación RSA",
                                                    MessageBoxButtons.YesNo);
                if (dg == DialogResult.Yes)
                    GenerateRSA();
            }
        }
        private void GenerateRSA()
        {
            string[] keys = Services.Crypt.RSAService.GeneratePrivateAndPublicKey();
            LblClavePublicValue.Text = keys[0];
            LblClavePriValue.Text = keys[1];
            MaestroForm.LblClavePublicValue.Text = keys[0];
            MaestroForm.LblClavePriValue.Text = keys[1];
        }

        private void LblClavePublicValue_Click(object sender, EventArgs e) =>  MessageBox.Show(LblClavePublicValue.Text,
            "Valor clave publica",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        private void LblClavePriValue_Click(object sender, EventArgs e) => MessageBox.Show(LblClavePriValue.Text,
            "Valor clave privada",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        private void BtnExportRSA_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(LblClavePublicValue.Text))
                Services.XML.Export.ExportPublicRSA(LblClavePublicValue.Text, 
                                                    Environment.GetFolderPath(
                                                        Environment.SpecialFolder.Desktop) + @"\cp_esclavo.xml");

            else
                MessageBox.Show("Debe generar primero un valor para la clave publica RSA",
                                "Error to export",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
        }

        private void BtnImportTDES_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                DefaultExt = "xml",
                Filter = "XML Files (*.xml)|*.xml",
                FilterIndex = 0,
                RestoreDirectory = true
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                if (!String.Equals(Path.GetExtension(fileDialog.FileName),
                                   ".xml",
                                   StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("The type of the selected file is not supported by this application. You must select an XML file.",
                                    "Invalid File Type",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    BtnImportTDES_Click(sender, e);
                }
                else
                {
                    if (Path.GetFileName(fileDialog.FileName) == "tdesencriptado.xml")
                    {
                        string tdes1 = Import.ImportDataFromNode(fileDialog.FileName, "tdes1").ToString();
                        string tdes2 = Import.ImportDataFromNode(fileDialog.FileName, "tdes2").ToString();
                        string tdes3 = Import.ImportDataFromNode(fileDialog.FileName, "tdes3").ToString();
                        string iv = Import.ImportDataFromNode(fileDialog.FileName, "iv").ToString();
                        LblTDESEncrypted.Text = tdes1 + Environment.NewLine + tdes2 + Environment.NewLine +
                                                tdes3 + Environment.NewLine + iv;
                    }
                    else
                    {
                        MessageBox.Show("El xml se tiene que llamar 'tdesencriptado.xml'",
                                        "XML erroneo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void LblTDESEncrypted_Click(object sender, EventArgs e) => MessageBox.Show(LblTDESEncrypted.Text,
            "Valor clave privada",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        private void BtnDecryptTDES_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LblTDESEncrypted.Text) || string.IsNullOrWhiteSpace(LblClavePriValue.Text))
                MessageBox.Show("Debe haber importado primero la clave TDES Encriptada y haber generado una clave privada.",
                                    "Wrong way",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            else
            {
                string[] encryptedTDESKeys = LblTDESEncrypted.Text.Split(new[] { "\r\n" }, StringSplitOptions.None);

                if (encryptedTDESKeys.Length > 4)
                    encryptedTDESKeys = encryptedTDESKeys.AsEnumerable().ToArray();

                List<string> decryptedKeys = new List<string>();
                foreach (string key in encryptedTDESKeys)
                {
                    var hexKey = ByteTransform.HexStringToByteArray(key);
                    var decrypted = RSAService.Decrypt(hexKey, LblClavePriValue.Text);
                    var a = (ByteTransform.DeleteSpacesFromHex(BitConverter.ToString(decrypted)));
                    decryptedKeys.Add(a);
                }

                TDESService.TDESIv = ByteTransform.HexStringToByteArray(decryptedKeys[3]);
                decryptedKeys.RemoveAt(3);
                LblTDESDecrypted.Text = string.Join("", decryptedKeys.ToArray());
                
            }
        }
        private void LblTDESDecrypted_Click(object sender, EventArgs e) => MessageBox.Show(LblTDESDecrypted.Text,
            "Valor TDES Desencriptada",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        private void BtnMssgEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LblTDESDecrypted.Text))
                MessageBox.Show("Debe haber desencriptado la clave TDES primero.",
                                        "Wrong way",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
            else
            {            
                byte[] msgEncrypted = Services.Crypt.TDESService.Encrypt(MssgToEncrypt.Text, 
                                                                 ByteTransform.HexStringToByteArray(LblTDESDecrypted.Text));
                LblMssgEncrypted.Text = ByteTransform.DeleteSpacesFromHex(BitConverter.ToString(msgEncrypted));
            }
        }
        private void LblMssgEncrypted_Click(object sender, EventArgs e) => MessageBox.Show(LblMssgEncrypted.Text,
            "Valor clave privada",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        private void BtnExportToXML_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(LblMssgEncrypted.Text))
                Services.XML.Export.ExportHexStringToXML("textoe", LblMssgEncrypted.Text,
                                                    Environment.GetFolderPath(
                                                        Environment.SpecialFolder.Desktop) + @"\textoencriptado.xml");

            else
                MessageBox.Show("Debe haber generado el mensaje encriptado primero.",
                                "Error to export",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
        }
    }
}
