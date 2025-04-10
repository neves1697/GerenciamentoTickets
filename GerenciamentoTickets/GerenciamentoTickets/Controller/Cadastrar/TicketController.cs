using GerenciamentoTickets.Model;
using GerenciamentoTickets.Model.DataBase;

namespace GerenciamentoTickets.Controller.Cadastrar;
public class TicketController
{
    private readonly Context contexto;
    private readonly DAL<Ticket> dalTicket;
    private readonly DAL<Funcionario> dalFuncionario;

    public TicketController(Context contexto)
    {
        this.contexto = contexto;
        dalTicket = new DAL<Ticket>(contexto);
        dalFuncionario = new DAL<Funcionario>(contexto);
    }

    public void InserirTicket()
    {
        Console.WriteLine("Cadastro de Ticket");

        string cpf = ObterCPF();
        Funcionario funcionario = BuscarOuCadastrarFuncionario(cpf);
        int quantidade = ObterQuantidadeTickets();

        CadastrarTicket(funcionario, quantidade);

        Console.WriteLine("\nTicket cadastrado com sucesso!");
    }

    private string ObterCPF()
    {
        Console.Write("Digite o CPF do Funcionário: ");
        return Console.ReadLine()?.Trim()!;
    }

    private Funcionario BuscarOuCadastrarFuncionario(string cpf)
    {
        Funcionario funcionario = BuscarFuncionarioPorCPF(cpf);

        if (funcionario == null)
        {
            Console.WriteLine("Funcionário não encontrado. Criando um novo cadastro.");
            funcionario = CadastrarFuncionario(cpf);
        }
        else
        {
            Console.WriteLine($"Funcionário encontrado: {funcionario.Nome}");
        }

        return funcionario;
    }

    private Funcionario BuscarFuncionarioPorCPF(string cpf)
    {
        foreach (var f in contexto.Set<Funcionario>())
        {
            if (f.Cpf == cpf)
            {
                return f;
            }
        }
        return null;
    }

    private Funcionario CadastrarFuncionario(string cpf)
    {
        Console.Write("Nome do Funcionário: ");
        string nome = Console.ReadLine()?.Trim()!;

        var funcionario = new Funcionario
        {
            Nome = nome,
            Cpf = cpf,
            Situacao = "A",
            DataAlteracao = DateTime.Now
        };

        dalFuncionario.Adicionar(funcionario);
        contexto.SaveChanges();

        Console.WriteLine("Novo funcionário cadastrado com sucesso!");
        return funcionario;
    }

    private int ObterQuantidadeTickets()
    {
        int quantidade;
        do
        {
            Console.Write("Digite a quantidade de tickets: ");
        } while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade <= 0);

        return quantidade;
    }

    private void CadastrarTicket(Funcionario funcionario, int quantidade)
    {
        var novoTicket = new Ticket
        {
            Funcionario = funcionario,
            Quantidade = quantidade,
            Situacao = "A",
            DataModificacao = DateTime.Now
        };

        if (funcionario.Situacao.ToUpper() == "I")
        {
            Console.WriteLine("Não é possível cadastrar tickets para funcionários inativos\n");
            return;
        }
        else
        {
            dalTicket.Adicionar(novoTicket);
            contexto.SaveChanges();
        }
    }
}
