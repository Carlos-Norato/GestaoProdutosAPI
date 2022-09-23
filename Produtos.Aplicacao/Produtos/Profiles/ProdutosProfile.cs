using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Produtos.DataTransfer.Produtos.Requests;
using Produtos.DataTransfer.Produtos.Responses;
using Produtos.Dominio.Fornecedores.Entidades;
using Produtos.Dominio.Produtos.Entidades;


namespace Produtos.Aplicacao.Produtos.Profiles
{
    public class ProdutosProfile : Profile
    {
        public ProdutosProfile(){
            CreateMap<ProdutoInserirRequest, Produto>();
            CreateMap<ProdutoUpdateRequest, Produto>();
            // .ConstructUsing(
            //     x=> new Produto(x.DescProduto,x.DataFabricacao, x.DataValidade)
            //     );
            CreateMap<Produto, ProdutoInserirResponse>();
            CreateMap<Produto, ProdutoReadResponse>();
        }
    }
}