using System;
using System.Collections.Generic;

namespace Dominio.Core
{
    public class Paciente
    {
        public int Id { get; set; }
        public int Protocolo { get;}
        public String Nome { get; set; }
        public String NomeResponsável { get; set; }
        public String ContatoResponsável { get; set; }
        public DateTime DataNascimento { get; set; }


        public Paciente(int Protocolo, String Nome, String NomeResponsável, String ContatoResponsável, DateTime dataNascimento)
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new ArgumentNullException("Nome");
            }/*else if (String.IsNullOrEmpty(NomeResponsável))
            {
                throw new ArgumentNullException("NomeResponsável");
            }else if (String.IsNullOrEmpty(ContatoResponsável))
            {
                throw new ArgumentNullException("ContatoResponsável");
            */else if (dataNascimento == null)
            {
                throw new ArgumentNullException("dataNascimento");
            }

            this.Protocolo = Protocolo;
            this.Nome = Nome;
            this.ContatoResponsável = ContatoResponsável;
            this.NomeResponsável = NomeResponsável;
            this.DataNascimento = dataNascimento;

        }

        public Paciente(int v1, string v2)
        {
            /*
            apagar esse ctor temporario
            */
            this.Protocolo = v1;
            this.Nome= v2;
        }
    }
}