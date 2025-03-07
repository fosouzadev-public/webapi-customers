﻿using FluentAssertions;
using FoSouzaDev.Customers.CommonTests;
using FoSouzaDev.Customers.Domain.Entities;
using Xunit.Gherkin.Quick;

namespace FoSouzaDev.Customers.FunctionalTests.Features.CustomerTests;

[FeatureFile("./Features/CustomerTests/DeleteCustomer.feature")]
public sealed class DeleteCustomerFeature(MongoDbFixture mongoDbFixture) : BaseCustomerFeature(mongoDbFixture)
{
    [When("I send the deletion request")]
    public async Task SendDeletionRequest()
    {
        StartApplication();

        HttpResponse = await HttpClient.DeleteAsync($"{Route}/{CustomerId}");
    }

    [And("The customer must not exist in the database")]
    public async Task ValidateDatabase()
    {
        Customer customer = await Repository.GetByIdAsync(CustomerId);
        customer.Should().BeNull();
    }
}