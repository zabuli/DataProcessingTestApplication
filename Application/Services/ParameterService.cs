using Application.Contract.Dtos;
using AutoMapper;
using Domain.Models;
using Interfaces.Application.Services;
using Interfaces.Repository.Database;

namespace Application.Services
{
    public class ParameterService : BaseService, IParameterService
    {
        public ParameterService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        { }

        public IEnumerable<Parameter>? StoreParameters(int userId, Indicator indicator)
        {
            if (indicator == null || string.IsNullOrWhiteSpace(indicator.Name) || indicator.Parameters?.Any() == false)
            {
                throw new ArgumentNullException("indicator");
            }

            var indicatorDto = _unitOfWork.Indicator.GetIndicator(indicator.Name, indicator.TimeFrom, indicator.TimeTo);
            if (indicatorDto == null)
            {
                throw new ArgumentException("Input parameters are invalid!");
            }
            if (indicatorDto.Parameters?.Any() == false)
            {
                throw new InvalidDataException("Data for indicator are invalid!");
            }

            var indicatorWithDefaultValues = _mapper.Map<Indicator>(indicatorDto);
            var indicatorDtoWithUserValues = _unitOfWork.Indicator.GetIndicatorsByName(indicator.Name, userId)?
                                            .FirstOrDefault(x => x.TimeFrom >= indicator.TimeFrom && x.TimeTo <= indicator.TimeTo);

            if (indicatorDtoWithUserValues == null || indicatorDtoWithUserValues.Parameters?.Any() == false)
            {
                return CreateParameters(indicatorWithDefaultValues, indicator);
            }
            else
            {
                var indicatorWithUserValues = _mapper.Map<Indicator>(indicatorDtoWithUserValues);
                return UpdateParameters(indicatorWithUserValues, indicator);
            }
        }

        public IEnumerable<Parameter>? CreateParameters(Indicator indicatorWithDefaultValues, Indicator indicator)
        {
            if (indicatorWithDefaultValues.Parameters == null || !indicatorWithDefaultValues.Parameters.Any() ||
                 indicator.Parameters == null || !indicator.Parameters.Any())
            {
                return null;
            }

            Parameter userParameter; var parameters = indicatorWithDefaultValues.Parameters.ToList();
            foreach (var parameter in parameters)
            {
                userParameter = indicator.Parameters.FirstOrDefault(x => x.Name.Equals(parameter.Name, StringComparison.InvariantCultureIgnoreCase));
                if (userParameter != null)
                {
                    parameter.SetValue(userParameter.Value);
                }

            }
            var parametersDto = _unitOfWork.Parameter.Insert(_mapper.Map<List<ParameterDto>>(parameters));
            return _mapper.Map<List<Parameter>>(parametersDto);
        }

        public IEnumerable<Parameter>? UpdateParameters(Indicator indicatorWithUserValues, Indicator indicator)
        {
            if (indicatorWithUserValues.Parameters == null || !indicatorWithUserValues.Parameters.Any() ||
                indicator.Parameters == null || !indicator.Parameters.Any())
            {
                return null;
            }

            Parameter userParameter;
            var parameters = indicatorWithUserValues.Parameters.ToList();
            foreach (var parameter in parameters)
            {
                userParameter = indicator.Parameters.FirstOrDefault(x => x.Name.Equals(parameter.Name, StringComparison.InvariantCultureIgnoreCase));
                if (userParameter != null)
                {
                    parameter.SetValue(userParameter.Value);
                }

            }
            var parametersDto = _unitOfWork.Parameter.Update(_mapper.Map<List<ParameterDto>>(parameters));
            return _mapper.Map<List<Parameter>>(parametersDto);
        }
    }
}