using ConferencePlanner.GraphQL;
using ConferencePlanner.GraphQL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source=conferences.db"));

//  Setup GraphQL and register our query root type https://github.com/ChilliCream/graphql-workshop/blob/master/docs/1-creating-a-graphql-server-project.md
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGraphQL();

app.Run();
