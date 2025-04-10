using GerenciamentoTickets.Controller.Relatorios;
using GerenciamentoTickets.Model.DataBase;

namespace GerenciamentoTickets.View;
public static class ListarTicketsPorPeriodo
{
    public static void ExibirTicketsPorPeriodo()
    {
        var contexto = new Context();
        ListarTicketsPorPeriodoController listarTicketsPorPeriodoController = new ListarTicketsPorPeriodoController(contexto);
        listarTicketsPorPeriodoController.ObterDatasInputUsuario();
    }
}
