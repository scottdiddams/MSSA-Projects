using System;

namespace ProgEx06
{
    class Program
    {
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
            Console.WriteLine("Welcome to the US Army Airborne Scout Platoon! What would you like to explore");
            Console.WriteLine("1: Scouts");
            Console.WriteLine("2: Weapons");
            Console.WriteLine("3: Vehicles");
            Console.WriteLine("4: Missions");
            Console.WriteLine("5: exit");
            int menu = int.Parse(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    Scouts();
                    return true;

                case 2:
                    Weapons();
                    return true;

                case 3:
                    Vehicles();
                    return true;

                case 4:
                    Missions();
                    return true;

                case 5:
                    Console.WriteLine("Scouts Out!");
                    Console.ReadLine();
                    return false;

                default:
                    Console.WriteLine("Thats not an option");
                    Console.ReadLine();
                    return true;
            }
        }
        private static void Scouts()
        {
            Console.WriteLine("Scouts in the platoon may have a variety of different roles: hit enter to learn more");
            Console.ReadLine();
            Scouts scout = new Scouts();
            Driver driver = new Driver();
            Gunner gunner = new Gunner();
            Dismount dismount = new Dismount();
            scout.Recon();
            Console.WriteLine("");
            driver.teammateDriver();
            Console.WriteLine("press enter to continue");
            Console.ReadLine();
            gunner.teammateGunner();
            Console.WriteLine("press enter to continue");
            Console.ReadLine();
            dismount.teammateDismount();
            Console.WriteLine("press enter to return to the menu");
            Console.ReadLine();
        }
        private static void Weapons()
        {
            Console.WriteLine("Scouts are trained to operate a variety of small arms, crew-served, " +
                "and high-explosive weapon systems - hit enter to learn more");
            Console.ReadLine();
            Weapon guns = new Weapon();
            M240B m240 = new M240B();
            LRAS lras = new LRAS();
            TOW tow = new TOW();
            guns.Guns();
            Console.WriteLine("");
            m240.Bravo();
            Console.WriteLine("press enter to continue");
            Console.ReadLine();
            lras.Optic();
            Console.WriteLine("press enter to continue");
            Console.ReadLine();
            tow.BGM71();
            Console.WriteLine("press enter to return to the menu");
            Console.ReadLine();
        }
        private static void Vehicles()
        {
            Console.WriteLine("Airborne Scout platoons use light air-dropable vehicles to get them far ahead of " +
                "friendly forces to find and report the location of the enemy");
            Console.ReadLine();
            Vehicle car = new Vehicle();
            HMMWV truck = new HMMWV();
            DAGOR dagger = new DAGOR();
            PD100 heli = new PD100();
            car.truck();
            Console.WriteLine("");
            truck.M1161();
            Console.WriteLine("press enter to continue");
            Console.ReadLine();
            dagger.Polaris();
            Console.WriteLine("press enter to continue");
            Console.ReadLine();
            heli.SBS();
            Console.WriteLine("press enter to return to the menu");
            Console.ReadLine();
        }
        private static void Missions()
        {
            Console.WriteLine("Scouts are trained to accomplish a variety of reconnaissance missions" +
                " - hit enter to learn more");
            Console.ReadLine();
            Mission job = new Mission();
            Area map = new Area();
            Route wheel = new Route();
            Screen door = new Screen();
            job.job();
            Console.WriteLine("");
            map.Find();
            Console.WriteLine("press enter to continue");
            Console.ReadLine();
            wheel.Road();
            Console.WriteLine("press enter to continue");
            Console.ReadLine();
            door.Space();
            Console.WriteLine("press enter to return to the menu");
            Console.ReadLine();
        }
    }

    class Scouts
    {
        public virtual void Recon()
        {
            Console.WriteLine("--I am the eyes and ears of the commander on the battlefield, it is my job to find the enemy--");
        }
    }
    class Driver : Scouts
    {
        public void teammateDriver()
        {
            Console.WriteLine("I am a driver");
            Console.WriteLine("I am responsible for maintaining, operating, and securing my assigned vehicle.");
            Console.WriteLine("I am trained to maneuver my vehicle to give my teammates the best opportunity " +
                "to find and destroy the enemy, while keeping us out of harms way or hidden in camoflauge");
        }
    }
    class Gunner : Scouts
    {
        public void teammateGunner()
        {
            Console.WriteLine("I am a gunner");
            Console.WriteLine("I am responsible for maintaining, operating, and securing my assigned heavy weapon system.");
            Console.WriteLine("I am trained to engage with precise, long-range fire to disrupt the enemy's operations " +
                "and to operate long-range advanced surveilance systems to see the enemy from miles away");
        }
    }
    class Dismount : Scouts
    {
        public void teammateDismount()
        {
            Console.WriteLine("I am a dismount");
            Console.WriteLine("I am responsible for establishing observation posts to observe and report enemy activity");
            Console.WriteLine("I am trained to operate advanced optics and high-frequency radios, the use of " +
                "camoflauge techniques, and the construction of sub-surface surveillance sites");
        }
    }
    class Weapon
    {
        public virtual void Guns()
        {
            Console.WriteLine("--I am the eyes and ears of the commander on the battlefield, it is my job to find the enemy--");
        }
    }
    class M240B : Weapon
    {
        public void Bravo()
        {
            Console.WriteLine("Each Platoon is asigned four M240B machine guns");
            Console.WriteLine("The M240B is a crew-served weapon that fires a 7.62mm rifle round");
            Console.WriteLine("two of these weapons are mounted on humvees to compliment the LRAS3 " +
                "the other two are available to dismounts to augment their observation posts.");
        }
    }
    class LRAS : Weapon
    {
        public void Optic()
        {
            Console.WriteLine("Each platoon is assigned two LRAS3s");
            Console.WriteLine("LRAS3 stands for Long Range Advanced Scout Surveillance System.");
            Console.WriteLine("Scouts use this high-powered, infrared optic to identify the enemy under any conditions" +
                "from more than 10 miles away. It includes GPS & a laser range finder to send accurate location data " +
                "and call for artillery fire");
        }
    }
    class TOW : Weapon
    {
        public void BGM71()
        {
            Console.WriteLine("Each Platoon is assigned two BGM-71 TOW Missile launchers");
            Console.WriteLine("TOW stands for Tube-launched, Optically-tracked, & Wire-guided");
            Console.WriteLine("Scouts operate far ahead of friendly forces and may have to fight for information, alone, " +
                "against much stronger opponents - this anti-tank weapon system gives the team a firepower boost");
        }
    }

    class Vehicle
    {
        public virtual void truck()
        {
            Console.WriteLine("--I am the eyes and ears of the commander on the battlefield, it is my job to find the enemy--");
        }
    }
    class DAGOR : Vehicle
    {
        public void Polaris()
        {
            Console.WriteLine("Scout platoons may have up to four Dagors in place of their aging HMMWVs");
            Console.WriteLine("The Polaris Dagor is an ultra-light, air-droppable combat vehicle");
            Console.WriteLine("these vehicles get scouts and their weapons to their reconnaissance objective" +
                "just like the HMMWV, and trade armor for greater mobility");
        }
    }
    class HMMWV : Vehicle
    {
        public void M1161()
        {
            Console.WriteLine("Each platoon is assigned up to six HMMWVs");
            Console.WriteLine("HMMWV stands for High-Mobility, Multipurpose Wheeled Vehicle - pronounced 'HUM-vee'");
            Console.WriteLine("These vehicles can be dropped out of airplanes and delivered to scouts via parachute" +
                "and are used primarily to carry the scouts, their weapons, and optics to their reconnaissance objective. " +
                "Airborne Scout platoons will rarely bring more than four vehicles with them on a mission");
        }
    }
    class PD100 : Vehicle
    {
        public void SBS()
        {
            Console.WriteLine("Each Platoon is assigned four PD100 SBS drones");
            Console.WriteLine("SBS stands for Soldier-Borne Sensor - it's a small unmanned helicopter");
            Console.WriteLine("Scouts can use the SBS in good weather to get a birds-eye view of their surroundings. " +
                "Equipped with thermal cameras and GPS, the SBS can help scouts find and accurately report the enemy");
        }
    }

    class Mission
    {
        public virtual void job()
        {
            Console.WriteLine("--I am the eyes and ears of the commander on the battlefield, it is my job to find the enemy--");
        }
    }
    class Area : Mission
    {
        public void Find()
        {
            Console.WriteLine("In order to find the enemy, Scouts execute area reconnaissance missions");
            Console.WriteLine("Area recon missions focus on a defined geographic space, called an 'area'.");
            Console.WriteLine("Scouts are tasked to deliberately collect information about the enemy in that area" +
                ", and destroy any enemy reconnaissance units they encounter.");
        }
    }
    class Route : Mission
    {
        public void Road()
        {
            Console.WriteLine("In order to ensure a large body of soldiers can get from point A to B, scouts conduct route recon.");
            Console.WriteLine("This mission has scouts move out ahead of friendly forces to ensure that roads and bridges are trafficable.");
            Console.WriteLine("Additionally, should the specified routes be home to hostile forces, scouts must destroy them.");
        }
    }
    class Screen : Mission
    {
        public void Space()
        {
            Console.WriteLine("To give friendly forces in the defense as much reaction time as possible," +
                " Scouts conduct a screen");
            Console.WriteLine("a screen is an array of observation posts emplaced in a manner to detect an approaching enemy.");
            Console.WriteLine("Scouts use all of their assets - optics, radios and weapons to find the enemy, report them " +
                "to the commander, fight them off if necessary, and make it back to friendly lines safely");
        }
    }
}

