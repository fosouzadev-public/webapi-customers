using FluentAssertions;
using FoSouzaDev.Customers.CommonTests;
using Xunit.Gherkin.Quick;

namespace FoSouzaDev.Customers.FunctionalTests.Features;

[FeatureFile("./Features/HealthCheck.feature")]
public sealed class HealthCheckFeature(MongoDbFixture mongoDbFixture) : BaseFeature(mongoDbFixture)
{
    [Given("All dependencies are ok")]
    public void DependenciesOk()
    {
        StartApplication();
    }

    [Given("Database unavailable")]
    public void DatabaseUnavailable()
    {
        DefaultConfiguration["MongoDbSettings:ConnectionURI"] = "mongodb://test:test@localhost:27017";

        StartApplication();
    }

    [When("I send the request")]
    public async Task SendRequest()
    {
        HttpResponse = await HttpClient.GetAsync("api/health-check");
    }

    [And("The response data must be (.*)")]
    public async Task ValidateResponseData(string expectedData)
    {
        string data = await HttpResponse.Content.ReadAsStringAsync();

        data.Should().Be(expectedData);
    }
}