using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace WorkSharp
{
    public class Delay : IWorkflowTask
    {

        public IDictionary<string, dynamic> Definition { get; }
        private Interpolator Interpolator { get; }

        public string DurationExpression { get; }

        public Delay(object definition, Interpolator interpolator)
        {
            Interpolator = interpolator;
            Definition = (IDictionary<string, dynamic>)definition;
            DurationExpression = ((object)Definition["duration"]).ToString();
        }


        public async Task<object> Invoke(object context)
        {
            var durationValue = await interpolate(DurationExpression, new ContextFrame { Scope = context, Step = this });
            await Task.Delay((int)durationValue);
            return (int)durationValue;
            Task<object> interpolate<T>(string expression, T contextFrame) => Interpolator.InterpolateExpression(expression, contextFrame);
           
        }
    }
}
