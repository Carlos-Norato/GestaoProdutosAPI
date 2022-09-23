using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Produtos.Dominio.Fornecedores.Entidades;

namespace Produtos.Dominio.Fornecedores.Repositorios
{
    public interface IFornecedoresRepositorio
    {
        Fornecedor Recuperar(int id);
        Fornecedor Inserir(Fornecedor fornecedor);
        Fornecedor Editar(Fornecedor fornecedor);
        void Deletar(Fornecedor fornecedor);
        IQueryable<Fornecedor> Query();
    }
}