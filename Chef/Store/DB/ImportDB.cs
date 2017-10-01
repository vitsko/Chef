namespace Chef.Store.DB
{
    using System.Collections.Generic;
    using System.Data;
    using Salad;

    internal class ImportDB : Import
    {
        public override bool ImportToFile(Salad salad, string fileName)
        {
            try
            {
                Common.InitializeDB(salad, fileName);

                if (InitializationDB.Table.Rows.Count != 0)
                {
                    salad.MixtureOfVegetables.Clear();

                    salad.MixtureOfVegetables.AddRange(GetVegetablesFromRows());
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        private static IEnumerable<Vegetable> GetVegetablesFromRows()
        {
            foreach (DataRow row in InitializationDB.Table.Rows)
            {
                var vegetable = new Vegetable(row["Name"].ToString(), row["Color"].ToString(), (int)row["Weight"], (int)row["Calories"]);
                vegetable.ChangeID(row);

                yield return vegetable;
            }
        }
    }
}