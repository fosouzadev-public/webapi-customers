using FoSouzaDev.Customers.Application.DataTransferObjects;
using FoSouzaDev.Customers.Domain.Entities;

namespace FoSouzaDev.Customers.Application.Factories;

public interface ICustomerFactory
{
    CustomerDto CustomerToCustomerDto(Customer customer);
    Customer AddCustomerDtoToCustomer(AddCustomerDto addCustomerDto);
    EditCustomerDto CustomerToEditCustomerDto(Customer customer);
}