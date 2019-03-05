using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Criptografia.Maestro.Forms
{
    public partial class EsclavoForm : Form
    {
        public EsclavoForm()
        {
            InitializeComponent();
            this.MssgToEncrypt.Text = "Texto to encrypt";
        }

        private void CloseImage_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MssgToEncrypt.Text))
            {
                MssgToEncrypt.Text = "Texto to encrypt";
            }
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            MssgToEncrypt.TextAlign = HorizontalAlignment.Left;
            MssgToEncrypt.Text = "";
        }

        
    }
}
