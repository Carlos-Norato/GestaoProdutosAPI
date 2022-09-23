using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NHibernate;
using Produtos.Aplicacao.Fornecedores.Servicos.Interfaces;
using Produtos.DataTransfer.Fornecedores.Requests;
using Produtos.DataTransfer.Fornecedores.Responses;
using Produtos.Dominio.Fornecedores.Entidades;
using Produtos.Dominio.Fornecedores.Repositorios;
using Produtos.Dominio.Fornecedores.Servicos.Interfaces;

namespace Produtos.Aplicacao.Fornecedores.Servicos
{
    public class FornecedoresAppServico : IFornecedoresAppServico
    {
        private readonly IFornecedoresServico fornecedorServico;
        private readonly IMapper mapper;
        private readonly ISession session;
        private readonly IFornecedoresRepositorio fornecedoresRepositorio;

        public FornecedoresAppServico(IFornecedoresServico fornecedorServico, IMapper mapper, ISession session, IFornecedoresRepositorio fornecedoresRepositorio)
        {
            this.fornecedorServico = fornecedorServico;
            this.mapper = mapper;
            this.session = session;
            this.fornecedoresRepositorio = fornecedoresRepositorio;
        }

        public FornecedorReadResponse Editar(int id, FornecedorEditarRequest fornecedorEditarRequest)
        {
            fornecedorEditarRequest = fornecedorEditarRequest ?? new FornecedorEditarRequest();
            var fornecedor = fornecedorServico.Instanciar(
                                                    fornecedorEditarRequest.DescFornecedor,
                                                    fornecedorEditarRequest.Cnpj);
            var transacao = session.BeginTransaction();
            try
            {
                fornecedor = fornecedorServico.Editar(id,fornecedor.DescFornecedor,fornecedor.Cnpj);
                var response = mapper.Map<FornecedorReadResponse>(fornecedor);
                if(transacao.IsActive)
                    transacao.Commit();
                    return response;
            }
            catch
            {
                if(transacao.IsActive)
                    transacao.Rollback(); 
                throw;
            }
        }

        public FornecedorInserirResponse Inserir(FornecedorInserirRequest fornecedorInserirRequest)
        {
            fornecedorInserirRequest = fornecedorInserirRequest ?? new FornecedorInserirRequest();
            var fornecedor = fornecedorServico.Instanciar(
                                    fornecedorInserirRequest.DescFornecedor, 
                                    fornecedorInserirRequest.Cnpj);;
            var transacao = session.BeginTransaction();
            try
            {
                fornecedor = fornecedoresRepositorio.Inserir(fornecedor);
                if(transacao.IsActive)
                    transacao.Commit();
                return mapper.Map<FornecedorInserirResponse>(fornecedor);
            }
            catch 
            {
                
                if(transacao.IsActive)
                    transacao.Rollback(); 
                throw; 
            }
        }

        public FornecedorReadResponse Recuperar(int id)
        {
            var fornecedor = fornecedorServico.Validar(id);
            return mapper.Map<FornecedorReadResponse>(fornecedor);
        }
        
        public void Delete(int id)
        {
            var transacao = session.BeginTransaction();
            try{
                var fornecedor = fornecedorServico.Validar(id);
                fornecedoresRepositorio.Deletar(fornecedor);
                if(transacao.IsActive)
                    transacao.Commit(); 
            }
            catch
            {
                if(transacao.IsActive)
                    transacao.Rollback(); 
                throw; 
            }
            
        }

        public IList<Fornecedor> RecuperarFornecedores()
        {
            IList<Fornecedor> fornecedores = fornecedorServico.Query().ToList();
            return fornecedores;
        }
    }
}