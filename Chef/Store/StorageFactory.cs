namespace Chef.Store
{
    internal abstract class StorageFactory
    {
        public abstract Export CreateExport();

        public abstract Import CreateImport();
    }
}