namespace ERP.Reports.Api.ViewModels
{
    public class EndpointParameter
    {
        public string Name { get; }
        public string Type { get; }

        public string Caption => $"{Name}:{Type}";

        public EndpointParameter(string name, string type)
        {
            Name = name;
            Type = type;
        }

    }
}