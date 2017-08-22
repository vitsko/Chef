namespace Chef.Store
{
    using Salad;

    internal abstract class Import
    {
        public abstract bool ImportToFile(Salad salad, string fileName);
    }
}