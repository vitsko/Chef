namespace Chef
{
    using System;
    using Data;
    using Resource;
    using Salad;
    using static System.Console;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            bool exit = false;

            Title = Text.Title;
            ConsoleKey selectPointMenu;

            Salad salad = new Salad();
            salad.MixtureOfVegetables = Data.GetVegetablesForSalad();

            while (!exit)
            {
                Screen.ShowWithClear(Text.MainMenu);
                selectPointMenu = ReadKey().Key;

                switch (selectPointMenu)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        {
                            Screen.AboutSalad(salad);
                            break;
                        }

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        {
                            Screen.ShowWithClear(string.Format(Text.AboutCaloricity, salad.GetTotalCalories()));
                            break;
                        }

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        {
                            var sortByColor = Operations.SortBy(salad.MixtureOfVegetables, vegetable => ((Vegetable)vegetable).Color);
                            Screen.ShowResult(sortByColor);
                            break;
                        }

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        {
                            MainMenu.SearchByCalories(salad);
                            break;
                        }

                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        {
                            MainMenu.SearchById(salad);
                            break;
                        }

                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        {
                            StorageMenu.Main(salad);
                            break;
                        }

                    case ConsoleKey.Q:
                        {
                            exit = true;
                            break;
                        }

                    default:
                        break;
                }

                if (Screen.IsSelectedKey(selectPointMenu))
                {
                    Screen.AboutPressAnyKey();
                }
            }
        }
    }
}