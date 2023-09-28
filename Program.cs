using System.Reflection.Metadata;
using Heist.Models;

List<IRobber> rolodex = new List<IRobber>(){
    new Hacker{ Name = "Bob", PercentageCut = 10, SkillLevel = 60},
    new Muscle{ Name = "Bill", PercentageCut = 5, SkillLevel = 40},
    new LockSpecialist{ Name = "Tom", PercentageCut = 20, SkillLevel = 90},
    new Hacker{ Name = "Joe", PercentageCut = 15, SkillLevel = 80},
    new Muscle{ Name = "Jack", PercentageCut = 10, SkillLevel = 60},
    new LockSpecialist{ Name = "John", PercentageCut = 15, SkillLevel = 80}
};

Console.WriteLine($"Welcome to Heist II! Press any key to begin:");
Console.ReadKey();
Console.Clear();

Console.WriteLine(@$"Currently Available Crew Members:
");

foreach (IRobber robber in rolodex)
{
    Console.WriteLine($"{robber.Name} - Class: {robber.GetType().Name}");
};

Console.WriteLine($" ");

string choice = null;

Console.WriteLine($"Would you like to create a new crew member? Y/N");

choice = Console.ReadLine();

Console.Clear();

while (choice != "N")
{
    Console.WriteLine($"Enter name of new crewmember:");
    string newCrewName = Console.ReadLine();
    Console.Clear();

    Console.WriteLine(@$"Pick crewmember profession (1 - 3):
    1. Hacker (Disables alarms)
    2. Muscle (Disables guards)
    3. Lock Specialist (Cracks vault)");
    int newCrewProfession = int.Parse(Console.ReadLine());
    Console.Clear();

    Console.WriteLine($"Enter skill level of new crewmember (1 - 100):");
    int newCrewSkillLevel = int.Parse(Console.ReadLine());
    Console.Clear();

    Console.WriteLine($"Enter percentage cut for new crewmember (1 - 50):");
    int newCrewPercentageCut = int.Parse(Console.ReadLine());
    Console.Clear();

    switch (newCrewProfession)
    {
        case 1:
            rolodex.Add(new Hacker { Name = newCrewName, PercentageCut = newCrewPercentageCut, SkillLevel = newCrewSkillLevel });
            break;

        case 2:
            rolodex.Add(new Muscle { Name = newCrewName, PercentageCut = newCrewPercentageCut, SkillLevel = newCrewSkillLevel });
            break;
        case 3:
            rolodex.Add(new LockSpecialist { Name = newCrewName, PercentageCut = newCrewPercentageCut, SkillLevel = newCrewSkillLevel });
            break;
    }
    Console.WriteLine($"Crewmember added!");
    Console.WriteLine(@$"Crewmembers now available:
    ");
    foreach (IRobber robber in rolodex)
    {
        Console.WriteLine($"{robber.Name} - Class: {robber.GetType().Name}");
    };
    Console.WriteLine($" ");
    Console.WriteLine($"Would you like to add another crewmember?");
    choice = Console.ReadLine();
    Console.Clear();
}

Console.WriteLine($"Bye!");



