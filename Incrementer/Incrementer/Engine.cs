using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Timers;
using MonoGame;

namespace Incrementer
{
    public class Engine
    {
        private Int64 total;
        private Int64 increment;
        private Int64 dollaDollaBillz;

        private int amountToSell = 5;
        private int cowPrice = 10;
        private int pigPrice = 5;
        private int chickenPrice = 2;
        private int autoSellPrice = 100;

        private object consoleLock;
        private object meatLock;
        private object moneyLock;
        private object incrementLock;

        private Timer messageDisplay;
        private Timer updater;
        private Timer fifthMeatMode;

        private bool autoSell;

        public Engine()
        {
            total = 0;
            increment = 1;
            consoleLock = new object();
            meatLock = new object();
            moneyLock = new object();
            incrementLock = new object();

            Console.CursorVisible = false;

            messageDisplay = new Timer(2000);
            messageDisplay.Elapsed += ClearMessageDisplay;

            updater = new Timer(1000);
            updater.Elapsed += UpdateCounts;

            fifthMeatMode = new Timer(1000);
            fifthMeatMode.Elapsed += SummonTheMeats;
            fifthMeatMode.AutoReset = true;
        }

        public void start()
        {
            updater.Start();
            bool done = false;
            UpdateControls();
            UpdateMoney();

            while (!done)
            {
                if (autoSell)
                {
                    SellMeats();
                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Spacebar:
                        SellMeats();
                        break;
                    case ConsoleKey.L:
                        TryBuyPig();
                        break;
                    case ConsoleKey.J:
                        TryBuyCow();
                        break;
                    case ConsoleKey.U:
                        if (!fifthMeatMode.Enabled)
                        {
                            WriteToConsole((int) Column.Start, (int) Row.Message, ConsoleColor.White,
                                ConsoleColor.Black,
                                messageDisplay, "Added the fifth meat...");
                            fifthMeatMode.Start();
                        }
                        else
                        {
                            WriteToConsole((int)Column.Start, (int)Row.Message, ConsoleColor.White,
                                ConsoleColor.Black,
                                messageDisplay, "FIFTH MEAT MODE CANNOT BE DISABLED. LIVE WITH YOUR CHOICES");
                        }
                        break;
                    case ConsoleKey.Escape:
                        done = true;
                        break;
                    case ConsoleKey.M:
                        DisplayMenu();
                        break;
                    case ConsoleKey.A:
                        TryBuyAutoSell();
                        break;
                }
            }
        }

        private void DisplayMenu()
        {
            
        }

        private void SellMeats()
        {
            lock (meatLock)
            {
                lock (moneyLock)
                {
                    if (total >= amountToSell)
                    {
                        dollaDollaBillz += 2 * amountToSell;
                        total -= amountToSell;
                        WriteToConsole((int)Column.Start, (int)Row.Message, ConsoleColor.DarkYellow,
                            ConsoleColor.Black, messageDisplay, "Meat: Sold");
                        UpdateMeats();
                        UpdateMoney();
                    }
                    else
                    {
                        WriteToConsole((int) Column.Start, (int) Row.Message, ConsoleColor.White, ConsoleColor.Black,
                            messageDisplay, "NOT ENOUGH MEATS TO SELL YOU WASTREL");
                    }
                }
            }
        }

        private void TryBuyCow()
        {
            lock (moneyLock)
            {
                if (dollaDollaBillz >= cowPrice)
                {
                    dollaDollaBillz -= cowPrice;
                    cowPrice++;
                    IncrementIncrement(2);
                    WriteToConsole((int)Column.Start, (int)Row.Message, ConsoleColor.White, ConsoleColor.Black,
                        messageDisplay, "Added a cow!");
                    UpdateMoney();
                    UpdateControls();
                }
            }
        }

        private void TryBuyAutoSell()
        {
            lock (moneyLock)
            {
                if (dollaDollaBillz >= autoSellPrice)
                {
                    dollaDollaBillz -= autoSellPrice;
                    autoSell = true;
                    WriteToConsole((int)Column.Start, (int)Row.Message, ConsoleColor.White, ConsoleColor.Black,
                        messageDisplay, "Now selling meats automatically");
                    UpdateMoney();
                    UpdateControls();
                }
            }
        }

        private void TryBuyPig()
        {
            lock (moneyLock)
            {
                if (dollaDollaBillz >= pigPrice)
                {
                    dollaDollaBillz -= pigPrice;
                    pigPrice++;
                    IncrementIncrement(1);
                    WriteToConsole((int)Column.Start, (int)Row.Message, ConsoleColor.White, ConsoleColor.Black,
                        messageDisplay, "Added a pig!");
                    UpdateMoney();
                    UpdateControls();
                }
            }
        }

        private void UpdateControls()
        {
            string message = $"[c] Buy cow ({cowPrice} money) [p] Buy pig ({pigPrice} money)";
            if (!autoSell)
            {
                message += $" [a] Buy salesman ({autoSellPrice} money)";
            }
            WriteToConsole((int)Column.Start, (int)Row.Controls, ConsoleColor.Black,
                ConsoleColor.White, messageDisplay, message
                );
        }

        private void WriteToConsole(int column, int row, ConsoleColor textColor, 
                                    ConsoleColor bgColor, Timer timer, string message)
        {
            lock (consoleLock)
            {
                ClearLine(row);
                Console.SetCursorPosition(column, row);
                Console.ForegroundColor = textColor;
                Console.BackgroundColor = bgColor;
                Console.Write(message);
                Console.ResetColor();
            }

            if (timer != null)
            {
                timer.Stop();
                timer.Start();
            }
        }

        private void UpdateMoney()
        {
            WriteToConsole((int)Column.Start, (int)Row.Money, ConsoleColor.Green,
                ConsoleColor.Black, messageDisplay, $"Money: {dollaDollaBillz}");
        }

        private void UpdateMeats()
        {
            WriteToConsole((int)Column.Start, (int)Row.Meats, ConsoleColor.Red, 
                ConsoleColor.Black, null, $"Meats: {total}");
        }

        private void ClearMessageDisplay(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            messageDisplay.Stop();
            ClearLine((int)Row.Message);
        }

        private static void ClearLine(int line)
        {
            Console.SetCursorPosition((int) Column.Start, line);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition((int) Column.Start, (int)Row.Meats);
        }

        private void UpdateCounts(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            IncrementMeats();
            UpdateMeats();
        }

        private void SummonTheMeats(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            Random rando = new Random();
            increment += rando.Next(1000) - 500;

            lock (consoleLock)
            {
                WriteToConsole((int)Column.Start, (int)Row.Meats, ConsoleColor.DarkMagenta, ConsoleColor.Black,
                                messageDisplay, "TASTE THESE MEATS");
            }
        }

        private void IncrementIncrement(int increase)
        {
            lock (incrementLock)
            {
                increment += increase;
            }
        }

        private void IncrementMeats()
        {
            lock (meatLock)
            {
                lock (incrementLock)
                {
                    total += increment;
                }
            }
        }
    }
}
