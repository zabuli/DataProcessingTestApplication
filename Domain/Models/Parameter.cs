namespace Domain.Models
{
    public class Parameter
    {
        public int Id { get; private set; }
        public int? UserId { get; private set; }
        public string? Name { get; private set; }
        public string? Value { get; private set; }
        public bool IsDefault { get; private set; }

        public int IndicatorId { get; private set; }
        public Indicator? Indicator { get; private set; }

        public Parameter() { }

        public Parameter(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}