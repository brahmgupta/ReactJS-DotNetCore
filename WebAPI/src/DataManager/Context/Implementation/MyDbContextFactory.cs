using System;
using Microsoft.Extensions.DependencyInjection;
using DataManager.Context.Contracts;

namespace DataManager.Context.Implementation
{
    public class MyDbContextFactory : IMyDbContextFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public MyDbContextFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IMyDbContext CreateMyDbContext()
        {
            return _serviceProvider.GetRequiredService<IMyDbContext>();
        }
    }
}
