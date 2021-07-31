using Projeto02.Entities;
using Projeto02.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Controllers
{
    class FuncionarioController
    {
        public void CadastrarFuncionario()
        {
            Console.WriteLine("\n --- Cadastro de Funcionario ---\n");
           
            var funcionario = new Funcionario();

            funcionario.Setor = new Setor();
            funcionario.Dependentes = new List<Dependente>();

            funcionario.IdFuncionario = Guid.NewGuid();

            Console.Write("Nome do Funcionario .............:");
            funcionario.Nome = Console.ReadLine();

            Console.Write("CPF do Funcionario...............:");
            funcionario.Cpf = Console.ReadLine();

            Console.Write("Matricula do Funcionario ........:");
            funcionario.Matricula = Console.ReadLine();

            Console.Write("Data de Admissão do Funcionario .:");
            funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());


            funcionario.Setor.IdSetor = Guid.NewGuid();

            Console.WriteLine("Nome do Setor..............:");
            funcionario.Setor.Nome = Console.ReadLine();

            Console.WriteLine("Descrição do setor.........:");
            funcionario.Setor.Descricao = Console.ReadLine();

            Console.WriteLine("Número de dependentes......:");
            var numDependentes = int.Parse(Console.ReadLine());


            for (int i = 0; i < numDependentes; i++)
            {
                var dependente = new Dependente();

                dependente.IdDependente = Guid.NewGuid();

                Console.WriteLine($"\n  ENTRE COM O {i+1}º DEPENDENTE:\n");

                Console.WriteLine("Nome do dependente................:");
                dependente.Nome = Console.ReadLine();

                Console.WriteLine("Data de Nascimento................:");
                dependente.DataNascimento = DateTime.Parse(Console.ReadLine());
                funcionario.Dependentes.Add(dependente);
            }
            var funcionarioRepository = new FuncionarioRepository();
            funcionarioRepository.ExportarJSON(funcionario);

            Console.WriteLine("\nAquivo JSON gerado com sucesso!");



        }
    }
}
