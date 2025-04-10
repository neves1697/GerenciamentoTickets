using GerenciamentoTickets.Model.DataBase;
using GerenciamentoTickets.Model;

namespace GerenciamentoTickets.Controller.Relatorios;
public class ListarFuncionariosController
{
    public static void ExibirFuncionariosCadastrados()
    {
        using (var contexto = new Context())
        {
            var dalFuncionario = new DAL<Funcionario>(contexto);
            var funcionarios = dalFuncionario.Listar();

            Console.WriteLine("Lista Funcionários\n");

            foreach (var funcionario in funcionarios)
            {
                Console.WriteLine($"IDFuncionario: {funcionario.Id}\nNome: {funcionario.Nome}\n" +
                    $"CPF: {funcionario.Cpf}\n" +
                    $"Situação: {funcionario.Situacao}\n" +
                    $"Data de alteração: {funcionario.DataAlteracao}\n");
            }
        }
    }
}
