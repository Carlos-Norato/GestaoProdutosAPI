using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Produtos.DataTransfer.Produtos.Requests
{
    public class ProdutoInserirRequest
    {
        public virtual string? DescProduto{get; set;}
        public virtual DateTime? DataFabricacao {get;set;}
        public virtual DateTime? DataValidade {get;set;}
        public virtual int IdFornecedor {get; set;}

    }
}