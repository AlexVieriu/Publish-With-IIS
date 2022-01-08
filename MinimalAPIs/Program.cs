// https://www.youtube.com/watch?v=5tYSO5mAjXs&t=1927s&ab_channel=IAmTimCorey

using MinimalAPIs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServerSideBlazor().AddCircuitOptions(option => { option.DetailedErrors = true; });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ISql, Sql>();
builder.Services.AddSingleton<IUserData, UserData>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

else if(app.Environment.IsProduction()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureApi();

app.Run();


