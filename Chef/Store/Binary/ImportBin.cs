namespace Chef.Store.Txt
{
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    internal class ImportBin : Import
    {
        public override bool ImportToFile(Salad.Salad salad, string fileName)
        {
            try
            {
                var serializer = new BinaryFormatter();
                var stream = new FileStream(fileName, FileMode.Open);

                var temp = serializer.Deserialize(stream) as List<object>;

                salad.MixtureOfVegetables.Clear();
                salad.MixtureOfVegetables.AddRange(temp);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}