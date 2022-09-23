using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Produtos.Dominio.Fornecedores.Entidades;
using Produtos.Dominio.Fornecedores.Repositorios;

namespace Produtos.Infra.Fornecedores
{
    public class FornecedoresRepositorio : IFornecedoresRepositorio
    {
        private readonly ISession session;

        public FornecedoresRepositorio(ISession session)
        {
            this.session = session;
        }

        public void Deletar(Fornecedor fornecedor)
        {
            session.Delete(fornecedor);
        }

        public Fornecedor Editar(Fornecedor fornecedor)
        {
            session.Update(fornecedor);
            session.Flush();
            return fornecedor;
        }

        public Fornecedor Inserir(Fornecedor fornecedor)
        {
            fornecedor.SetId((int)session.Save(fornecedor));
            return fornecedor;
        }

        public IQueryable<Fornecedor> Query()
        {
            return session.Query<Fornecedor>();
        }

        public Fornecedor Recuperar(int id)
        {
            return session.Get<Fornecedor>(id);
        }
    }
}