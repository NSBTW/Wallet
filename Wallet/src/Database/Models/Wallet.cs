using System.Linq;

namespace Wallet
{
    public class Wallet
    {
        public string Id { get; set; }
        public Account Account { get; set; }

        public Currency Currency { get; set; }
        public double Value { get; set; }

        private CommissionsStack GetPersonalCommissionsStack() => Account.User.PersonalCommissions
            .FirstOrDefault(c => c.Currency.Id == Currency.Id)?.CommissionsStack;
        public bool TryTransferTo(Wallet target, double value)
        {
            var personalCommission = GetPersonalCommissionsStack().TransferCommission;
            var commission = personalCommission ?? Currency.CommissionsStack.TransferCommission;
            var commissionValue = commission.CalculateCommission(value);
            var cost = value + commissionValue;
            if (cost > value)
                return false;

            value -= cost;
            target.Value += cost;
            return true;
        }

        public bool TryPut(double value)
        {
            var personalCommission = GetPersonalCommissionsStack().InCommission;
            var commission = personalCommission ?? Currency.CommissionsStack.InCommission;
            var commissionValue = commission.CalculateCommission(value);
            if (commissionValue > value)
                return false;
            Value += value - commissionValue;
            return true;
        }
        public bool TryGet(double value)
        {
            var personalCommission = GetPersonalCommissionsStack().OutCommission;
            var commission = personalCommission ?? Currency.CommissionsStack.OutCommission;
            var commissionValue = commission.CalculateCommission(value);
            if (commissionValue > value)
                return false;
            Value -= commissionValue + value;
            return true;
        }
    }
}