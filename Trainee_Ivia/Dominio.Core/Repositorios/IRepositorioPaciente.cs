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
        List<Paciente> obterPacientes(String nome);
        List<Paciente> obterPacientes();
    }
}
