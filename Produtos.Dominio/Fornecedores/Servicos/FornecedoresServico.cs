using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Produtos.Dominio.Fornecedores.Entidades;
using Produtos.Dominio.Fornecedores.Repositorios;
using Produtos.Dominio.Fornecedores.Servicos.Interfaces;

namespace Produtos.Dominio.Fornecedores.Servicos
{
    public class FornecedoresServico : IFornecedoresServico
    {
        private readonly IFornecedoresRepositorio fornecedoresRepositorio;

        public FornecedoresServico(IFornecedoresRepositorio fornecedoresRepositorio)
        {
            this.fornecedoresRepositorio = fornecedoresRepositorio;
        }
        public Fornecedor Editar(int id, string? descFornecedor, string? cnpj)
        {
            Fornecedor fornecedor = Validar(id);
            if(fornecedor.DescFornecedor != descFornecedor && !string.IsNullOrEmpty(descFornecedor)) 
                fornecedor.SetDescFornecedor(descFornecedor);
            if(fornecedor.Cnpj != cnpj && !string.IsNullOrEmpty(cnpj)) 
                fornecedor.SetCnpj(cnpj);
            return fornecedoresRepositorio.Editar(fornecedor);
        }



        public Fornecedor Instanciar(string? descFornecedor, string? cnpj)
        {
            var forncedor = new Fornecedor(descFornecedor,cnpj);
            return forncedor;
        }

        public IQueryable<Fornecedor> Query()
        {
            return fornecedoresRepositorio.Query();
        }

        public Fornecedor Validar(int? id)
        {
            Fornecedor fornecedor = fornecedoresRepositorio.Recuperar(id.Value);
            if(fornecedor is null)
            {
                throw new Exception("Fornecedor não existe");
            }
            return fornecedor;
        }
    }
}