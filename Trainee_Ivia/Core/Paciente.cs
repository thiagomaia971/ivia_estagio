using System;
using System.Collections.Generic;

namespace Core
{
    public class Paciente
    {

        private int Id { get; set; }
        private int Protocolo;
        private String Nome;
        
        public Paciente()
        {
        }

        public Paciente(int Protocolo, String Nome)
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new ArgumentNullException("Nome");
            }
            this.Protocolo = Protocolo;
            this.Nome = Nome;

            ListaDeConsultas = new List<Agendamento>();

        }

        public Agendamento UltimoAgendamento()
        {
            Agendamento ag = new Agendamento();

            foreach (var agendamento in ListaDeConsultas)
            {
                ag = agendamento;
            }

            return ag;
        }

        //Getters e Setters

        public int getProtocolo() { return Protocolo; }

        public string getNome() { return Nome; }
        public void setNome(string Nome) { this.Nome = Nome; }

        public List<Agendamento> getListaDeConsultas() { return ListaDeConsultas; }
        public void AddConsulta(Agendamento Agendamento) { this.ListaDeConsultas.Add(Agendamento); }

    }
}