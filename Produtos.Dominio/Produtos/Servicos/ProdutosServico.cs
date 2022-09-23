using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Produtos.Dominio.Fornecedores.Entidades;
using Produtos.Dominio.Fornecedores.Servicos.Interfaces;
using Produtos.Dominio.Produtos.Entidades;
using Produtos.Dominio.Produtos.Repositorios;
using Produtos.Dominio.Produtos.Servicos.Interfaces;

namespace Produtos.Dominio.Produtos.Servicos
{
    public class ProdutosServico : IProdutosServico
    {
        private readonly IProdutosRepositorio produtosRepositorio;
        private readonly IFornecedoresServico fornecedoresServico;

        public ProdutosServico(IProdutosRepositorio produtosRepositorio, IFornecedoresServico fornecedoresServico)
        {
            this.produtosRepositorio = produtosRepositorio;
            this.fornecedoresServico = fornecedoresServico;
        }

        public Produto Editar(int id, string? descProduto, DateTime? dataFabricacao, DateTime? dataValidade, Fornecedor fornecedor)
        {
            var produto = Validar(id);
            if(!string.IsNullOrEmpty(descProduto) && produto.DescProduto != descProduto) produto.SetDescProduto(descProduto);
            if(dataFabricacao.HasValue && produto.DataFabricacao.Value.CompareTo(dataFabricacao) != 0) produto.SetDataFabricacao(dataFabricacao);
            if(dataValidade.HasValue && produto.DataValidade.Value.CompareTo(dataValidade) != 0) produto.SetDataValidade(dataValidade);
            if(fornecedor is not null) produto.SetFornecedor(fornecedor);

            return produto;

        }

        public Produto Instanciar(string? descProduto, DateTime? dataFabricacao, DateTime? dataValidade, int idFornecedor)
        {
            var fornecedor = fornecedoresServico.Validar(idFornecedor);
            var produto = new Produto(descProduto, dataFabricacao, dataValidade,fornecedor);
            return produto;
        }

        public Produto Validar(int id)
        {
            var produto = produtosRepositorio.Recuperar(id);
            if (produto is null)
            {
                throw new Exception("Produto não existe");
            }
            return produto;
        }
    }
}