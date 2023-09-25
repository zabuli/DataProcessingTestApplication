using Application.Contract.Dtos;
using Interfaces.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Database;
using Repository.Helpers;

namespace Repository.Repositories
{
	public class IndicatorRepository : GenericRepository<IndicatorDto>, IIndicatorRepository
    {
        public IndicatorRepository(MyDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<IndicatorDto>? GetSymbolIndicators(DateTime timeFrom, DateTime timeTo, IEnumerable<IndicatorDto> indicators)
        {
            if (!indicators.Any())
            {
                return null;
            }

            var indicatorsNames = indicators.Select(x => x.Name);
            if (indicatorsNames == null || !indicatorsNames.Any())
            {
                return null;
            }

            var indicatorsDtos = DbContext?.Indicator?
                                    .Where(x => indicatorsNames.Contains(x.Name) && x.TimeFrom >= timeFrom && x.TimeTo <= timeTo)
                                    .Include(x => x.Parameters).ToList();
            if (indicatorsDtos == null || !indicatorsDtos.Any())
            {
                return null;
            }

            return IndicatorHelper.GetFilteredIndicators(indicators, indicatorsDtos);
        }

        public IEnumerable<IndicatorDto>? GetIndicatorsByName(string? name, int? userId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            return DbContext?.Indicator?.Where(x => name.Equals(x.Name))
                        .Include(x => x.Parameters.Where(y => y.UserId == userId));
        }

        public IndicatorDto? GetIndicator(string? name, DateTime timeFrom, DateTime timeTo)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            return DbContext?.Indicator?
                .Include(x => x.Parameters)
                .FirstOrDefault(x => name.Equals(x.Name) && x.TimeFrom >= timeFrom && x.TimeTo <= timeTo);
        }
     }
}