using DataProcessingApplication.Models;
using Domain.Models;

namespace DataProcessingApplication.Helpers
{
	public static class ModelMapperHelper
	{
		public static Query GetQuery(QueryModel queryModel)
		{
			return new Query
			{
				Symbols = new List<Symbol> { new Symbol(queryModel.Symbol.Name, queryModel.Symbol.TimeFrom, queryModel.Symbol.TimeTo) },
				Indicators = queryModel.Indicators.Select(x => new Indicator(x.Name, x.Parameters.Select(y => new Parameter(y.Name, y.Value))))
            };
		}
	}
}