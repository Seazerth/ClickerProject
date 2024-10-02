namespace ClickerWebProject.Domain
{
    public class UserBoost
    {

        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int BoostId { get; set; }

        public Boost Boost { get; set; }

        public long CurentPrice { get; set; }

        public long Quantity { get; set; }
    }
}
