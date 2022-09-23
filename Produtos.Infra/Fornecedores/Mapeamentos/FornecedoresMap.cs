using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Produtos.Dominio.Fornecedores.Entidades;

namespace Produtos.Infra.Fornecedores.Mapeamentos
{
    public class FornecedoresMap : ClassMap<Fornecedor>
    {
        public FornecedoresMap()
        {
            Schema("prova");
            Table("fornecedor");
            Id(x=>x.Id).Column("id");
            Map(x=>x.DescFornecedor).Column("desc_fornecedor");
            Map(x=>x.Cnpj).Column("cnpj");
        }
        
    }
}