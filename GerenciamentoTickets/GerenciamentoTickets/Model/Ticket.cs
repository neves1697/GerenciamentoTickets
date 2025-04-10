namespace GerenciamentoTickets.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Ticket
{
    [Key]
    [Column("idticket")]
    public int Id { get; set; }
    [ForeignKey("idfuncionario")]
    public virtual Funcionario Funcionario { get; set; }
    [Column("quantidade")]
    public int Quantidade { get; set; }
    [Column("situacao")]
    public string Situacao { get; set; }
    [Column("datamodificacao")]
    public DateTime DataModificacao { get; set; }

    public Ticket(int id, Funcionario funcionario, int quantidade, string situacao, DateTime dataModificacao)
    {
        Id = id;
        Funcionario = funcionario ?? throw new ArgumentNullException(nameof(funcionario));
        Quantidade = quantidade;
        Situacao = situacao;
        DataModificacao = dataModificacao;
    }

    public Ticket() { }

    public void ExibirInformacoes()
    {
        Console.WriteLine($"Id: {Id}\n" +
            $"Funcionário: {Funcionario}\n" +
            $"Quantidade: {Quantidade}\n" +
            $"Situação: {Situacao}\n" +
            $"Data de Modificação: {DataModificacao}");
    }

    public override string ToString()
    {
        return $"IdTicket: {Id}\n" +
            $"Funcionário: {Funcionario}\n" +
            $"Quantidade: {Quantidade}\n" +
            $"Situação: {Situacao}\n" +
            $"Data de modificação: {DataModificacao} ";
    }
}
