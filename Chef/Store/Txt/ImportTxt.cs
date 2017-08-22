namespace Chef.Store.Txt
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Resource;

    internal class ImportTxt : Import
    {
        public override bool ImportToFile(Salad.Salad salad, string fileName)
        {
            List<Salad.Vegetable> temp;

            try
            {
                var stringsFromFile = GetDataFromTxt(fileName);

                if (stringsFromFile.Count != 0)
                {
                    temp = new List<Salad.Vegetable>();

                    foreach (var vegetable in stringsFromFile)
                    {
                        temp.Add(
                                new Salad.Vegetable(
                                          vegetable.ElementAt(0),
                                          vegetable.ElementAt(1),
                                          int.Parse(vegetable.ElementAt(2)),
                                          int.Parse(vegetable.ElementAt(3))));
                    }
                }
                else
                {
                    throw new IOException();
                }
            }
            catch
            {
                return false;
            }

            salad.MixtureOfVegetables.Clear();
            salad.MixtureOfVegetables.AddRange(temp);

            return true;
        }

        private static List<List<string>> GetDataFromTxt(string fileName)
        {
            var reader = new StreamReader(fileName);
            var stringsFromFile = new List<List<string>>();

            while (reader.Peek() > 0)
            {
                var aboutVegetable = reader.ReadLine();

                var titleAndData = ImportTxt.ParseString(aboutVegetable, Text.SpliterOfData);

                var data = ImportTxt.GetinfoAboutVegetable(titleAndData);

                stringsFromFile.Add(data);
            }

            reader.Close();

            return stringsFromFile;
        }

        private static List<string> ParseString(string aboutVegetable, string spliter)
        {
            return new List<string>(aboutVegetable.Split(spliter.ToArray(), StringSplitOptions.RemoveEmptyEntries));
        }

        private static List<string> GetinfoAboutVegetable(List<string> oneStringValue)
        {
            var valuesOfVegetable = new List<string>();

            for (var index = 0; index < oneStringValue.Count; index++)
            {
                var stringValue = ImportTxt.ParseString(oneStringValue.ElementAt(index), Text.SpliterOfTitle);

                if (stringValue.Count != 2)
                {
                    valuesOfVegetable.Add(string.Empty);
                }
                else
                {
                    valuesOfVegetable.Add(stringValue.ElementAt(1));
                }
            }

            return valuesOfVegetable;
        }
    }
}