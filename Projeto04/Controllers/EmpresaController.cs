using Projeto04.Entities;
using Projeto04.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Controllers
{
    public class EmpresaController
    {
        //Atributo
        private readonly EmpresaRepository _empresaRepository;

        //Método construtor
        public EmpresaController()
        {
            //inicializando o(s) atributo(s)
            _empresaRepository = new EmpresaRepository();
        }
        public void CadastrarEmpresa()
        {
            try
            {
                Console.WriteLine("\nCadastro de empresa:\n");

                var empresa = new Empresa();

                Console.Write("Entre com o Nome Fantasia.....: ");
                empresa.NomeFantasia = Console.ReadLine();
                Console.Write("Entre com a Razão Social......: ");
                empresa.RazaoSocial = Console.ReadLine();
                Console.Write("Entre com o CNPJ..............: ");
                empresa.Cnpj = Console.ReadLine();

                _empresaRepository.Add(empresa);

                Console.WriteLine("\nEmpresa cadastrada com sucesso.");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFalha ao cadastrar empresa: " + e.Message);
            }
        }
        public void AtualizarEmpresa()
        {
            try
            {
                Console.WriteLine("\nEdição de empresa:\n");

                Console.Write("Entre com o ID da Empresa.....: ");
                var idEmpresa = Guid.Parse(Console.ReadLine());

                var empresa = _empresaRepository.GetById(idEmpresa);

                if (empresa != null)
                {
                    Console.WriteLine("\nDados da empresa:");
                    Console.WriteLine($"\tID da empresa....: {empresa.IdEmpresa}");
                    Console.WriteLine($"\tNome fantasia....: {empresa.NomeFantasia}");
                    Console.WriteLine($"\tRazão social.....: {empresa.RazaoSocial}");
                    Console.WriteLine($"\tCNPJ.............: {empresa.Cnpj}");

                    Console.WriteLine("\nAltere os dados da empresa:");

                    Console.Write("Entre com o Nome Fantasia.....: ");
                    empresa.NomeFantasia = Console.ReadLine();
                    Console.Write("Entre com a Razão Social......: ");
                    empresa.RazaoSocial = Console.ReadLine();
                    Console.Write("Entre com o CNPJ..............: ");
                    empresa.Cnpj = Console.ReadLine();

                    _empresaRepository.Update(empresa);

                    Console.WriteLine("\nEmpresa atualizada com sucesso.");
                }
                else
                {
                    Console.WriteLine("\nEmpresa não encontrada.");
                }               
            }
            catch(Exception e)
            {
                Console.WriteLine("\nFalha ao atualizar empresa: " + e.Message);
            }
        }
        public void ExcluirEmpresa()
        {
            try
            {
                Console.WriteLine("\nExclusão de empresa:\n");

                Console.Write("Entre com o ID da Empresa.....: ");
                var idEmpresa = Guid.Parse(Console.ReadLine());

                var empresa = _empresaRepository.GetById(idEmpresa);

                if (empresa != null)
                {
                    Console.WriteLine("\nDados da empresa:");
                    Console.WriteLine($"\tID da empresa....: {empresa.IdEmpresa}");
                    Console.WriteLine($"\tNome fantasia....: {empresa.NomeFantasia}");
                    Console.WriteLine($"\tRazão social.....: {empresa.RazaoSocial}");
                    Console.WriteLine($"\tCNPJ.............: {empresa.Cnpj}");

                    Console.WriteLine("Deseja excluir a empresa ? (S/N): ");
                    var opcao = Console.ReadLine();

                    if (opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
                    {
                        _empresaRepository.Delete(empresa);
                        Console.WriteLine("\nEmpresa excluída com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("\nOperação cancelada.");
                    }     
                }
                else
                {
                    Console.WriteLine("\nEmpresa não encontrada.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFalha ao excluir empresa: " + e.Message);
            }
        }
        public void ConsultarEmpresas()
        {
            try
            {
                Console.WriteLine("\nConsulta de empresas:\n");

                var empresas = _empresaRepository.GetAll();

                foreach (var item in empresas)
                {
                    Console.WriteLine($"\tID da empresa....: {item.IdEmpresa}");
                    Console.WriteLine($"\tNome fantasia....: {item.NomeFantasia}");
                    Console.WriteLine($"\tRazão social.....: {item.RazaoSocial}");
                    Console.WriteLine($"\tCNPJ.............: {item.Cnpj}");
                    Console.WriteLine("=========");
                }

                Console.WriteLine($"Quantidade de empresas: {empresas.Count}");
            }
            catch(Exception e)
            {
                Console.WriteLine("\nFalha ao consultar empresas: " + e.Message);
            }
        }
    }
}