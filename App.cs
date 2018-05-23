using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace WorkSharp
{
    class App
    {
        public WorkSharp _workSharp;
        public Interpolator _interpolator;
        public App(WorkSharp workSharp, Interpolator interpolator)
        {
            _workSharp = workSharp;
            _interpolator = interpolator;
        }

        public async Task RunAppAsync()
        {

            // read config
            var configText = System.IO.File.ReadAllText("sample-wf.json");
            object o = JToken.Parse(configText).ToObject<object>();

            // run config
            var intance = _workSharp.CreateFromJSON(o);
            var itemResult = await intance.Invoke(new ExpandoObject());

        }



    }
}
