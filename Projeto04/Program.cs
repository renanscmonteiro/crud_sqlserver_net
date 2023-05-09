using Projeto04.Controllers;

namespace Projeto04
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nProjeto par controle de empresas e funcionários\n");

            Console.WriteLine("(1) - Adicionar\n(2) - Atualizar\n(3) - Excluir \n(4) - Listar");

            Console.Write("\nInforme a opção desejada: ");
            var opcao = int.Parse(Console.ReadLine());

            var empresaController = new EmpresaController();

            switch (opcao)
            {
                case 1:
                    empresaController.CadastrarEmpresa();
                    break;

                case 2:
                    empresaController.AtualizarEmpresa();
                    break;

                case 3:
                    empresaController.ExcluirEmpresa();
                    break;

                case 4:
                    empresaController.ConsultarEmpresas();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }

            Console.WriteLine("Deseja continuar ? (S/N): ");
            var continuar = Console.ReadLine();

            if(continuar.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                Main(args);
            }
            else
            {
                Console.WriteLine("Fim do programa.");
            }
        }
    }
}