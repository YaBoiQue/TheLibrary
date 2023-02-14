using RapidTireEstimates.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace RapidTireEstimates.Models
{
    public class Customer
    {
        public Customer()
        {
            Estimates = new List<Estimate>();
            Comments = new List<CustomerComment>();
            Vehicles = new List<Vehicle>();
        }

        public Customer(Customer customer)
        {
            if (customer != null)
            {
                Id = customer.Id;
                Name = customer.Name;
                PhoneNumber = customer.PhoneNumber;
                Estimates = customer.Estimates;
                Comments = customer.Comments;
                Vehicles = customer.Vehicles;
            }

            Estimates ??= new List<Estimate>();

            Comments ??= new List<CustomerComment>();

            Vehicles ??= new List<Vehicle>();
        }

        public Customer(CustomerViewModel customerViewModel)
        {
            if (customerViewModel != null)
            {
                Id = customerViewModel.Id;
                Name = customerViewModel.Name;
                PhoneNumber = customerViewModel.PhoneNumber;
                Estimates = customerViewModel.Estimates;
                Comments = customerViewModel.Comments;
                Vehicles = customerViewModel.Vehicles;
            }

            Estimates ??= new List<Estimate>();

            Comments ??= new List<CustomerComment>();

            Vehicles ??= new List<Vehicle>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        public IEnumerable<Estimate> Estimates { get; set; }
        public IEnumerable<CustomerComment> Comments { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}