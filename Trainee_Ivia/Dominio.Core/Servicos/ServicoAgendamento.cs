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
        IRepositorioPaciente repPaciente;

        public ServicoAgendamento(IRepositorioAgendamento repAgendamento, IRepositorioPaciente repPaciente)
        {
            if(repAgendamento == null)
            {
                throw new ArgumentNullException("repAgendamento");
            }

            if(repPaciente == null)
            {
                throw new ArgumentNullException("repPaciente");
            }

            this.repAgendamento = repAgendamento;
            this.repPaciente = repPaciente;
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
            
            agendamento.Paciente = repPaciente.obterPaciente(agendamento.Paciente.Protocolo);
            agendamento.PacienteId = agendamento.Paciente.Id;

            repAgendamento.incluirAgendamento(agendamento);

            return true;
        }
        public bool setStatus(Agendamento agendamento)
        {
            if (agendamento == null)
            {
                throw new ArgumentNullException("agendamento");
            }

            repAgendamento.incluirStatus(agendamento);
            return true;
        }

    }
}
