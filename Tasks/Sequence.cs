using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace WorkSharp
{
    public class Sequence : IWorkflowTask
    {
        private Interpolator Interpolator { get; }
        public List<IWorkflowTask> Items { get; }
        public IDictionary<string, dynamic> Definition { get; }

        public Sequence(object definition, Interpolator interpolator)
        {
            Interpolator = interpolator;
            Definition = (IDictionary<string, dynamic>)definition;
            IEnumerable<object> items = (IEnumerable<dynamic>)Definition["items"];
            Items = items.Select(item => IOC.ConstructFromDefinition(item, interpolator)).ToList();

        }

        public async Task<object> Invoke(object context)
        {
            dynamic ctx = context;

            foreach (var item in Items)
            {
                var itemResult = await item.Invoke(context);
                if (item.Definition.ContainsKey("_resultTo"))
                {
                    var key = item.Definition["_resultTo"];
                    await Interpolator.InterpolateExpression($"{key} = Marshal.Result",
                        new ContextAssignmentFrame { Scope = context, Marshal = new Marshal { Result = itemResult } });
                }
            }
            return await Task.FromResult((object)true);
        }
    }
}
