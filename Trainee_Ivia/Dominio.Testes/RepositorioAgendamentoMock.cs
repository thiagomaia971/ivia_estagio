using Dominio.Core.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Core.Entidades;

namespace Dominio.Testes
{
    class RepositorioAgendamentoMock : IRepositorioAgendamento
    {
        private List<Agendamento> lista;

        public RepositorioAgendamentoMock(IRepositorioPaciente repPacienteMock)
        {
            lista = new List<Agendamento>();
            Mock(repPacienteMock);
        }

        private void Mock(IRepositorioPaciente repPacienteMock)
        {
            var pacientes = repPacienteMock.obterPacientes();
            foreach (var paciente in pacientes)
            {
                if (paciente == pacientes.Last()) break;

                var data = DateTime.Today;
                data = data.AddDays(5);

                lista.Add(new Agendamento(paciente,data,ETipoDeTratamento.Quimioterapia_Dia));
            }
            lista.Add(new Agendamento(pacientes.Last(), 
                DateTime.Now.AddHours(2), ETipoDeTratamento.Quimioterapia_Dia));
        }

        public void incluirAgendamento(Agendamento agendamento)
        {
            if (agendamento == null) throw new ArgumentNullException("Agendamento");

            lista.Add(agendamento);
        }

        public List<Agendamento> obterAgendamentos(DateTime dia)
        {
            if (dia == null) throw new ArgumentNullException("Dia");

            var agendamentos = lista.FindAll(a => a.DiaDoAgendamento.Date.CompareTo(dia.Date)==0 );
            return agendamentos;
        }

        public List<Agendamento> obterAgendamentos(DateTime dia, ETipoDeTratamento tipo)
        {
            if (dia == null) throw new ArgumentNullException("dia");
            
            var agendamentos = lista.FindAll(a => a.DiaDoAgendamento == dia && a.TipoDeTratamento == tipo);
            return agendamentos;
        }

        public List<Agendamento> obterAgendamentos()
        {
            return lista.ToList();
        }

        public List<Agendamento> obterAgendamentos(string nome)
        {
            if (String.IsNullOrEmpty(nome))
            {
                throw new ArgumentNullException("nome");
            }
            return lista.FindAll(a => a.Paciente.Nome.Contains(nome));
        }

        public List<Agendamento> obterAgendamentos(string protocolo, DateTime dia)
        {
            if (String.IsNullOrEmpty(protocolo))
            {
                throw new ArgumentNullException("protocolo");
            }

            if (dia == null) throw new ArgumentNullException("dia");

            return lista.FindAll(a => a.Paciente.Protocolo.Equals(protocolo));
        }

        public List<Agendamento> obterAgendamentosPorProtocolo(string protocolo, DateTime dia)
        {
            throw new NotImplementedException();
        }

        public List<Agendamento> obterAgendamentosPorProtocolo(string protocolo)
        {
            throw new NotImplementedException();
        }
    }
}
