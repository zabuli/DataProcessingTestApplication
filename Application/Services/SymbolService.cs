using Application.Contract.Dtos;
using AutoMapper;
using Domain.Models;
using File;
using Interfaces.Application.Services;
using Interfaces.Repository.Database;

namespace Application.Services
{
    public class SymbolService : BaseService, ISymbolService
    {
        public SymbolService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        { }

        public bool ImportSymbolData(Stream fileStream)
        {
            try
            {
                var symbols = CsvParser.GetlData<Symbol>(fileStream, out bool isFileValid);
                if (!isFileValid || symbols?.Any() == false)
                {
                    return false;
                }

                var symbolsDto = _mapper.Map<List<SymbolDto>>(symbols);
                _unitOfWork.Symbol.Insert(symbolsDto);

                return true;
            }
            catch(Exception ex)
            {
                //logging
                return false;
            }
        }
    }
}