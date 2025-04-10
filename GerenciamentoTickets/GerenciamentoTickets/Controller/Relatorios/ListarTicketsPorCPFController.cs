using GerenciamentoTickets.Model;
using GerenciamentoTickets.Model.DataBase;

namespace GerenciamentoTickets.Controller.Relatorios;
public class ListarTicketsPorCPFController
{
    private readonly Context contexto;

    public ListarTicketsPorCPFController(Context contexto)
    {
        this.contexto = contexto;
    }

    private List<Ticket> ExibirTicketsPorCPF(string cpf)
    {
        List<Ticket> listaTickets = new List<Ticket>();
        foreach (var ticket in contexto.Ticket)
        {
            if (ticket.Funcionario.Cpf == cpf)
            {
                listaTickets.Add(ticket);
            }
        }
        return listaTickets;
    }

    private string ObterCPF()
    {
        string cpf;
        do
        {
            cpf = Console.ReadLine()?.Trim()!;
            
        } while (string.IsNullOrEmpty(cpf));

        return cpf;
    }

    public void ObterCPFDoFuncionario()
    {
        Console.WriteLine("Digite o CPF: ");
        string cpf = ObterCPF();

        List<Ticket> tickets = ExibirTicketsPorCPF(cpf);

        if (tickets.Count == 0)
        {
            Console.WriteLine("Tickets não encontrados para o CPF fornecido\n");
        }
        else
        {
            Console.WriteLine("Ticket encontrado\n");

            foreach (var ticket in tickets)
            {
                Console.WriteLine($"idticket: {ticket.Id}\n" +
                    $"Funcionário: {ticket.Funcionario.Nome}\n" +
                    $"CPF: {ticket.Funcionario.Cpf}\n" +
                    $"Quantidade: {ticket.Quantidade}\n" +
                    $"Situação: {ticket.Situacao}\n" +
                    $"Data de modificação: {ticket.DataModificacao}\n ");
            }
        }
    }
}
