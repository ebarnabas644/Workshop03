using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkShop03.Models
{
    public class Advertisement
    {
        [Key]
        public string Uid { get; set; }

        public string Position { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }


        public int Pay { get; set; }

        
        public virtual List<User> Subscribed { get; set; }

        public Advertisement()
        {
            Uid = Guid.NewGuid().ToString();

            Subscribed = new List<User>();
        }
    }
}
