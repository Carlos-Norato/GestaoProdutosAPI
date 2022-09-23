using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Produtos.DataTransfer.Fornecedores.Requests;
using Produtos.DataTransfer.Fornecedores.Responses;
using Produtos.Dominio.Fornecedores.Entidades;

namespace Produtos.Aplicacao.Fornecedores.Servicos.Interfaces
{
    public interface IFornecedoresAppServico
    {
        FornecedorInserirResponse Inserir(FornecedorInserirRequest fornecedorInserirRequest);
        FornecedorReadResponse Editar(int id,FornecedorEditarRequest fornecedorEditarRequest);
        FornecedorReadResponse Recuperar(int id);
        void Delete(int id);
        IList<Fornecedor> RecuperarFornecedores();
    }
}