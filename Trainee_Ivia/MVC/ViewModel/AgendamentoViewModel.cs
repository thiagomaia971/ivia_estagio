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

        public AgendamentoViewModel()
        {
            ListaDeAgendamento = new List<Agendamento>();
            SearchEntity = new Agendamento();
            SearchEntity.Paciente = new Paciente();

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
            foreach(var letra in np)
            {
                int n;
                if(int.TryParse(""+letra, out n))
                {
                    return true;
                }
            }

            return false;
        }

        public void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "lista":
                case "pesquisar":
                    GetAgendamentos();

                    break;

                case "imprimir":

                    break;
            }
        }
    }
}