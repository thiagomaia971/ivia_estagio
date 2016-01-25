using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Core.Entidades;
using Dominio.Core.Repositorios;

namespace DAO
{
    public class PacienteManager
    {

        IRepositorioPaciente repPaciente;
        Contexto contexto;

        public PacienteManager()
        {
            contexto = new Contexto();
            repPaciente = new RepositorioPaciente(contexto);
        }

        public List<Paciente> getPacientes(Paciente paciente)
        {
            List<Paciente> listPaciente = new List<Paciente>();

            if (!string.IsNullOrEmpty(paciente.Nome))
            {
                listPaciente = repPaciente.obterPacientes(paciente.Nome);
            }
            else if (!string.IsNullOrEmpty(paciente.Protocolo))
            {
                listPaciente.Add(repPaciente.obterPaciente(paciente.Protocolo));
            }

            return listPaciente;
        }
    }
}
