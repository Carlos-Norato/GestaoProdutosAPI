using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Produtos.Dominio.Produtos.Entidades;
using Produtos.Dominio.Produtos.Enums;
using Produtos.Dominio.Produtos.Repositorios;

namespace Produtos.Infra.Produtos
{
    public class ProdutosRepositorio : IProdutosRepositorio
    {
        private readonly ISession session;

        public ProdutosRepositorio(ISession session)
        {
            this.session = session;
        }

        public void Deletar(Produto produto)
        {
            produto.SetSituacao(SituacaoProdutoEnum.Inativo);
            session.Update(produto);
            session.Flush();
        }

        public Produto Inserir(Produto produto)
        {
            produto.SetId((int)session.Save(produto));
            return produto;
        }

        public IQueryable<Produto> Query()
        {
            return session.Query<Produto>().Where(x=>x.Situacao != SituacaoProdutoEnum.Inativo);
        }
        
        public Produto Recuperar(int id)
        {
            var produto = session.Query<Produto>()
            .Where(x => x.Id == id && x.Situacao != SituacaoProdutoEnum.Inativo)
            .FirstOrDefault();
            return produto;
        }

        public Produto Update(Produto produto)
        {
            session.Update(produto);
            session.Flush();
            return produto;
        }
    }
}