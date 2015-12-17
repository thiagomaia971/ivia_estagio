using System;
using System.Collections.Generic;

namespace Core
{
    public class Atendente
    {

        private AgendaCompleta Agenda { get; set; }

        public Atendente()
        {
            Agenda = new AgendaCompleta();

        }

        public bool ImprimirRelatorioPeloTipo(string TipoDeTratamento)
        {

            try
            {
                List<Paciente> ListaDePacientesPeloTipoDeTratamento = Agenda.PacientesAgendadosPeloTipo(TipoDeTratamento);

                switch (TipoDeTratamento)
                {
                    case "Quimioterapia Dia":
                        //Implementar a Impressão.
                        break;

                    case "Quimioterapia Sequencial":
                        //Implementar a Impressão.
                        break;

                    case "Intercorrencia":
                        //Implementar a Impressão.
                        break;

                    case "Procedimento":
                        //Implementar a Impressão.
                        break;

                    default:
                        break;
                }

                return true;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            
        }

        public Paciente GetPacientePeloNome(string NomePaciente)
        {
            Paciente paciente = new Paciente();

            List<Paciente> pacientesAgendados = ConsultarPacientesAgendados();

            foreach (var auxPaciente in pacientesAgendados)
            {
                if (NomePaciente.Equals(auxPaciente.getNome()))
                {
                    paciente = auxPaciente;
                }
            }

            return paciente;
        }

        public bool RegistrarAgendamento(Paciente Paciente, DateTime DiaDoAtendimento)
        {

            bool registroBool = false;

            try
            {
                //Implementar a adição do Paciente no banco de dados e depois atualizar a Lista.
                //Agenda.AtualizarLista();

                registroBool = true;
            }
            catch (Exception)
            {
                registroBool = false;
                throw;
            }

            return registroBool;

        }

        public List<Paciente> ConsultarPacientesAgendados()
        {
            return Agenda.PacientesAgendados();
        }

        public List<Paciente> ConsultarPacientesAgendados(DateTime diaQueAAtendenteQuerConsultar)
        {
            return Agenda.PacientesAgendados(diaQueAAtendenteQuerConsultar);
        }
    }
}