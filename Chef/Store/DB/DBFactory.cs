namespace Chef.Store.DB
{
    internal class DBFactory : StorageFactory
    {
        public override Export CreateExport()
        {
            return new ExportDB();
        }

        public override Import CreateImport()
        {
            return new ImportDB();
        }
    }
}