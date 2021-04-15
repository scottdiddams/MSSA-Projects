using System;

namespace C3Ex04
{
    class Program
    {
        internal class Animal
        {
            public string Name;
            public string Speech;
            public string Activity;
            public bool isHuman = false;
            public string Species;

            internal void pig(string name, string speech, string activity, string species)
            {
                Name = name;
                Speech = speech;
                Activity = activity;
                Species = species;
                Console.WriteLine($"You approach a {species}");
                Console.WriteLine($"This is {name}, says Squealer, {activity}");
                Console.WriteLine($"{name} gets up on to his hind legs and says: {speech}");
            }
            internal void equine(string name, string speech, string activity, string species)
            {
                Name = name;
                Speech = speech;
                Activity = activity;
                Species = species;
                Console.WriteLine($"You approach a {species}");
                Console.WriteLine($"This is {name}, says Squealer, {activity}");
                Console.WriteLine($"{name} bows their head to greet you and says: {speech}");
            }
            internal void sheep(string name, string speech, string activity, string species)
            {
                Name = name;
                Speech = speech;
                Activity = activity;
                Species = species;
                Console.WriteLine($"You approach a {species}");
                Console.WriteLine($"This is {name}, says Squealer, {activity}");
                Console.WriteLine($"{name} turns to greet you and says: {speech}");
            }
        }

        static void Main(string[] lenny)
        {
            bool startMenu = true;
            while (startMenu)
            {
                Console.Clear();
                startMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.WriteLine("You enter the gate of the Animal Farm - you see a bright green flag -" +
                " It has a hoof and horn, crossed in the top left corner.");
            Console.WriteLine("Welcome to Manor Farm, my name is Squealer and I will be your guide.");
            Console.WriteLine("What would you like to see?");
            Console.WriteLine("1: The Barn");
            Console.WriteLine("2: The Field");
            Console.WriteLine("3: The House");
            Console.WriteLine("4: The mud pit");
            Console.WriteLine("5: exit");

            int menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        theBarn();
                        return true;

                    case 2:
                        theField();
                        return true;

                    case 3:
                        theHouse();
                        return true;

                    case 4:
                        Console.WriteLine("Oh, nobody lives there anymore, perhaps somewhere else?");
                        Console.ReadLine();
                        return true;

                    case 5:
                        Console.WriteLine("GoodBye");
                        Console.ReadLine();
                        return false;

                    default:
                        Console.WriteLine("I'm Afraid thats not an option");
                        Console.ReadLine();
                        return true;
                }

            

        }



        private static void theBarn()
        {
            Console.WriteLine("You enter a great red barn and see a number of equines standing in their stalls.");
            Console.WriteLine("Something seems off, but you're not quite sure");
            Console.ReadLine();
            Animal Boxer = new Animal();
            Boxer.Name = "Boxer";
            Boxer.Species = "Cart-Horse";
            Boxer.Activity = "He is one of our most faithful and strong equines";
            Boxer.Speech = "Greetings, I'm afraid I no longer have the strength I used to, you see i've been injured." +
                  " Napoleon will know what to do to help me get back to work - Napoleon is always right";
            Boxer.equine(Boxer.Name, Boxer.Speech, Boxer.Activity, Boxer.Species);
            Console.ReadLine();
            Console.WriteLine("You move on");
            Animal Clover = new Animal();
            Clover.Name = "Clover";
            Clover.Species = "Mare with an estranged look on her face";
            Clover.Activity = "She is one of our most loyal colleagues - isn't that so, Clover";
            Clover.Speech = "Of course, Squealer - I am priviledged to have the opportunity to be a part of the Manor farm";
            Clover.equine(Clover.Name, Clover.Speech, Clover.Activity, Clover.Species);
            Console.ReadLine();
            Console.WriteLine("You hear Clover breathe out a sigh of relief as you move away");
            Console.WriteLine("Squealer: perhaps we should go someplce else");
            Console.ReadLine();

        }


        private static void theField()
        {
            Console.WriteLine("You aproach a field of sheep, grazing on the thin grass - they look rather skinny.");
            Animal Bailey = new Animal();
            Bailey.Name = "Bailey";
            Bailey.Species = "Sheep with a blank look on his face";
            Bailey.Activity = "One of our sheep";
            Bailey.Speech = "BAAAH! Four Legs Good, Four Legs good, Two Legs BAAAAAH";
            Bailey.sheep(Bailey.Name, Bailey.Speech, Bailey.Activity, Bailey.Species);
            Console.WriteLine("I think i'll stop you there, Bailey, thank you");
            Console.ReadLine();
            Console.WriteLine("Ah, here is one of our brightest sheep");
            Console.ReadLine();

            Animal Seamus = new Animal();
            Seamus.Name = "Seamus";
            Seamus.Species = "Sheep - he perks up when he sees Squealer, as if expecting a treat";
            Seamus.Activity = "An incredibly smart sheep";
            Seamus.Speech = "BAAAH! Four Legs Good, Two legs Better! Four legs good, Two legs better!";
            Seamus.sheep(Seamus.Name, Seamus.Speech, Seamus.Activity, Seamus.Species);
            Console.ReadLine();
            Console.WriteLine("Such a wonderful group...shall we move on?");
            Console.ReadLine();
        }

        private static void theHouse()
        {
            Console.WriteLine("You enter the farm house and see a group of individuals playing cards");
            Animal Minimus = new Animal();
            Minimus.Name = "Minius";
            Minimus.Species = "Pig, you almost mistake him for a human...";
            Minimus.Activity = "A brilliant Poet and author of our wondrous national anthem";
            Minimus.Speech = "Greetings! and welcome fiend to our *hic*... farm..." +
                " I'm currently writing a new *hic* ... anthem for our com...munity!" +
                " Who doesn't love a good song and drink";
            Minimus.pig(Minimus.Name, Minimus.Speech, Minimus.Activity, Minimus.Species);
            Console.WriteLine("Minimus stumbles back into his chair and reaches for his cigar and glass of whiskey." +
                " You notice he is hiding an extra card under his seat - the ace of spades");
            Console.ReadLine();
            Console.WriteLine("Ah, Comrade Napoleon, would you like to meet our guest?");
            Console.ReadLine();
            Animal Napoleon = new Animal();
            Napoleon.Name = "Napoleon";
            Napoleon.Species = "Pig, or a human, maybe...deffinitely a pig";
            Napoleon.Activity = "Without his leadership and sacrifice, we would be lost";
            Napoleon.Speech = "Greetings friend, I hope you are enjoying your visit - " +
                "remember: all animals are created equal *he turns to Squealer* but some more equal than others!";
            Napoleon.pig(Napoleon.Name, Napoleon.Speech, Napoleon.Activity, Napoleon.Species);
            Console.ReadLine();
            Console.WriteLine("Napoleon slips and drops his cards on the table, a king of spades lands heads up");
            Console.WriteLine("The human farmer opposite him raises his head: wait a minute, i have that same card in MY hand");
            Console.WriteLine("Napoleon and the farmer start shouting - accusing the other of cheating");
            Console.WriteLine("You decide it's time to leave - you look back as you exit the door and see pigs and men " +
                "fighting each other...pigs and men, but you cannot tell the difference");
            Console.ReadLine();
        }
    }
}