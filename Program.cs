
using pedidos.Servicios;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddTransient<IServicioPedidosTransitorio, ServicioPedidos>();
builder.Services.AddScoped<IServicioPedidosDelimitado, ServicioPedidos>();
builder.Services.AddSingleton<IServicioPedidosSingleton, ServicioPedidos>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
