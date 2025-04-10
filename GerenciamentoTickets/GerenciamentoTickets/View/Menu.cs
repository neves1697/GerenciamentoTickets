using GerenciamentoTickets.Controller.Cadastrar;
using GerenciamentoTickets.Controller.Editar;
using GerenciamentoTickets.Model.DataBase;

namespace GerenciamentoTickets.View;
public class Menu
{
    public static void IniciarMenu()
    {
        var contexto = new Context();
        var inserirFuncionarioController = new FuncionarioController(contexto);
        var inserirTicketController = new TicketController(contexto);
        var editarFuncionarioController = new EditarFuncionarioController(contexto);
        var editarTicketController = new EditarTicketController(contexto);

        int opcao;

        do
        {
            Console.Clear();
            Console.WriteLine("\nMENU PRINCIPAL\n");

            Console.WriteLine("1 - Adicionar Funcionário\n");
            Console.WriteLine("2 - Adicionar Tickets\n");
            Console.WriteLine("3 - Editar Funcionários\n");
            Console.WriteLine("4 - Editar Tickets\n");
            Console.WriteLine("5 - Listar Todos os Funcionários\n");
            Console.WriteLine("6 - Listar Todos Tickets\n");
            Console.WriteLine("7 - Listar Tickets por período\n");
            Console.WriteLine("8 - Listar Tickets por CPF\n");
            Console.WriteLine("0 - Sair\n");
            Console.Write("Escolha uma opção: ");

            while (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.Write("Opção inválida! Digite um número: ");
            }

            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    inserirFuncionarioController.InserirFuncionario();
                    break;
                case 2:
                    Console.Clear();
                    inserirTicketController.InserirTicket();
                    break;
                case 3:
                    Console.Clear();
                    editarFuncionarioController.EditarFuncionario();
                    break;
                case 4:
                    Console.Clear();
                    editarTicketController.EditarTicket();
                    break;
                case 5:
                    Console.Clear();
                    ListarFuncionarios.ExibirFuncionarios();
                    break;
                case 6:
                    Console.Clear();
                    ListarTicketsFuncionario.ExibirTicketsFuncionario();
                    break;
                case 7:
                    Console.Clear();
                    ListarTicketsPorPeriodo.ExibirTicketsPorPeriodo();
                    break;
                case 8:
                    Console.Clear();
                    ListarTicketsPorCPF.ExibirTicketsPorCPF();
                    break;
                case 0:
                    Console.WriteLine("\nSaindo...");
                    break;

                default:
                    Console.WriteLine("\nOpção inválida! Tente novamente.");
                    break;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();

        } while (opcao != 0);
    }
}
