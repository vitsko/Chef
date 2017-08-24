namespace Chef.Store.Txt
{
    using System.IO;
    using Newtonsoft.Json;

    internal class ExportJSON : Export
    {
        public override bool ExportToFile(Salad.Salad salad, string fileName)
        {
            try
            {
                var serializer = new JsonSerializer();
                serializer.NullValueHandling = NullValueHandling.Ignore;

                StreamWriter writer = new StreamWriter(fileName);

                serializer.Serialize(writer, salad.MixtureOfVegetables);
                writer.Close();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}