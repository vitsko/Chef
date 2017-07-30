namespace Chef
{
    using System;
    using Resource;
    using Salad;
    using static System.Console;

    internal static class MainMenu
    {
        internal static void SearchByCalories(Salad salad)
        {
            Screen.ShowWithClear(Text.QuestionRange);

            int toParse = 0;
            var maxCalorie = ReadLine();

            if (Helper.IsMoreThanZero(maxCalorie, out toParse))
            {
                var vegetableWithCalories = Operations.Search(salad.MixtureOfVegetables, vegetable => ((Vegetable)vegetable).CaloriesPerUnitWeigth <= toParse);

                Screen.ShowResult(vegetableWithCalories);
            }
            else
            {
                Screen.ShowWithClear(Text.ErrorRange);
            }
        }

        internal static void SearchById(Salad salad)
        {
            Screen.ShowWithClear(Text.QuestionId);

            int toParse = 0;
            var idVegatable = ReadLine();

            try
            {
                if (Helper.IsMoreThanZero(idVegatable, out toParse))
                {
                    var vegetableWithId = Operations.Search(salad.MixtureOfVegetables, vegetable => ((Vegetable)vegetable).Id == toParse);

                    Screen.ShowResult(vegetableWithId);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(string.Format(Text.NotExistId, idVegatable));
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Screen.ShowWithClear(ex.Message);
            }
        }
    }
}