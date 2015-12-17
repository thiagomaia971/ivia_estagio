using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Como_Atendente_Devo_Ser_Capaz_De_Imprimir_O_Relatório_Quimioterapia_Dia()
        {

            //Arange

            Atendente atendente = new Atendente();
            bool resultadoDaImpressao = false;

            //Act

            resultadoDaImpressao = atendente.ImprimirRelatorioPeloTipo("Quimioterapia Dia");

            //Assert

            Assert.IsTrue(resultadoDaImpressao);

        }

        [TestMethod]
        public void Como_Atendente_Devo_Ser_Capaz_De_Registrar_Um_Agendamento_Ou_Retorno()
        {

            //Arange

            Atendente atendente = new Atendente();

            Paciente paciente = new Paciente();

            bool resultadoDoRegistro = false;

            //Act

            paciente = atendente.GetPacientePeloNome("Thiago");

            resultadoDoRegistro = atendente.RegistrarAgendamento(paciente, new DateTime(2015, 12, 17, 14, 0, 0));

            //Assert

            Assert.IsTrue(resultadoDoRegistro);

        }

        [TestMethod]
        public void Como_Atendente_Devo_Ser_Capaz_De_Consultar_Os_Pacientes_Que_Foram_Agendados_Para_Determinado_Dia()
        {

            //Arange

            Atendente atendente = new Atendente();

            DateTime DiaQueAAtendenteQuerConsultar = new DateTime(2015, 12, 17);

            List<Paciente> pacientes = new List<Paciente>();
            List<Paciente> pacientesEsperado = new List<Paciente>();

            //Act

            pacientesEsperado.Add(new Paciente("Thiago", "Qt_Dia", new DateTime(2015, 12, 17)));
            pacientesEsperado.Add(new Paciente("Daniel", "Qt_Dia", new DateTime(2015, 12, 17)));
            pacientesEsperado.Add(new Paciente("Ricson", "Qt_Dia", new DateTime(2015, 12, 17)));
            pacientesEsperado.Add(new Paciente("Antonio", "Qt_Dia", new DateTime(2015, 12, 17)));
            pacientesEsperado.Add(new Paciente("Random1", "Qt_Dia", new DateTime(2015, 12, 17)));

            pacientes = atendente.ConsultarPacientesAgendados(DiaQueAAtendenteQuerConsultar);

            //Assert

            CollectionAssert.Equals(pacientesEsperado, pacientes);
            
        }

        [TestMethod]
        public void Como_Atendente_Devo_Ser_Capaz_De_Consultar_Todos_Os_Agendamentos_De_Um_Paciente()
        {

            //Arange

            Atendente atendente = new Atendente();

            Paciente paciente = new Paciente();

            List<DateTime> ListaEsperada = new List<DateTime>();
            List<DateTime> TodasConsultasDoPaciente = new List<DateTime>();

            //Act

            paciente = atendente.GetPacientePeloNome("Thiago");
            TodasConsultasDoPaciente = paciente.getListaDeConsultas();

            ListaEsperada.Add(new DateTime(2015, 11, 01));
            ListaEsperada.Add(new DateTime(2015, 11, 07));
            ListaEsperada.Add(new DateTime(2015, 11, 08));
            ListaEsperada.Add(new DateTime(2015, 11, 09));
            ListaEsperada.Add(new DateTime(2015, 11, 13));
            ListaEsperada.Add(new DateTime(2015, 11, 17));
            ListaEsperada.Add(new DateTime(2015, 12, 16));
            ListaEsperada.Add(new DateTime(2015, 11, 17));

            //Assert

            CollectionAssert.Equals(ListaEsperada, TodasConsultasDoPaciente);

        }

    }
}
