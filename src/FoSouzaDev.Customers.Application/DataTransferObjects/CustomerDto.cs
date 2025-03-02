namespace FoSouzaDev.Customers.Application.DataTransferObjects;

public sealed record CustomerDto
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required string LastName { get; init; }
    public required DateTime BirthDate { get; init; }
    public required string Email { get; init; }
    public string Notes { get; init; }
}