using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core.Entidades
{
    public class Paciente
    {
        public int Id { get; set; }
        public String Protocolo { get; set; }
        public String Nome { get; set; }

        public Paciente(String Protocolo, String Nome)
        {
            if (String.IsNullOrEmpty(Protocolo))
            {
                throw new ArgumentNullException("protocolo is null or empty");
            }else if (String.IsNullOrEmpty(Nome))
            {
                throw new ArgumentNullException("protocolo is null or empty");
            }

            this.Protocolo = Protocolo;
            this.Nome = Nome;
        }
    }
}
