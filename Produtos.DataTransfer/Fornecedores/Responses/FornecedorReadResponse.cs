using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Produtos.DataTransfer.Fornecedores.Responses
{
    public class FornecedorReadResponse
    {
        public virtual int Id{get;set;}
        public virtual string? DescFornecedor{get;set;}
        public virtual string? Cnpj{get;set;}
    }
}