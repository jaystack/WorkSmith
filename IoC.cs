using Microsoft.Extensions.DependencyInjection;
using Neleus.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSharp
{
    //public delegate IWorkflowTask CreateStep(object definition, Interpolator interpolator);
    

    //public class IOC
    //{
    //    //public readonly Dictionary<string, CreateStep> TaskFactories = new Dictionary<string, CreateStep>();
    //    private readonly Interpolator _interpolator;
    //    private readonly IServiceByNameFactory<IWorkflowTask> _taskServices;

    //    IOC(Interpolator interpolator, IServiceByNameFactory<IWorkflowTask> taskServices)
    //    {

    //        //Interpolator i = new Interpolator();
    //        //TaskFactories.Add("ConsoleWrite", (definition, interpolator) => new ConsoleWrite(definition, interpolator));
    //        //TaskFactories.Add("Sequence", (definition, interpolator) => new Sequence(definition, interpolator));
    //        //TaskFactories.Add("Assign", (definition, interpolator) => new Assign(definition, interpolator));
    //        //TaskFactories.Add("Delay", (definition, interpolator) => new Delay(definition, interpolator));
    //        //TaskFactories.Add("HttpGet", (definition, interpolator) => new HttpGet(definition, interpolator));

    //        _interpolator = interpolator;
    //        _taskServices = taskServices;

    //    }

    //    IWorkflowTask Construct(string type, object definition, Interpolator interpolator)
    //    {

    //        //if (!TaskFactories.ContainsKey(type)) throw new ArgumentException($"invalid type ${type}");
    //        //return TaskFactories[type](definition, interpolator);

    //        IWorkflowTask task = _taskServices.GetByName(type);

    //    }

    //    public  IWorkflowTask ConstructFromDefinition(object definition, Interpolator interpolator)
    //    {
    //        dynamic def = definition;
    //        string taskType = def._type;
    //        return Construct(taskType, definition, interpolator);
    //    }

    //    internal class ServiceCollection : List<ServiceDescriptor>, IServiceCollection
    //    {
    //    }

    //}
}
