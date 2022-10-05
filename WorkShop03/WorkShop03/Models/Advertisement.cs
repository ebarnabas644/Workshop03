using System.ComponentModel.DataAnnotations;

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

        public Advertisement()
        {
            Uid = Guid.NewGuid().ToString();
        }
    }
}
