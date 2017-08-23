namespace Chef.Store.Txt
{
    internal class TxtFactory : StorageFactory
    {
        public override Export CreateExport()
        {
            return new ExportTxt();
        }

        public override Import CreateImport()
        {
            return new ImportTxt();
        }
    }
}