using DAO;
using Dominio.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.ViewModel
{
    public class PacienteViewModel
    {

        public List<Agendamento> ListaDeAgendamento { get; set; }
        public Agendamento SearchEntity { get; set; }
        public String NameOrProtocol { get; set; }

        public string EventCommand { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool isSearchAreaVisible { get; set; }

        public PacienteViewModel()
        {
            ListaDeAgendamento = new List<Agendamento>();
            SearchEntity = new Agendamento();

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
            if (isProtocol(NameOrProtocol))
            {
                SearchEntity.Paciente.Protocolo = NameOrProtocol;
            }
            else
            {
                SearchEntity.Paciente.Nome = NameOrProtocol;
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

                    break;

                case "pesquisar":

                    break;

                case "imprimir":

                    break;
            }
        }
    }
}