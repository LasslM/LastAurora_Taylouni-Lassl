using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BusinessLogic;

namespace ConsoleApp
{
    class Program
    {
        // All available cards
        static List<Truck> TruckCards = new List<Truck>();
        static List<Trailer> TrailerCards = new List<Trailer>();
        static List<Addon> AddonCards = new List<Addon>();
        
        static Convoy Convoy { get; set; }
        
        static bool gameRunning = true;
        
        // Text for display
        static List<string> startGameOptions = new List<string>{"Neuen Konvoy erstellen"};
        static List<string> editConvoyOptions = new List<string>{"Truck hinzufügen", "Trailer hinzufügen", "Addons hinzufügen"};

        static void InitializeCards()
        {
            TruckCards = new List<Truck>
            {
                new Truck(
                    "Tesla Tank",
                    3,
                    10_000,
                    3,
                    new List<Keyword>() { Keyword.Chain_drive, Keyword.Tesla_Weaponry }
                ),
        
                new Truck(
                    "Railgun Tank",
                    4,
                    140_000,
                    3,
                    new List<Keyword>() { Keyword.Armor }
                )
            };
            TrailerCards = new List<Trailer>
            {
                new Trailer(
                    "Medical Wagon",
                    15_000,
                    4
                ),
        
                new Trailer(
                    "Reinforced Fuelwagon",
                    10_000,
                    4
                ),
        
                new Trailer(
                    "Wagon",
                    5_000,
                    3
                ),
        
                new Trailer(
                    "Reinforced Wagon",
                    7_000,
                    4
                )
            };
            AddonCards = new List<Addon>
            {
                new Addon(
                    "Heavygun Addon",
                    35_000,
                    1,
                    new List<Keyword>() { Keyword.Heavygun, Keyword.Heavygun }
                ),
        
                new Addon(
                    "Small Storageaddon",
                    1_000,
                    2,
                    new List<Keyword>() { Keyword.Addon }
                ),
        
                new Addon(
                    "Armoraddon",
                    2_000,
                    3,
                    new List<Keyword>() { Keyword.Addon }
                ),
        
                new Addon(
                    "Nuclearreactor Addon",
                    25_000,
                    1,
                    new List<Keyword>() { Keyword.Addon }
                ),
        
                new Addon(
                    "Storage Addon",
                    30_000,
                    1,
                    new List<Keyword>() { Keyword.Addon }
                )
            };
        }
        
        
        static void Main(string[] args)
        {
            InitializeCards();
           
            while (gameRunning)
            {
                if (Convoy == null)
                {
                    HomeScreen();
                }

                else
                {
                    EditConvoyScreen();
                }
            }
        }
        
        // --- SCREENS -----------------------------------------------
        static void EditConvoyScreen()
        {
            var input = DefaultInterface("Was möchtest du tun?", editConvoyOptions);
            
            Console.Clear();
            
            switch (input)
            {
                case "1":
                    AddTruck();
                    break;
                case "2":
                    AddTrailer();
                    break;
                case "3":
                    AddAddon();
                    break;
                
                // Abbrechen, Convoy is getting deleted
                case "4":
                    Convoy = null;
                    break;
                
                default:
                    Console.WriteLine("Ungültige Eingabe, bitte erneut versuchen.");
                    break;
            }
        }

        static void HomeScreen()
        {
            var input = DefaultInterface("Was möchtest du tun?", startGameOptions);
            Console.Clear();
            
            switch (input)
            {
                case "1":
                    CreateConvoy();
                    break;
                case "2":
                    gameRunning = false;
                    break;
                default:
                    Console.WriteLine("Ungültige Eingabe, bitte erneut versuchen.");
                    break;
            }
        }
        
        // --- INTERFACES ---------------------------------------------

        static string DefaultInterface(string headline, List<string> displaylist)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("┌───────────────────────────────┐");
            Console.WriteLine("│  WILLKOMMEN BEI LAST AURORA!  │");
            Console.WriteLine("└───────────────────────────────┘");
            Console.ResetColor();

            if(Convoy != null){DisplayConvoy();}
            
