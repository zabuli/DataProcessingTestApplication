namespace Application.Contract.Dtos;

public class ParameterDto
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public string? Name { get; set; }
    public string? Value { get; set; }
    public bool IsDefault { get; set; }

    public int IndicatorId { get; set; }
    public IndicatorDto? Indicator { get; set; }
}