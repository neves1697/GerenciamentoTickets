using Microsoft.EntityFrameworkCore;

namespace GerenciamentoTickets.Model.DataBase;
public class Context : DbContext
{
    public DbSet<Funcionario> Funcionario { get; set; }
    public DbSet<Ticket> Ticket { get; set; }

    private string conexao = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GerenciamentoTickets;Integrated Security=True;MultipleActiveResultSets=True";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(conexao)
            .UseLazyLoadingProxies();
    }

    public void TesteConexao()
    {
        try
        {
            Console.WriteLine("Testando conexão com o banco de dados...\n");
            this.Database.OpenConnection();
            Console.WriteLine("Conexão com o banco de dados com sucesso...\n ");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao conectar com o banco\n" + ex.GetBaseException());
            throw;
        }
        finally
        {
            this.Database.CloseConnection();
        }
    }
}
