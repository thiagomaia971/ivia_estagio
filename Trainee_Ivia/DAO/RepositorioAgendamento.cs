using Dominio.Core.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Core.Entidades;

namespace DAO
{
    public class RepositorioAgendamento : IRepositorioAgendamento
    {
        private Contexto _ctx;

        public RepositorioAgendamento(Contexto ctx)
        {
            _ctx = ctx;
        }

        public void incluirAgendamento(Agendamento agendamento)
        {
            if (agendamento == null) throw new ArgumentNullException("Agendamento");

            _ctx.Agendamentos.Add(agendamento);
            _ctx.SaveChanges();
        }

        public List<Agendamento> obterAgendamentos()
        {   
            return _ctx.Agendamentos.OrderByDescending(a => a.DiaDoAgendamento).Take(100).ToList();
        }

        public List<Agendamento> obterAgendamentos(string nome)
        {
            if (String.IsNullOrEmpty(nome))
            {
                throw new ArgumentNullException("nome");
            }
            return _ctx.Agendamentos.Where(a => a.Paciente.Nome.Contains(nome)).ToList();

        }

        public List<Agendamento> obterAgendamentos(DateTime dia)
        {
            if (dia == null) throw new ArgumentNullException("Dia");

            var data = dia.Date;

            return _ctx.Agendamentos.Where<Agendamento>(
                a => a.DiaDoAgendamento.Day == dia.Day
                 && a.DiaDoAgendamento.Month == dia.Month
                 && a.DiaDoAgendamento.Year == dia.Year).ToList();
            //a => a.DiaDoAgendamento.Date.CompareTo(data) == 0).ToList<Agendamento>();
        }

        public List<Agendamento> obterAgendamentos(string protocolo, DateTime dia)
        {
            if (String.IsNullOrEmpty(protocolo))
            {
                throw new ArgumentNullException("protocolo");
            }

            if (dia == null) throw new ArgumentNullException("dia");

            return _ctx.Agendamentos.Where(a => a.Paciente.Protocolo.Equals(protocolo)
                && a.DiaDoAgendamento.Day == dia.Day
                && a.DiaDoAgendamento.Month == dia.Month
                && a.DiaDoAgendamento.Year == dia.Year
            ).ToList();
        }

        public List<Agendamento> obterAgendamentos(DateTime dia, ETipoDeTratamento tipo)
        {
            if (dia == null) throw new ArgumentNullException("dia");

            return _ctx.Agendamentos.Where<Agendamento>(
                a => a.DiaDoAgendamento.Day == dia.Day
                 && a.DiaDoAgendamento.Month == dia.Month
                 && a.DiaDoAgendamento.Year == dia.Year
                 && a.TipoDeTratamento == tipo).ToList<Agendamento>();
        }
    }
}
