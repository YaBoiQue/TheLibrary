using RapidTireEstimates.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace RapidTireEstimates.Models
{
    public class CustomerComment : Comment
    {
        public CustomerComment()
        {
            Customer = new Customer();
        }

        public CustomerComment(Customer customer)
        {
            if (customer != null)
            {
                CustomerId = customer.Id;
                Customer = customer;
            }

            Customer ??= new Customer();
        }

        public CustomerComment(CustomerCommentViewModel customerCommentViewModel)
        {
            if (customerCommentViewModel != null)
            {
                Id = customerCommentViewModel.Id;
                CustomerId = customerCommentViewModel.CustomerId;
                Customer = customerCommentViewModel.Customer;
                Contents = customerCommentViewModel.Contents;
                DateCreated = customerCommentViewModel.DateCreated;
            }

            Customer ??= new Customer();
        }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}