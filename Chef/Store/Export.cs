namespace Chef.Store
{
    using Salad;

    internal abstract class Export
    {
        public abstract bool ExportToFile(Salad salad, string fileName);
    }
}