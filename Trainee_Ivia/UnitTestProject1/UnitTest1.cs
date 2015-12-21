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
        public void Como_Atendente_Devo_Ser_Capaz_De_Verificar_Se_Tem_3_Pacientes_Para_Serem_Atendidos_No_Dia_Atual()
        {

            //Arange
            RepositorioAgendamento repAgendamento;
            RepositorioPaciente repPaciente;

            //Act
            repPaciente = new RepositorioPaciente();
            repAgendamento = new RepositorioAgendamento(repPaciente);

            //Assert
            Assert.AreEqual(3, repAgendamento.QuantidadeDePacientesAgendados(DateTime.Today));

        }

        [TestMethod]
        public void Como_Atendente_Devo_Ser_Capaz_De_Verificar_Se_Tem_0_Pacientes_Para_Serem_Atendidos_No_Dia_Atual()
        {

            //Arange
            RepositorioAgendamento repAgendamento;
            RepositorioPaciente repPaciente;

            //Act
            repPaciente = new RepositorioPaciente();
            repAgendamento = new RepositorioAgendamento(repPaciente);

            //Assert
            Assert.AreEqual(0, repAgendamento.QuantidadeDePacientesAgendados(DateTime.Today));

        }

        [TestMethod]
        public void Como_Atendente_Devo_Ser_Capaz_De_Registrar_Uma_Consulta_e_Verificar_Se_Tem_1_Paciente_Para_Ser_Atendido_No_Dia_Da_Consulta_Registrada()
        {

            //Arange
            RepositorioAgendamento repAgendamento;
            RepositorioPaciente repPaciente;
            DateTime diaConsulta = DateTime.Now;

            //Act
            repPaciente = new RepositorioPaciente();
            repAgendamento = new RepositorioAgendamento(repPaciente);

            diaConsulta = diaConsulta.AddHours(3);
            repAgendamento.RegistrarAgendamento(new Agendamento(123948, diaConsulta, EnumTipoDeTratamento.Intercorrencia));

            //Assert
            Assert.AreEqual(1, repAgendamento.QuantidadeDePacientesAgendados(DateTime.Today));

        }

        [TestMethod]
        public void Como_Atendente_Não_Posso_Registrar_Uma_Consulta_Para_Uma_Data_Passada()
        {

            //Arange
            RepositorioAgendamento repAgendamento;
            RepositorioPaciente repPaciente;
            DateTime diaConsulta = DateTime.Now;
            bool registroConsultaBoolean;

            //Act
            repPaciente = new RepositorioPaciente();
            repAgendamento = new RepositorioAgendamento(repPaciente);

            diaConsulta = diaConsulta.AddDays(-10);
            registroConsultaBoolean = repAgendamento.RegistrarAgendamento(new Agendamento(123948, diaConsulta, EnumTipoDeTratamento.Intercorrencia));

            //Assert
            Assert.IsFalse(registroConsultaBoolean);

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

            repAgendamento.RegistrarAgendamento(new Agendamento(123948, diaAtual, EnumTipoDeTratamento.Intercorrencia));

            diaAtual = diaAtual.AddDays(1);

            //Assert
            Assert.AreEqual(1, repAgendamento.QuantidadeDePacientesAgendados(diaAtual));

        }

        [TestMethod]
        public void Como_Atendente_Devo_Ser_Capaz_De_Registrar_Uma_Consulta_e_Verificar_Se_Tem_1_Paciente_Para_Ser_Atendido_Pelo_Tipo_Quimioterapia_Dia()
        {

            //Arange
            RepositorioAgendamento repAgendamento;
            RepositorioPaciente repPaciente;
            DateTime diaAtual = DateTime.Now;

            //Act
            repPaciente = new RepositorioPaciente();
            repAgendamento = new RepositorioAgendamento(repPaciente);

            diaAtual = diaAtual.AddHours(2);
            repAgendamento.RegistrarAgendamento(new Agendamento(123948, diaAtual, EnumTipoDeTratamento.Quimioterapia_Dia));

            //Assert
            List<Paciente> p = repAgendamento.PacientesAgendadosPeloTipo(EnumTipoDeTratamento.Quimioterapia_Dia);
            int cont = 0;
            foreach (var item in p)
            {
                cont++;
            }

            Assert.AreEqual(1, cont);

        }

        /*[TestMethod]
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

        }*/

    }
}
