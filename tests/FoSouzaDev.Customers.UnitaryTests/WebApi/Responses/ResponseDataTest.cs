﻿using AutoFixture;
using FluentAssertions;
using FoSouzaDev.Customers.CommonTests;
using FoSouzaDev.Customers.WebApi.Responses;

namespace FoSouzaDev.Customers.UnitaryTests.WebApi.Responses;

public sealed class ResponseDataTest : BaseTest
{
    [Fact]
    public void Constructor_SuccessWithData_CreateAnObject()
    {
        // Arrange
        string expectedData = Fixture.Create<string>();

        // Act
        ResponseData<string> responseData = new(data: expectedData);

        // Assert
        responseData.Data.Should().Be(expectedData);
        responseData.ErrorMessage.Should().BeNull();
    }

    [Fact]
    public void Constructor_SuccessWithErrorMessage_CreateAnObject()
    {
        // Arrange
        string expectedErrorMessage = Fixture.Create<string>();

        // Act
        ResponseData<string> responseData = new(errorMessage: expectedErrorMessage);

        // Assert
        responseData.Data.Should().BeNull();
        responseData.ErrorMessage.Should().Be(expectedErrorMessage);
    }

    [Fact]
    public void Constructor_SuccessWithDataAndErrorMessage_CreateAnObject()
    {
        // Arrange
        string expectedData = Fixture.Create<string>();
        string expectedErrorMessage = Fixture.Create<string>();

        // Act
        ResponseData<string> responseData = new(expectedData, expectedErrorMessage);

        // Assert
        responseData.Data.Should().Be(expectedData);
        responseData.ErrorMessage.Should().Be(expectedErrorMessage);
    }

    [Fact]
    public void Constructor_InvalidData_ThrowArgumentNullException()
    {
        // Act
        Action act = () => new ResponseData<string>(null, null);

        // Assert
        act.Should().ThrowExactly<ArgumentNullException>().WithMessage("Invalid data.");
    }
}