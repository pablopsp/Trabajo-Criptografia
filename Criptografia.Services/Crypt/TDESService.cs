using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criptografia.Services.Crypt
{
    public class TDESService
    {
        public string Word() => "Hola desde csharp";
        public Task<object> SayHello(object obj) => Task.Factory.StartNew( () => Word() as object);
    }
}
