using System.Threading;
using System.Windows.Forms;

namespace Criptografia.Maestro
{
    public class MultiFormContext : ApplicationContext
    {
        private int openForms;

        /// <summary>
        /// Permite ejecutar mas de un Windows Form a la vez
        /// </summary>
        /// <param name="forms"></param>
        public MultiFormContext(params Form[] forms)
        {
            openForms = forms.Length;

            foreach (var form in forms)
            {
                form.FormClosed += (s, args) =>
                {
                    //When we have closed the last of the "starting" forms, 
                    //end the program.
                    if (Interlocked.Decrement(ref openForms) == 0)
                        ExitThread();
                };

                form.Show();
            }
        }
    }
}
