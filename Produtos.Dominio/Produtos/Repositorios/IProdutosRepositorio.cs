using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Produtos.Dominio.Produtos.Entidades;

namespace Produtos.Dominio.Produtos.Repositorios
{
    public interface IProdutosRepositorio
    {
        public Produto Inserir(Produto produto);
        public Produto Recuperar(int id);
        public IQueryable<Produto> Query();
        public Produto Update(Produto produto);
        public void Deletar(Produto produto);
    }
}