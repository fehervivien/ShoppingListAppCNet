using System;
using System.Collections.Generic;

namespace ShoppingListApp
{
    class Program
    {
        static List<string> shoppingList = new List<string>(); // A bevásárlólista tárolására

        static void Main(string[] args)
        {
            bool running = true; // A program futási állapotát jelzi

            while (running)
            {
                DisplayMenu(); // Menü megjelenítése
                string choice = Console.ReadLine(); // Felhasználói választás bekérése

                switch (choice)
                {
                    case "1":
                        AddItem(); // Tétel hozzáadása
                        break;
                    case "2":
                        ViewList(); // Lista megtekintése
                        break;
                    case "3":
                        RemoveItem(); // Tétel törlése
                        break;
                    case "4":
                        running = false; // Kilépés a programból
                        Console.WriteLine("Viszlát!");
                        break;
                    default:
                        Console.WriteLine("Érvénytelen választás. Kérlek, próbáld újra!");
                        break;
                }
                Console.WriteLine("\nNyomj meg egy gombot a folytatáshoz...");
                Console.ReadKey(); // Várakozás, mielőtt visszatér a menü
                Console.Clear(); // Törli a konzol tartalmát a menü újbóli megjelenítése előtt
            }
        }

        // Menü megjelenítése
        static void DisplayMenu()
        {
            Console.WriteLine("--- Bevásárlólista Alkalmazás ---");
            Console.WriteLine("1. Tétel hozzáadása");
            Console.WriteLine("2. Lista megtekintése");
            Console.WriteLine("3. Tétel törlése");
            Console.WriteLine("4. Kilépés");
            Console.Write("Válassz egy opciót: ");
        }

        // Tétel hozzáadása a listához
        static void AddItem()
        {
            Console.Write("Add meg a hozzáadni kívánt tételt: ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item)) // Ellenőrzi, hogy nem üres-e a bemenet
            {
                shoppingList.Add(item);
                Console.WriteLine($"'{item}' hozzáadva a listához.");
            }
            else
            {
                Console.WriteLine("A tétel nem lehet üres.");
            }
        }

        // Lista megjelenítése
        static void ViewList()
        {
            if (shoppingList.Count == 0)
            {
                Console.WriteLine("A bevásárlólista üres.");
            }
            else
            {
                Console.WriteLine("--- Bevásárlólista ---");
                for (int i = 0; i < shoppingList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {shoppingList[i]}");
                }
                Console.WriteLine("---------------------");
            }
        }

        // Tétel törlése a listából
        static void RemoveItem()
        {
            if (shoppingList.Count == 0)
            {
                Console.WriteLine("A bevásárlólista üres, nincs mit törölni.");
                return;
            }

            ViewList(); // Megmutatja a listát, hogy a felhasználó lássa a számokat
            Console.Write("Add meg a törölni kívánt tétel sorszámát: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int index))
            {
                // Ellenőrzi, hogy az index érvényes-e (1-től számol a felhasználónak)
                if (index > 0 && index <= shoppingList.Count)
                {
                    string removedItem = shoppingList[index - 1]; // Az index-1-re van szükség, mert a List 0-tól indexel
                    shoppingList.RemoveAt(index - 1);
                    Console.WriteLine($"'{removedItem}' törölve a listáról.");
                }
                else
                {
                    Console.WriteLine("Érvénytelen sorszám.");
                }
            }
            else
            {
                Console.WriteLine("Érvénytelen bemenet. Kérlek, számot adj meg.");
            }
        }
    }
}