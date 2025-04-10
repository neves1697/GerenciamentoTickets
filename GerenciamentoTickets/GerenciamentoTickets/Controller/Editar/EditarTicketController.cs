using GerenciamentoTickets.Model;
using GerenciamentoTickets.Model.DataBase;

namespace GerenciamentoTickets.Controller.Editar;
public class EditarTicketController
{
    private readonly Context contexto;
    private readonly DAL<Ticket> dalTicket;

    public EditarTicketController(Context contexto)
    {
        this.contexto = contexto;
        dalTicket = new DAL<Ticket>(contexto);
    }

    public void EditarTicket()
    {
        Console.WriteLine("\nEdição de Ticket\n");
        string cpf = ObterCPF();

        Funcionario funcionario = BuscarFuncionarioPorCPF(cpf);

        if (funcionario == null)
        {
            Console.WriteLine("Funcionário não encontrado.\n");
            return;
        }

        Ticket ticket = BuscarTicketPorFuncionario(funcionario);

        if (ticket == null)
        {
            Console.WriteLine("Nenhum ticket encontrado para esse funcionário.\n");
            return;
        }
        else
        {
            ExibirDadosAtuaisTicket(ticket);
            AtualizarInformacoesTicket(ticket);

            dalTicket.Editar(ticket);
            contexto.SaveChanges();

            Console.WriteLine("\nTicket atualizado com sucesso!");
        }
    }

    private string ObterCPF()
    {
        Console.Write("Digite o CPF do funcionário que deseja editar: ");
        return Console.ReadLine()?.Trim()!;
    }

    private Funcionario BuscarFuncionarioPorCPF(string cpf)
    {
        foreach (var funcionario in contexto.Set<Funcionario>())
        {
            if (funcionario.Cpf == cpf)
            {
                return funcionario;
            }
        }
        return null;
    }

    private Ticket BuscarTicketPorFuncionario(Funcionario funcionario)
    {
        foreach (var ticket in contexto.Set<Ticket>())
        {
            if (ticket.Funcionario.Id == funcionario.Id)
            {
                return ticket;
            }
        }
        return null;
    }

    private void ExibirDadosAtuaisTicket(Ticket ticket)
    {
        Console.WriteLine("\nInformações atuais do Ticket do Funcionário:");
        Console.WriteLine($"Funcionário: {ticket.Funcionario.Nome}");
        Console.WriteLine($"CPF: {ticket.Funcionario.Cpf}");
        Console.WriteLine($"ID do Ticket: {ticket.Id}");
        Console.WriteLine($"Quantidade: {ticket.Quantidade}");
        Console.WriteLine($"Situação: {ticket.Situacao}");
    }

    private void AtualizarInformacoesTicket(Ticket ticket)
    {
        Console.Write("\nNova quantidade. Pressione Enter para manter a atual ");
        string entradaQuantidade = Console.ReadLine()?.Trim()!;
        if (!string.IsNullOrEmpty(entradaQuantidade) && int.TryParse(entradaQuantidade, out int novaQuantidade) && novaQuantidade > 0)
        {
            ticket.Quantidade = novaQuantidade;
        }

        Console.Write("Nova situação (A - Ativo / I - Inativo, pressione Enter para manter a atual): ");
        string novaSituacao = Console.ReadLine()?.Trim().ToUpper()!;
        if (!string.IsNullOrEmpty(novaSituacao) && (novaSituacao == "A" || novaSituacao == "I"))
        {
            ticket.Situacao = novaSituacao;
        }

        ticket.DataModificacao = DateTime.Now;
    }
}
