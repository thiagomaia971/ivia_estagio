using Dominio.Core.Entidades;
using Dominio.Core.Repositorios;
using Dominio.Core.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AgendamentoManager
    {
        ServicoAgendamento servicoAgendamento;
        IRepositorioAgendamento repAgendamento;
        IRepositorioPaciente repPaciente;
        Contexto contexto;

        public AgendamentoManager()
        {
            contexto = new Contexto();
            repAgendamento = new RepositorioAgendamento(contexto);
            repPaciente = new RepositorioPaciente(contexto);
            servicoAgendamento = new ServicoAgendamento(repAgendamento, repPaciente);
            
        }

        public List<Agendamento> GetAgendamentos(Agendamento searchEntity)
        {
            if (searchEntity == null) throw new ArgumentNullException("searchEntity");
            List<Agendamento> listaAgendamento = new List<Agendamento>();
            if (searchEntity.DiaDoAgendamento != null && searchEntity.DiaDoAgendamento.Year != 1)
            {
                if (!String.IsNullOrEmpty(searchEntity.Paciente.Protocolo))
                {
                    listaAgendamento = repAgendamento.obterAgendamentosPorProtocolo(
                        searchEntity.Paciente.Protocolo, searchEntity.DiaDoAgendamento);
                }
                else
                {
                    listaAgendamento = repAgendamento.obterAgendamentos(searchEntity.DiaDoAgendamento);
                    if (!String.IsNullOrEmpty(searchEntity.Paciente.Nome))
                    {
                        listaAgendamento = listaAgendamento.FindAll(
                            a => a.Paciente.Nome.Contains(searchEntity.Paciente.Nome));
                    }

                }
            }
            else
            {
                if (!string.IsNullOrEmpty(searchEntity.Paciente.Nome))
                {
                    listaAgendamento = repAgendamento.obterAgendamentos(searchEntity.Paciente.Nome);
                }
                else if (!string.IsNullOrEmpty(searchEntity.Paciente.Protocolo))
                {
                    listaAgendamento = repAgendamento.obterAgendamentosPorProtocolo(searchEntity.Paciente.Protocolo);
                }
                else
                {
                    listaAgendamento = repAgendamento.obterAgendamentos();
                }
            }

            listaAgendamento.OrderByDescending(a => a.DiaDoAgendamento);

            return listaAgendamento;
        }

        public void AdicionarAgendamento(Agendamento agendamento)
        {
            if (agendamento == null)
            {
                throw new ArgumentNullException("agendamento");
            }
            else
            {
                if (agendamento.DiaDoAgendamento.CompareTo(DateTime.Now) > 0)
                {
                    servicoAgendamento.registrarAgendamento(agendamento);
                }
            }
        }
    }

}
