using GerenciamentoTickets.Model;
using GerenciamentoTickets.Model.DataBase;

namespace GerenciamentoTickets.Controller.Cadastrar
{
    public class FuncionarioController
    {
        private readonly Context contexto;
        private readonly DAL<Funcionario> dalFuncionario;

        public FuncionarioController(Context contexto)
        {
            this.contexto = contexto;
            dalFuncionario = new DAL<Funcionario>(contexto);
        }

        public void InserirFuncionario()
        {
            Console.WriteLine("Cadastro de Funcionário\n");
            ValidarCamposObrigatorios();
        }

        private bool ValidarCpf(string cpf)
        {
            List<Funcionario> listaFuncionarios = contexto.Funcionario.ToList();

            foreach (var funcionario in listaFuncionarios)
            {
                if (funcionario.Cpf == cpf)
                {
                    return true; 
                }
            }
            return false;
        }

        private void ValidarCamposObrigatorios()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine()?.Trim()!;

            Console.Write("CPF: ");
            string cpf = Console.ReadLine()?.Trim()!;

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cpf))
            {
                Console.WriteLine("Nome e CPF obrigatórios!\n");
                return;
            }

            if (ValidarCpf(cpf))
            {
                Console.WriteLine($"O CPF {cpf} já cadastrado!\n");
                return;
            }

            var novoFuncionario = new Funcionario
            {
                Nome = nome,
                Cpf = cpf,
                Situacao = "A",
                DataAlteracao = DateTime.Now
            };

            dalFuncionario.Adicionar(novoFuncionario);
            contexto.SaveChanges();

            Console.WriteLine("Funcionário cadastrado com sucesso!\n");
        }
    }
}
