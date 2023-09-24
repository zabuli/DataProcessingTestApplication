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

        public IEnumerable<IndicatorDto>? GetSymbolIndicators(SymbolDto symbol, IEnumerable<IndicatorDto> indicators)
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
                                    .Where(x => x.SymbolId == symbol.Id && indicatorsNames.Contains(x.Name) && x.TimeFrom >= symbol.TimeFrom && x.TimeTo <= symbol.TimeTo)
                                    .Include(x => x.Parameters).ToList();
            if (indicatorsDtos == null || !indicatorsDtos.Any())
            {
                return null;
            }

            return IndicatorHelper.GetFilteredIndicators(indicators, indicatorsDtos);
        }
    }
}