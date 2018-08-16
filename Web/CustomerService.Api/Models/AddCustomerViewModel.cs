﻿using System.ComponentModel.DataAnnotations;

namespace CustomerService.Api.ViewModels
{
    public class AddCustomerViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Telephone number")]
        [Range(100000000, 999999999, ErrorMessage = "The thelephone number can only contain numbers and has to be 9 numbers long")]
        public int TelephoneNumber { get; set; }

        [Required]
        public string Address { get; set; }
    }
}