using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NHibernate;
using Produtos.Aplicacao.Produtos.Servicos.Interfaces;
using Produtos.DataTransfer.Produtos.Requests;
using Produtos.DataTransfer.Produtos.Responses;
using Produtos.Dominio.Fornecedores.Servicos.Interfaces;
using Produtos.Dominio.Produtos.Entidades;
using Produtos.Dominio.Produtos.Enums;
using Produtos.Dominio.Produtos.Repositorios;
using Produtos.Dominio.Produtos.Servicos.Interfaces;

namespace Produtos.Aplicacao.Produtos.Servicos
{
    public class ProdutosAppServico : IProdutosAppServico
    {
        private readonly IProdutosServico produtosServico;
        private readonly IMapper mapper;
        private readonly ISession session;
        private readonly IProdutosRepositorio produtosRepositorio;
        private readonly IFornecedoresServico fornecedorServico;

        public ProdutosAppServico(IProdutosServico produtosServico, IMapper mapper, ISession session, IProdutosRepositorio produtosRepositorio, IFornecedoresServico fornecedorServico)
        {
            this.produtosServico = produtosServico;
            this.mapper = mapper;
            this.session = session;
            this.produtosRepositorio = produtosRepositorio;
            this.fornecedorServico = fornecedorServico;
        }

        public void Deletar(int id)
        {
            var transacao = session.BeginTransaction();
            try
            {
                var produto = produtosServico.Validar(id);
                produtosRepositorio.Deletar(produto);
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

        public ProdutoReadResponse Editar(int id, ProdutoUpdateRequest produtoUpdateRequest)
        {
            produtoUpdateRequest = produtoUpdateRequest ?? new ProdutoUpdateRequest();
            var forncedor = fornecedorServico.Validar(produtoUpdateRequest.IdFornecedor.Value);
            var produto = mapper.Map<Produto>(produtoUpdateRequest);
            produto.SetFornecedor(forncedor);
            produto = produtosServico.Editar(id, 
                                    produto.DescProduto, 
                                    produto.DataFabricacao, 
                                    produto.DataValidade, 
                                    produto.Fornecedor);
            var transacao = session.BeginTransaction();
            try
            {
                produto = produtosRepositorio.Update(produto);
                if(transacao.IsActive)
                    transacao.Commit();
                return mapper.Map<ProdutoReadResponse>(produto);;
            }
            catch
            {
                if(transacao.IsActive)
                    transacao.Rollback();
                throw;
            }
            
           
            

        }

        public ProdutoInserirResponse Inserir(ProdutoInserirRequest produtoInserirRequest)
        {
            produtoInserirRequest = produtoInserirRequest ?? new ProdutoInserirRequest();
            var produto = produtosServico.Instanciar(
                produtoInserirRequest.DescProduto,
                produtoInserirRequest.DataFabricacao, 
                produtoInserirRequest.DataValidade, 
                produtoInserirRequest.IdFornecedor
                );
            var transacao = session.BeginTransaction();
            try
            {
                produto = produtosRepositorio.Inserir(produto);
                if(transacao.IsActive)
                    transacao.Commit();
                return mapper.Map<ProdutoInserirResponse>(produto);
            }
            catch
            {
                if(transacao.IsActive)
                    transacao.Rollback();
                throw;
            }
        }

        public ProdutoReadResponse Recuperar(int id)
        {
            var produto = produtosServico.Validar(id);
            var response = mapper.Map<ProdutoReadResponse>(produto);
            return response;
        }

        public IList<ProdutoReadResponse> Listar(int pagina, int tamanho, int? order = 0, string? search = "")
        {
            IQueryable<Produto> produtos = produtosRepositorio.Query()
            .Where(x => x.Situacao != SituacaoProdutoEnum.Inativo);
            
            if (!string.IsNullOrEmpty(search))
            {
                produtos = produtos.Where(x=>x.DescProduto.Contains(search));
            }
            
            switch (order)
            {
                case 1:
                    produtos = produtos.OrderBy(x=>x.Id);
                    break;
                case 2:
                    produtos = produtos.OrderBy(x=>x.DescProduto);
                    break;
                case 3:
                    produtos = produtos.OrderBy(x=>x.DataFabricacao);
                    break;
                case 4:
                    produtos = produtos.OrderBy(x=>x.DataValidade);
                    break;
            } 
            produtos = produtos.Skip((pagina-1)*tamanho).Take(tamanho);
            var response = mapper.Map<IList<ProdutoReadResponse>>(produtos.ToList());
            return response;
        }
    }
}