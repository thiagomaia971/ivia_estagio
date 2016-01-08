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
        public String NameOrProtocol { get; set; }

        public string EventCommand { get; set; }
        public string Mode { get; set; }
        public bool isValid { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool isSearchAreaVisible { get; set; }
        public bool isOpcaoAgendamentoAreaVisible { get; set; }
        public bool isReagendamentoAreaVisible { get; set; }
        public Delegate handleRequest { get; set; }
        
        public AgendamentoViewModel()
        {
            ListaDeAgendamento = new List<Agendamento>();
            SearchEntity = new Agendamento();
            SearchEntity.Paciente = new Paciente();
            handleRequest = new Action(HandleRequest);

            Start();
        }

        private void Start()
        {
            EventCommand = "Lista";

            IsListAreaVisible = true;
            isSearchAreaVisible = true;
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

                case "opcao":
                    isOpcaoAgendamentoAreaVisible = true;
                    break;
            }
        }
    }
}