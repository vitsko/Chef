namespace Chef.Store
{
    internal class Storage
    {
        private Export export;
        private Import import;
        private Salad.Salad salad;
        private string fileName;

        internal Storage(Salad.Salad salad, string fileName, StorageFactory factory)
        {
            this.salad = salad;
            this.export = factory.CreateExport();
            this.import = factory.CreateImport();
            this.fileName = fileName;
        }

        internal string FileName
        {
            get
            {
                return this.fileName;
            }
        }

        internal bool Export()
        {
            return this.export.ExportToFile(this.salad, this.fileName);
        }

        internal bool Import()
        {
            return this.import.ImportToFile(this.salad, this.fileName);
        }
    }
}