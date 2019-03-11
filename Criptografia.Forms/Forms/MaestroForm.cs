using Criptografia.Maestro.Forms;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Criptografia.Maestro
{
    public partial class MaestroForm : Form
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
                    string rsa = Services.XML.Import.ImportPublicRSA(fileDialog.FileName).ToString();
                    LblClavePublicaEsclavo.Text = rsa;
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
                LblClaveTDES.Text = Encoding.Default.GetString(Services.Crypt.TDESService.TDESKey);
            else
            {
                DialogResult dg = MessageBox.Show("¿Esta segur@ de que desea generar otra clave TDES?",
                                                    "Comprobación de generación TDES",
                                                    MessageBoxButtons.YesNo);
                if (dg == DialogResult.Yes)
                    LblClaveTDES.Text = Encoding.Default.GetString(Services.Crypt.TDESService.TDESKey);
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
                byte[] encryptedTDES = Services.Crypt.RSAService.Encrypt(LblClaveTDES.Text, LblClavePublicaEsclavo.Text);
                LblTDESEncrypted.Text = Encoding.Default.GetString(encryptedTDES);
            }
        }
        private void LblTDESEncrypted_Click(object sender, EventArgs e) => MessageBox.Show(LblTDESEncrypted.Text,
            "Valor clave TDES Encriptada",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);

        private void BtnExportTDESEncrypted_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(LblTDESEncrypted.Text))
                Services.XML.Export.ExportEncryptedTDES(LblTDESEncrypted.Text,
                                                        Environment.GetFolderPath(
                                                        Environment.SpecialFolder.Desktop) + @"\tdesencriptado.xml");
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
                    string msgEncrypted = Services.XML.Import.ImportEncryptedMssg(fileDialog.FileName).ToString();
                    byte[] arrByteTDES = Services.Util.ByteTransform.GetByteArrayOnString(msgEncrypted);
                    LblEncryptedMssg.Text = Encoding.Default.GetString(arrByteTDES);
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
                string decryptedText = Services.Crypt.TDESService.Decrypt(LblEncryptedMssg.Text, Encoding.Default.GetBytes(LblClaveTDES.Text));
                LblDecryptedMssg.Text = decryptedText;
            }
        }
        private void LblDecryptedMssg_Click(object sender, EventArgs e) => MessageBox.Show(LblDecryptedMssg.Text,
            "Mesnaje desencriptado",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }
}
