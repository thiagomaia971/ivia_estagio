using Dominio.Testes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core
{
    public class RepositorioAgendamento
    {

        private RepositorioPaciente repPaciente;

        private List<Agendamento> agendamentos;

        //Ok.
        public RepositorioAgendamento(RepositorioPaciente repPaciente)
        {
            if (repPaciente == null)
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

        public List<Agendamento> receberTodosAgendamentos()
        {
            return agendamentos;
        }

        //Ok.
        public List<Agendamento> receberAgendamentosPaciente(int protocolo)
        {
            if (repPaciente.pacienteExiste(protocolo))
            {
                if (agendamentos.Exists(p => p.Protocolo == protocolo))
                {
                    return agendamentos.FindAll(p => p.Protocolo == protocolo);
                }
                /*
                lembrar de verificar se o cliente foi encontrado sugiro exigir trycath e 
                gerar erro caso não encontre o paciente para tratamento e causar o mesmo erro 

                caso não vá gerar erro deve-se retornar lista vazia mesmo
                */

            }
            else
            {
                throw new ArgumentException("Paciênte não existe ou Protocolo errado!", "protocolo");
            }
            return null;
        }

        //Ok.
        public void registrarAgendamento(Agendamento agendamento)
        {

            if (repPaciente.pacienteExiste(agendamento.Protocolo))
            {
                /*
                essa verificação a baixo não deve ser feita aqui, pois deve ser feita antes
                temos aqui só o repositorio!! A única coisa a ser feita aqui é a verificação
                da existência do paciente*/

                DateTime diaAtual = DateTime.Now;
                if (agendamento.DiaAgendado.CompareTo(diaAtual) > 0)
                {
                    //Adicionar no Banco de Dados o agendamento.
                    agendamentos.Add(agendamento);
                    // return true;
                } else
                {
                    throw new ArgumentNullException("Data inválida!");

                }
            }
            /*
            prefiro tornar throwable o método e exigir trycath no metodo que chama
            */
            //return false;
        }

        //
        public List<Paciente> pacientesAgendados(DateTime dia)
        {
            var pacientes = new List<Paciente>();

            var agendamentosDia = agendamentos.FindAll(a => a.DiaAgendado.Date.CompareTo(dia.Date) == 0);

            foreach (var auxAgendamento in agendamentosDia)
            {
                pacientes.Add(repPaciente.receberPaciente(auxAgendamento.Protocolo));

            }

            /*foreach (var a in agendamentosDia)
            {
                if (pacientes.Exists(p => p.Protocolo == a.Protocolo))
                {
                    pacientes.Add(repPaciente.receberPaciente(a.Protocolo));
                }
            }*/

            return pacientes;
        }

        //Ok.
        public int quantidadePacientesAgendados(DateTime dia)
        {
            return pacientesAgendados(dia).Count;
        }


        public List<Paciente> pacientesAgendadosPeloTipo(EnumTipoDeTratamento tipoDeTratamento)
        {

            /*esse método eu acredito que não faz sentido na nossa aplicação. 
            Porquê deve existir um método que retorna 
            toooooodos os pacientes de um tipo? alguma contabilidade?
            */

            var PacientesAgendadosPeloTipo = new List<Paciente>();

            foreach (var auxAgendamento in agendamentos.FindAll(a => a.TipoDeTratamento == tipoDeTratamento))
            {
                PacientesAgendadosPeloTipo.Add(repPaciente.receberPaciente(auxAgendamento.Protocolo));

            }
            return PacientesAgendadosPeloTipo;
        }


        private void Mock(List<Agendamento> agendamentos)
        {
            var diaAtual = DateTime.Now;
            var proximoDia = diaAtual.AddDays(1);
            var diaAnterior = diaAtual.AddDays(-1);

            agendamentos.Add(new Agendamento(123948, DateTime.Now, EnumTipoDeTratamento.Procedimento));
            agendamentos.Add(new Agendamento(123948, DateTime.Now, EnumTipoDeTratamento.Intercorrencia));
            agendamentos.Add(new Agendamento(239847, DateTime.Now, EnumTipoDeTratamento.Procedimento));
            agendamentos.Add(new Agendamento(239848, DateTime.Now, EnumTipoDeTratamento.Procedimento));
            agendamentos.Add(new Agendamento(324579, DateTime.Now, EnumTipoDeTratamento.Procedimento));
            agendamentos.Add(new Agendamento(3485720, DateTime.Now, EnumTipoDeTratamento.Procedimento));
            agendamentos.Add(new Agendamento(3485720, DateTime.Now, EnumTipoDeTratamento.Intercorrencia));
            agendamentos.Add(new Agendamento(000012, proximoDia, EnumTipoDeTratamento.Procedimento));
            agendamentos.Add(new Agendamento(120250, diaAnterior, EnumTipoDeTratamento.Quimioterapia_Dia));


        }

    }
}
