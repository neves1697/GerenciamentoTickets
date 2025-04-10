using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoTickets.Model;
public class Funcionario
{
    [Key]
    [Column("idfuncionario")]
    public int Id { get; set; }
    [Column("nome")]
    public string Nome { get; set; }
    [Column("cpf")]
    public string Cpf { get; set; }
    [Column("situacao")]
    public string Situacao { get; set; }
    [Column("dataalteracao")]
    public DateTime DataAlteracao { get; set; }

    public Funcionario(int id, string nome, string cpf, string situacao, DateTime dataAlteracao)
    {
        Id = id;
        Nome = nome!;
        Cpf = cpf;
        Situacao = situacao;
        DataAlteracao = dataAlteracao;
    }

    public Funcionario() { }

    public override string ToString()
    {
        return $"\nInformações do funcionário\n" +
            $"IdFuncionários: {Id}\n" +
            $"Nome: {Nome}\n" +
            $"CPF: {Cpf} \n" +
            $"Situação: {Situacao}\n" +
            $"Data de alteração: {DataAlteracao}";
    }
}
