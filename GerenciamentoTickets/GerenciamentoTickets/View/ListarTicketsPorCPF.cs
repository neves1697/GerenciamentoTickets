using GerenciamentoTickets.Controller.Relatorios;
using GerenciamentoTickets.Model.DataBase;

namespace GerenciamentoTickets.View;
public static class ListarTicketsPorCPF
{
    public static void ExibirTicketsPorCPF()
    {
        var contexto = new Context();
        ListarTicketsPorCPFController listarTicketsPorCPF = new ListarTicketsPorCPFController(contexto);
        listarTicketsPorCPF.ObterCPFDoFuncionario();
    }
}
