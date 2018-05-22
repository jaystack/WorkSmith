using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSharp
{
    public delegate IWorkflowTask CreateStep(object definition, Interpolator interpolator);

    public static class IOC
    {
        public static readonly Dictionary<string, CreateStep> TaskFactories = new Dictionary<string, CreateStep>();
        static IOC()
        {
            Interpolator i = new Interpolator();
            TaskFactories.Add("ConsoleWrite", (definition, interpolator) => new ConsoleWrite(definition, interpolator));
            TaskFactories.Add("Sequence", (definition, interpolator) => new Sequence(definition, interpolator));
            TaskFactories.Add("Assign", (definition, interpolator) => new Assign(definition, interpolator));
            TaskFactories.Add("Delay", (definition, interpolator) => new Delay(definition, interpolator));
            TaskFactories.Add("HttpGet", (definition, interpolator) => new HttpGet(definition, interpolator));
        }

        static IWorkflowTask Construct(string type, object definition, Interpolator interpolator)
        {
            if (!TaskFactories.ContainsKey(type)) throw new ArgumentException($"invalid type ${type}");

            return TaskFactories[type](definition, interpolator);
        }

        public static IWorkflowTask ConstructFromDefinition(object definition, Interpolator interpolator)
        {
            dynamic def = definition;
            string taskType = def._type;
            return Construct(taskType, definition, interpolator);
        }
    }
}
