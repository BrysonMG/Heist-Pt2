using System;

namespace Heist
{
    public class Hacker : IRobber
    {
        public string Name { get; set; } = "The Hacker";
        public int SkillLevel { get; set; } = 25;
        public int PercentageCut { get; set; } = 20;

        public Hacker(string TheName, int Skill, int Percent)
        {
            Name = TheName;
            SkillLevel = Skill;
            PercentageCut = Percent;
        }

        public void PerformSkill(Bank TheBank)
        {
            TheBank.AlarmScore -= SkillLevel;
            Console.WriteLine($"{Name} is hacking the alarm system. Alarm security decreased by {SkillLevel} points.");

            if (TheBank.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the alarms!");
            }
            else
            {
                Console.WriteLine("The alarms are still active...");
                Console.WriteLine($"Alarm security points remaining: {TheBank.AlarmScore}");
            }
        }
    }
}