            Console.WriteLine($"\n{headline}");
                
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < displaylist.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {displaylist[i]}");
            }
            
            Console.WriteLine($"{displaylist.Count + 1}. Abbrechen");
            Console.ResetColor();
                
            Console.Write("\nNummer eingeben: ");
            
            return Console.ReadLine();
        }
        
        // Muss noch optimiert werden
        #region AddCardsInterface
        static string AddCardsInterface(string headline, List<Truck> displaylist)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("┌───────────────────────────────┐");
            Console.WriteLine("│  WILLKOMMEN BEI LAST AURORA!  │");
            Console.WriteLine("└───────────────────────────────┘");
            Console.ResetColor();

            Console.WriteLine($"\n> {headline}");
                
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < displaylist.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {displaylist[i].Code}");
            }
            
            Console.WriteLine($"{displaylist.Count + 1}. Abbrechen");
            Console.ResetColor();
                
            Console.Write("\nNummer eingeben: ");
            return Console.ReadLine();
        }
        
        static string AddCardsInterface(string headline, List<Trailer> displaylist)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("┌───────────────────────────────┐");
            Console.WriteLine("│  WILLKOMMEN BEI LAST AURORA!  │");
            Console.WriteLine("└───────────────────────────────┘");
            Console.ResetColor();

            Console.WriteLine($"\n> {headline}");
                
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < displaylist.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {displaylist[i].Code}");
            }
            
            Console.WriteLine($"{displaylist.Count + 1}. Abbrechen");
            Console.ResetColor();
                
            Console.Write("\nNummer eingeben: ");
            return Console.ReadLine();
        }
        
        static string AddCardsInterface(string headline, List<Addon> displaylist)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("┌───────────────────────────────┐");
            Console.WriteLine("│  WILLKOMMEN BEI LAST AURORA!  │");
            Console.WriteLine("└───────────────────────────────┘");
            Console.ResetColor();

            Console.WriteLine($"\n> {headline}");
                
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < displaylist.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {displaylist[i].Code}");
            }
            
            Console.WriteLine($"{displaylist.Count + 1}. Abbrechen");
            Console.ResetColor();
                
            Console.Write("\nNummer eingeben: ");
            return Console.ReadLine();
        }
        #endregion
        
        
        
        // --- ADD CARDS / CREATE CONVOY ------------------------------
        
        
        static void CreateConvoy()
        {
            try
            {
                var input = Convert.ToInt32(AddCardsInterface("Truck hinzufügen", TruckCards))-1;

                Convoy = new Convoy(TruckCards[input]);
                Console.WriteLine($"Neuer Konvoi mit {TruckCards[input].Code} erstellt!");
                Console.WriteLine("Drücken Sie eine Taste, um fortzufahren...");
                Console.ReadKey();

                // redirect to edit convoy page
                EditConvoyScreen();
            }
            
            catch
            {
                Console.Clear();
                Console.WriteLine("Vorgang wird abgebrochen");
                Console.WriteLine("Drücken Sie eine Taste, um fortzufahren...");
                Console.ReadKey();
            }
            Console.Clear();
        }
        
        static void AddTrailer()
        {
            try
            {
                var input = Convert.ToInt32(AddCardsInterface("Trailer hinzufügen", TrailerCards))-1;
                Convoy.AddTrailer(TrailerCards[input]);
            }
            
            catch
            {
                Console.Clear();
                Console.WriteLine("Vorgang wird abgebrochen");
            }
            Console.WriteLine("Drücken Sie eine Taste, um fortzufahren...");
            Console.ReadKey();
            Console.Clear();
        }
        static void AddTruck()
        {
            try
            {
                var input = Convert.ToInt32(AddCardsInterface("Truck hinzufügen", TruckCards))-1;
                Convoy.AddTailTruck(TruckCards[input]);
            }
            
            catch
            {
                Console.Clear();
                Console.WriteLine("Vorgang wird abgebrochen");
            }
            Console.WriteLine("Drücken Sie eine Taste, um fortzufahren...");
            Console.ReadKey();
            Console.Clear();
        }
        
        static void AddAddon()
        {
            try
            {
                var input = Convert.ToInt32(AddCardsInterface("Addon hinzufügen", AddonCards))-1;

                Console.Clear();
                Console.WriteLine($"Zu welchem Komponent soll {AddonCards[input].Code} hinzugefügt werden?");
                
                
                Console.WriteLine($"1. {Convoy.HeadTruck.Code}");
                if (Convoy.TailTruck != null){
                    Console.WriteLine($"2. {Convoy.TailTruck.Code}");
                }
                
                if (Convoy.Trailers != null)
                {
                    foreach (var trailer in Convoy.Trailers.Select((value, index) => new { value, index }))
                    {
                        Console.WriteLine($"{trailer.index+3}. {trailer.value.Code}");
                    }
                }
                
                Console.Write("\nNummer eingeben: ");
                var inputComponent = Convert.ToInt32(Console.ReadLine());

                try
                {

                }

                catch
                {
                    
                }
                
            }
            
            catch
            {
                Console.Clear();
                Console.WriteLine("Vorgang wird abgebrochen");
            }
            Console.WriteLine("Drücken Sie eine Taste, um fortzufahren...");
            Console.ReadKey();
            Console.Clear();
        }
        
        
        
        // --- DISPLAY -----------------------------------------------

        static void DisplayConvoy()
        {
            Console.WriteLine("\nDein Konvoi: ");

            Console.Write($"{Convoy.HeadTruck.Code}");
            
            if (Convoy.Trailers.Any())
            {
                Console.Write(" ---");
                foreach (Trailer t in Convoy.Trailers)
                {
                    Console.Write($" {t.Code} -");
                }
            }
            if (Convoy.TailTruck != null){Console.Write($"-- {Convoy.TailTruck.Code}");}
          

        Console.WriteLine();
        }
        static void DisplayDetailedConvoy()
        {
            Console.WriteLine("\nDein Konvoi:\n");
            
            Console.WriteLine("+---------------------+---------------------+");
            Console.WriteLine("|   Head Truck        |");
            Console.WriteLine("+---------------------+---------------------+");
            Console.WriteLine($"| Code: {Convoy.HeadTruck.Code,-10}       |");
            Console.WriteLine($"| Geschwindigkeit: {Convoy.HeadTruck.Velocity,-3} km/h |");
            Console.WriteLine($"| Zugkraft: {Convoy.HeadTruck.Traction,-5} N     |");
            Console.WriteLine($"| Preis: {Convoy.HeadTruck.Price,-8} €      |");
            Console.WriteLine($"| Slots: {Convoy.HeadTruck.SlotsCount,-2}         |");
            Console.WriteLine("+---------------------+---------------------+");
            
            if (Convoy.Trailers.Any())
            {
                Console.WriteLine("\n   Attached Trailers");
                Console.WriteLine("+---------------------+---------------------+");

                foreach (Trailer t in Convoy.Trailers)
                {
                    Console.WriteLine("|      Trailer        |");
                    Console.WriteLine("+---------------------+---------------------+");
                    Console.WriteLine($"| Code: {t.Code,-10}       |");
                    Console.WriteLine($"| Preis: {t.Price,-8} €      |");
                    Console.WriteLine($"| Slots: {t.SlotsCount,-2}         |");
                    Console.WriteLine("+---------------------+---------------------+");
                }
            }
            
            if (Convoy.TailTruck != null)
            {
                Console.WriteLine("\n+---------------------+---------------------+");
                Console.WriteLine("|    Tail Truck       |");
                Console.WriteLine("+---------------------+---------------------+");
                Console.WriteLine($"| Code: {Convoy.TailTruck.Code,-10}       |");
                Console.WriteLine($"| Geschwindigkeit: {Convoy.TailTruck.Velocity,-3} km/h |");
                Console.WriteLine($"| Zugkraft: {Convoy.TailTruck.Traction,-5} N     |");
                Console.WriteLine($"| Preis: {Convoy.TailTruck.Price,-8} €      |");
                Console.WriteLine($"| Slots: {Convoy.TailTruck.SlotsCount,-2}         |");
                Console.WriteLine("+---------------------+---------------------+");
            }

            Console.WriteLine();
        }
    }
}
