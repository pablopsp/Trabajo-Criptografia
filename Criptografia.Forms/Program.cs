using Criptografia.Maestro.Forms;
using System;
using System.Windows.Forms;

namespace Criptografia.Maestro
{
    static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MultiFormContext(new MaestroForm(), new EsclavoForm()));
        }
    }
}
