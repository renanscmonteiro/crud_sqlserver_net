using Dapper;
using Projeto04.Entities;
using Projeto04.Helpers;
using Projeto04.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {

        private readonly string _connectionString;

        public EmpresaRepository()
        {
            _connectionString = ConfigurationHelper.GetConnectionString();
        }

        public void Add(Empresa empresa)
        {
            var query = @"insert into Empresa (IdEmpresa, NomeFantasia, RazaoSocial, Cnpj) 
                            values (NEWID(), @NomeFantasia, @RazaoSocial, @Cnpj)";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, empresa);
            }
        }

        public void Update(Empresa empresa)
        {
            var query = @"update Empresa
                            set NomeFantasia = @NomeFantasia,
                                RazaoSocial = @RazaoSocial,
                                Cnpj = @Cnpj
                            where IdEmpresa = @IdEmpresa";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, empresa);
            }
        }

        public void Delete(Empresa empresa)
        {
            var query = @"delete from empresa
                            where IdEmpresa = @IdEmpresa";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, empresa);
            }
        }

        public List<Empresa> GetAll()
        {
            var query = @"select IdEmpresa as IdEmpresa, 
                            NomeFantasia as NomeFantasia, 
                            RazaoSocial as RazaoSocial, 
                            Cnpj as Cnpj 
                        from Empresa
                        order by NomeFantasia";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Empresa>(query).ToList();
            }
        }

        public Empresa? GetById(Guid idEmpresa)
        {
            var query = @"select IdEmpresa as IdEmpresa, 
                            NomeFantasia as NomeFantasia, 
                            RazaoSocial as RazaoSocial, 
                            Cnpj as Cnpj 
                        from Empresa
                        where IdEmpresa = @IdEmpresa";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Empresa>(query, new { idEmpresa }).FirstOrDefault();
            }
        }
    }
}