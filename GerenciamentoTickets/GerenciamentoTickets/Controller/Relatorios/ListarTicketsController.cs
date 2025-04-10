using GerenciamentoTickets.Model;
using GerenciamentoTickets.Model.DataBase;

namespace GerenciamentoTickets.Controller.Relatorios;
public static class ListarTicketsController
{
    public static void ExibirTickets()
    {
        using (var contexto = new Context())
        {
            var dalTicket = new DAL<Ticket>(contexto);
            var tickets = dalTicket.Listar();

            Console.WriteLine("\nLista de Tickets\n");

            foreach (var ticket in tickets)
            {
                Console.WriteLine($"idticket: {ticket.Id}\n" +
                    $"idfuncionario: {ticket.Funcionario.Id}\n" +
                    $"nome: {ticket.Funcionario.Nome}\n" +
                    $"quantidade: {ticket.Quantidade}\n" +
                    $"situação: {ticket.Situacao}\n" +
                    $"data modificação: {ticket.DataModificacao}\n ");
            }
        }
    }
}

