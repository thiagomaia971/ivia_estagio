using Dominio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Testes
{
    //Ok.
    public class RepositorioPaciente
    {
        //Context do Entity Framework
        private List<Paciente> Pacientes;

        public RepositorioPaciente()
        {
            /*
            substituir list por ctx e inicializa-lo
            */
            Pacientes = new List<Paciente>();
            Mock(Pacientes);
        }

        public List<Paciente> receberTodosPacientes()
        {
            //Recebe todos os Pacientes do Banco de Dados.
            //Pacientes = ctx.Pacientes.List();
            return Pacientes;
        }

        public Paciente receberPaciente(int Protocolo)
        {
            /*
            substituir o mock pelo contexto
            paciente = ctx.Pacientes.find.....            
            */           
            return Pacientes.Find(p => p.Protocolo == Protocolo);
        }

        public bool pacienteExiste(int Protocolo)
        {
            /*
            substituir mock por ctx
            */
            return Pacientes.Exists(p => p.Protocolo == Protocolo);
        }


        private void Mock(List<Paciente> Pacientes)
        {
            Pacientes.Add(new Paciente(123948, "Thiago"));
            Pacientes.Add(new Paciente(239847, "Daniel"));
            Pacientes.Add(new Paciente(239848, "Ricson"));
            Pacientes.Add(new Paciente(324579, "Ryan"));
            Pacientes.Add(new Paciente(3485720, "Antonio"));
            Pacientes.Add(new Paciente(128562, "Marcos"));
            Pacientes.Add(new Paciente(120250, "Antônia"));
            Pacientes.Add(new Paciente(000012, "Marcia"));
        }

    }
}
