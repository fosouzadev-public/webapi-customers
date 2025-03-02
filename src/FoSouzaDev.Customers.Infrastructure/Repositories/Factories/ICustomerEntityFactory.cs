using FoSouzaDev.Customers.Domain.Entities;
using FoSouzaDev.Customers.Infrastructure.Repositories.Entities;

namespace FoSouzaDev.Customers.Infrastructure.Repositories.Factories;

internal interface ICustomerEntityFactory
{
    CustomerEntity CustomerToCustomerEntity(Customer customer);
    Customer CustomerEntityToCustomer(CustomerEntity customerEntity);
}