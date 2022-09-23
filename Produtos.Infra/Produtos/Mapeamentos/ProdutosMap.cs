using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Produtos.Dominio.Produtos.Entidades;
using Produtos.Dominio.Produtos.Enums;

namespace Produtos.Infra.Produtos.Mapeamentos
{
    public class ProdutosMap : ClassMap<Produto>
    {
        public ProdutosMap()
        {
            Schema("prova");
            Table("produto");
            Id(x=>x.Id).Column("id");
            Map(x=>x.DescProduto).Column("desc_produto");
            Map(x=>x.DataFabricacao).Column("data_fab");
            Map(x=>x.DataValidade).Column("data_val");
            Map(x=>x.Situacao).CustomType<SituacaoProdutoEnum>().Column("situacao");
            References(x=>x.Fornecedor).Column("id_fornecedor");
        }
    }
}