namespace FoSouzaDev.Customers.Application.DataTransferObjects;

public sealed record EditCustomerDto
{
    public string Name { get; init; }
    public string LastName { get; init; }
    public string Notes { get; init; }
}