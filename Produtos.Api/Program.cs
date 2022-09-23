using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Produtos.Aplicacao.Fornecedores.Profiles;
using Produtos.Aplicacao.Fornecedores.Servicos;
using Produtos.Aplicacao.Fornecedores.Servicos.Interfaces;
using Produtos.Aplicacao.Produtos.Servicos;
using Produtos.Aplicacao.Produtos.Servicos.Interfaces;
using Produtos.Dominio.Fornecedores.Repositorios;
using Produtos.Dominio.Fornecedores.Servicos;
using Produtos.Dominio.Fornecedores.Servicos.Interfaces;
using Produtos.Dominio.Produtos.Repositorios;
using Produtos.Dominio.Produtos.Servicos;
using Produtos.Dominio.Produtos.Servicos.Interfaces;
using Produtos.Infra.Fornecedores;
using Produtos.Infra.Fornecedores.Mapeamentos;
using Produtos.Infra.Produtos;
using ISession = NHibernate.ISession;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<ISessionFactory>(factory => 
{
    string connectionString = builder.Configuration.GetConnectionString("MySql");
    return Fluently.Configure()
    .Database((MySQLConfiguration.Standard.ConnectionString(connectionString)
    .FormatSql()
    .ShowSql()))
    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<FornecedoresMap>()) 
    .BuildSessionFactory();
});
builder.Services.AddSingleton<ISession>(factory => 
{
    return factory.GetService<ISessionFactory>()!.OpenSession();
});

builder.Services.AddSingleton<IFornecedoresRepositorio, FornecedoresRepositorio>();
builder.Services.AddSingleton<IFornecedoresAppServico, FornecedoresAppServico>();
builder.Services.AddSingleton<IFornecedoresServico, FornecedoresServico>();

builder.Services.AddSingleton<IProdutosRepositorio, ProdutosRepositorio>();
builder.Services.AddSingleton<IProdutosAppServico, ProdutosAppServico>();
builder.Services.AddSingleton<IProdutosServico, ProdutosServico>();

builder.Services.AddAutoMapper(typeof(FornecedoresProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
