using Microsoft.Extensions.DependencyInjection;
using Neleus.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSharp
{
    class Program
    {
        static void Main(string[] args)
        {
        
            //setup our DI
            var services = new ServiceCollection();

            services.AddSingleton<App>();
            services.AddTransient<Runner>();
            services.AddSingleton<Interpolator>();

            services.AddTransient<TaskFactory<ConsoleWrite>>();
            services.AddTransient<TaskFactory<Sequence>>();
            services.AddTransient<TaskFactory<Assign>>();
            services.AddTransient<TaskFactory<Delay>>();
            services.AddTransient<TaskFactory<HttpGet>>();

            services.AddByName<ITaskFactory>()
                .Add<TaskFactory<ConsoleWrite>>("ConsoleWrite")
                .Add<TaskFactory<Sequence>>("Sequence")
                .Add<TaskFactory<Assign>>("Assign")
                .Add<TaskFactory<Delay>>("Delay")
                .Add<TaskFactory<HttpGet>>("HttpGet")
                .Build();

            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<App>();

        }

    }
}
