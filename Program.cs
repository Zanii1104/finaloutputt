using System;
using System.Collections.Generic;

namespace SYSTEMFINAL_OUTPUT
{
    public static class Program
    {
        static Dictionary<string, string> accounts = new Dictionary<string, string>();
        static string currentUser = "";
        static int userPoints = 0;
        static int userCash = 0;

        public static void Main()
        {
            ShowLogo();
            MainMenu();
        }

        static void ShowLogo()
        {
            string[] logo = new string[]
            {
                " _        _   _       _     _ ____ _ ",
                " \\ \\      / /__| |__   (_) __| |  ____| |",
                "  \\ \\ /\\ / / _ \\ '_ \\  | |/ _` |  _|  | |",
                "   \\ V  V /  _/ |) | | | (_| | |____| |",
                "    \\_/\\_/ \\___|_.__/  |_|\\__,_|______|_|",
                "",
                "          *       *     ***   ***      ",
                "         * *     * *    *       *   *      ",
                "        ***   ***   ***   ***      ",
                "       *     * *     *  *       *   *      ",
                "      *       *       * ***   *    *     ",
                "",
                "               W A T C H  F I           "
            };

            foreach (string line in logo)
            {
                Console.WriteLine(line);
            }
        }

        static void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("\n[1] Login");
                Console.WriteLine("[2] Create Account");
                Console.WriteLine("[3] Exit");
                Console.Write("Choose option: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    Login();
                }
                else if (option == "2")
                {
                    CreateAccount();
                }
                else if (option == "3")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }

        static void CreateAccount()
        {
            Console.Write("\nCreate Username: ");
            string username = Console.ReadLine();
            Console.Write("Create Password: ");
            string password = Console.ReadLine();

            if (accounts.ContainsKey(username))
            {
                Console.WriteLine("Username already exists. Try again.");
            }
            else
            {
                accounts[username] = password;
                Console.WriteLine("Account created successfully!");
                currentUser = username;
                userPoints = 0;
                userCash = 0;
                HomeMenu();
            }
        }

        static void Login()
        {
            Console.Write("\nEnter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            if (accounts.ContainsKey(username))
            {
                if (accounts[username] == password)
                {
                    Console.WriteLine("Login successful!");
                    currentUser = username;
                    HomeMenu();
                }
                else
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }
            else
            {
                Console.WriteLine("Account not found. Please create an account first.");
                Console.WriteLine("Press Enter to return...");
                Console.ReadLine();
            }
        }

        static void HomeMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\nWelcome to WatchFi, {currentUser}! Choose an option:\n");

                Console.WriteLine("Left Side:");
                Console.WriteLine("[1] Profile");
                Console.WriteLine("[2] Points to Cash");
                Console.WriteLine("[3] Balance");

                Console.WriteLine("\nRight Side:");
                Console.WriteLine("[4] TikTok");
                Console.WriteLine("[5] YouTube Shorts");
                Console.WriteLine("[6] Instagram");
                Console.WriteLine("[7] Facebook Reels");

                Console.WriteLine("\n[0] Logout");
                Console.Write("Select option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowProfile();
                        break;
                    case "2":
                        PointsToCash();
                        break;
                    case "3":
                        ShowBalance();
                        break;
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                        WatchAndGrind(choice);
                        break;
                    case "0":
                        Console.WriteLine("Logging out...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void ShowProfile()
        {
            Console.WriteLine($"\nUsername: {currentUser}");
            Console.WriteLine($"Password: {new string('*', accounts[currentUser].Length)}");
            Console.WriteLine("Press Enter to return...");
            Console.ReadLine();
        }

        static void PointsToCash()
        {
            Console.WriteLine($"\nYour Points: {userPoints}");

            if (userPoints >= 100)
            {
                int pesos = userPoints / 100;
                userCash += pesos;
                userPoints -= pesos * 100;
                Console.WriteLine($"Converted {pesos * 100} points to {pesos} pesos.");
            }
            else
            {
                Console.WriteLine("You need at least 100 points to convert. Keep grinding!");
            }

            Console.WriteLine("Press Enter to return...");
            Console.ReadLine();
        }

        static void ShowBalance()
        {
            while (true)
            {
                Console.WriteLine($"\nCurrent Cash: {userCash} pesos");
                Console.WriteLine("[1] Withdraw (GCash)");
                Console.WriteLine("[2] View History (Mock)");
                Console.WriteLine("[0] Back");
                Console.Write("Select option: ");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    WithdrawCash();
                }
                else if (input == "2")
                {
                    Console.WriteLine("No history yet. Press Enter...");
                    Console.ReadLine();
                }
                else if (input == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }

        static void WithdrawCash()
        {
            if (userCash < 50)
            {
                Console.WriteLine("Minimum to withdraw is 50 pesos. Earn more first.");
                Console.WriteLine("Press Enter to return...");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter GCash Number: ");
            string gcashNumber = Console.ReadLine();

            Console.WriteLine($"Withdrawing {userCash} pesos to GCash: {gcashNumber}...");
            userCash = 0;
            Console.WriteLine("Withdrawal successful. Press Enter to return...");
            Console.ReadLine();
        }

        static void WatchAndGrind(string platform)
        {
            string name = platform switch
            {
                "4" => "TikTok",
                "5" => "YouTube Shorts",
                "6" => "Instagram",
                "7" => "Facebook Reels",
                _ => "Unknown"
            };

            Console.WriteLine($"\nWelcome to {name} - Start Grind!");

            while (true)
            {
                Console.Write("\nSimulate video seconds (5–60, or 0 to stop): ");
                if (int.TryParse(Console.ReadLine(), out int seconds))
                {
                    if (seconds == 0) break;

                    int points = seconds switch
                    {
                        >= 60 => 10,
                        >= 30 => 5,
                        >= 5 => 3,
                        _ => 0
                    };

                    if (points > 0)
                    {
                        userPoints += points;
                        Console.WriteLine($"+{points} points added! Total: {userPoints} points.");
                    }
                    else
                    {
                        Console.WriteLine("Video too short. No points.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }
    }
}
