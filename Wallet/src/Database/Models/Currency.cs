using Wallet.Database.Models.Commissions;

namespace Wallet.Database.Models
{
    public class Currency
    {
        public  string Id { get; set; }
        public string Name { get; set; }
        public CommissionsStack CommissionsStack { get; set; }
    }
}