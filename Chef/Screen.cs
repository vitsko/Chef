namespace Chef
{
    using System;
    using System.Collections.Generic;
    using Salad;
    using static System.Console;

    internal static class Screen
    {
        internal static void ShowText(string text)
        {
            WriteLine(text);
        }

        internal static void AboutSalad(List<Vegetable> salad)
        {
            ClearScreen();
            WriteLine(Text.AboutVegetables);

            foreach (var vegetable in salad)
            {
                WriteLine(vegetable.ToString());
            }
        }

        internal static bool IsSelectedKey(ConsoleKey selectCreateditem)
        {
            return selectCreateditem == ConsoleKey.D1 ||
                   selectCreateditem == ConsoleKey.D2 ||
                   selectCreateditem == ConsoleKey.D3 ||
                   selectCreateditem == ConsoleKey.D4 ||
                   selectCreateditem == ConsoleKey.NumPad1 ||
                   selectCreateditem == ConsoleKey.NumPad2 ||
                   selectCreateditem == ConsoleKey.NumPad3 ||
                   selectCreateditem == ConsoleKey.NumPad4;
        }

        internal static void ClearScreen()
        {
            Clear();
        }
    }
}