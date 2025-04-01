using GraphQLServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services
   .AddMyGraphQL();

var app = builder.Build();

app
    .UseRouting()
    .UseHttpsRedirection()
    .UseWebSockets()
    ;

app.MapGet("/", () => "Hello World!");
app.MapGraphQL();

app.RunWithGraphQLCommands(args);

public partial class Program
{
}
