namespace DataProcessingApplication.Models
{
	public class QueryModel
	{
		public SymbolModel Symbol { get; set; }
		public IndicatorModel[] Indicators { get; set; }
    }
}