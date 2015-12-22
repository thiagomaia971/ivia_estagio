﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
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

        public List<Paciente> ReceberTodosPacientes()
        {
            //Recebe todos os Pacientes do Banco de Dados.
            //Pacientes = ctx.Pacientes.List();
            return Pacientes;
        }

        public Paciente ReceberPaciente(int Protocolo)
        {
            /*
            substituir o mock pelo contexto
            paciente = ctx.Pacientes.find.....            
            */           
            return Pacientes.Find(p => p.Protocolo == Protocolo);
        }

        public bool PacienteExiste(int Protocolo)
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
        }

    }
}
