using System;

namespace Heist
{
    public class Muscle : IRobber
    {
        public string Name { get; set; } = "The Muscle";
        public int SkillLevel { get; set; } = 25;
        public int PercentageCut { get; set; } = 20;

        public Muscle(string TheName, int Skill, int Percent)
        {
            Name = TheName;
            SkillLevel = Skill;
            PercentageCut = Percent;
        }

        public void PerformSkill(Bank TheBank)
        {
            TheBank.SecurityGuardScore -= SkillLevel;
            Console.WriteLine($"{Name} is handling the security guards. Guard score decreased by {SkillLevel} points.");

            if (TheBank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has dealt with the security guards!");
            }
            else
            {
                Console.WriteLine("The security guards have not been fully dealt with...");
                Console.WriteLine($"Security guard points remaining: {TheBank.SecurityGuardScore}");
            }
        }
    }
}