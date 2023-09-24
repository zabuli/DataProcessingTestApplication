namespace Application.Contract.Dtos;

public class IndicatorDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime TimeFrom { get; set; }
    public DateTime TimeTo { get; set; }
    public string? Execution { get; set; }
    public ICollection<ParameterDto>? Parameters { get; set; }
}