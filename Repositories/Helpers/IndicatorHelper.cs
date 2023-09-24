using Application.Contract.Dtos;

namespace Repository.Helpers
{
	internal static class IndicatorHelper
	{
        public static IEnumerable<IndicatorDto> GetFilteredIndicators(IEnumerable<IndicatorDto> indicatorsFromSource, IEnumerable<IndicatorDto> indicatorsFromDB)
        {
            return indicatorsFromDB.Where(x => IsFilteredIndicator(x, indicatorsFromSource));
        }

        private static bool IsFilteredIndicator(IndicatorDto indicatorFromDB, IEnumerable<IndicatorDto> indicatorsFromSource)
        {
            if (indicatorFromDB.Parameters == null || !indicatorFromDB.Parameters.Any())
            {
                return false;
            }

            return indicatorsFromSource.Any(x => IsSameIndicator(x, indicatorFromDB) &&
                x.Parameters != null && x.Parameters.Any() &&
                x.Parameters.Any(y => indicatorFromDB.Parameters.Any(z => IsSameParameter(z, y))));
        }

        private static bool IsSameIndicator(IndicatorDto indicatorFromSource, IndicatorDto indicatorFromDB)
        {
            return !string.IsNullOrEmpty(indicatorFromSource.Name) && !string.IsNullOrEmpty(indicatorFromDB.Name)
            && indicatorFromSource.Name.Equals(indicatorFromDB.Name, StringComparison.OrdinalIgnoreCase);
        }

        private static bool IsSameParameter(ParameterDto parameterFromSource, ParameterDto parameterFromDB)
        {
            return !string.IsNullOrEmpty(parameterFromSource.Name) && !string.IsNullOrEmpty(parameterFromDB.Name)
                && parameterFromSource.Name.Equals(parameterFromDB.Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}