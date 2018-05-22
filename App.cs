using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace WorkSharp
{
    class App
    {

        public Runner _runner { get; }
        public Interpolator _interpolator { get; }
        public App(Runner runner, Interpolator interpolator)
        {
            _runner = runner;
            _interpolator = interpolator;
            RunApp();
        }

        private void RunApp()
        {

            // read config
            var configText = System.IO.File.ReadAllText("sample-wf.json");
            object o = JToken.Parse(configText).ToObject<object>();

            _runner.ConstructFromDefinition(o, _interpolator);

        // run config
        }



    }
}
