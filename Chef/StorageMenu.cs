namespace Chef
{
    using System;
    using System.IO;
    using Chef.Store;
    using Chef.Store.Txt;
    using Resource;
    using Salad;
    using static System.Console;

    internal static class StorageMenu
    {
        private static Storage txtStorage;

        internal static void Main(Salad salad)
        {
            bool exitToMainMenu = false;
            ConsoleKey selectPointMenu;

            while (!exitToMainMenu)
            {
                Screen.ShowWithClear(Text.StorageMenu);
                selectPointMenu = ReadKey().Key;

                switch (selectPointMenu)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        if (salad.MixtureOfVegetables == null || salad.MixtureOfVegetables.Count == 0)
                        {
                            Screen.ResultStorage(Text.SaladIsEmpty, string.Empty);
                        }
                        else
                        {
                            StorageMenu.Export(salad);
                        }

                        exitToMainMenu = true;
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:

                        StorageMenu.Import(salad);
                        exitToMainMenu = true;

                        break;

                    case ConsoleKey.Q:

                        exitToMainMenu = true;
                        break;

                    default:
                        break;
                }
            }
        }

        private static void Export(Salad salad)
        {
            bool exitToExportMenu = false;
            ConsoleKey selectPointMenu;

            while (!exitToExportMenu)
            {
                Screen.ShowWithClear(Text.ExportMenu);
                selectPointMenu = ReadKey().Key;

                switch (selectPointMenu)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        txtStorage = new Storage(salad, Text.TxtFile, new TxtTactory());

                        if (txtStorage.Export())
                        {
                            Screen.ResultStorage(Text.AboutSavedFile, Text.TxtFile);
                        }
                        else
                        {
                            Screen.ResultStorage(Text.FileNotSaved, Text.TxtFile);
                        }

                        exitToExportMenu = true;
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        break;

                    case ConsoleKey.Q:
                        exitToExportMenu = true;
                        break;

                    default:
                        break;
                }
            }
        }

        private static void Import(Salad salad)
        {
            bool exitToImportMenu = false;
            ConsoleKey selectPointMenu;

            while (!exitToImportMenu)
            {
                Screen.ShowWithClear(Text.ImportMenu);
                selectPointMenu = ReadKey().Key;

                switch (selectPointMenu)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        txtStorage = new Storage(salad, Text.TxtFile, new TxtTactory());

                        if (File.Exists(Text.TxtFile))
                        {
                            if (txtStorage.Import())
                            {
                                Screen.ResultStorage(Text.AboutLoadFile, Text.TxtFile);
                            }
                            else
                            {
                                Screen.ResultStorage(Text.FileNotLoaded, Text.TxtFile);
                            }
                        }
                        else
                        {
                            Screen.ResultStorage(Text.FileNotLoaded, Text.TxtFile);
                        }

                        exitToImportMenu = true;
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        break;

                    case ConsoleKey.Q:
                        exitToImportMenu = true;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}