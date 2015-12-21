using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class RepositorioAgendamento
    {

        RepositorioPaciente repPaciente;

        public RepositorioAgendamento(RepositorioPaciente repPaciente)
        {
            this.repPaciente = repPaciente;
        }


        public List<Agendamento> ReceberTodosAgendamentosPeloProtocolo(int Protocolo)
        {
            List<Agendamento> Agendamentos = new List<Agendamento>();

            Paciente paciente = repPaciente.ReceberPacientePeloProtocolo(Protocolo);
            Agendamentos = paciente.getListaDeConsultas();

            return Agendamentos;
        }

        public bool RegistrarAgendamento(Agendamento Agendamento)
        {

            if (repPaciente.PacienteExiste(Agendamento.Protocolo))
            {

                DateTime diaAtual = DateTime.Now;

                if (Agendamento.DiaAgendado.CompareTo(diaAtual) == 1)
                {
                    //Adicionar no Banco de Dados o agendamento.
                    repPaciente.ReceberPacientePeloProtocolo(Agendamento.Protocolo).AddConsulta(Agendamento);
                    return true;
                }
            }

            return false;
        }


        public List<Paciente> PacientesAgendados(DateTime dia)
        {
            List<Paciente> pacientes = new List<Paciente>();


            foreach (var auxPaciente in repPaciente.ReceberTodosPacientes())
            {
                DateTime ultimoAgendamento = auxPaciente.UltimoAgendamento().DiaAgendado;
                if (ultimoAgendamento.Day == dia.Day &&
                    ultimoAgendamento.Month == dia.Month &&
                    ultimoAgendamento.Year == dia.Year)
                {

                    pacientes.Add(auxPaciente);

                }
            }

            return pacientes;
        }

        public List<Paciente> PacientesAgendadosPeloTipo(EnumTipoDeTratamento tipoDeTratamento)
        {
            List<Paciente> PacientesAgendadosPeloTipo = new List<Paciente>();

            foreach (var auxPaciente in repPaciente.ReceberTodosPacientes())
            {
                foreach (var auxConsulta in auxPaciente.getListaDeConsultas())
                {
                    if (auxConsulta.TipoDeTratamento.Equals(tipoDeTratamento))
                    {
                        PacientesAgendadosPeloTipo.Add(auxPaciente);
                    }

                }
            }

            return PacientesAgendadosPeloTipo;
        }

        public int QuantidadeDePacientesAgendados(DateTime Dia)
        {
            int qtde = 0;
            DateTime diaAtual = Dia;

            foreach (var auxPaciente in PacientesAgendados(Dia))
            {
                qtde++;
            }

            return qtde;
        }

        public void Mock()
        {

        }

    }
}
