﻿using AutoFixture;
using FluentAssertions;
using FoSouzaDev.Customers.CommonTests;
using FoSouzaDev.Customers.Domain.Exceptions;

namespace FoSouzaDev.Customers.UnitaryTests.Domain.Exceptions;

public sealed class ValidateExceptionTest : BaseTest
{
    [Fact]
    public void Constructor_Success_CreateAnException()
    {
        // Arrange
        string expectedMessage = Fixture.Create<string>();

        // Act
        ValidateException ex = new(expectedMessage);

        // Assert
        ex.Message.Should().Be(expectedMessage);
    }
}