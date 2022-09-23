using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Produtos.Dominio.Fornecedores.Entidades;

namespace Produtos.Dominio.Fornecedores.Servicos.Interfaces
{
    public interface IFornecedoresServico
    {
        Fornecedor Validar(int? id);
        Fornecedor Instanciar(string? descFornecedor, string? cnpj);
        Fornecedor Editar(int id, string? descFornecedor, string? cnpj);
        IQueryable<Fornecedor> Query();
    }
}