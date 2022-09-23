using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Produtos.Aplicacao.Fornecedores.Servicos.Interfaces;
using Produtos.DataTransfer.Fornecedores.Requests;
using Produtos.DataTransfer.Fornecedores.Responses;
using Produtos.Dominio.Fornecedores.Entidades;

namespace Produtos.Api.Controllers.Fornecedores
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedoresAppServico fornecedoresAppServico;

        public FornecedoresController(IFornecedoresAppServico fornecedoresAppServico)
        {
            this.fornecedoresAppServico = fornecedoresAppServico;
        }

        [HttpPost]
        public ActionResult<FornecedorInserirResponse> Inserir([FromBody] FornecedorInserirRequest fornecedorInserirRequest)
        {
            var response = fornecedoresAppServico.Inserir(fornecedorInserirRequest);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<FornecedorReadResponse> Recuperar(int id)
        {
            var response = fornecedoresAppServico.Recuperar(id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            fornecedoresAppServico.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult<FornecedorReadResponse> Editar(int id, FornecedorEditarRequest fornecedorEditarRequest)
        {
            var response = fornecedoresAppServico.Editar(id, fornecedorEditarRequest);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<IList<Fornecedor>> RecuperaFonrnecedores()
        {
            var fornecedores = fornecedoresAppServico.RecuperarFornecedores();
            return Ok(fornecedores);
        }
    }
}