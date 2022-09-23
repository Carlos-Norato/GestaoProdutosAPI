using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Produtos.Aplicacao.Produtos.Servicos.Interfaces;
using Produtos.DataTransfer.Produtos.Requests;
using Produtos.DataTransfer.Produtos.Responses;
using Produtos.Dominio.Produtos.Entidades;

namespace Produtos.Api.Controllers.Produtos
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosAppServico produtosAppServico;

        public ProdutosController(IProdutosAppServico produtosAppServico)
        {
            this.produtosAppServico = produtosAppServico;
        }

        [HttpPost]
        public ActionResult<ProdutoInserirResponse> Inserir(ProdutoInserirRequest produtoInserirRequest)
        {
            var response = produtosAppServico.Inserir(produtoInserirRequest);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<ProdutoReadResponse> Recuperar(int id)
        {
            var response = produtosAppServico.Recuperar(id);
            return Ok(response);
        }
        
        [HttpGet]
        public ActionResult<IList<ProdutoReadResponse>> Listar(int pagina, int tamanho, int? order, string? search )
        {
            var response = produtosAppServico.Listar(pagina, tamanho, order, search);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public ActionResult<ProdutoReadResponse> Editar(int id, [FromBody]ProdutoUpdateRequest produtoUpdateRequest)
        {
            var response = produtosAppServico.Editar(id, produtoUpdateRequest);
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public ActionResult Deletar(int id)
        {
            produtosAppServico.Deletar(id);
            return Ok();
        }
    }
}