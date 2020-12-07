using Wallet.Database.Models.Commissions;

namespace Wallet.Database.Models
{
    public class PersonalCommission
    {
        public  string Id { get; set; }
        
        public User User { get; set; }
        public Currency Currency { get; set; }
        public CommissionsStack CommissionsStack { get; set; }
    }
}