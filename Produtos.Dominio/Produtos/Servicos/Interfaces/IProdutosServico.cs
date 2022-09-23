using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Produtos.Dominio.Fornecedores.Entidades;
using Produtos.Dominio.Produtos.Entidades;

namespace Produtos.Dominio.Produtos.Servicos.Interfaces
{
    public interface IProdutosServico
    {
        public Produto Instanciar (string? descProduto, DateTime? dataFabricacao, DateTime? dataValidade, int idFornecedor);
        public Produto Validar(int id);
        public Produto Editar(int id,string? descProduto, DateTime? dataFabricacao, DateTime? dataValidade, Fornecedor fornecedor);
    }
}