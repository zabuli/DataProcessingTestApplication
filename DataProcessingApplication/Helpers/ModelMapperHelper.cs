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

		public static Indicator GetIndicator(IndicatorModel indicatorModel, int userId)
		{
			return new Indicator(0, indicatorModel.Name, indicatorModel.TimeFrom, indicatorModel.TimeTo, "",
				indicatorModel.Parameters.Select(x => new Parameter(x.Name, x.Value, userId)));
        }
	}
}