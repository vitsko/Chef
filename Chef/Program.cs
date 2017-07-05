namespace Chef
{
    using System;
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

            while (!exit)
            {
                Screen.ClearScreen();
                Screen.ShowText(Text.MainMenu);
                selectPointMenu = ReadKey().Key;

                switch (selectPointMenu)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        {
                            Screen.AboutSalad(salad.MixtureOfVegetables);
                            break;
                        }

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        {
                            Screen.ClearScreen();
                            Screen.ShowText(string.Format(Text.AboutCaloricity, salad.GetTotalCalories()));
                            break;
                        }

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        {
                            var sortByColor = salad.SortBy(vegetable => vegetable.Color);
                            Screen.AboutSalad(sortByColor);
                            break;
                        }

                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        {
                            Screen.ClearScreen();
                            Screen.ShowText(Text.QuestionRange);

                            int toParse = 0;
                            var maxCalorie = ReadLine();

                            if (Helper.IsMoreThanZero(maxCalorie, out toParse))
                            {
                                var vegetableWithCalories = salad.Search(vegetable => vegetable.CaloriesPerUnitWeigth <= toParse);

                                if (vegetableWithCalories.Count == 0)
                                {
                                    Screen.ShowText(Text.ResultEmpty);
                                }
                                else
                                {
                                    Screen.AboutSalad(vegetableWithCalories);
                                }
                            }
                            else
                            {
                                Screen.ClearScreen();
                                Screen.ShowText(Text.ErrorRange);
                            }

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
                    Screen.ShowText(Text.PressAnyKey);
                    ReadKey();
                }
            }
        }
    }
}