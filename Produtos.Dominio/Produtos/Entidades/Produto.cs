using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Produtos.Dominio.Fornecedores.Entidades;
using Produtos.Dominio.Produtos.Enums;

namespace Produtos.Dominio.Produtos.Entidades
{
    public class Produto
    {
        public virtual int Id {get; protected set;}
        public virtual string? DescProduto {get; protected set;}
        public virtual SituacaoProdutoEnum? Situacao {get; protected set;}
        public virtual DateTime? DataFabricacao {get; protected set;}
        public virtual DateTime? DataValidade {get; protected set;}
        public virtual Fornecedor? Fornecedor {get; protected set;}

        protected Produto()
        {
            
        }

        public Produto(string? descProduto, DateTime? dataFabricacao, DateTime? dataValidade, Fornecedor? fornecedor)
        {
            SetDescProduto(descProduto);
            SetSituacao(SituacaoProdutoEnum.Ativo);
            SetDataValidade(dataValidade);
            SetDataFabricacao(dataFabricacao);
            SetFornecedor(fornecedor);
        }

        public virtual void SetId(int id)
        {
            this.Id = id;
        }

        public virtual void SetDescProduto(string? descProduto)
        {
            if (string.IsNullOrEmpty(descProduto))
            {
                throw new Exception("A descricao do produto é obrigatorio");
            }
            this.DescProduto = descProduto;
        }

        public virtual void SetSituacao(SituacaoProdutoEnum? situacao)
        {
            if (!situacao.HasValue)
            {
                throw new Exception("A situacao do produto é obrigatorio");
            }
            this.Situacao = situacao.Value;
        }
    
        public virtual void SetDataFabricacao(DateTime? dataFabricacao)
        {
            if (!dataFabricacao.HasValue)
            {
                throw new Exception("A data de fabricacao é obrigatorio");
            }
            if (dataFabricacao.Value.CompareTo(this.DataValidade) > 0 || dataFabricacao.Value.CompareTo(this.DataValidade) == 0)
            {
                throw new Exception("A data de fabricacao nao pode ser anterior ou na mesma data que a data de validade");
            }
            this.DataFabricacao = dataFabricacao.Value;
        }
    
        public virtual void SetDataValidade(DateTime? dataValidade)
        {
            if (!dataValidade.HasValue)
            {
                throw new Exception("A data de validade é obrigatorio");
            }
            this.DataValidade = dataValidade.Value;
        }

        public virtual void SetFornecedor(Fornecedor? fornecedor)
        {
            if (fornecedor is null)
            {
                throw new Exception("Produto precisa ter um fornecedor");
            }
            this.Fornecedor = fornecedor;
        }
    }
}