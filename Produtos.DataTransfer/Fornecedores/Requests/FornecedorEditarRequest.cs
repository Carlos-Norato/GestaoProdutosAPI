using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Produtos.DataTransfer.Fornecedores.Requests
{
    public class FornecedorEditarRequest
    {    
        public virtual string? DescFornecedor{get;set;}
        public virtual string? Cnpj{get;set;}
    }
}