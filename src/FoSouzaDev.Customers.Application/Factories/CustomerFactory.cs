﻿using FoSouzaDev.Customers.Application.DataTransferObjects;
using FoSouzaDev.Customers.Domain.Entities;
using FoSouzaDev.Customers.Domain.ValueObjects;

namespace FoSouzaDev.Customers.Application.Factories;

internal class CustomerFactory : ICustomerFactory
{
    public CustomerDto CustomerToCustomerDto(Customer customer) => new()
    {
        Id = customer.Id,
        Name = customer.FullName.Name,
        LastName = customer.FullName.LastName,
        BirthDate = customer.BirthDate.Date,
        Email = customer.Email.Value,
        Notes = customer.Notes
    };

    public Customer AddCustomerDtoToCustomer(AddCustomerDto addCustomerDto) => new()
    {
        Id = string.Empty,
        FullName = new FullName(addCustomerDto.Name, addCustomerDto.LastName),
        BirthDate = new BirthDate(addCustomerDto.BirthDate),
        Email = new Email(addCustomerDto.Email),
        Notes = addCustomerDto.Notes
    };

    public EditCustomerDto CustomerToEditCustomerDto(Customer customer) => new()
    {
        Name = customer.FullName.Name,
        LastName = customer.FullName.LastName,
        Notes = customer.Notes
    };
}