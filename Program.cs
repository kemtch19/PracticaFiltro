

using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregamos el servicio del controlador para que estos funcionen de manera correcta
builder.Services.AddControllers();

// Agregamos el servicio de los cors ya que necesitamos configurar de manera correcta los cors para dejar pasar a la persona o ip que tengamos identificada en nuestra lista pero de momento solamente que este ahí para dejar pasar a las personas desde el backend ya si queremos que no todos pase hay que configurarlo
builder.Services.AddCors(Options=>{
    Options.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

// Configuración del servicio de la base de datos
builder.Services.AddDbContext<>

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();