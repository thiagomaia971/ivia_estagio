using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio.Core.Repositorios;
using Dominio.Core.Servicos;
using Dominio.Core.Entidades;

namespace Dominio.Testes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void como_atendente_devo_registrar_um_agendamento()
        {
            //arrenge
            IRepositorioAgendamento repAgendamento;
            IRepositorioPaciente repPaciente;
            ServicoAgendamento servicoAgendamento;
            //act
            repPaciente = new RepositorioPacienteMock();
            repAgendamento = new RepositorioAgendamentoMock(repPaciente);
            servicoAgendamento = new ServicoAgendamento(repPaciente, repAgendamento);

            var paciente = repPaciente.obterPaciente("1");
            var data = DateTime.Now;
            data = data.AddDays(5);
            var agendamento = new Agendamento(paciente,data, ETipoDeTratamento.quimioterapiaDia);
            var funfou = servicoAgendamento.registrarAgendamento(agendamento);

            //assert
            Assert.IsTrue(funfou);
        }
        [TestMethod]
        public void como_atendente_devo_registrar_um_agendamento_e_obter_o_mesmo_agendamento()
        {
            //arrenge
            IRepositorioAgendamento repAgendamento;
            IRepositorioPaciente repPaciente;
            ServicoAgendamento servicoAgendamento;
            //act
            repPaciente = new RepositorioPacienteMock();
            repAgendamento = new RepositorioAgendamentoMock(repPaciente);
            servicoAgendamento = new ServicoAgendamento(repPaciente, repAgendamento);

            var paciente = repPaciente.obterPaciente("1");
            var data = DateTime.Now;
            data = data.AddDays(5);
            var agendamento = new Agendamento(paciente, data, ETipoDeTratamento.quimioterapiaDia);
            var funfou = servicoAgendamento.registrarAgendamento(agendamento);

            //assert
            Assert.IsTrue(funfou);
            Assert.IsTrue(repAgendamento.obterAgendamentos().Contains(agendamento));
        }

        [TestMethod]
        public void como_atendente_devo_obter_todos_agendamentos_pelo_dia()
        {
            //arrenge
            IRepositorioAgendamento repAgendamento;
            IRepositorioPaciente repPaciente;
            ServicoAgendamento servicoAgendamento;
            //act
            repPaciente = new RepositorioPacienteMock();
            repAgendamento = new RepositorioAgendamentoMock(repPaciente);
            servicoAgendamento = new ServicoAgendamento(repPaciente, repAgendamento);

            var agendamentos = repAgendamento.obterAgendamentos(DateTime.Today.AddDays(5));

            //assert
            Assert.IsNotNull(agendamentos);
        }

        [TestMethod]
        public void como_atendente_devo_obter_todos_agendamentos_do_dia_atual()
        {
            //arrenge
            IRepositorioAgendamento repAgendamento;
            IRepositorioPaciente repPaciente;
            ServicoAgendamento servicoAgendamento;
            //act
            repPaciente = new RepositorioPacienteMock();
            repAgendamento = new RepositorioAgendamentoMock(repPaciente);
            servicoAgendamento = new ServicoAgendamento(repPaciente, repAgendamento);

            var agendamentos = repAgendamento.obterAgendamentos(DateTime.Today);

            //assert
            Assert.AreEqual(DateTime.Today.Day, agendamentos[0].DiaDoAgendamento.Day);
        }
        [TestMethod]
        public void como_atendente_devo_obter_todos_agendamentos_do_para_daqui_a_5_dias()
        {
            //arrenge
            IRepositorioAgendamento repAgendamento;
            IRepositorioPaciente repPaciente;
            ServicoAgendamento servicoAgendamento;
            //act
            repPaciente = new RepositorioPacienteMock();
            repAgendamento = new RepositorioAgendamentoMock(repPaciente);
            servicoAgendamento = new ServicoAgendamento(repPaciente, repAgendamento);

            var agendamentos = repAgendamento.obterAgendamentos(DateTime.Today.AddDays(5));

            //assert
            Assert.AreEqual(DateTime.Today.AddDays(5).Day, agendamentos[0].DiaDoAgendamento.Day);
        }
        [TestMethod]
        public void como_atendente_devo_obter_todos_agendamentos_do_para_daqui_a_5_dias_por_qmtDia()
        {
            //arrenge
            IRepositorioAgendamento repAgendamento;
            IRepositorioPaciente repPaciente;
            ServicoAgendamento servicoAgendamento;
            //act
            repPaciente = new RepositorioPacienteMock();
            repAgendamento = new RepositorioAgendamentoMock(repPaciente);
            servicoAgendamento = new ServicoAgendamento(repPaciente, repAgendamento);

            var agendamentos = repAgendamento.obterAgendamentos
                (DateTime.Today.AddDays(5),ETipoDeTratamento.quimioterapiaDia);

            //assert
            Assert.AreEqual(9,agendamentos.Count);
        }
        [TestMethod]
        public void como_atendente_devo_obter_o_paciente_pedro_pelo_nome()
        {
            //arrenge
            IRepositorioAgendamento repAgendamento;
            IRepositorioPaciente repPaciente;
            ServicoAgendamento servicoAgendamento;
            //act
            repPaciente = new RepositorioPacienteMock();
            repAgendamento = new RepositorioAgendamentoMock(repPaciente);
            servicoAgendamento = new ServicoAgendamento(repPaciente, repAgendamento);

            var pacientes = repPaciente.obterPacientes("pedro");

            //assert
            Assert.AreEqual(1, pacientes.Count);
        }

    }
}
