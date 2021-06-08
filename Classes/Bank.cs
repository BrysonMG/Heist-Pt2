using System;

namespace Heist
{
    public class Bank
    {
        public int AlarmScore { get; set; }
        public int VaultScore { get; set; }
        public int SecurityGuardScore { get; set; }
        public int CashOnHand { get; set; }
        public Bank(int alarm, int vault, int guard, int cash)
        {
            AlarmScore = alarm;
            VaultScore = vault;
            SecurityGuardScore = guard;
            CashOnHand = cash;
        }
        public bool IsSecure()
        {
            if (AlarmScore <= 0 && VaultScore <= 0 && SecurityGuardScore <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}