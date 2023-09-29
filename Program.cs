using System.Reflection.Metadata;
using Heist.Models;

List<IRobber> rolodex = new List<IRobber>(){
    new Hacker{ Name = "Bob", PercentageCut = 15, SkillLevel = 60},
    new Muscle{ Name = "Bill", PercentageCut = 10, SkillLevel = 40},
    new LockSpecialist{ Name = "Tom", PercentageCut = 40, SkillLevel = 90},
    new Hacker{ Name = "Joe", PercentageCut = 25, SkillLevel = 80},
    new Muscle{ Name = "Jack", PercentageCut = 15, SkillLevel = 60},
    new LockSpecialist{ Name = "John", PercentageCut = 25, SkillLevel = 80}
};

Random random = new Random();

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
    Console.WriteLine($"Would you like to add another crewmember? Y/N");
    choice = Console.ReadLine();
    Console.Clear();
}
Bank bank = new Bank
{
    AlarmScore = random.Next(1, 100),
    SecurityGuardScore = random.Next(1, 100),
    VaultScore = random.Next(1, 100),
    CashOnHand = random.Next(50000, 1000000)
};

int maxValue = int.MinValue;
string maxPropertyName = null;

if (bank.AlarmScore > maxValue)
{
    maxValue = bank.AlarmScore;
    maxPropertyName = "Alarms";
}
if (bank.SecurityGuardScore > maxValue)
{
    maxValue = bank.SecurityGuardScore;
    maxPropertyName = "Security Guards";
}
if (bank.VaultScore > maxValue)
{
    maxValue = bank.VaultScore;
    maxPropertyName = "Vault";
}

int minValue = int.MaxValue;
string minPropertyName = null;

if (bank.AlarmScore < minValue)
{
    minValue = bank.AlarmScore;
    minPropertyName = "Alarms";
}
if (bank.SecurityGuardScore < minValue)
{
    minValue = bank.SecurityGuardScore;
    minPropertyName = "Security Guards";
}
if (bank.VaultScore < minValue)
{
    minValue = bank.VaultScore;
    maxPropertyName = "Vault";
}

Console.WriteLine(@$"
Press any key to assemble your crew...");

Console.ReadKey();

Console.Clear();


string selectMoreCrew = null;

List<IRobber> assembledCrew = new List<IRobber>();

int totalPercentageCutOfSelectedCrew = 0;

while (selectMoreCrew != "N" && totalPercentageCutOfSelectedCrew < 100 && rolodex.Count > 0)
{
    bool acceptableSelectionMade = false;
    int selectedCrewIndex = 0;
    string selectedCrewMemberName = null;
    while (acceptableSelectionMade == false)
    {

        Console.WriteLine(@$"Select a crew member by number (1 - {rolodex.Count}):");

        void printAllDetails()
        {
            for (int i = 0; i < rolodex.Count; i++)
            {
                Console.WriteLine(@$"
        {i + 1}. {rolodex[i].Name}");
                rolodex[i].PrintDetails();
            }
        }
        printAllDetails();

        selectedCrewIndex = int.Parse(Console.ReadLine());

        if (assembledCrew.Sum(c => c.PercentageCut) + rolodex[selectedCrewIndex - 1].PercentageCut <= 100)
        {
            selectedCrewMemberName = rolodex[selectedCrewIndex - 1].Name;
            assembledCrew.Add(rolodex[selectedCrewIndex - 1]);
            totalPercentageCutOfSelectedCrew += rolodex[selectedCrewIndex - 1].PercentageCut;
            rolodex.RemoveAt(selectedCrewIndex - 1);
            acceptableSelectionMade = true;
        }
        else
        {
            Console.WriteLine($"You cannot afford that crew member! Press any key to make a new selection...");
            
            Console.ReadKey();
            
            Console.Clear();
        }
    }



    Console.Clear();

    List<bool> checkIfCanBeAddedYet = new List<bool>();

    foreach (IRobber r in rolodex)
    {
        if (totalPercentageCutOfSelectedCrew + r.PercentageCut <= 100)
        {
            checkIfCanBeAddedYet.Add(true);
        }
        else
        {
            checkIfCanBeAddedYet.Add(false);
        }
    }

    bool canStillAffordAnyRemainingCrew = checkIfCanBeAddedYet.Any(value => value == true);

    if (canStillAffordAnyRemainingCrew == true)
    {
        Console.WriteLine(@$"{selectedCrewMemberName} was added to your crew! The total cut of the profits taken by your crew currently is {totalPercentageCutOfSelectedCrew}%.Would you like to add another member? Y/N");
        selectMoreCrew = Console.ReadLine();
        Console.Clear();
    }
    else if (totalPercentageCutOfSelectedCrew == 100)
    {
        Console.WriteLine(@$"{selectedCrewMemberName} was added to your crew! The total cut of the profits taken by your crew is 100%. You cannot afford to hire any other crew members. Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
        selectMoreCrew = "N";
    } 
    else
    {
        Console.WriteLine(@$"{selectedCrewMemberName} was added to your crew! There are no remaining crew members for hire that you can afford. Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
        selectMoreCrew = "N";
    }
}

foreach (IRobber r in assembledCrew)
{
    r.PerformSkill(bank);
}
if (!bank.IsSecure) {
    Console.WriteLine($"The heist was a success! The total take was ${bank.CashOnHand}");
    decimal cashAmountLeftAfterPayouts = bank.CashOnHand;
    foreach (IRobber r in assembledCrew)
    {
        decimal convertToPercentage = (decimal)r.PercentageCut / 100.0m;
        decimal earningsTakeen = bank.CashOnHand * convertToPercentage;
        Console.WriteLine($"{r.Name} took ${earningsTakeen}.");
        cashAmountLeftAfterPayouts -= earningsTakeen;
    }

    Console.WriteLine($"The remainder for you to take is ${cashAmountLeftAfterPayouts}.");
    

    Console.WriteLine($"Press any key to end the game...");
    Console.ReadKey();
    Console.Clear();

}
else
{
    Console.WriteLine($"The heist was a failure");
    Console.WriteLine($"Press any key to end the game...");
    Console.ReadKey();
    Console.Clear();
}







