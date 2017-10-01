namespace Chef.Store.DB
{
    using Salad;

    internal static class Common
    {
        internal static void InitializeDB(Salad salad, string fileName)
        {
            InitializationDB initializer = new InitializationDB(fileName, salad);

            InitializationDB.SetPrimaryKey();
            InitializationDB.Table.Clear();
            InitializationDB.DataAdpater.Fill(InitializationDB.Table);
        }
    }
}