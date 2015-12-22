﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int Protocolo { get; set; }
        public DateTime DiaAgendado { get; set; }
        public EnumTipoDeTratamento TipoDeTratamento { get; set; }
        public bool EstadoDaConsulta { get; set; }

        public Agendamento()
        {

        }

        public Agendamento(int Protocolo, DateTime DiaAgendado, EnumTipoDeTratamento TipoDeTratamento)
        {
            if(DiaAgendado == null)
            {
                throw new ArgumentNullException("dia agendado");
            }

            this.Protocolo = Protocolo;
            this.DiaAgendado = DiaAgendado;
            this.TipoDeTratamento = TipoDeTratamento;
            this.EstadoDaConsulta = false;
        }

    }
}
