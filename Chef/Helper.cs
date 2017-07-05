namespace Chef
{
    internal static class Helper
    {
        public static bool IsMoreThanZero(string parseToInt, out int intValue)
        {
            return int.TryParse(parseToInt, out intValue) && intValue > 0;
        }
    }
}