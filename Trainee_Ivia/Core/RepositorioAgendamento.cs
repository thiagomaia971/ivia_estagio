using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class RepositorioAgendamento
    {

        private RepositorioPaciente repPaciente;

        private List<Agendamento> agendamentos;
        
        public RepositorioAgendamento(RepositorioPaciente repPaciente)
        {
            if(repPaciente == null)
            {
                throw new ArgumentNullException("repPaciente");
            }
            this.repPaciente = repPaciente;
            /*
            substituir list por ctx e inicializa-lo
            */
            agendamentos = new List<Agendamento>();
        }


        public List<Agendamento> ReceberAgendamentosPaciente(int protocolo)
        {
            if(agendamentos.Exists(a => a.Protocolo == protocolo))
            {
                return agendamentos.FindAll(a => a.Protocolo == protocolo);
            }
            /*
            lembrar de verificar se o cliente foi encontrado sugiro exigir trycath e 
            gerar erro caso não encontre o paciente para tratamento e causar o mesmo erro 

            caso não vá gerar erro deve-se retornar lista vazia mesmo
            */
            return null;
        }

        public bool RegistrarAgendamento(Agendamento agendamento)
        {

            if (repPaciente.PacienteExiste(agendamento.Protocolo))
            {
                /*
                essa verificação não deve ser feita aqui, pois deve ser feita antes
                temos aqui só o repositorio!! A única coisa a ser feita aqui é a verificação
                da existência do paciente

                DateTime diaAtual = DateTime.Now;
                if (Agendamento.DiaAgendado.CompareTo(diaAtual) == 1)
                {
                    //Adicionar no Banco de Dados o agendamento.
                    repPaciente.ReceberPacientePeloProtocolo(Agendamento.Protocolo).AddConsulta(Agendamento);
                    return true;
                }
                */

                /*
                substituir list por ctx
                */
                agendamentos.Add(agendamento);

                return true;
            }
            /*
            prefiro tornar throwable o método e exigir trycath no metodo que chama
            */
            return false;
        }


        public List<Paciente> PacientesAgendados(DateTime dia)
        {
            List<Paciente> pacientes = new List<Paciente>();
            
            var agendamentosDia = agendamentos.FindAll(a => a.DiaAgendado.Date.CompareTo(dia.Date) == 0);
            
            if(agendamentosDia.Count != 0)
            {
                pacientes.Add   
            }
                
            /*

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
            */

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
