using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Produtos.DataTransfer.Fornecedores.Requests;
using Produtos.DataTransfer.Fornecedores.Responses;
using Produtos.Dominio.Fornecedores.Entidades;

namespace Produtos.Aplicacao.Fornecedores.Profiles
{
    public class FornecedoresProfile : Profile
    {
        public FornecedoresProfile(){
            CreateMap<FornecedorInserirRequest, Fornecedor>();
            CreateMap<FornecedorEditarRequest, Fornecedor>();
            CreateMap<Fornecedor, FornecedorInserirResponse>();
            CreateMap<Fornecedor, FornecedorReadResponse>();
        }
    }
}