using System;
using System.Collections.Generic;
using System.Linq;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine(@"
            __  __     _      __                           
           / / / /__  (_)____/ /_                          
          / /_/ / _ \/ / ___/ __/                          
         / __  /  __/ (__  ) /_                            
        /_/_/_/\___/_/____/\__/    __      __  _           
          / ___/(_)___ ___  __  __/ /___ _/ /_(_)___  ____ 
          \__ \/ / __ `__ \/ / / / / __ `/ __/ / __ \/ __ \
         ___/ / / / / / / / /_/ / / /_/ / /_/ / /_/ / / / /
        /____/_/_/ /_/ /_/\__,_/_/\__,_/\__/_/\____/_/ /_/ 
------------------------------------------------------------------
            ");

            List<IRobber> Rolodex = new List<IRobber>();

            //-------------Starting Crew Members---------------
            Hacker Mike = new Hacker("Mike", 100, 60);
            Hacker Kevin = new Hacker("Kevin", 40, 15);

            Muscle Igor = new Muscle("Igor", 75, 35);
            Muscle Mary = new Muscle("Mary", 10, 5);

            LockSpecialist Emily = new LockSpecialist("Emily", 85, 40);
            LockSpecialist Aaron = new LockSpecialist("Aaron", 50, 25);

            Rolodex.Add(Mike);
            Rolodex.Add(Kevin);
            Rolodex.Add(Igor);
            Rolodex.Add(Mary);
            Rolodex.Add(Emily);
            Rolodex.Add(Aaron);
            //-------------------------------------------------

            Console.WriteLine($"You are hoping to pull off a heist. Currently, you have {Rolodex.Count} contacts to choose from.");
            Console.Write("Would you like to add any new contacts (Y/N)? ");
            string NewContactResp = Console.ReadLine().ToLower();
            string SpecialtyResp = string.Empty;

            if (NewContactResp == "y")
            {
                bool AddingContacts = true;
                while (AddingContacts)
                {
                    Console.Write("What is the name of your new contact? ");
                    string NewContactName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(NewContactName))
                    {
                        Console.WriteLine("Adding contacts cancelled...");
                        break;
                    }

                    bool ValidSpecialty = false;
                    while (!ValidSpecialty)
                    {
                        Console.WriteLine($@"
What is {NewContactName}'s specialty?
---------------------------
1) Hacker
2) Muscle
3) Lock Specialist
                ");

                        SpecialtyResp = Console.ReadLine();

                        if (SpecialtyResp != "1" && SpecialtyResp != "2" && SpecialtyResp != "3")
                        {
                            Console.WriteLine("Invalid Response");
                        }
                        else
                        {
                            ValidSpecialty = true;
                        }
                    }

                    Console.Write($"What is {NewContactName}'s skill level (1-100)? ");
                    int NewContactSkill = int.Parse(Console.ReadLine());

                    Console.Write($"What percentage of the cut will {NewContactName} take (1-100)? ");
                    int NewContactPercent = int.Parse(Console.ReadLine());

                    if (SpecialtyResp == "1")
                    {
                        Rolodex.Add(new Hacker(NewContactName, NewContactSkill, NewContactPercent));
                    }
                    else if (SpecialtyResp == "2")
                    {
                        Rolodex.Add(new Muscle(NewContactName, NewContactSkill, NewContactPercent));
                    }
                    else if (SpecialtyResp == "3")
                    {
                        Rolodex.Add(new LockSpecialist(NewContactName, NewContactSkill, NewContactPercent));
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong...");
                    }

                    Console.WriteLine($"{NewContactName} has been added to your contacts.");
                    Console.WriteLine();
                    Console.Write("Would you like to add another contact (Y/N)? ");
                    string KeepAddingContacts = Console.ReadLine().ToLower();

                    if (KeepAddingContacts == "y")
                    {
                        AddingContacts = true;
                    }
                    else if (KeepAddingContacts == "n")
                    {
                        Console.WriteLine("Ok, let's move on.");
                        AddingContacts = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Response. No new contacts will be added.");
                        AddingContacts = false;
                    }
                }
            }
            else if (NewContactResp == "n")
            {
                Console.WriteLine("Ok, let's move on.");
            }
            else
            {
                Console.WriteLine("Invalid response. No new contacts will be added.");
            }

            if (Rolodex.Count != 6)
            {
                Console.WriteLine($"You now have {Rolodex.Count} contacts in your rolodex.");
            }

            StartHeist();
        }

        public static void StartHeist()
        {
            int RandomAlarm = new Random().Next(1, 101);
            int RandomVault = new Random().Next(1, 101);
            int RandomGuard = new Random().Next(1, 101);
            int RandomPayload = new Random().Next(50000, 1000001);

            List<int> BankStats = new List<int>()
            {
                RandomAlarm, RandomVault, RandomGuard
            };

            Bank Target = new Bank(RandomAlarm, RandomVault, RandomGuard, RandomPayload);

            string MostSecure = string.Empty;
            string LeastSecure = string.Empty;

            if (BankStats.Max() == RandomAlarm)
            {
                MostSecure = "The Alarms";
            }
            else if (BankStats.Max() == RandomVault)
            {
                MostSecure = "The Vault";
            }
            else
            {
                MostSecure = "The Guards";
            }

            Console.WriteLine();
            Console.WriteLine("Recon Report:");
            Console.WriteLine($"Our Target's Most Secure System is: {MostSecure}");

        }
    }
}
