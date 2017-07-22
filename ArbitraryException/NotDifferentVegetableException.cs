namespace ArbitraryException
{
    using System;

    public class NotDifferentVegetableException : Exception
    {
        public NotDifferentVegetableException(string message) : base(message)
        {
        }
    }
}