namespace DAO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agendamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PacienteId = c.Int(nullable: false),
                        DiaDoAgendamento = c.DateTime(nullable: false),
                        TipoDeTratamento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pacientes", t => t.PacienteId, cascadeDelete: true)
                .Index(t => t.PacienteId);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Protocolo = c.String(),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agendamentoes", "PacienteId", "dbo.Pacientes");
            DropIndex("dbo.Agendamentoes", new[] { "PacienteId" });
            DropTable("dbo.Pacientes");
            DropTable("dbo.Agendamentoes");
        }
    }
}
