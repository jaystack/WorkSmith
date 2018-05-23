using Neleus.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSharp
{
    public class Runner
    {

        private readonly IServiceByNameFactory<ITaskFactory> _taskServices;

        public Runner(IServiceByNameFactory<ITaskFactory> taskServices)
        {
            _taskServices = taskServices;
        }

        IWorkflowTask Construct(string type, object definition, Interpolator interpolator)
        {

            //if (!TaskFactories.ContainsKey(type)) throw new ArgumentException($"invalid type ${type}");
            //return TaskFactories[type](definition, interpolator);

            ITaskFactory taskFactory = _taskServices.GetByName(type);
            return taskFactory.CreateInstance(definition);

        }

        public IWorkflowTask ConstructFromDefinition(object definition, Interpolator interpolator)
        {
            dynamic def = definition;
            string taskType = def._type;
            return Construct(taskType, definition, interpolator);
        }

    }
}
