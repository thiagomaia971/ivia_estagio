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
            if (String.IsNullOrEmpty(protocolo))
            {
                throw new ArgumentNullException("protocolo");
            }
            return _ctx.Pacientes.Where(p => p.Protocolo.Contains(protocolo)).First();
        }

        public List<Paciente> obterPacientes()
        {
            return _ctx.Pacientes.Take(100).ToList();
        }

        public List<Paciente> obterPacientes(string nome)
        {
            if (String.IsNullOrEmpty(nome))
            {
                throw new ArgumentNullException("nome");
            }
            return _ctx.Pacientes.Where(p => p.Nome.Contains(nome)).ToList();
        }
    }
}
