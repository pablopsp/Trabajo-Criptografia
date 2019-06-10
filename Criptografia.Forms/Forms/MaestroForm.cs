using Criptografia.Maestro.Forms;
using Criptografia.Services.Crypt;
using Criptografia.Services.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Criptografia.Maestro
{
    public partial class MaestroForm : Form
    {
        public static Label LblClavePriValue;
        public static Label LblClavePublicValue;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                Capture = false;
                Message msg = Message.Create(Handle, 0XA1, new IntPtr(2), IntPtr.Zero);
                WndProc(ref msg);
            }
        }

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
        public MaestroForm()
        {
            InitializeComponent();
            InitializeSharedLbl();
        }

        private void CloseImage_Click(object sender, EventArgs e) => this.Close();

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
            EsclavoForm.LblClavePublicValue.Text = keys[0];
            EsclavoForm.LblClavePriValue.Text = keys[1];
        }

        private void LblClavePublicValue_Click(object sender, EventArgs e) => MessageBox.Show(LblClavePublicValue.Text,
            "Valor clave publica",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        private void LblClavePriValue_Click(object sender, EventArgs e) => MessageBox.Show(LblClavePriValue.Text,
            "Valor clave privada",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        private void BtnImportRSA_Click(object sender, EventArgs e)
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
                    BtnImportRSA_Click(sender, e);
                }
                else
                {
                    if (Path.GetFileName(fileDialog.FileName) == "cp_esclavo.xml")
                    {
                        string rsa = Services.XML.Import.ImportDataFromNode(fileDialog.FileName, "clavepublica").ToString();
                        LblClavePublicaEsclavo.Text = rsa;
                    }
                    else
                    {
                        MessageBox.Show("El xml se tiene que llamar 'cp_exclavo.xml'",
                                        "XML erroneo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void LblClavePublicaEsclavo_Click(object sender, EventArgs e) => MessageBox.Show(LblClavePublicaEsclavo.Text, 
            "Valor clave publica del esclavo", 
            MessageBoxButtons.OK, 
            MessageBoxIcon.Information);

        private void BtnGenerateTDES_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LblClaveTDES.Text))
            {
                List<string> tdesKeys = TDESService.Keys.ToList();
                LblClaveTDES.Text = tdesKeys[0] + tdesKeys[1] + tdesKeys[2];
            }
            else
            {
                //intentar generar una nueva clave TDES
                DialogResult dg = MessageBox.Show("¿Esta segur@ de que desea generar otra clave TDES?",
                                                    "Comprobación de generación TDES",
                                                    MessageBoxButtons.YesNo);
                if (dg == DialogResult.Yes)
                {
                    List<string> tdesKeys = TDESService.Keys.ToList();
                    LblClaveTDES.Text = tdesKeys[0] + tdesKeys[1] + tdesKeys[2];
                }
            }
        }
        private void LblClaveTDES_Click(object sender, EventArgs e) => MessageBox.Show(LblClaveTDES.Text,
            "Valor clave TDES",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        private void BtnEncryptTDES_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LblClaveTDES.Text) || string.IsNullOrWhiteSpace(LblClavePublicaEsclavo.Text))
                MessageBox.Show("No puede encriptar la clave TDES si no ha importado la clave publica RSA del esclavo ni generado la clave TDES.",
                                "Cannot encrypt TDES key",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            
            else
            {
                var list = TDESService.Keys.ToList();
                list.Add(ByteTransform.DeleteSpacesFromHex(BitConverter.ToString(TDESService.TDESIv)));
                List<byte[]> encryptedTDES = RSAService.EncryptTDES(list, LblClavePublicaEsclavo.Text).ToList();
                LblTDESEncrypted.Text = ByteTransform.DeleteSpacesFromHex(BitConverter.ToString(encryptedTDES[0])) + Environment.NewLine +
                                        ByteTransform.DeleteSpacesFromHex(BitConverter.ToString(encryptedTDES[1])) + Environment.NewLine +
                                        ByteTransform.DeleteSpacesFromHex(BitConverter.ToString(encryptedTDES[2])) + Environment.NewLine +
                                        ByteTransform.DeleteSpacesFromHex(BitConverter.ToString(encryptedTDES[3]));
            }
        }
        private void LblTDESEncrypted_Click(object sender, EventArgs e) => MessageBox.Show(LblTDESEncrypted.Text,
            "Valor clave TDES Encriptada",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        private void BtnExportTDESEncrypted_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(LblTDESEncrypted.Text))
                Services.XML.Export.ExportTDES(LblTDESEncrypted.Text, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\tdesencriptado.xml");
            else
                MessageBox.Show("Primero debe generar la clave TDES encriptada.",
                                "Wrong way",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            
        }

        private void BtnImportMssg_Click(object sender, EventArgs e)
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
                    BtnImportMssg_Click(sender, e);
                }
                else
                {
                    if (Path.GetFileName(fileDialog.FileName) == "textoencriptado.xml")
                        LblEncryptedMssg.Text = Services.XML.Import.ImportDataFromNode(fileDialog.FileName, "textoe").ToString();
                    
                    else
                        MessageBox.Show("El xml se tiene que llamar 'textoencriptado.xml'",
                                        "XML erroneo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                }
            }
        }
        private void LblEncryptedMssg_Click(object sender, EventArgs e) => MessageBox.Show(LblEncryptedMssg.Text,
            "Mesnaje encriptado",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        private void BtnDecryptMssg_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(LblEncryptedMssg.Text) || string.IsNullOrWhiteSpace(LblClaveTDES.Text))
                MessageBox.Show("Debe haber importado el texto encriptado y haber generado la clave TDES.",
                                    "Wrong way",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
            else
            {
                byte[] decryptedText = TDESService.Decrypt(LblEncryptedMssg.Text, ByteTransform.HexStringToByteArray(LblClaveTDES.Text));
                LblDecryptedMssg.Text = Encoding.Default.GetString(decryptedText);
            }
        }
        private void LblDecryptedMssg_Click(object sender, EventArgs e) => MessageBox.Show(LblDecryptedMssg.Text,
            "Mesnaje desencriptado",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }
}
