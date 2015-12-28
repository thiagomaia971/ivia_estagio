using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core.Entidades
{
    public class Agendamento
    {
        public int Id { get; set; }
        public Paciente Paciente { get; set; }
        public int PacienteId { get; set; }
        public DateTime DiaDoAgendamento { get; set; }
        public ETipoDeTratamento TipoDeTratamento { get; set; }

        public Agendamento()
        {

        }

        public Agendamento(Paciente paciente, DateTime dia, ETipoDeTratamento tipo)
        {
            if (paciente == null)
            {
                throw new ArgumentNullException("paciente");
            }
            else if(dia == null)
            {
                throw new ArgumentNullException("dia");
            }

            this.Paciente = paciente;
            this.PacienteId = paciente.Id;
            this.DiaDoAgendamento = dia;
            this.TipoDeTratamento = tipo;
        }
    }
}
