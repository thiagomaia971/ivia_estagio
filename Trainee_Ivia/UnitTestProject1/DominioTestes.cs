using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Dominio.Core;

namespace Dominio.Testes
{
    [TestClass]
    public class DominioTestes
    {
        
        [TestMethod]
        public void Como_Atendente_Devo_Ser_Capaz_De_Verificar_A_Lista_De_Pacientes_Do_Dia_Atual()
        {

            //Arange
            RepositorioAgendamento repAgendamento;
            RepositorioPaciente repPaciente;
            var listaDePacientes = new List<Paciente>();

            //Act
            repPaciente = new RepositorioPaciente();
            repAgendamento = new RepositorioAgendamento(repPaciente);

            listaDePacientes.Add(new Paciente(123948, "Thiago"));
            listaDePacientes.Add(new Paciente(239847, "Daniel"));
            listaDePacientes.Add(new Paciente(239848, "Ricson"));
            listaDePacientes.Add(new Paciente(324579, "Ryan"));
            listaDePacientes.Add(new Paciente(3485720, "Antonio"));


            //Assert
            CollectionAssert.Equals(listaDePacientes, repAgendamento.pacientesAgendados(DateTime.Now));

        }

        [TestMethod]
        public void Como_Atendente_Devo_Ser_Capaz_De_Verificar_A_Lista_De_Pacientes_Do_Proximo_Dia()
        {

            //Arange
            RepositorioAgendamento repAgendamento;
            RepositorioPaciente repPaciente;
            var listaDePacientes = new List<Paciente>();
            var dia = DateTime.Now;

            //Act
            repPaciente = new RepositorioPaciente();
            repAgendamento = new RepositorioAgendamento(repPaciente);
            dia = dia.AddDays(1);

            listaDePacientes.Add(new Paciente(000012, "Marcia"));


            //Assert
            CollectionAssert.Equals(listaDePacientes, repAgendamento.pacientesAgendados(dia));

        }

        [TestMethod]
        public void Como_Atendente_Devo_Ser_Capaz_De_Verificar_A_Lista_De_Pacientes_Do_Dia_Anterior()
        {

            //Arange
            RepositorioAgendamento repAgendamento;
            RepositorioPaciente repPaciente;
            var listaDePacientes = new List<Paciente>();
            var dia = DateTime.Now;

            //Act
            repPaciente = new RepositorioPaciente();
            repAgendamento = new RepositorioAgendamento(repPaciente);
            dia = dia.AddDays(-1);

            listaDePacientes.Add(new Paciente(120250, "Antônia"));


            //Assert
            CollectionAssert.Equals(listaDePacientes, repAgendamento.pacientesAgendados(dia));

        }


        [TestMethod]
        public void Como_Atendente_Devo_Ser_Capaz_De_Registrar_Uma_Consulta_e_Verificar_Se_O_Mesmo_Paciente_Foi_Agendado()
        {

            //Arange
            RepositorioAgendamento repAgendamento;
            RepositorioPaciente repPaciente;
            DateTime diaConsulta = DateTime.Now;

            //Act
            repPaciente = new RepositorioPaciente();
            repAgendamento = new RepositorioAgendamento(repPaciente);


            diaConsulta = diaConsulta.AddDays(3);
            repAgendamento.registrarAgendamento(new Agendamento(123948, diaConsulta, EnumTipoDeTratamento.Intercorrencia));
            var TodosOsAgendamentos = repAgendamento.receberAgendamentosPaciente(123948);

            Agendamento UltimoAgendamento = TodosOsAgendamentos.Find(a => a.DiaAgendado.Date.CompareTo(diaConsulta.Date) == 0);


            //Assert
            Assert.AreEqual(UltimoAgendamento.DiaAgendado.Date, diaConsulta.Date);

        }

        [TestMethod]
       // [ExpectedException(typeof(ArgumentException))]
        public void Como_Atendente_Não_Posso_Registrar_Uma_Consulta_Para_Uma_Data_Passada()
        {

            //Arange
            RepositorioAgendamento repAgendamento;
            RepositorioPaciente repPaciente;
            DateTime diaConsulta = DateTime.Now;
            bool registroConsultaBoolean = false;

            //Act
            repPaciente = new RepositorioPaciente();
            repAgendamento = new RepositorioAgendamento(repPaciente);

            try
            {
                diaConsulta = diaConsulta.AddDays(-10);
                repAgendamento.registrarAgendamento(new Agendamento(123948, diaConsulta, EnumTipoDeTratamento.Intercorrencia));

            }
            catch (Exception e )
            {
                registroConsultaBoolean = true;
               // throw;
            }
            Assert.IsTrue(registroConsultaBoolean);

            //Assert

        }

        [TestMethod]
        public void Como_Atendente_Devo_Ser_Capaz_De_Registrar_Uma_Consulta_e_Verificar_Se_Tem_1_Paciente_Para_Ser_Atendido_No_Dia_Seguinte()
        {

            //Arange
            RepositorioAgendamento repAgendamento;
            RepositorioPaciente repPaciente;
            DateTime diaAtual = DateTime.Now;

            //Act
            repPaciente = new RepositorioPaciente();
            repAgendamento = new RepositorioAgendamento(repPaciente);

            diaAtual = diaAtual.AddHours(2);

            repAgendamento.registrarAgendamento(new Agendamento(123948, diaAtual, EnumTipoDeTratamento.Intercorrencia));

            diaAtual = diaAtual.AddDays(1);

            //Assert
            Assert.AreEqual(1, repAgendamento.quantidadePacientesAgendados(diaAtual));

        }

        [TestMethod]
        public void Como_Atendente_Devo_Ser_Capaz_De_Verificar_A_Lista_De_Pacientes_Pelo_TipoDeTratamento_QuimioterapiaDia()
        {

            //Arange
            RepositorioAgendamento repAgendamento;
            RepositorioPaciente repPaciente;
            var listaDePacientes = new List<Paciente>();

            //Act
            repPaciente = new RepositorioPaciente();
            repAgendamento = new RepositorioAgendamento(repPaciente);

            listaDePacientes.Add(new Paciente(120250, "Antônia"));

            //Assert
            CollectionAssert.Equals(listaDePacientes, repAgendamento.pacientesAgendadosPeloTipo(EnumTipoDeTratamento.Quimioterapia_Dia));

        }
        
    }
}
