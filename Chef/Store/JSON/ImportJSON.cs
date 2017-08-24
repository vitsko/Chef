namespace Chef.Store.Txt
{
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    internal class ImportJSON : Import
    {
        public override bool ImportToFile(Salad.Salad salad, string fileName)
        {
            try
            {
                var serializer = new JsonSerializer();
                serializer.NullValueHandling = NullValueHandling.Ignore;

                StreamReader reader = new StreamReader(fileName);

                salad.MixtureOfVegetables.Clear();
                salad.MixtureOfVegetables.AddRange((List<Salad.Vegetable>)serializer.Deserialize(reader, typeof(List<Salad.Vegetable>)));
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}