using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorkSharp
{
    public class ConsoleWrite : IWorkflowTask
    {
        
        public IDictionary<string, dynamic> Definition { get; }
        public Interpolator Interpolator { get; }

        public string MessageExpression { get; }

        public ConsoleWrite(object definition, Interpolator interpolator)
        {
            Interpolator = interpolator;
            Definition = (IDictionary<string, dynamic>)definition;

            MessageExpression = Definition["message"];
        }

        public async Task<object> Invoke(object context)
        {
            var interpolatedMessage = await Interpolator.InterpolateExpression(MessageExpression,
                new ContextFrame { Scope = context, Step = this });
            Console.WriteLine(interpolatedMessage);
            return interpolatedMessage;
        }

    }

}
