namespace Chef.Store.Txt
{
    internal class JSONFactory : StorageFactory
    {
        public override Export CreateExport()
        {
            return new ExportJSON();
        }

        public override Import CreateImport()
        {
            return new ImportJSON();
        }
    }
}