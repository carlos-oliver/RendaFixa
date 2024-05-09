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
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ContratacaoRendaFixa");

builder.Services.AddDbContext<ContratacoesContext>(opts =>
    opts.UseNpgsql(connectionString));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IObterTipoProdutoUseCase, ObterTipoProdutoUseCase>();
builder.Services.AddScoped<IConsultarProdutoUseCase, ConsultarProdutoUseCase>();
builder.Services.AddScoped<ICriarProdutoUseCase, CriarProdutoUseCase>();
builder.Services.AddScoped<IAlterarProdutoUseCase, AlterarProdutoUseCase>();
builder.Services.AddScoped<ICriarContratanteUseCase, CriarContratanteUseCase>();
builder.Services.AddScoped<IHabilitarContratanteUseCase, HabilitarContratanteUseCase>();
builder.Services.AddScoped<IRealizarContratacaoUseCase, RealizarContratacaoUseCase>();
builder.Services.AddScoped<IAtualizarContratacaoUseCase, AtualizarContratacaoUseCase>();
builder.Services.AddScoped<IConsultarProdutoBloqueadoUseCase, ConsultarProdutoBloqueadoUseCase>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<CustomExceptionFilter>(); // Adicionar o filtro de exceção personalizado
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(opt =>
    opt.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "date",
        Format = "date",
        Example = new OpenApiString(DateTime.Today.ToString("yyyy-MM-dd"))
    })
);

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
