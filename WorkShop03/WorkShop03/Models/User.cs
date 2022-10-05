using Microsoft.AspNetCore.Identity;

namespace WorkShop03.Models
{
    public class User : IdentityUser
    {


        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int MinimumPay { get; set; }

    }
}
 