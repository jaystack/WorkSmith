using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WorkSharp
{
    public class Assign : IWorkflowTask
    {

        public IDictionary<string, dynamic> Definition { get; }
        private Interpolator Interpolator { get; }
        public string Name { get; }
        public string Expression { get; }

        public Assign(object definition, Interpolator interpolator)
        {
            Interpolator = interpolator;
            Definition = (IDictionary<string, dynamic>)definition;
            Name = Definition["name"];
            Expression = Definition["expression"];
        }


        public async Task<object> Invoke(object context)
        {
            var expressionValue = await interpolate(Expression, new ContextFrame { Scope = context, Step = this });
            await interpolate($"{Name} = Marshal.Result", new ContextAssignmentFrame(context, expressionValue));
            return true;

            Task<object> interpolate<T>(string expression, T contextFrame) => Interpolator.InterpolateExpression(expression, contextFrame);
           
        }
    }
}
