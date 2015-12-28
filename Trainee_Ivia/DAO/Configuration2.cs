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
                new Paciente("1","joão"), 
                new Paciente("2", "rebeca"),
                new Paciente("3", "roberto"),
                new Paciente("4", "breno"),
                new Paciente("5", "pedro"),
                new Paciente("6", "jessica"),
                new Paciente("7", "sara"),
                new Paciente("8", "clara"),
                new Paciente("9", "carlos alberto"),
                new Paciente("10", "valfonso pereira"));

            var pacientes = context.Pacientes;
            foreach (var paciente in context.Pacientes)
            {
                if (paciente == pacientes.Last()) break;

                var data = DateTime.Today;
                data = data.AddDays(5);
                
                context.Agendamentos.AddOrUpdate(new Agendamento(paciente, data, ETipoDeTratamento.quimioterapiaDia));
            }
            context.Agendamentos.AddOrUpdate(new Agendamento(pacientes.Last(),
               DateTime.Now.AddHours(2), ETipoDeTratamento.quimioterapiaDia));
        }
    }
}
