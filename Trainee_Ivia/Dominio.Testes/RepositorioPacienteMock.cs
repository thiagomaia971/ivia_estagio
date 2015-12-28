using Dominio.Core.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Core.Entidades;

namespace Dominio.Testes
{
    class RepositorioPacienteMock : IRepositorioPaciente
    {
        private List<Paciente> lista;

        public RepositorioPacienteMock()
        {
            lista = new List<Paciente>();
            Mock();
        }

        private void Mock()
        {
            lista.Add(new Paciente("2", "rebeca"));
            lista.Add(new Paciente("3", "roberto"));
            lista.Add(new Paciente("1","joão"));
            lista.Add(new Paciente("4", "breno"));
            lista.Add(new Paciente("5", "pedro"));
            lista.Add(new Paciente("6", "jessica"));
            lista.Add(new Paciente("7", "sara"));
            lista.Add(new Paciente("8", "clara"));
            lista.Add(new Paciente("9", "carlos alberto"));
            lista.Add(new Paciente("10", "valfonso pereira"));
        }

        public Paciente obterPaciente(string protocolo)
        {
            return lista.Find(p => p.Protocolo.Equals(protocolo));
        }

        public IList<Paciente> obterPacientes()
        {
            return lista.ToList<Paciente>();
        }

        public IList<Paciente> obterPacientes(string nome)
        {
            return lista.FindAll(p => p.Nome.Equals(nome));
        }
    }
}
