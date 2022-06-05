using Helbiz.Api.GraphQL;
using Helbiz.Application;
using Helbiz.Infrastructure;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration).AddApplication();
builder.Services.AddControllers();
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UsePlayground(new PlaygroundOptions() {QueryPath = "/gql", Path = "/playground"});
}

app.UseInfrastructure();
app.MapGraphQL("/gql");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();