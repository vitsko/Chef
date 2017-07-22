namespace Salad
{
    using System;
    using System.Collections.Generic;
    using Resource;

    public static class Helper
    {
        public static bool IsMoreThanZero(string parseToInt, out int intValue)
        {
            return int.TryParse(parseToInt, out intValue) && intValue > 0;
        }

        public static void SaladIsEmpty(List<object> salad)
        {
            if (salad == null || salad.Count == 0)
            {
                throw new InvalidOperationException(Text.SaladIsEmpty);
            }
        }

        public static void ObjectIsNotVegetable(object vegetable)
        {
            if (vegetable == null)
            {
                throw new NullReferenceException(Text.VegetableIsNull);
            }

            if (vegetable is Vegetable == false)
            {
                throw new InvalidCastException(Text.VegetableIsNull);
            }
        }

        internal static bool IsResult(List<object> salad)
        {
            bool isResult = true;

            try
            {
                Helper.SaladIsEmpty(salad);

                foreach (var vegetable in salad)
                {
                    Helper.ObjectIsNotVegetable(vegetable);
                }
            }
            catch
            {
                isResult = false;
            }

            return isResult;
        }
    }
}