using Projeto_Odontpro.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Projeto_Odontpro.Models;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Projeto_Odontpro.Services
{
    public class FuncionarioService
    {
        private readonly FuncionarioDAO _dao;

        public FuncionarioService(FuncionarioDAO dao)
        {
            _dao = dao;
        }

        public Task<List<Funcionario>> ObterTodos() => _dao.ObterTodos();
        public Task<Funcionario?> ObterPorId(int id) => _dao.ObterPorId(id);
        public Task Adicionar(Funcionario f) => _dao.Adicionar(f);
        public Task Atualizar(Funcionario f) => _dao.Atualizar(f);
        public Task Excluir(int id) => _dao.Excluir(id);
    }
}
