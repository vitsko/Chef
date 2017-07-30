namespace ArbitraryException
{
    using System;

    /// <summary>
    /// Salad contains only one vegetable.
    /// </summary>
    public class OneVegetableExceptionException : Exception
    {
        public OneVegetableExceptionException(string message) : base(message)
        {
        }
    }
}