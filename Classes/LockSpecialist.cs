using System;

namespace Heist
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; } = "The Lockpicker";
        public int SkillLevel { get; set; } = 25;
        public int PercentageCut { get; set; } = 20;

        public LockSpecialist(string TheName, int Skill, int Percent)
        {
            Name = TheName;
            SkillLevel = Skill;
            PercentageCut = Percent;
        }

        public void PerformSkill(Bank TheBank)
        {
            TheBank.VaultScore -= SkillLevel;
            Console.WriteLine($"{Name} is picking the vault's lock. Vault security decreased by {SkillLevel} points.");

            if (TheBank.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has unlocked the vault!");
            }
            else
            {
                Console.WriteLine("The vault is still locked...");
                Console.WriteLine($"Vault security points remaining: {TheBank.VaultScore}");
            }
        }
    }
}