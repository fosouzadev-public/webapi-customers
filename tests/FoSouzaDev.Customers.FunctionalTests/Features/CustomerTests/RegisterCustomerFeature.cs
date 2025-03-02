﻿using System.Text;
using AutoFixture;
using FluentAssertions;
using FoSouzaDev.Customers.Application.DataTransferObjects;
using FoSouzaDev.Customers.CommonTests;
using FoSouzaDev.Customers.Domain.Entities;
using FoSouzaDev.Customers.WebApi.Responses;
using Newtonsoft.Json;
using Xunit.Gherkin.Quick;

namespace FoSouzaDev.Customers.FunctionalTests.Features.CustomerTests;

[FeatureFile("./Features/CustomerTests/RegisterCustomer.feature")]
public sealed class RegisterCustomerFeature(MongoDbFixture mongoDbFixture) : BaseCustomerFeature(mongoDbFixture)
{
    private AddCustomerDto _customerDto;

    [Given("I choose valid random data for a new customer")]
    public void GenerateValidCustomerData()
    {
        _customerDto = Fixture.Build<AddCustomerDto>()
            .With(a => a.BirthDate, ValidDataGenerator.ValidBirthDate)
            .With(a => a.Email, ValidDataGenerator.ValidEmail)
            .Create();
    }

    [Given("I choose valid random data for a new customer, but I choose an existing email address")]
    public async Task GenerateValidCustomerDataWithExistingEmail()
    {
        GenerateValidCustomerData();

        Customer currentCustomer = ApplicationFactory.AddCustomerDtoToCustomer(_customerDto);
        await Repository.AddAsync(currentCustomer);
    }

    [Given("I choose the data for a new customer with an invalid (.*)")]
    public void GenerateInvalidCustomerData(string invalidData)
    {
        _customerDto = Fixture.Build<AddCustomerDto>()
            .With(a => a.Name, invalidData == "name" ? string.Empty : Fixture.Create<string>())
            .With(a => a.LastName, invalidData == "last name" ? string.Empty : Fixture.Create<string>())
            .With(a => a.BirthDate, invalidData == "date of birth" ? DateTime.Now.Date : ValidDataGenerator.ValidBirthDate)
            .With(a => a.Email, invalidData == "email" ? string.Empty : ValidDataGenerator.ValidEmail)
            .Create();
    }

    [When("I send a registration request")]
    public async Task SendRegistrationRequest()
    {
        StartApplication();

        using StringContent jsonContent = new(JsonConvert.SerializeObject(_customerDto), Encoding.UTF8, "application/json");
        HttpResponse = await HttpClient.PostAsync(Route, jsonContent);
    }

    [And("The response contains the inserted id")]
    public async Task ValidateResponseData()
    {
        ResponseData<string> responseData = await GetResponseDataAsync<string>();

        responseData.Should().NotBeNull();
        responseData.Data.Should().NotBeNull();
        responseData.ErrorMessage.Should().BeNull();

        CustomerId = responseData.Data;
    }

    [And("The customer must exist in the database")]
    public async Task ValidateDatabase()
    {
        Customer customer = await Repository.GetByIdAsync(CustomerId);
        customer.Should().NotBeNull();

        Customer expectedCustomer = ApplicationFactory.AddCustomerDtoToCustomer(_customerDto);
        expectedCustomer.Id = CustomerId;
        
        customer.Should().BeEquivalentTo(expectedCustomer);
    }
}