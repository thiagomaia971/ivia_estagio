using System;
using System.Collections.Generic;

namespace Core
{
    public class Paciente
    {

        private int Id { get; set; }
        private string Nome;
        private string TipoDeTratamento;
        private DateTime DiaDaConsulta;
        private List<DateTime> ListaDeConsultas;
        
        public Paciente()
        {
            DiaDaConsulta = new DateTime();

            ListaDeConsultas = new List<DateTime>();
            //Consultas criadas randomicamente.
            Mock();
        }

        public Paciente(string Nome, string TipoDeTratamento, DateTime DiaDaConsulta)
        {
            this.Nome = Nome;
            this.TipoDeTratamento = TipoDeTratamento;
            this.DiaDaConsulta = DiaDaConsulta;

            ListaDeConsultas = new List<DateTime>();
            //Consultas criadas randomicamente.
            Mock();
        }

        private void Mock()
        {
            ListaDeConsultas.Add(new DateTime(2015, 11, 01));
            ListaDeConsultas.Add(new DateTime(2015, 11, 07));
            ListaDeConsultas.Add(new DateTime(2015, 11, 08));
            ListaDeConsultas.Add(new DateTime(2015, 11, 09));
            ListaDeConsultas.Add(new DateTime(2015, 11, 13));
            ListaDeConsultas.Add(new DateTime(2015, 11, 17));
            ListaDeConsultas.Add(new DateTime(2015, 12, 16));
            ListaDeConsultas.Add(new DateTime(2015, 11, 17));
        }

        //Getters e Setters

        public string getNome() { return Nome; }
        public void setNome(string Nome) { this.Nome = Nome; }

        public string getTipoDeTratamento() { return TipoDeTratamento; }
        public void setTipoDeTratamento(string TipoDeTratamento) { this.TipoDeTratamento = TipoDeTratamento; }

        public DateTime getDiaDaConsulta() { return DiaDaConsulta; }
        public void setDiaDaConsulta(DateTime DiaDaConsulta) { this.DiaDaConsulta = DiaDaConsulta; }

        public List<DateTime> getListaDeConsultas() { return ListaDeConsultas; }

    }
}