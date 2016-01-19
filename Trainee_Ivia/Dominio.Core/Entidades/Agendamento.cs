using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Core.Entidades
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }

        
        [Required(ErrorMessage = "Dia do Agendamento Obrigatório!")]
        public DateTime DiaDoAgendamento { get; set; }

        [Required(ErrorMessage = "Tipo de Tratamento Obrigatório!")]
        [Range(1, 4, ErrorMessage = "Informe um Tipo de Tratamento!")]
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
