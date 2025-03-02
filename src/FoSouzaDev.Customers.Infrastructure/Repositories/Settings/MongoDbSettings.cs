namespace FoSouzaDev.Customers.Infrastructure.Repositories.Settings;

internal sealed class MongoDbSettings
{
    public string ConnectionUri { get; init; }
    public string DatabaseName { get; init; }
}