using DAO;
using Dominio.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ViewModel
{
    public class AgendamentoViewModel
    {

        public List<Agendamento> ListaDeAgendamento { get; set; }
        public Agendamento SearchEntity { get; set; }
        public Agendamento NovoAgendamento { get; set; }
        public Agendamento AtualizarAgendamento { get; set; }
        public String NameOrProtocol { get; set; }
        public int statusAtualizarAgendamento { get; set; }

        public string EventCommand { get; set; }
        public string Mode { get; set; }
        public bool isValid { get; set; }
        public bool IsListMode { get; set; }
        public bool IsAgendamentoMode { get; set; }

        public AgendamentoViewModel()
        {
            ListaDeAgendamento = new List<Agendamento>();
            SearchEntity = new Agendamento();
            NovoAgendamento = new Agendamento();
            NovoAgendamento.DiaDoAgendamento = new DateTime();
            AtualizarAgendamento = new Agendamento();
            AtualizarAgendamento.DiaDoAgendamento = new DateTime();
            AtualizarAgendamento.Paciente = new Paciente();
            SearchEntity.Paciente = new Paciente();

            Start();
        }

        private void Start()
        {
            EventCommand = "Lista";

            isValid = true;
        }

        public void GetAgendamentos()
        {
            if (!String.IsNullOrEmpty(NameOrProtocol))
            {
                if (isProtocol(NameOrProtocol))
                {
                    SearchEntity.Paciente.Protocolo = NameOrProtocol;
                }
                else
                {
                    SearchEntity.Paciente.Nome = NameOrProtocol;
                }
            }
            AgendamentoManager agendamentoManager = new AgendamentoManager();
            ListaDeAgendamento = agendamentoManager.GetAgendamentos(SearchEntity);
        }

        private bool isProtocol(String np)
        {
            foreach(char letra in np)
            {
                int i = Convert.ToInt32(letra);

                if (i <= 57 && i >= 48) return true;
                    
            }

            return false;
        }

        public void HandleRequest()
        {
            Console.WriteLine(EventCommand);
            switch (EventCommand.ToLower())
            {
                case "lista":
                case "pesquisar":
                    GetAgendamentos();

                    break;

                case "imprimir":

                    break;

                case "salvar":
                    salvarAgendamento();
                    break;

                case "reagendar":
                case "cancelar":
                    AtualizarStatus();
                    break;                    
            }
        }

        private void AtualizarStatus()
        {
            AgendamentoManager agendamentoManager = new AgendamentoManager();

            Agendamento agendamentoAtualizado = agendamentoManager.getAgendamento(AtualizarAgendamento);
            switch (statusAtualizarAgendamento)
            {
                case 0:
                    agendamentoAtualizado.Status = EStatusDeAgendamento.Opcao;
                    break;

                case 1:
                    agendamentoAtualizado.Status = EStatusDeAgendamento.Normal;
                    break;

                case 2:
                    agendamentoAtualizado.Status = EStatusDeAgendamento.Cancelado;
                    break;

                case 3:
                    agendamentoAtualizado.Status = EStatusDeAgendamento.Faltado;
                    break;

                case 4:
                    agendamentoAtualizado.Status = EStatusDeAgendamento.Realizado;
                    break;
            }

            agendamentoManager.setStatus(agendamentoAtualizado);
            GetAgendamentos();
        }

        private void salvarAgendamento()
        {
            if (isValid)
            {
                AgendamentoManager agendamentoManager = new AgendamentoManager();
                agendamentoManager.AdicionarAgendamento(NovoAgendamento);
            }
            GetAgendamentos();
        }
    }
}