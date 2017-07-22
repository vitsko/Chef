namespace Chef
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Resource;
    using Salad;
    using static System.Console;

    internal static class Screen
    {
        internal static void ShowText(string text)
        {
            WriteLine(text);
        }

        internal static void AboutSalad(Salad salad)
        {
            Screen.ShowWithClear(salad.ToString());
        }

        internal static bool IsSelectedKey(ConsoleKey selectCreateditem)
        {
            return selectCreateditem == ConsoleKey.D1 ||
                   selectCreateditem == ConsoleKey.D2 ||
                   selectCreateditem == ConsoleKey.D3 ||
                   selectCreateditem == ConsoleKey.D4 ||
                   selectCreateditem == ConsoleKey.D5 ||
                   selectCreateditem == ConsoleKey.NumPad1 ||
                   selectCreateditem == ConsoleKey.NumPad2 ||
                   selectCreateditem == ConsoleKey.NumPad3 ||
                   selectCreateditem == ConsoleKey.NumPad4 ||
                   selectCreateditem == ConsoleKey.NumPad5;
        }

        internal static void ShowResult(List<object> result)
        {
            if (result.Count == 0)
            {
                Screen.ShowText(Text.ResultEmpty);
            }
            else
            {
                var info = Screen.GetInfoFromVegetable(result);
                Screen.ShowWithClear(info);
            }
        }

        internal static void ShowWithClear(string text)
        {
            Clear();
            Screen.ShowText(text);
        }

        private static string GetInfoFromVegetable(List<object> result)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(Text.AboutVegetables);
            builder.AppendLine();

            foreach (var vegetable in result)
            {
                builder.AppendLine(vegetable.ToString());
            }

            return builder.ToString();
        }
    }
}