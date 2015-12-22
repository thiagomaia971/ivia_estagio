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
            Mock(agendamentos);
        }
        
        public List<Agendamento> receberAgendamentosPaciente(int protocolo)
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

        public bool registrarAgendamento(Agendamento agendamento)
        {

            if (repPaciente.PacienteExiste(agendamento.Protocolo))
            {
                /*
                essa verificação a baixo não deve ser feita aqui, pois deve ser feita antes
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


        public List<Paciente> pacientesAgendados(DateTime dia)
        {
            List<Paciente> pacientes = new List<Paciente>();
            
            var agendamentosDia = agendamentos.FindAll(a => a.DiaAgendado.Date.CompareTo(dia.Date) == 0);
            
            foreach( var a in agendamentosDia)
            {
                if (!pacientes.Exists(p => p.Protocolo == a.Protocolo))
                {
                    pacientes.Add(repPaciente.ReceberPaciente(a.Protocolo));   
                }
            }            

            return pacientes;
        }

        public int quantidadePacientesAgendados(DateTime dia)
        {
            return pacientesAgendados(dia).Count;
        }

        
       /* public List<Paciente> PacientesAgendadosPeloTipo(EnumTipoDeTratamento tipoDeTratamento)
        {
            /*
            esse método eu acredito que não faz sentido na nossa aplicação. 
            Porquê deve existir um método que retorna 
            toooooodos os pacientes de um tipo? alguma contabilidade?
            

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
    */
        
        private void Mock(List<Agendamento> agendamentos)
        {
            agendamentos.Add(new Agendamento(123948, DateTime.Now, EnumTipoDeTratamento.Procedimento));
            agendamentos.Add(new Agendamento(123948, DateTime.Now, EnumTipoDeTratamento.Intercorrencia));
            agendamentos.Add(new Agendamento(239847, DateTime.Now, EnumTipoDeTratamento.Procedimento));
            agendamentos.Add(new Agendamento(239848, DateTime.Now, EnumTipoDeTratamento.Procedimento));
            agendamentos.Add(new Agendamento(324579, DateTime.Now, EnumTipoDeTratamento.Procedimento));
            agendamentos.Add(new Agendamento(3485720, DateTime.Now, EnumTipoDeTratamento.Procedimento));
            agendamentos.Add(new Agendamento(3485720, DateTime.Now, EnumTipoDeTratamento.Intercorrencia));
        }

    }
}
