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
        private const byte ToExport = 0,
                            ToImport = 1;

        private static Storage storage;

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

                        storage = new Storage(salad, Text.TxtFile, new TxtFactory());
                        StorageMenu.CommonToStorage(storage, StorageMenu.ToExport);
                        exitToExportMenu = true;

                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:

                        storage = new Storage(salad, Text.BinFile, new BinFactory());
                        StorageMenu.CommonToStorage(storage, StorageMenu.ToExport);
                        exitToExportMenu = true;

                        break;

                    case ConsoleKey.Q:

                        exitToExportMenu = true;

                        break;

                    default:
                        break;
                }
            }
        }

        private static void CommonToStorage(Storage storage, byte exportOrImport)
        {
            string correctOperation = string.Empty,
                   incorrectOperation = string.Empty;

            bool isOperation = true;

            switch (exportOrImport)
            {
                case StorageMenu.ToExport:

                    isOperation = storage.Export();
                    correctOperation = Text.AboutSavedFile;
                    incorrectOperation = Text.FileNotSaved;

                    break;

                case StorageMenu.ToImport:

                    isOperation = storage.Import();
                    correctOperation = Text.AboutLoadFile;
                    incorrectOperation = Text.FileNotLoaded;

                    break;

                default:
                    break;
            }

            if (isOperation)
            {
                Screen.ResultStorage(correctOperation, storage.FileName);
            }
            else
            {
                Screen.ResultStorage(incorrectOperation, storage.FileName);
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

                        storage = new Storage(salad, Text.TxtFile, new TxtFactory());
                        StorageMenu.CommonToImport();
                        exitToImportMenu = true;

                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:

                        storage = new Storage(salad, Text.BinFile, new BinFactory());
                        StorageMenu.CommonToImport();
                        exitToImportMenu = true;

                        break;

                    case ConsoleKey.Q:

                        exitToImportMenu = true;

                        break;

                    default:
                        break;
                }
            }
        }

        private static void CommonToImport()
        {
            if (File.Exists(storage.FileName))
            {
                StorageMenu.CommonToStorage(storage, StorageMenu.ToImport);
            }
            else
            {
                Screen.ResultStorage(Text.FileNotLoaded, storage.FileName);
            }
        }
    }
}