using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkShop03.Models
{
    public class User : IdentityUser
    {


        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int MinimumPay { get; set; }

        public virtual List<Advertisement> Subscribed { get; set; }

        public User() : base()
        {
            Subscribed = new List<Advertisement>();
        }

    }
}
 