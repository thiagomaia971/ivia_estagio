using Dominio.Core.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core.Servicos
{
    public class ServicoAgendamento
    {
        IRepositorioAgendamento repAgendamento;
        IRepositorioPaciente repPaciente;

        public ServicoAgendamento(IRepositorioPaciente repPaciente, IRepositorioAgendamento repAgendamento)
        {
            if(repPaciente == null)
            {
                throw new ArgumentNullException("repPaciente");
            }else if(repAgendamento == null)
            {
                throw new ArgumentNullException("repAgendamento");
            }

            this.repAgendamento = repAgendamento;
            this.repPaciente = repPaciente;
        }




    }
}
