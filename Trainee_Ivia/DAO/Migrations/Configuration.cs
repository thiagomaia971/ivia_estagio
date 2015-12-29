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
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Pacientes.AddOrUpdate(p => p.Nome,
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
            var pacientes = context.Pacientes.ToList();
            
            context.Agendamentos.AddOrUpdate(p => p.DiaDoAgendamento,
                new Agendamento { PacienteId = pacientes[0].Id, DiaDoAgendamento = data, TipoDeTratamento = ETipoDeTratamento.quimioterapiaDia },
                new Agendamento { PacienteId = pacientes[1].Id, DiaDoAgendamento = data, TipoDeTratamento = ETipoDeTratamento.quimioterapiaDia },
                new Agendamento { PacienteId = pacientes[2].Id, DiaDoAgendamento = data, TipoDeTratamento = ETipoDeTratamento.quimioterapiaDia },
                new Agendamento { PacienteId = pacientes[3].Id, DiaDoAgendamento = data, TipoDeTratamento = ETipoDeTratamento.quimioterapiaDia },
                new Agendamento { PacienteId = pacientes[4].Id, DiaDoAgendamento = data, TipoDeTratamento = ETipoDeTratamento.quimioterapiaDia },
                new Agendamento { PacienteId = pacientes[5].Id, DiaDoAgendamento = data, TipoDeTratamento = ETipoDeTratamento.quimioterapiaDia },
                new Agendamento { PacienteId = pacientes[6].Id, DiaDoAgendamento = data, TipoDeTratamento = ETipoDeTratamento.quimioterapiaDia },
                new Agendamento { PacienteId = pacientes[7].Id, DiaDoAgendamento = data, TipoDeTratamento = ETipoDeTratamento.quimioterapiaDia },
                new Agendamento { PacienteId = pacientes[8].Id, DiaDoAgendamento = data, TipoDeTratamento = ETipoDeTratamento.quimioterapiaDia },
                new Agendamento { PacienteId = pacientes[9].Id, DiaDoAgendamento = DateTime.Now.AddHours(2), TipoDeTratamento = ETipoDeTratamento.quimioterapiaDia }
            );
           
        }
    }
}
