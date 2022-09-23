using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Produtos.DataTransfer.Fornecedores.Responses;

namespace Produtos.DataTransfer.Produtos.Responses
{
    public class ProdutoReadResponse
    {
        public virtual int Id{get;set;}
        public virtual string? DescProduto {get; set;}
        public virtual DateTime? DataFabricacao {get; set;}
        public virtual DateTime? DataValidade {get; set;}
        public virtual FornecedorReadResponse? Fornecedor {get; set;}
        
    }
}