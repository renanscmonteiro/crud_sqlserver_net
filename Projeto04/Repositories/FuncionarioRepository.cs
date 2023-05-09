using Projeto04.Entities;
using Projeto04.Helpers;
using Projeto04.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {

        private readonly string _connectionString;

        public FuncionarioRepository()
        {
            _connectionString = ConfigurationHelper.GetConnectionString();
        }

        public void Add(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public void Update(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public void Delete(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        public Funcionario? GetById(Guid idFuncionario)
        {
            throw new NotImplementedException();
        }

        public List<Funcionario> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
