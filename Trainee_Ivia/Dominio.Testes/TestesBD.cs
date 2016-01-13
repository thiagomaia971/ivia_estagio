using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dominio.Core.Repositorios;
using Dominio.Core.Servicos;
using Dominio.Core.Entidades;
using DAO;

namespace Dominio.Testes
{
    [TestClass]
    public class TestesBD
    {
        [TestMethod]
        public void BD_ao_abrir_a_pagina_devo_ver_os_100_primeiros_agendamentos_mais_recentes()
        {
            //arrenge
            IRepositorioAgendamento repAgendamento;
            IRepositorioPaciente repPaciente;
            Contexto ctx;
            ServicoAgendamento servicoAgendamento;

            //act
            ctx = new Contexto();
            repPaciente = new RepositorioPaciente(ctx);
            repAgendamento = new RepositorioAgendamento(ctx);
            servicoAgendamento = new ServicoAgendamento(repAgendamento);

            var agendamentos = repAgendamento.obterAgendamentos();

            //assert
            Assert.IsTrue(100 == agendamentos.Count);
        }

        [TestMethod]
        public void BD_como_atendente_devo_registrar_um_agendamento()
        {
            //arrenge
            IRepositorioAgendamento repAgendamento;
            IRepositorioPaciente repPaciente;
            Contexto ctx;
            ServicoAgendamento servicoAgendamento;

            //act
            ctx = new Contexto();
            repPaciente = new RepositorioPaciente(ctx);
            repAgendamento = new RepositorioAgendamento(ctx);
            servicoAgendamento = new ServicoAgendamento(repAgendamento);

            var paciente = repPaciente.obterPaciente("1");
            var data = DateTime.Now.AddDays(5);
            var agendamento = new Agendamento(paciente,data, ETipoDeTratamento.Quimioterapia_Dia);
            var funfou = servicoAgendamento.registrarAgendamento(agendamento);

            //assert
            Assert.IsTrue(funfou);
        }

        [TestMethod]
        public void BD_como_atendente_devo_registrar_um_agendamento_e_obter_o_mesmo_agendamento()
        {
            //arrenge
            IRepositorioAgendamento repAgendamento;
            IRepositorioPaciente repPaciente;
            Contexto ctx;
            ServicoAgendamento servicoAgendamento;

            //act
            ctx = new Contexto();
            repPaciente = new RepositorioPaciente(ctx);
            repAgendamento = new RepositorioAgendamento(ctx);
            servicoAgendamento = new ServicoAgendamento(repAgendamento);

            var paciente = repPaciente.obterPaciente("1");
            var data = DateTime.Now;
            data = data.AddDays(5);
            var agendamento = new Agendamento(paciente, data, ETipoDeTratamento.Quimioterapia_Dia);
            var funfou = servicoAgendamento.registrarAgendamento(agendamento);

            //assert
            Assert.IsTrue(funfou);
            Assert.IsTrue(repAgendamento.obterAgendamentos().Contains(agendamento));
        }

        [TestMethod]
        public void BD_como_atendente_devo_obter_todos_agendamentos_pelo_dia()
        {
            //arrenge
            IRepositorioAgendamento repAgendamento;
            IRepositorioPaciente repPaciente;
            Contexto ctx;
            ServicoAgendamento servicoAgendamento;

            //act
            ctx = new Contexto();
            repPaciente = new RepositorioPaciente(ctx);
            repAgendamento = new RepositorioAgendamento(ctx);
            servicoAgendamento = new ServicoAgendamento(repAgendamento);

            var agendamentos = repAgendamento.obterAgendamentos(DateTime.Today.AddDays(5));

            //assert
            Assert.IsNotNull(agendamentos);
        }

        [TestMethod]
        public void BD_como_atendente_devo_obter_todos_agendamentos_do_dia_atual()
        {
            //arrenge
            IRepositorioAgendamento repAgendamento;
            IRepositorioPaciente repPaciente;
            Contexto ctx;
            ServicoAgendamento servicoAgendamento;

            //act
            ctx = new Contexto();
            repPaciente = new RepositorioPaciente(ctx);
            repAgendamento = new RepositorioAgendamento(ctx);
            servicoAgendamento = new ServicoAgendamento(repAgendamento);

            var agendamentos = repAgendamento.obterAgendamentos(DateTime.Today);

            //assert
            Assert.AreEqual(DateTime.Today.Day, agendamentos[0].DiaDoAgendamento.Day);
        }
        [TestMethod]
        public void BD_como_atendente_devo_obter_todos_agendamentos_do_para_daqui_a_5_dias()
        {
            //arrenge
            IRepositorioAgendamento repAgendamento;
            IRepositorioPaciente repPaciente;
            Contexto ctx;
            ServicoAgendamento servicoAgendamento;

            //act
            ctx = new Contexto();
            repPaciente = new RepositorioPaciente(ctx);
            repAgendamento = new RepositorioAgendamento(ctx);
            servicoAgendamento = new ServicoAgendamento(repAgendamento);

            var agendamentos = repAgendamento.obterAgendamentos(DateTime.Today.AddDays(5));

            //assert
            Assert.AreEqual(DateTime.Today.AddDays(5).Day, agendamentos[0].DiaDoAgendamento.Day);
        }
        [TestMethod]
        public void BD_como_atendente_devo_obter_todos_agendamentos_do_para_daqui_a_5_dias_por_qmtDia()
        {
            //arrenge
            IRepositorioAgendamento repAgendamento;
            IRepositorioPaciente repPaciente;
            Contexto ctx;
            ServicoAgendamento servicoAgendamento;

            //act
            ctx = new Contexto();
            repPaciente = new RepositorioPaciente(ctx);
            repAgendamento = new RepositorioAgendamento(ctx);
            servicoAgendamento = new ServicoAgendamento(repAgendamento);

            var agendamentos = repAgendamento.obterAgendamentos
                (DateTime.Today.AddDays(5),ETipoDeTratamento.Quimioterapia_Dia);

            //assert
            Assert.IsTrue(agendamentos.Count > 0);
        }
        [TestMethod]
        public void BD_como_atendente_devo_obter_o_paciente_pedro_pelo_nome()
        {
            //arrenge
            IRepositorioAgendamento repAgendamento;
            IRepositorioPaciente repPaciente;
            Contexto ctx;
            ServicoAgendamento servicoAgendamento;

            //act
            ctx = new Contexto();
            repPaciente = new RepositorioPaciente(ctx);
            repAgendamento = new RepositorioAgendamento(ctx);
            servicoAgendamento = new ServicoAgendamento(repAgendamento);

            var pacientes = repPaciente.obterPacientes("pedro");

            //assert
            Assert.AreEqual(1, pacientes.Count);
        }

    }
}
