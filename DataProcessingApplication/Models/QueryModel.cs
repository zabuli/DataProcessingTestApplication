namespace DataProcessingApplication.Models
{
	public class QueryModel
	{
		public SymbolModel Symbol { get; set; }
		public SymbolIndicatorModel[] Indicators { get; set; }
    }
}