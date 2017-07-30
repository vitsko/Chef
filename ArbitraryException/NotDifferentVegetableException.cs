namespace ArbitraryException
{
    using System;

    /// <summary>
    /// Salad contains same vegetable more than once. 
    /// </summary>
    public class NotDifferentVegetableException : Exception
    {
        public NotDifferentVegetableException(string message) : base(message)
        {
        }
    }
}