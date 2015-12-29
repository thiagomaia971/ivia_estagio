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

        public IList<Agendamento> obterAgendamentos()
        {
            return _ctx.Agendamentos.ToList<Agendamento>();
        }

        public IList<Agendamento> obterAgendamentos(DateTime dia)
        {
            if (dia == null) throw new ArgumentNullException("Dia");

            return _ctx.Agendamentos.Where<Agendamento>(
                a => a.DiaDoAgendamento.Date.CompareTo(dia.Date) == 0).ToList<Agendamento>();
        }

        public IList<Agendamento> obterAgendamentos(DateTime dia, ETipoDeTratamento tipo)
        {
            if (dia == null) throw new ArgumentNullException("dia");

            return _ctx.Agendamentos.Where<Agendamento>(
                a => a.DiaDoAgendamento == dia && a.TipoDeTratamento == tipo).ToList<Agendamento>();
        }
    }
}
