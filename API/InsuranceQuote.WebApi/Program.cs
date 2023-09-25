using AutoMapper;
using InsuranceQuote.Application.Dto;
using InsuranceQuote.Application.Services;
using InsuranceQuote.Application.UseCases;
using InsuranceQuote.Domain.Entities;
using InsuranceQuote.Domain.Interfaces;
using InsuranceQuote.Infra.DataAccess;
using InsuranceQuote.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ContextDb>();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<ICalculateInsuranceUseCase, CalculateInsuranceUseCase>();
builder.Services.AddScoped<IGetReportInsuranceUseCase, GetReportInsuranceUseCase>();
builder.Services.AddScoped<IGetInsuranceDataUseCase, GetInsuranceDataUseCase>();
builder.Services.AddScoped<ISaveInsuranceUseCase, SaveInsuranceUseCase>();
builder.Services.AddScoped<ISaveVehicleUseCase, SaveVehicleUseCase>();

var configurationMapper = new MapperConfiguration(mapper =>
{
    mapper.CreateMap<VehiclesDTO, Vehicles>();
    mapper.CreateMap<Vehicles, VehiclesDTO>();
    mapper.CreateMap<Quote, QuoteDTO>();
    mapper.CreateMap<QuoteDTO, Quote>();
});
IMapper mapper = configurationMapper.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

app.UseDeveloperExceptionPage();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ContextDb>();
    context.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseCors("corsapp");
app.UseAuthorization();

app.MapControllers();

app.Run();
