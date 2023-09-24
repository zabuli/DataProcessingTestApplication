namespace Domain.Models
{
	public class Query
	{
		public IEnumerable<Symbol> Symbols { get; set; }
		public IEnumerable<Indicator> Indicators { get; set; }

        public bool IsValid()
        {
            if (Symbols?.Any() == false)
            {
                return false;
            }
            if (Indicators?.Any() == false)
            {
                return false;
            }

            return true;
        }
    }
}