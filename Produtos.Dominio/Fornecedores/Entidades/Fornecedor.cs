using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Produtos.Dominio.Fornecedores.Entidades
{
    public class Fornecedor
    {
        public virtual int Id{get;protected set;}
        public virtual string? DescFornecedor{get;protected set;}
        public virtual string? Cnpj{get;protected set;}

        protected Fornecedor()
        {

        }

        public Fornecedor(string? descFornecedor, string? cnpj)
        {
            SetDescFornecedor(descFornecedor);
            SetCnpj(cnpj);
        }

        public virtual void SetId(int id)
        {
            this.Id = id;
        }    

        public virtual void SetDescFornecedor(string? descFornecedor)
        {
            if(String.IsNullOrEmpty(descFornecedor))
            {
                throw new Exception("O nome do fornecedor é obrigatorio");
            }
            this.DescFornecedor = descFornecedor;
        }

        public virtual void SetCnpj(string? cnpj)
        {
            if(String.IsNullOrEmpty(cnpj))
            {
                throw new Exception("O cnpj do fornecedor é obrigario");
            }
            this.Cnpj = cnpj;

        }          


    }
}