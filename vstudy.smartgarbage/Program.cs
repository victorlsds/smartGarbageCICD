using vstudy.smartgarbage.Data.Context;
using Microsoft.EntityFrameworkCore;
using vstudy.smartgarbage.Data.Repository.Interface;
using vstudy.smartgarbage.Data.Repository.Implementation;
using vstudy.smartgarbage.Service.Interface;
using vstudy.smartgarbage.Service.Implementation;
using vstudy.smartgarbage.Model;
using vstudy.smartgarbage.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

#region INICIALIZANDO O BANCO DE DADOS
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true)
);
#endregion

#region REPOSITÓRIOS
builder.Services.AddScoped<IAgendamentoColetaRepository, AgendamentoColetaRepository>();
builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
builder.Services.AddScoped<IPontosColetaRepository, PontosColetaRepository>();
builder.Services.AddScoped<IResiduoColetaRepository, ResiduoColetaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
#endregion

#region SERVIÇOS
builder.Services.AddScoped<IAgendamentoColetaService, AgendamentoColetaService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<IPontosColetaService, PontosColetaService>();
builder.Services.AddScoped<IResiduoColetaService, ResiduoColetaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IAuthService, AuthService>();
#endregion

#region AUTOMAPPER
var mapperConfig = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AllowNullCollections = true;
    cfg.AllowNullDestinationValues = true;

    cfg.CreateMap<AgendamentoColetaModel, AgendamentoVisualizacaoVM>()
        .ForMember(dest => dest.PontoColetaEndereco, opt => opt.MapFrom(src => src.PontoColeta.Logradouro))
        .ForMember(dest => dest.UsuarioNome, opt => opt.MapFrom(src => src.Usuario.Nome));

    cfg.CreateMap<AgendamentoCadastroVM, AgendamentoColetaModel>();

    cfg.CreateMap<FeedbackModel, FeedbackCadastroVM>();
    cfg.CreateMap<FeedbackCadastroVM, FeedbackModel>();

    cfg.CreateMap<PontosColetaModel, PontosColetaVisualizacaoVM>();
    cfg.CreateMap<PontosColetaVisualizacaoVM, PontosColetaModel>();

    cfg.CreateMap<ResiduoColetaModel, ResiduoColetaCadastroVM>();
    cfg.CreateMap<ResiduoColetaCadastroVM, ResiduoColetaModel>();

    cfg.CreateMap<UsuarioModel, UsuarioVisualizacaoVM>();
    cfg.CreateMap<UsuarioCadastroVM, UsuarioModel>();
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion


#region AUTENTICAÇÃO
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f+ujXAKHk00L5jlMXo2XhAWawsOoihNP1OiAM25lLSO57+X7uBMQgwPju6yzyePi")),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
