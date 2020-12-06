namespace Wallet
{
    public class PersonalCommission
    {
        public  string Id { get; set; }
        
        public User User { get; set; }
        public Currency Currency { get; set; }
        public Commission Commission { get; set; }
    }
}