using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Produtos.DataTransfer.Produtos.Requests;
using Produtos.DataTransfer.Produtos.Responses;
using Produtos.Dominio.Produtos.Entidades;

namespace Produtos.Aplicacao.Produtos.Servicos.Interfaces
{
    public interface IProdutosAppServico
    {
        public ProdutoInserirResponse Inserir(ProdutoInserirRequest produtoInserirRequest);
        public ProdutoReadResponse Recuperar(int id);

        public IList<ProdutoReadResponse> Listar(int pagina, int tamanho, int? order = 0, string? search = null);
        public ProdutoReadResponse Editar(int id, ProdutoUpdateRequest produtoUpdateRequest);
        public void Deletar(int id);
    }
}