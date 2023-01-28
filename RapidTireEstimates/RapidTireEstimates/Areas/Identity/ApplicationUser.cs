using Microsoft.AspNetCore.Identity;

namespace RapidTireEstimates.Areas.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            FirstName = "";
            LastName = "";
        }

        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
    }
}
