using Dominio.Core.Repositorios;
using Dominio.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class RepositorioPaciente : IRepositorioPaciente
    {
        private Contexto _ctx;

        public RepositorioPaciente(Contexto ctx)
        {
            _ctx = ctx;
        }

        public Paciente obterPaciente(string protocolo)
        {
            return _ctx.Pacientes.Where(p => p.Protocolo.Equals(protocolo)).First();
        }

        public IList<Paciente> obterPacientes()
        {
            return _ctx.Pacientes.ToList();
        }

        public IList<Paciente> obterPacientes(string nome)
        {
            return _ctx.Pacientes.Where(p => p.Nome.Contains(nome)).ToList();
        }
    }
}
