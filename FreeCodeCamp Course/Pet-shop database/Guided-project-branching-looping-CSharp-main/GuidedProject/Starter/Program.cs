// the ourAnimals array will store the following: 
using System.Globalization;

string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 6];

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}

// display the top-level menu options
do
{
    Console.Clear();

    Console.WriteLine("\nWelcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    /*
    Console.WriteLine($"You selected menu option {menuSelection}.");
    Console.WriteLine("Press the Enter key to continue");

    // pause code execution
    readResult = Console.ReadLine();
    */

    switch (menuSelection)
    {
        // List all current Pet Info
        case "1":
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine($"\n {ourAnimals[i, 0]}");

                    for (int j = 1; j < 6; j++)
                    {
                        Console.WriteLine($"\t {ourAnimals[i, j]}");
                    }
                }
            }

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        // Add a new animal to ourAnimal array
        case "2":
            string anotherPet = "y";
            int petCount = 0;

            for (int i = 0; i < maxPets; i++)
                if (ourAnimals[i, 0] != "ID #: ") petCount += 1;

            if (petCount < maxPets)
            {
                Console.WriteLine($"We curently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");

                while (anotherPet == "y" && petCount < maxPets)
                {
                    Console.WriteLine("Do you want to enter info for another pet (y/n)");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null) anotherPet = readResult.ToLower();
                        if (readResult != "y" && readResult != "n") Console.WriteLine("Please enter a valid input");
                    } while (anotherPet != "y" && anotherPet != "n");

                    if (anotherPet == "y")
                    {
                        bool ValidEntry = false;
                        // animal species either cat or dog
                        do
                        {
                            Console.WriteLine("\n\rEnter 'dog or 'cat' to begin a new entry");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalSpecies = readResult.ToLower();
                                if (animalSpecies == "dog" || animalSpecies == "cat") ValidEntry = true;
                                else ValidEntry = false;
                            }
                        } while (ValidEntry == false);

                        animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                        ValidEntry = false;
                        // animal age either int or ? for unknown
                        do
                        {
                            int petAge;
                            Console.WriteLine("Enter the pet's age or enter ? if unknown");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalAge = readResult;
                                if (animalAge != "?") ValidEntry = int.TryParse(animalAge, out petAge);
                                else ValidEntry = true;
                            }
                        } while (ValidEntry == false);

                        // animal physical description can be blank
                        do
                        {
                            Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalPhysicalDescription = readResult.ToLower();
                                if (animalPhysicalDescription == "") animalPhysicalDescription = "tbd";
                            }
                        } while (animalPhysicalDescription == "");

                        //animal personality - description can be blank
                        do
                        {
                            Console.WriteLine("Enter a description of the pet's personality (likes and dislikes, tricks, energy levels etc)");
                            readResult = Console.ReadLine();
                            if (readResult != null)
                            {
                                animalPersonalityDescription = readResult.ToLower();
                                if (animalPersonalityDescription == "") animalPersonalityDescription = "tbd";
                            }
                        } while (animalPersonalityDescription == "");

                        // get pet nickname - can be blank
                        do
                        {
                            Console.WriteLine("Enter a nickname for the pet");
                            readResult = Console.ReadLine();

                            if (readResult != null)
                            {
                                animalNickname = readResult.ToLower();
                                if (animalNickname == "") animalNickname = "tbd";
                            }
                        } while (animalNickname == "");

                        // store the pet information into ourAnimals array
                        ourAnimals[petCount, 0] = "ID #: " + animalID;
                        ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                        ourAnimals[petCount, 2] = "Age: " + animalAge;
                        ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                        ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                        ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

                        petCount += 1;
                    }
                }
            }

            if (petCount == maxPets) Console.WriteLine("We have reached our limit, sorry");
            else Console.WriteLine("\nEntry cancelled.");

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        // Ensure age and physical are complete
        case "3":
            for (int i = 0; i < maxPets; i++)
            {
                // Checks what need updating
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    // Forces Age insert
                    if (ourAnimals[i, 2] == "Age: ?")
                    {
                        int petAge = 0;
                        bool validEntry = false;
                        do
                        {
                            Console.WriteLine($"Enter an age for {ourAnimals[i, 0]}");
                            readResult = Console.ReadLine();

                            if (readResult != null)
                            {
                                validEntry = int.TryParse(readResult, out petAge);
                                if (petAge > 99)
                                {
                                    validEntry = false;
                                    Console.WriteLine("Must be under 99");
                                }
                            }
                        } while (validEntry == false);
                        ourAnimals[i, 2] = $"Age: {petAge}";
                    }
                    
                    // Forces physcial description insert
                    if (ourAnimals[i, 4] == "Physical description: tbd" || ourAnimals[i, 4] == "Physical description: ") 
                    {
                        Console.WriteLine($"Enter a physcial description for the pet: {ourAnimals[i,0]}");
                        do 
                        {
                            readResult = Console.ReadLine();
                            if (readResult != null && readResult.Length >= 3) break;
                            else Console.WriteLine("Invalid, try again");
                        } while (true);
                        ourAnimals[i, 4] = $"Physical description: {readResult}";
                    }
                }
            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        // nickname and personality are complete
        case "4":
           for (int i = 0; i < maxPets; i++)
            {
                // Checks what need updating
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    // Forces nickname insert
                    if (ourAnimals[i, 3] == "Nickname: tbd" || ourAnimals[i, 3] == "Nickname: ") 
                    {
                        Console.WriteLine($"Enter a nickname for the pet: {ourAnimals[i,0]}");
                        do 
                        {
                            readResult = Console.ReadLine();
                            if (readResult != null && readResult.Length >= 3) break;
                            else Console.WriteLine("Invalid, try again");
                        } while (true);
                        ourAnimals[i, 3] = $"Nickname: {readResult}";
                    }

                    // Forces personality insert
                    if (ourAnimals[i, 5] == "Personality: tbd" || ourAnimals[i, 5] == "Personality: ") 
                    {
                        Console.WriteLine($"Enter a personality description for the pet: {ourAnimals[i,0]}");
                        do 
                        {
                            readResult = Console.ReadLine();
                            if (readResult != null && readResult.Length >= 3) break;
                            else Console.WriteLine("Invalid, try again");
                        } while (true);
                        ourAnimals[i, 5] = $"Personality: {readResult}";
                    }
                }
            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        // TODO: Case 5 - 6
        // Edit age
        case "5":
            Console.WriteLine("Feature not available");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        // edit personality
        case "6":
            Console.WriteLine("Feature not available");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        // Display all cats with specified trait
        case "7":
           string catCharacteristic = "";

            // Gets the users input
            while (catCharacteristic == "")
            {   
                Console.WriteLine("\nEnter multiple desired cat characteristic to search for, seperated by a ',' e.g. golden, large, hairy...");
                readResult = Console.ReadLine();
                if (readResult != null) catCharacteristic = readResult.ToLower().Trim();
            }

            // Checks for charactestic matches
            bool noMatchescat = true;
            string[] catCharacteristicArray = catCharacteristic.Split(",");
            Array.Sort(catCharacteristicArray);

            for (int i = 0; i < maxPets; i++)
            {
                
                if (ourAnimals[i, 1].Contains("cat"))
                {
                    bool currentCatMatch = false;
                    foreach (string searchCharacteristic in catCharacteristicArray)
                    {
                        Console.WriteLine($"\tSearching {searchCharacteristic.Trim()}");
                        string catDescription = ourAnimals[i, 4] + " " + ourAnimals[i, 5];
                        if (catDescription.Contains(searchCharacteristic.Trim()))
                        {
                            Console.WriteLine($"Our cat, {ourAnimals[i, 3]}, is a match for {searchCharacteristic.Trim()}");
                            noMatchescat = false;
                            currentCatMatch = true;
                        }
                    }
                    if (currentCatMatch)
                    {
                    Console.WriteLine("\n" + ourAnimals[i, 3]);
                    Console.WriteLine(ourAnimals[i, 4]);
                    Console.WriteLine(ourAnimals[i, 5] + "\n");
                    }
                }
            }

            if (noMatchescat) Console.WriteLine($"None of our cats are a match for {catCharacteristic} :(");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        // Display all dogs with specified traits
        case "8":
           string dogCharacteristic = "";

            // Gets the users input
            while (dogCharacteristic == "")
            {   
                Console.WriteLine("\nEnter multiple desired dog characteristic to search for, seperated by a ',' e.g. golden, large, hairy...");
                readResult = Console.ReadLine();
                if (readResult != null) dogCharacteristic = readResult.ToLower().Trim();
            }

            // Checks for charactestic matches
            bool noMatchesDog = true;
            string[] dogCharacteristicArray = dogCharacteristic.Split(",");
            Array.Sort(dogCharacteristicArray);

            for (int i = 0; i < maxPets; i++)
            {
                
                if (ourAnimals[i, 1].Contains("dog"))
                {
                    foreach (string searchCharacteristic in dogCharacteristicArray)
                    {
                        Console.WriteLine($"\tSearching {searchCharacteristic.Trim()}");
                        string dogDescription = ourAnimals[i, 4] + " " + ourAnimals[i, 5];
                        if (dogDescription.Contains(searchCharacteristic.Trim()))
                        {
                            Console.WriteLine($"Our dog, {ourAnimals[i, 3]}, is a match for {searchCharacteristic.Trim()}");
                            noMatchesDog = false;
                        }
                    }
                    Console.WriteLine("\n" + ourAnimals[i, 3]);
                    Console.WriteLine(ourAnimals[i, 4]);
                    Console.WriteLine(ourAnimals[i, 5] + "\n");
                }
            }

            if (noMatchesDog) Console.WriteLine($"None of our dogs are a match for {dogCharacteristic} :(");

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        default:
            Console.WriteLine("Feature not available");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
    }

} while (menuSelection != "exit");