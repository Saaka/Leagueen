using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Leagueen.Application.UpdateLogs
{
    /// <summary>
    /// This factory is needed due to limitations of .NET CORE DI container. 
    /// </summary>
    public interface IUpdateTrackerFactory
    {
        IUpdateTracker<T, R> Create<T, R>()
            where T : IRequest<R>;
    }

    public class UpdateTrackerFactory : IUpdateTrackerFactory
    {
        private readonly IServiceProvider serviceProvider;

        public UpdateTrackerFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IUpdateTracker<T, R> Create<T, R>()
            where T : IRequest<R>
        {
            return serviceProvider.GetService<IUpdateTracker<T, R>>();
        }
    }
}
