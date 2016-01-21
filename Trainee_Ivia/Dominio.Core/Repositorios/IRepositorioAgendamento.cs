using Dominio.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core.Repositorios
{
    public interface IRepositorioAgendamento
    {
        List<Agendamento> obterAgendamentos();
        List<Agendamento> obterAgendamentos(DateTime dia);
        List<Agendamento> obterAgendamentos(DateTime dia, ETipoDeTratamento tipo);
        List<Agendamento> obterAgendamentos(string nome);
        List<Agendamento> obterAgendamentosPorProtocolo(string protocolo, DateTime dia);
        List<Agendamento> obterAgendamentosPorProtocolo(string protocolo);
        void incluirAgendamento(Agendamento agendamento);
        void incluirStatus(Agendamento agendamento);
    }
}
