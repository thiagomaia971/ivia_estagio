using Dominio.Core.Entidades;
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

        public ServicoAgendamento(IRepositorioAgendamento repAgendamento)
        {
            if(repAgendamento == null)
            {
                throw new ArgumentNullException("repAgendamento");
            }

            this.repAgendamento = repAgendamento;
        }

        public bool registrarAgendamento(Agendamento agendamento)
        {
            if (agendamento == null) throw new ArgumentNullException("agendamento");

            var pacientes = agendamento.Paciente;
            if(pacientes == null)
            {
                throw new ArgumentNullException("agendamento.Paciente");
            }

            if (agendamento.DiaDoAgendamento.CompareTo(DateTime.Now) <= 0)
            {
                return false;
            }

            repAgendamento.incluirAgendamento(agendamento);

            return true;
        }


    }
}
