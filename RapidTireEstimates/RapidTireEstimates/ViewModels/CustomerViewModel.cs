﻿using System.Security.Cryptography.X509Certificates;
using RapidTireEstimates.Models;
using static RapidTireEstimates.Helpers.Constants;

namespace RapidTireEstimates.ViewModels
{
    public class CustomerViewModel : Customer
    {
        public CustomerViewModel()
        {
            Customer = new Customer();
            Customers = new List<Customer>();
            Estimates = new List<Estimate>();
            Comments = new List<CustomerComment>();
            Vehicles = new List<Vehicle>();

            ReturnController = "Customers";
            ReturnAction = "Index";
            ReturnId = "";

            FilterBy = "";
        }

        public CustomerViewModel(Customer customer)
        {
            if (customer != null)
            {
                Customer = customer;

                Id = customer.Id;
                Name = customer.Name;
                PhoneNumber = customer.PhoneNumber;
                Estimates = customer.Estimates;
                Comments = customer.Comments;
                Vehicles = customer.Vehicles;
            }

            Customer ??= new Customer();

            Customers ??= new List<Customer>();

            ReturnController = "Customers";
            ReturnAction = "Index";
            ReturnId = "";

            FilterBy = "";

        }

        //Storage Variables
        public Customer Customer { get; set; }

        //Customer List
        public IEnumerable<Customer> Customers { get; set; }

        //Return Address Values (for dynamic return feature)
        public string ReturnController { get; set; }
        public string ReturnAction { get; set; }
        public string ReturnId { get; set; }

        //Filter/Sort Values (for filter/sort feature)
        public string FilterBy { get; internal set; }
        public SortByParameter SortBy { get; set; }
        public SortByParameter SortByName { get; set; }
        public SortByParameter SortByPhoneNumber { get; set; }
    }
}
