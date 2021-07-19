using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

// ReSharper disable ClassNeverInstantiated.Global

namespace _0501_MediatorDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddMediatR(typeof(Program).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(MyPipelineBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(MyPipelineBehaviorV2<,>));

            var serviceProvider = services.BuildServiceProvider();
            var mediator = serviceProvider.GetService<IMediator>();
            var result = await mediator.Send(new MyRequest("Test"));
            Console.WriteLine($"Result: {result}");
            //await mediator.Publish(new MyNotification("Test"));

            Console.WriteLine("End...");
        }
    }

    public class MyRequest : IRequest<long>
    {
        public MyRequest(string commandName) => CommandName = commandName;
        public string CommandName { get; private set; }
    }

    public class MyRequestHandler : IRequestHandler<MyRequest, long>
    {
        public Task<long> Handle(MyRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(MyRequestHandler)} 执行命令：{request.CommandName}");
            return Task.FromResult(0L);
        }
    }

    public class MyRequestHandlerV2 : IRequestHandler<MyRequest, long>
    {
        public Task<long> Handle(MyRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(MyRequestHandlerV2)} 执行命令：{request.CommandName}");
            return Task.FromResult(0L);
        }
    }

    public class MyNotification : INotification
    {
        public MyNotification(string commandName) => CommandName = commandName;
        public string CommandName { get; set; }
    }

    public class MyNotificationHandler : INotificationHandler<MyNotification>
    {
        public Task Handle(MyNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(MyNotificationHandler)} 执行命令：{notification.CommandName}");
            return Task.CompletedTask;
        }
    }

    public class MyNotificationHandlerV2 : INotificationHandler<MyNotification>
    {
        public Task Handle(MyNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(MyNotificationHandlerV2)} 执行命令：{notification.CommandName}");
            return Task.CompletedTask;
        }
    }

    public class MyPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            Console.WriteLine($"{nameof(MyPipelineBehavior<TRequest, TResponse>)} Start...");

            var response = await next();

            Console.WriteLine($"{nameof(MyPipelineBehavior<TRequest, TResponse>)} End...");

            return response;
        }
    }

    public class MyPipelineBehaviorV2<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            Console.WriteLine($"{nameof(MyPipelineBehaviorV2<TRequest, TResponse>)} Start...");

            var response = await next();

            Console.WriteLine($"{nameof(MyPipelineBehaviorV2<TRequest, TResponse>)} End...");

            return response;
        }
    }

    public class MyRequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    {
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(MyRequestPreProcessor<TRequest>)} Run...");
            return Task.CompletedTask;
        }
    }

    public class MyRequestPreProcessorV2<TRequest> : IRequestPreProcessor<TRequest>
    {
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(MyRequestPreProcessorV2<TRequest>)} Run...");
            return Task.CompletedTask;
        }
    }

    public class MyRequestPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        public Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(MyRequestPostProcessor<TRequest, TResponse>)} Run...");
            return Task.CompletedTask;
        }
    }

    public class MyRequestPostProcessorV2<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        public Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{nameof(MyRequestPostProcessorV2<TRequest, TResponse>)} Run...");
            return Task.CompletedTask;
        }
    }
}