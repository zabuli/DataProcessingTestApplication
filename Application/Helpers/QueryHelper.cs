using Application.Contract.Dtos;

namespace Application.Helpers
{
	internal static class QueryHelper
	{
        public static SymbolDto GetSymbol(IEnumerable<SymbolDto> symbolsDto)
        {
            var symbolDto = symbolsDto.First();
            symbolDto.TimeFrom = symbolsDto.Select(x => x.TimeFrom).OrderBy(x => x).First();
            symbolDto.TimeTo = symbolsDto.Select(x => x.TimeTo).OrderBy(x => x).Last();
            return symbolDto;
        }
    }
}