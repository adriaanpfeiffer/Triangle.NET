using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleNet.Examples
{
    public static class ExampleProvider
    {
        public static List<Example> Examples()
        {
            var type = typeof(Example);
            var retrievedExampleTypes = type.Assembly.GetTypes()
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract)
                .OrderBy(t => int.Parse(t.Name.Replace("Example", "")));
            var foundExamples = new List<Example>(); 
            retrievedExampleTypes.ToList().ForEach(t =>
            {
                var example = (Example)Activator.CreateInstance(t);
                foundExamples.Add(example);
            });
            return foundExamples;
        }
    }
}
