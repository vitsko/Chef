namespace Chef.Store.Txt
{
    internal class TxtTactory : StorageFactory
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