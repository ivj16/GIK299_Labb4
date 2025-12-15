namespace Labb4GIK299
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isRunAgain = true;
            Person personData = new Person();

            //Meny switch-sats

            Console.WriteLine("Välkommen till Evil Eavesdrop Enterprises data-stjälare.");


            while (isRunAgain)
            {
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("\nVad önskar du göra?\n");
                Console.WriteLine("1, Lägga till en ny person i databasen");
                Console.WriteLine("2, Skriva ut data om alla personer i databasen");
                Console.WriteLine("3, Avsluta programmet");
                Console.Write("\nSkriv in den siffra som motsvarar det önskade valet: ");


                try
                {
                    int programChoice = Convert.ToInt32(Console.ReadLine());

                    switch (programChoice)
                    {

                        case 1:
                            Console.WriteLine("\nDu har valt att lägga till en person.\n");
                            personData.AddPerson();

                            break;

                        case 2:
                            Console.WriteLine("\nHär kommer en utskrift av alla personer i listan: \n");
                            personData.ListPersons();
                            break;

                        case 3:
                            isRunAgain = false;
                            Console.WriteLine("Avslutar programmet, hejdå!");
                            break;

                        default:
                            Console.WriteLine("\nOgiltigt val, försök igen.\n");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nOgiltigt val, försök igen.\n");

                }
            }
        }
    }
}
