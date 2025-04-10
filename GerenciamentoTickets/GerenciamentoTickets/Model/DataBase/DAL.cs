using GerenciamentoTickets.Model;

namespace GerenciamentoTickets.Model.DataBase;
public class DAL<T> where T : class
{
    protected readonly Context banco;

    public DAL(Context banco)
    {
        this.banco = banco;
    }
    public IEnumerable<T> Listar()
    {
        return banco.Set<T>().ToList();
    }

    public void Adicionar(T objeto)
    {
        banco.Set<T>().Add(objeto);
        banco.SaveChanges();
    }

    public void Editar(T objeto)
    {
        banco.Set<T>().Update(objeto);
        banco.SaveChanges();
    }
}
