using Itau.RendaFixa.Contratacoes.Bussiness.Data;
using Itau.RendaFixa.Contratacoes.Bussiness.Filters;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AlterarNomeProduto;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.AtualizarContratacao;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarProdutos;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.ConsultarTipoProdutos;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarContratante;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.CriarNovoProduto;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.HabilitarContratante;
using Itau.RendaFixa.Contratacoes.Bussiness.UseCases.RealizarContratacao;
using Microsoft.EntityFrameworkCore;
using NodaTime.Serialization.SystemTextJson;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ContratacaoRendaFixa");

builder.Services.AddDbContext<ContratacoesContext>(opts =>
    opts.UseNpgsql(connectionString));

builder.Services.AddControllers()
    .AddJsonOptions(config =>
    {
        config.JsonSerializerOptions.ConfigureForNodaTime(NodaTime.DateTimeZoneProviders.Tzdb);
    });

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IObterTipoProdutoUseCase, ObterTipoProdutoUseCase>();
builder.Services.AddScoped<IConsultarProdutoUseCase, ConsultarProdutoUseCase>();
builder.Services.AddScoped<ICriarProdutoUseCase, CriarProdutoUseCase>();
builder.Services.AddScoped<IAlterarProdutoUseCase, AlterarProdutoUseCase>();
builder.Services.AddScoped<ICriarContratanteUseCase, CriarContratanteUseCase>();
builder.Services.AddScoped<IHabilitarContratanteUseCase, HabilitarContratanteUseCase>();
builder.Services.AddScoped<IRealizarContratacaoUseCase, RealizarContratacaoUseCase>();
builder.Services.AddScoped<IAtualizarContratacaoUseCase, AtualizarContratacaoUseCase>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilter>(); // Adicionar o filtro de exceção personalizado
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson();
//builder.Services.AddControllers().AddNewtonsoftJson(options =>
//{
//    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
//    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
