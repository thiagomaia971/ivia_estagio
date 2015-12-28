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
        IList<Agendamento> obterAgendamentos();
        IList<Agendamento> obterAgendamentos(DateTime dia);
        IList<Agendamento> obterAgendamentos(DateTime dia, ETipoDeTratamento tipo);
        void incluirAgendamento(Agendamento agendamento);
    }
}
