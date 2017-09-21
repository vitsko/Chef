namespace Chef.Store.DB
{
    using System.Data;
    using System.Data.SqlClient;
    using Data;
    using Resource;
    using Salad;

    internal class ExportDB : Export
    {
        public override bool ExportToFile(Salad salad, string fileName)
        {
            try
            {
                InitializationDB initializer = new InitializationDB(fileName);
                SqlDataAdapter dataAdpater = InitializationDB.DataAdpater;
                DataTable vegetableTable = InitializationDB.Table;

                dataAdpater.Fill(vegetableTable);

                DataRow row;

                foreach (var item in salad.MixtureOfVegetables)
                {
                    var vegetable = item as Vegetable;

                    if (vegetable != null)
                    {
                        if (vegetableTable.Rows.Count != 0)
                        {
                            if (vegetableTable.Rows.Contains(vegetable.Id))
                            {
                                continue;
                            }
                        }

                        row = vegetableTable.NewRow();

                        row["VegetableID"] = vegetable.Id;
                        row["Name"] = vegetable.Name;
                        row["Color"] = vegetable.Color;
                        row["Weight"] = vegetable.Weight;
                        row["Calories"] = vegetable.CaloriesPerUnitWeigth;

                        vegetableTable.Rows.Add(row);
                    }
                }

                dataAdpater.Update(vegetableTable);
            }
            catch
            {
                return false;
            }

            return true;
        }

        internal static void InitialLoadingData(Salad salad, string fileName)
        {
            salad.MixtureOfVegetables = Data.GetVegetablesForSalad();

            // TODO: insert, update, delete
            Storage storage = new Storage(salad, Text.FileDB, new DBFactory());
            storage.Export();
        }
    }
}