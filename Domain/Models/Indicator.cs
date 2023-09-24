namespace Domain.Models
{
	public class Indicator
	{
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public int SymbolId { get; private set; }
        public DateTime TimeFrom { get; private set; }
        public DateTime TimeTo { get; private set; }
        public string? Execution { get; private set; }
        public IEnumerable<Parameter>? Parameters { get; private set; }

        public Indicator() { }

        public Indicator(string name, IEnumerable<Parameter> parameters)
        {
            Name = name;
            Parameters = parameters;
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) && Parameters != null
                && Parameters.Any(y => !string.IsNullOrWhiteSpace(y.Name));
        }
    }
}