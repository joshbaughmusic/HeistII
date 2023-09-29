namespace Heist.Models;

public class LockSpecialist : IRobber
{
    public string Name { get; set; }
    public int SkillLevel { get; set; }
    public int PercentageCut { get; set; }
    public void PerformSkill(Bank bank)
    {
        bank.VaultScore -= SkillLevel;
        Console.WriteLine($"{Name} is picking the vault lock. Decreased vault security by {SkillLevel} points.");
        if (bank.VaultScore <= 0)
        {
            Console.WriteLine($"{Name} has opened the vault!");
        }
    }
    public void PrintDetails()
    {
        Console.WriteLine($"A lock specialist with a skill level of {SkillLevel}. Takes a {PercentageCut}% of all the earnings.");

    }
}