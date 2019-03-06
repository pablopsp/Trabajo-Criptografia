using Criptografia.Maestro.Forms;
using Criptografia.Services;
using Criptografia.Services.Crypt;
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
            LblClavePriValue.Location = new Point(357, 144);
            LblClavePriValue.Name = "LblClavePriValue";
            LblClavePriValue.Size = new Size(0, 13);
            LblClavePriValue.TabIndex = 13;
            LblClavePriValue.Click += new EventHandler(this.LblClavePriValue_Click);
            // 
            // LblClavePublicValue
            // 
            LblClavePublicValue.AutoSize = true;
            LblClavePublicValue.Location = new Point(357, 118);
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
                InitialDirectory = "c:\\",
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
            string TDESKey = Encoding.UTF8.GetString(TDESService.GenerateKey());
            LblClaveTDES.Text = TDESKey;
        }
        private void LblClaveTDES_Click(object sender, EventArgs e) => MessageBox.Show(LblClaveTDES.Text,
            "Valor clave TDES",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }
}
