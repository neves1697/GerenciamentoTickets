using GerenciamentoTickets.Controller.Relatorios;
using GerenciamentoTickets.Model;
using GerenciamentoTickets.Model.DataBase;

namespace GerenciamentoTickets.View;
public static class ListarFuncionarios
{
    public static void ExibirFuncionarios()
    {
        ListarFuncionariosController.ExibirFuncionariosCadastrados();
    }
}
