namespace Chef.Store.DB
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Salad;

    internal class ExportDB : Export
    {
        public override bool ExportToFile(Salad salad, string fileName)
        {
            try
            {
                var onlyVegatable = salad.MixtureOfVegetables.Where(v => v as Vegetable != null).Cast<Vegetable>().ToList();

                if (onlyVegatable.Count != 0)
                {
                    Common.InitializeDB(salad, fileName);

                    ExportDB.DeleteRows();
                    ExportDB.AddRows(onlyVegatable);

                    InitializationDB.DataAdpater.Update(InitializationDB.Table);
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

        private static void DeleteRows()
        {
            InitializationDB.Table.Rows.Clear();
            InitializationDB.Delete();

            InitializationDB.DataAdpater.Update(InitializationDB.Table);
        }

        private static void AddRows(List<Vegetable> onlyVegatable)
        {
            DataRow row;

            foreach (var vegetable in onlyVegatable)
            {
                row = InitializationDB.Table.NewRow();

                row["VegetableID"] = vegetable.Id;
                row["Name"] = vegetable.Name;
                row["Color"] = vegetable.Color;
                row["Weight"] = vegetable.Weight;
                row["Calories"] = vegetable.CaloriesPerUnitWeigth;

                InitializationDB.Table.Rows.Add(row);
            }
        }
    }
}