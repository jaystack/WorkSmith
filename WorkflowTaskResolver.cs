using System;
using System.Collections.Generic;
using System.Text;

namespace WorkSharp
{
    public class WorkflowTaskResolver
    {
  
        private IServiceProvider Provider { get; }
        public WorkflowTaskResolver(IServiceProvider provider)
        {
            Provider = provider;
        }

        //public static IWorkflowTask CreateFromJsonDefinition(object definition)
        //{
        //    dynamic def = definition;
        //    string taskType = def._type;
        //    var type = TaskTypes[taskType];
        //    var instance = 
        //}
    }
}
