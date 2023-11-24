using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

// Define a simple request and response
public class Ping : IRequest<string>
{
}

// Define a handler for the request
public class PingHandler : IRequestHandler<Ping, string>
{
    public Task<string> Handle(Ping request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Pong");
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        // Setup dependency injection
        var serviceProvider = new ServiceCollection()
            .AddMediatR(typeof(Program))
            .BuildServiceProvider();

        // Get Mediator instance from the service provider
        var mediator = serviceProvider.GetRequiredService<IMediator>();

        // Send a request and get the response
        var response = await mediator.Send(new Ping());

        // Display the response
        Console.WriteLine(response);
    }
}