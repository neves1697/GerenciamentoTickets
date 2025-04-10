using GerenciamentoTickets.Model;
using GerenciamentoTickets.Model.DataBase;

namespace GerenciamentoTickets.Controller.Relatorios;
public class ListarTicketsPorPeriodoController
{
    private readonly Context contexto;

    public ListarTicketsPorPeriodoController(Context contexto)
    {
        this.contexto = contexto;
    }

    private List<Ticket> ExibirTicketsPorPeriodo(DateTime inicio, DateTime fim)
    {
        List<Ticket> ticketsEncontrados = new List<Ticket>();

        foreach (var ticket in contexto.Ticket)
        {
            if (ticket.DataModificacao.Date >= inicio.Date && ticket.DataModificacao.Date <= fim.Date)
            {
                ticketsEncontrados.Add(ticket);
            }
        }
        return ticketsEncontrados;
    }

    public void ObterDatasInputUsuario()
    {
        Console.WriteLine("Digite a data de início (dd/MM/yyyy): ");
        DateTime inicio = ObterData();

        Console.WriteLine("Digite a data de fim (dd/MM/yyyy): ");
        DateTime fim = ObterData();

        List<Ticket> tickets = ExibirTicketsPorPeriodo(inicio, fim);

        if (tickets.Count == 0)
        {
            Console.WriteLine("Nenhum ticket encontrado nesse período.");
        }
        else
        {
            Console.WriteLine("\nTickets encontrados:");
            foreach (var ticket in tickets)
            {
                Console.WriteLine($"Idticket: {ticket.Id}\n" +
                    $"Funcionário: {ticket.Funcionario.Nome}\n" +
                    $"CPF: {ticket.Funcionario.Cpf}\n" +
                    $"Quantidade: {ticket.Quantidade}\n" +
                    $"Data: {ticket.DataModificacao:dd/MM/yyyy}\n");
            }
        }
    }

    private DateTime ObterData()
    {
        DateTime data;
        while (!DateTime.TryParse(Console.ReadLine(), out data))
        {
            Console.WriteLine("Data inválida. Digite novamente (dd/MM/yyyy): ");
        }
        return data;
    }
}
