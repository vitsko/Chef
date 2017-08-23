namespace Chef.Store.Txt
{
    internal class BinFactory : StorageFactory
    {
        public override Export CreateExport()
        {
            return new ExportBin();
        }

        public override Import CreateImport()
        {
            return new ImportBin();
        }
    }
}