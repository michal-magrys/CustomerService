﻿using CustomerService.Api.ViewModels;
using System.Threading.Tasks;

namespace CustomerService.Api.Abstract
{
    public interface ICustomerService
    {
        Task<EditCustomerViewModel> GetCustomerAsync(string id);

        Task<CustomersViewModel> GetCustomersAsync();

        Task<CustomerViewModel> AddCustomerAsync(AddCustomerViewModel model);

        Task<CustomerViewModel> EditCustomerAsync(EditCustomerViewModel model);

        Task<bool> RemoveCustomerAsync(string id);
    }
}