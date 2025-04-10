using GerenciamentoTickets.Model;
using GerenciamentoTickets.Model.DataBase;

namespace GerenciamentoTickets.Controller.Editar;
public class EditarFuncionarioController
{
    private readonly Context contexto;
    private readonly DAL<Funcionario> dalFuncionario;

    public EditarFuncionarioController(Context contexto)
    {
        this.contexto = contexto;
        dalFuncionario = new DAL<Funcionario>(contexto);
    }

    public void EditarFuncionario()
    {
        Console.WriteLine("\nEdição de Funcionário\n");

        string cpf = ObterCPF();
        Funcionario funcionario = BuscarFuncionarioPorCPF(cpf);

        if (funcionario == null)
        {
            Console.WriteLine("Funcionário não encontrado.");
            return;
        }

        ExibirDadosAtuaisDoFuncionario(funcionario);
        AtualizarInformacoes(funcionario);

        dalFuncionario.Editar(funcionario);
        contexto.SaveChanges();

        Console.WriteLine("Dados do funcionário atualizados com sucesso!");
    }

    private string ObterCPF()
    {
        Console.Write("Digite o CPF do funcionário que deseja editar: ");
        return Console.ReadLine()?.Trim()!;
    }

    private Funcionario BuscarFuncionarioPorCPF(string cpf)
    {
        foreach (var cpfFuncionario in contexto.Set<Funcionario>())
        {
            if (cpfFuncionario.Cpf == cpf)
            {
                return cpfFuncionario;
            }
        }
        return null;
    }

    private void ExibirDadosAtuaisDoFuncionario(Funcionario funcionario)
    {
        Console.WriteLine("\nDados atuais do funcionário:");
        Console.WriteLine($"Nome: {funcionario.Nome}");
        Console.WriteLine($"CPF: {funcionario.Cpf}");
        Console.WriteLine($"Situação: {funcionario.Situacao}");
    }

    private void AtualizarInformacoes(Funcionario funcionario)
    {
        Console.Write("\nDigite o novo nome ou pressione Enter para manter o atual: ");
        string novoNome = Console.ReadLine()?.Trim()!;
        if (!string.IsNullOrEmpty(novoNome))
        {
            funcionario.Nome = novoNome;
        }

        Console.Write("Nova situação (A - Ativo / I - Inativo, pressione Enter para manter o atual): ");
        string novaSituacao = Console.ReadLine()?.Trim().ToUpper()!;
        if (!string.IsNullOrEmpty(novaSituacao) && (novaSituacao == "A" || novaSituacao == "I"))
        {
            funcionario.Situacao = novaSituacao;
        }

        funcionario.DataAlteracao = DateTime.Now;
    }
}
