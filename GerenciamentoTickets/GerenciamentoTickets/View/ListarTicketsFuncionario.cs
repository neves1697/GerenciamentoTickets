using GerenciamentoTickets.Controller.Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoTickets.View;
public static class ListarTicketsFuncionario
{
    public static void ExibirTicketsFuncionario()
    {
        ListarTicketsController.ExibirTickets();
    }
}
