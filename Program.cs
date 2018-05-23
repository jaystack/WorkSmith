using Microsoft.Extensions.DependencyInjection;
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
            var workSharp = new WorkSharp();
            var serviceProvider = workSharp.Provider;

            // start app
            var application = serviceProvider.GetService<App>();
            application.RunAppAsync().Wait();

            // wait
            do
            {
                while (!Console.KeyAvailable)
                {
                    // Do something
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }

    }
}
