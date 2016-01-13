namespace DAO.Migrations
{
    using Dominio.Core.Entidades;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAO.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAO.Contexto context)
        {
            
            context.Pacientes.AddOrUpdate(
                new Paciente { Protocolo = "1", Nome = "joão" },
                new Paciente { Protocolo = "2", Nome = "rebeca" },
                new Paciente { Protocolo = "3", Nome = "roberto" },
                new Paciente { Protocolo = "4", Nome = "breno" },
                new Paciente { Protocolo = "5", Nome = "pedro" },
                new Paciente { Protocolo = "6", Nome = "jessica" },
                new Paciente { Protocolo = "7", Nome = "sara" },
                new Paciente { Protocolo = "8", Nome = "clara" },
                new Paciente { Protocolo = "9", Nome = "carlos alberto" },
                new Paciente { Protocolo = "10", Nome = "valfonso pereira" }
            );

            context.SaveChanges();

            var data = DateTime.Now.AddDays(5);
            
            context.Agendamentos.AddOrUpdate(
                new Agendamento { PacienteId = 1, DiaDoAgendamento = data, TipoDeTratamento = ETipoDeTratamento.Quimioterapia_Dia },
                new Agendamento { PacienteId = 2, DiaDoAgendamento = data, TipoDeTratamento = ETipoDeTratamento.Quimioterapia_Dia },
                new Agendamento { PacienteId = 3, DiaDoAgendamento = data, TipoDeTratamento = ETipoDeTratamento.Quimioterapia_Dia },
                new Agendamento { PacienteId = 4, DiaDoAgendamento = data, TipoDeTratamento = ETipoDeTratamento.Quimioterapia_Dia },
                new Agendamento { PacienteId = 5, DiaDoAgendamento = data, TipoDeTratamento = ETipoDeTratamento.Quimioterapia_Dia },
                new Agendamento { PacienteId = 6, DiaDoAgendamento = data, TipoDeTratamento = ETipoDeTratamento.Quimioterapia_Dia },
                new Agendamento { PacienteId = 7, DiaDoAgendamento = data, TipoDeTratamento = ETipoDeTratamento.Quimioterapia_Dia },
                new Agendamento { PacienteId = 8, DiaDoAgendamento = data, TipoDeTratamento = ETipoDeTratamento.Quimioterapia_Dia },
                new Agendamento { PacienteId = 9, DiaDoAgendamento = data, TipoDeTratamento = ETipoDeTratamento.Quimioterapia_Dia },
                new Agendamento { PacienteId = 10, DiaDoAgendamento = DateTime.Now.AddHours(2), TipoDeTratamento = ETipoDeTratamento.Quimioterapia_Dia }
            );

        }
    }
}
