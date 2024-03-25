using System.Collections.Generic;
using System.Linq;

namespace ERP.Reports.Api.ViewModels
{
    public class Endpoint
    {
        public string Name { get; }
        public IEnumerable<EndpointParameter> Parameters { get; }
        public string Path => $"/Download/{Name}";

        public string ParametersDescriptions => string.Join("; ", Parameters.Select(x => x.Caption));
        public Endpoint(string name, IEnumerable<EndpointParameter> parameters)
        {
            Name = name;
            Parameters = parameters;
        }
    }
}