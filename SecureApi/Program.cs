var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/values", () =>
{
    var rand = new Random().Next();
    var value = new GetValuesDto(
        Number: rand,
        Message: $"Hello, your result is {rand}."
    );
    return value;
});

app.Run();

record GetValuesDto(int Number, string Message);
