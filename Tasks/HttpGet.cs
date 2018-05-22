using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WorkSharp
{
    public class HttpGet : IWorkflowTask
    {

        public IDictionary<string, dynamic> Definition { get; }
        private Interpolator Interpolator { get; }
        public string UrlExpression { get; }
        public string IsJSONExpression { get; }

        public HttpGet(object definition, Interpolator interpolator)
        {
            Interpolator = interpolator;
            Definition = (IDictionary<string, dynamic>)definition;
            UrlExpression = Definition["url"];
            IsJSONExpression = Definition.ContainsKey("isJSON") ? Definition["isJSON"] : "true";
        }


        public async Task<object> Invoke(object context)
        {
            var contextFrame = new ContextFrame { Scope = context, Step = this };
            var url = (string)await interpolate(UrlExpression);
            var isJSON = (bool)await interpolate(IsJSONExpression);
            var client = new HttpClient();
            Console.WriteLine($"Request with HTTP GET from: ${url}... hold your horses.");
            var response = await client.GetAsync(url);
            var resultString = await response.Content.ReadAsStringAsync();
            if (!isJSON)
            {
                return resultString;
            }
            return JsonConvert.DeserializeObject<dynamic>(resultString);

            Task<object> interpolate(string expression) => Interpolator.InterpolateExpression(expression, contextFrame);
           
        }
    }
}
