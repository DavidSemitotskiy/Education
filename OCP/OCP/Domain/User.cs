namespace OCP.Domain
{
    public class User
    {
        public string Role { get; set; }

        public bool IsPremiumUser { get; set; }

        public Subscription Subscription { get; set; }
    }
}
