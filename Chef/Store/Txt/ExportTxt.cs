namespace Chef.Store.Txt
{
    using System.IO;

    internal class ExportTxt : Export
    {
        public override bool ExportToFile(Salad.Salad salad, string fileName)
        {
            try
            {
                StreamWriter writer;

                var toSave = salad.SaveInfo();

                if (!string.IsNullOrWhiteSpace(toSave))
                {
                    writer = new StreamWriter(fileName);
                    writer.Write(toSave);
                    writer.Close();
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

            return true;
        }
    }
}