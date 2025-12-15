using System;

namespace Labb4GIK299;

//Class som heter Person, innehåller data om en person

public class Person
{

    //Skapa två properties inom classen person;

    //Property av Birthday
    public DateOnly Birthday { get; set; }

    //Property av ögonfärg
    public string EyeColor { get; set; }


    //Instansierar vår struct och enum, för att kunna använda dem i konstruktorn.
    Hair hair;
    Gender gender;//this.gender från konstruktorn pekar på den här


    //konstruktorn med de parametrar vi behöver för att skapa en person.
    //I konstruktorn tilldelar vi den indata som klassen får till de properties som vi använder. 
    public Person(
        String eyeColor, 
        int hairLength,
        string hairColor,
        Gender gender,
        DateOnly birthday
        )
    {
        EyeColor = eyeColor;
        hair.HairLength = hairLength;
        hair.HairColor = hairColor;
        this.gender = gender;
        Birthday = birthday;
    }

    public Person() { }



    //Använder override ToString() för att få tillbaka unik sträng att skriva ut, så att datan om personen kommer med i meningen. Genom override gör
    //vi att ToString() skriver ut det vi returnerar istället för defaultvärde (klass osv.)
    public override string ToString()
    {
        return $"Ögonfärg: {EyeColor} \nHårlängd: {hair.HairLength}cm \n" +
                $"Hårfärg: {hair.HairColor} \nKön: {this.gender} \nFödelsedag: {Birthday}\n";
    }

    //Lista innehållande personer,

    public List <Person> PersonList = new List<Person>();


    //Metod som heter AddPerson och som lägger till personer i listan
    // Samlar först in info om personen och sparar i nya variabler
    // Skapar sedan en ny person med hjälp av konstruktorn och lägger till i listan

    public void AddPerson() {

        // Frågar om ögonfärg tills användaren anger en giltig ögonfärg (endast bokstäver).
        string newEyeColor;
        bool isInvalid = false;
        string stringBirthday;

        string stringYear;
        int year = 0;
        string stringMonth;
        int month = 0; 
        string stringDay;
        int day = 0;
        DateTime dateTime = DateTime.Now;
        DateOnly today = DateOnly.FromDateTime(dateTime);
        DateOnly newBirthday = today;





        do
        {
            Console.Write("Ange personens ögonfärg: ");
            newEyeColor = Console.ReadLine();

            // Loopar igenom varje tecken i strängen och kollar om det är en bokstav
            // Om det inte är en bokstav, sätts isNotLetter till true och ett felmeddelande skrivs ut
            foreach (char c in newEyeColor)
            {
                if (!char.IsLetter(c))
                {

                    Console.WriteLine("Ogiltigt val, ange en färg med bokstäver.\n");
                    isInvalid = true;
                    break;
                }

                else
                {
                    isInvalid = false;
                }
            }

                if (isInvalid == false && newEyeColor.Length < 3)
                {
                    Console.WriteLine("Ogiltigt val, ange en riktig färg.\n");
                    isInvalid = true;
                }
        }
        while (isInvalid);
        


        // Frågar om hårlängd tills användaren anger ett giltigt nummer (heltal över 0). 
        int newHairLength = 0;
        do {
            Console.Write("\nAnge personens hårlängd i centimeter: ");
            try
            {
                newHairLength = Convert.ToInt32(Console.ReadLine());
                isInvalid = false;

                if (newHairLength < 0)
                {
                    Console.WriteLine("Ogiltigt val, ange ett värde över 0 cm.");
                    isInvalid = true;
                }
                else
                {
                    isInvalid = false;
                }

            }
            // Om något annat än en siffra anges, fångas undantaget och ett felmeddelande skrivs ut
            catch (Exception)
            {
                Console.WriteLine("Ogiltigt val, skriv endast siffra/-or.");
                isInvalid = true;
            }
        }
        while (isInvalid);

        // Frågar om hårfärg tills användaren anger en giltig hårfärg (endast bokstäver).
        string newHairColor;

        do
        {
            Console.Write("\nAnge personens hårfärg: ");
            newHairColor = Console.ReadLine();

            foreach (char c in newHairColor)
            {
                if (!char.IsLetter(c))
                {

                    Console.WriteLine("Ogiltigt val, ange en färg med bokstäver.");
                    isInvalid = true;
                    break;
                }

                else
                {
                    isInvalid = false;
                }
            }

            if (isInvalid == false && newHairColor.Length < 3)
            {
                Console.WriteLine("Ogiltigt val, ange en riktig färg.");
                isInvalid = true;
            }

                

        }
        while (isInvalid);

        // Frågar om kön tills användaren anger ett giltigt nummer (1-4).
        int genderIndex = 0;
        do
        {
            Console.WriteLine("\nAnge personens kön.");
            Console.WriteLine("\n1, Man \n2, Kvinna \n3, Ickebinär \n4, Annan");
            Console.Write("\nSkriv den siffra som motsvarar personens kön: ");
            try
            {
                genderIndex = Convert.ToInt32(Console.ReadLine());
                isInvalid = false;

                if (genderIndex < 1 || genderIndex > 4)
                {
                    Console.WriteLine("Ogiltigt val, ange ett värde som matchar personens kön.");
                    isInvalid = true;
                }
                else
                {
                    isInvalid = false;
                }

            }
            // Om något annat än en siffra anges, fångas undantaget och ett felmeddelande skrivs ut
            catch (Exception)
            {
                Console.WriteLine("Ogiltigt val, skriv endast siffra/-or.");
                isInvalid = true;
            }
        }
        while (isInvalid);

        Gender newGender = (Gender)genderIndex - 1;


        // Frågar om födelsedag tills användaren anger ett giltigt datum i formatet "YYYY-MM-DD" som inte är i framtiden.
        do
        {
            Console.Write("\nAnge personens födelsedag i formatet \"YYYY-MM-DD\": ");
            try
            {
                stringBirthday = Console.ReadLine();

                stringYear = stringBirthday.Substring(0, 4);
                year = Convert.ToInt32(stringYear);
                stringMonth = stringBirthday.Substring(5, 2);
                month = Convert.ToInt32(stringMonth);
                stringDay = stringBirthday.Substring(8, 2);
                day = Convert.ToInt32(stringDay);

                newBirthday = new DateOnly(year, month, day);

                if (newBirthday > today)
                {
                    Console.WriteLine($"Det angivna datumet {newBirthday} har ännu inte varit, ange ett giltigt födelsedatum.");
                    isInvalid = true;
                }
                else
                {
                    isInvalid = false;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ogiltigt val, ange ett giltigt födelsedatum. Ange både siffror och bindesstreck.");
                isInvalid = true;
            }
        }
        while (isInvalid);
            



        Person newPerson = new Person(newEyeColor, newHairLength, newHairColor, newGender, newBirthday);

            PersonList.Add(newPerson);
    }



    //Metod som heter ListPersons, som skriver ut alla personer i listan

    public void ListPersons()
    {
        foreach (Person person in PersonList)
        {
            Console.WriteLine("--------------------------------------------------------------\n");
            Console.WriteLine(person);
            
            Thread.Sleep(1000);
        }
    }

   






}
