namespace Chef.Store.DB
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using Data;
    using Resource;
    using Salad;

    internal class ExportDB : Export
    {
        private static DataRow row;
        private static SqlDataAdapter dataAdpater;
        private static DataTable vegetableTable;

        public override bool ExportToFile(Salad salad, string fileName)
        {
            try
            {
                InitializationDB initializer = new InitializationDB(fileName, salad);
                dataAdpater = InitializationDB.DataAdpater;
                vegetableTable = InitializationDB.Table;

                ExportDB.SetPrimaryKey(vegetableTable, dataAdpater);

                dataAdpater.Fill(vegetableTable);

                var rows = vegetableTable.Rows;
                var onlyVegatable = salad.MixtureOfVegetables.Where(v => v as Vegetable != null).Cast<Vegetable>().ToList();

                if (onlyVegatable.Count != 0)
                {
                    foreach (var vegetable in onlyVegatable)
                    {
                        if (rows.Contains(vegetable.Id))
                        {
                            ExportDB.UpdateRow(rows, vegetable);

                            continue;
                        }

                        ExportDB.AddRow(rows, vegetable);
                    }

                    ExportDB.DeleteRows(rows, onlyVegatable);

                    dataAdpater.Update(vegetableTable);
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

        //internal static void InitialLoadingData(Salad salad, string fileName)
        //{
        //    salad.MixtureOfVegetables = Data.GetVegetablesForSalad();

        //    // TODO: insert, update, delete
        //    Storage storage = new Storage(salad, Text.FileDB, new DBFactory());
        //    storage.Export();
        //}

        private static void SetPrimaryKey(DataTable vegetableTable, SqlDataAdapter dataAdpater)
        {
            if (vegetableTable.PrimaryKey.Length == 0)
            {
                vegetableTable.PrimaryKey = dataAdpater.FillSchema(vegetableTable, SchemaType.Source).PrimaryKey;
            }
        }

        private static void UpdateRow(DataRowCollection rows, Vegetable vegetable)
        {
            row = rows.Find(vegetable.Id);

            row["Name"] = vegetable.Name;
            row["Color"] = vegetable.Color;
            row["Weight"] = vegetable.Weight;
            row["Calories"] = vegetable.CaloriesPerUnitWeigth;

            InitializationDB.Update(vegetable);

            dataAdpater.Update(vegetableTable);
        }

        private static void AddRow(DataRowCollection rows, Vegetable vegetable)
        {
            row = vegetableTable.NewRow();

            row["VegetableID"] = vegetable.Id;
            row["Name"] = vegetable.Name;
            row["Color"] = vegetable.Color;
            row["Weight"] = vegetable.Weight;
            row["Calories"] = vegetable.CaloriesPerUnitWeigth;

            rows.Add(row);
        }

        private static void DeleteRows(DataRowCollection rows, List<Vegetable> onlyVegatable)
        {
            for (var index = 0; index < rows.Count; index++)
            {
                var toDeleteId = (int)rows[index].ItemArray[0];

                var match = onlyVegatable.Where(v => v.Id == toDeleteId);

                if (match.Count() == 0)
                {
                    InitializationDB.Delete(toDeleteId);
                    rows.RemoveAt(index);
                }
            }
        }
    }
}