namespace Domain.Models
{
	public class Indicator
	{
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public DateTime TimeFrom { get; private set; }
        public DateTime TimeTo { get; private set; }
        public string? Execution { get; private set; }
        public IEnumerable<Parameter>? Parameters { get; private set; }

        public Indicator() { }

        public Indicator(int id, string name, DateTime timeFrom, DateTime timeTo, string execution, IEnumerable<Parameter> parameters)
        {
            Id = id;
            Name = name;
            TimeFrom = timeFrom;
            TimeTo = timeTo;
            Execution = execution;
            Parameters = parameters;
        }

        public Indicator(string name, IEnumerable<Parameter> parameters)
        {
            if (string.IsNullOrWhiteSpace(name) || parameters?.Any() == false)
            {
                throw new ArgumentException("input parameters are not valid!");
            }

            Name = name;
            Parameters = parameters;
        }

        public Indicator(string name, string timeFrom, string timeTo, string execution, params string[] parameters)
        {
            parameters = parameters.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            if (!AreParametersValid(name, timeFrom, timeTo, execution, parameters))
            {
                throw new ArgumentException("input parameters are not valid!");
            }

            if (DateTime.TryParse(timeFrom, out DateTime parsedTimeFrom))
            {
                TimeFrom = parsedTimeFrom;
            }
            if (DateTime.TryParse(timeTo, out DateTime parsedTimeTo))
            {
                TimeTo = parsedTimeTo;
            }

            Name = name;
            Execution = execution;
            Parameters = parameters.Where((x, i) => i % 2 == 0).Select((x, i) => new Parameter(x, parameters[i + 1], true));
        }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) && Parameters != null
                && Parameters.Any(y => !string.IsNullOrWhiteSpace(y.Name));
        }

        private static bool AreParametersValid(string name, string timeFrom, string timeTo, string execution, params string[] parameters)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(execution) || string.IsNullOrWhiteSpace(timeFrom)
                || string.IsNullOrWhiteSpace(timeTo))
            {
                return false;
            }
            if (parameters == null || parameters.Length == 0 || parameters.Length % 2 == 1)
            {
                return false;
            }
            return true;
        }
    }
}