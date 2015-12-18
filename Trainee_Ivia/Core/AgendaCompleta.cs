//using System;
//using System.Collections.Generic;

//namespace Core
//{
//    public class AgendaCompleta
//    {
//        private List<Paciente> ListaDeTodosOsPacientes { get; set; }


//        public AgendaCompleta()
//        {
//            ListaDeTodosOsPacientes = new List<Paciente>();
//            Mock();
//        }

//        public void Mock()
//        {
//            //Adicionando Pacientes para teste(uma vez que as Atendentes não poderão adicionar novos pacientes).
//            ListaDeTodosOsPacientes.Add(new Paciente("Thiago", "Qt_Dia", new DateTime(2015, 12, 17)));
//            ListaDeTodosOsPacientes.Add(new Paciente("Daniel", "Qt_Dia", new DateTime(2015, 12, 17)));
//            ListaDeTodosOsPacientes.Add(new Paciente("Ricson", "Qt_Dia", new DateTime(2015, 12, 17)));
//            ListaDeTodosOsPacientes.Add(new Paciente("Ryan", "Qt_Dia", new DateTime(2015, 12, 18)));
//            ListaDeTodosOsPacientes.Add(new Paciente("Antonio", "Qt_Dia", new DateTime(2015, 12, 17)));
//            ListaDeTodosOsPacientes.Add(new Paciente("Random1", "Qt_Dia", new DateTime(2015, 12, 17)));
//            ListaDeTodosOsPacientes.Add(new Paciente("Random2", "Qt_Dia", new DateTime(2015, 12, 19)));
//        }


//        public Paciente GetPacientePeloNome(string NomePaciente)
//        {
//            Paciente paciente = new Paciente();

//            foreach (var auxPaciente in ListaDeTodosOsPacientes)
//            {
//                if (auxPaciente.Equals(NomePaciente))
//                {
//                    paciente = auxPaciente;
//                }
//            }

//            return paciente;
//        }

//        public List<Paciente> PacientesAgendados()
//        {
//            List<Paciente> pacientes = new List<Paciente>();

//            DateTime diaAtual = new DateTime();

//            foreach (var auxPaciente in ListaDeTodosOsPacientes)
//            {

//                if (auxPaciente.getDiaDaConsulta().Day == diaAtual.Day)
//                {
//                    pacientes.Add(auxPaciente);
//                }
//            }

//            return pacientes;
//        }


//        public List<Paciente> PacientesAgendados(DateTime dia)
//        {
//            List<Paciente> pacientes = new List<Paciente>();


//            foreach (var auxPaciente in ListaDeTodosOsPacientes)
//            {

//                if (auxPaciente.getDiaDaConsulta().Day == dia.Day && 
//                    auxPaciente.getDiaDaConsulta().Month == dia.Month && 
//                    auxPaciente.getDiaDaConsulta().Year == dia.Year)
//                {

//                    pacientes.Add(auxPaciente);

//                }
//            }

//            return pacientes;
//        }

//        internal List<Paciente> PacientesAgendadosPeloTipo(string tipoDeTratamento)
//        {
//            List<Paciente> PacientesAgendadosPeloTipo = new List<Paciente>();

//            foreach (var auxPaciente in ListaDeTodosOsPacientes)
//            {
//                if (auxPaciente.getTipoDeTratamento().Equals(tipoDeTratamento))
//                {
//                    PacientesAgendadosPeloTipo.Add(auxPaciente);
//                }
//            }

//            return PacientesAgendadosPeloTipo;
//        }

//        public void AtualizarLista()
//        {
//            //Recebe todos os pacientes do banco de dados e insere na Lista de novo, para atualizar.
            
//        }
//    }
//}