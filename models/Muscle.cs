namespace Heist.Models;

public class Muscle : IRobber
{
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public int PercentageCut { get; set; }
    public void PerformSkill(Bank bank)
    {
        bank.SecurityGuardScore -= SkillLevel;
        Console.WriteLine($"{Name} is fighting off the security guards. Decreased security guards by ${SkillLevel} points.");
        if (bank.SecurityGuardScore <= 0)
        {
            Console.WriteLine($"{Name} has eliminated the remaining security guards!");
        }
    }
}