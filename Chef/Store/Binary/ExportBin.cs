namespace Chef.Store.Txt
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    internal class ExportBin : Export
    {
        public override bool ExportToFile(Salad.Salad salad, string fileName)
        {
            try
            {
                var serializer = new BinaryFormatter();

                var stream = new FileStream(fileName, FileMode.Create);

                serializer.Serialize(stream, salad.MixtureOfVegetables);
                stream.Close();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}