using Dominio.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core.Repositorios
{
    public interface IRepositorioPaciente
    {
        Paciente obterPaciente(String protocolo);
        IList<Paciente> obterPacientes(String nome);
        IList<Paciente> obterPacientes();
    }
}
