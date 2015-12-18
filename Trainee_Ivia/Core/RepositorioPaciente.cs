using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class RepositorioPaciente
    {
        //Context do Entity Framework
        List<Paciente> Pacientes = new List<Paciente>();

        public List<Paciente> ReceberTodosPacientes()
        {
            //Recebe todos os Pacientes do Banco de Dados.
            //Pacientes = ctx.Pacientes.List();
            if (Pacientes.Count == 0)
            {
                Mock(Pacientes);
            }

            return Pacientes;
        }

        public Paciente ReceberPacientePeloProtocolo(int Protocolo)
        {

            Paciente Paciente = new Paciente();
            List<Paciente> TodosPacientes = ReceberTodosPacientes();

            if (PacienteExiste(Protocolo))
            {
                foreach (var auxPaciente in TodosPacientes)
                {
                    if (auxPaciente.getProtocolo() == Protocolo)
                    {
                        Paciente = auxPaciente;
                    }
                }
            }

            return Paciente;
        }

        public bool PacienteExiste(int Protocolo)
        {
            foreach (var auxPaciente in ReceberTodosPacientes())
            {
                if (auxPaciente.getProtocolo() == Protocolo)
                {
                    return true;
                }
            }

            return false;
        }
        private void Mock(List<Paciente> Pacientes)
        {

            Pacientes.Add(new Paciente(123948, "Thiago"));
            Pacientes.Add(new Paciente(239847, "Daniel"));
            Pacientes.Add(new Paciente(23984, "Ricson"));
            Pacientes.Add(new Paciente(3245793, "Ryan"));
            Pacientes.Add(new Paciente(34857, "Antonio"));

        }

    }
}
