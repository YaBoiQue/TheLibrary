using System.Security.Cryptography.X509Certificates;
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
            Customers = new List<Customer>();
            Estimates ??= new List<Estimate>();
            Comments ??= new List<CustomerComment>();
            Vehicles ??= new List<Vehicle>();

        }


        public virtual Customer Customer { get; set; }
        public IEnumerable<Customer> Customers { get; internal set; }


        public string? FilterBy { get; set; }
        public SortByParameter SortBy { get; set; }
        public SortByParameter SortByName { get; set; }
        public SortByParameter SortByPhoneNumber { get; set; }

        public string? ReturnController { get; set; }
        public string? ReturnAction { get; set; }
        public string? ReturnUrl { get; set;}
    }
}
