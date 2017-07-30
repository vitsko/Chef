namespace Test
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Resource;
    using Salad;

    [TestClass]
    public class Test
    {
        private const int UnitOfWeigth = 100,
                         CaloriesDefault = 50,
                         WeigthDefault = 100,
                         TotalColories = 100,
                         ZeroCount = 0,
                         CountOfUniqueVegetables = 1,
                         ColoriesOfSalad = 295,
                         CountOfResultSearch = 3;

        private const string FirstColor = "Green",
                             LastColor = "Yellow";

        [TestMethod]
        public void CheckVegetableByEmptyName()
        {
            var vegetable = new Vegetable(string.Empty, "Green", 100, 50);

            Assert.IsTrue(vegetable.Name == Text.NameOfVegetable);
        }

        [TestMethod]
        public void CheckVegetableByEmptyColor()
        {
            var vegetable = new Vegetable("Pepper", string.Empty, 100, 50);

            Assert.IsTrue(vegetable.Color == Text.ColorOfVegetable);
        }

        [TestMethod]
        public void CheckVegetableByZeroWeight()
        {
            var vegetable = new Vegetable("Pepper", "Green", 0, 50);

            Assert.IsTrue(vegetable.Weight == Test.WeigthDefault);
        }

        [TestMethod]
        public void CheckVegetableByCaloriesPerUnitWeigth()
        {
            var vegetable = new Vegetable("Pepper", "Green", 100, 0);

            Assert.IsTrue(vegetable.CaloriesPerUnitWeigth == Test.CaloriesDefault);
        }

        [TestMethod]
        public void CheckVegetableByTotalCalories()
        {
            var vegetable = new Vegetable("Pepper", "Green", 200, 50);

            Assert.IsTrue(vegetable.TotalCalories == Test.TotalColories);
        }

        [TestMethod]
        public void CheckVegetableByTotalCaloriesWithoutData()
        {
            var vegetable = new Vegetable("Pepper", "Green", 0, 0);

            Assert.IsTrue(vegetable.TotalCalories == Test.CaloriesDefault);
        }

        [TestMethod]
        public void CheckMixtureOfVegetablesByEmpty()
        {
            Salad salad = new Salad();
            salad.MixtureOfVegetables = new List<object>();

            Assert.IsTrue(salad.MixtureOfVegetables.Count == Test.ZeroCount);
        }

        [TestMethod]
        public void CheckMixtureOfVegetablesByOnlySameVegetables()
        {
            Salad salad = new Salad();
            salad.MixtureOfVegetables = Data.GetSameVegetablesOnly();

            Assert.IsTrue(salad.MixtureOfVegetables.Count == Test.CountOfUniqueVegetables);
        }

        [TestMethod]
        public void CheckMixtureOfVegetablesByVegetableIsNull()
        {
            Salad salad = new Salad();
            salad.MixtureOfVegetables = Data.GetVegetablesWithNull();

            Assert.IsTrue(salad.MixtureOfVegetables.Count == Test.ZeroCount);
        }

        [TestMethod]
        public void CheckMixtureOfVegetablesWithAnotherObject()
        {
            Salad salad = new Salad();
            salad.MixtureOfVegetables = Data.GetVegetablesWithAnotherObject();

            Assert.IsTrue(salad.MixtureOfVegetables.Count == Test.ZeroCount);
        }

        [TestMethod]
        public void CheckMixtureOfVegetablesWithoutVegetables()
        {
            Salad salad = new Salad();
            salad.MixtureOfVegetables = Data.GetAllIsNotVegetables();

            Assert.IsTrue(salad.MixtureOfVegetables.Count == Test.ZeroCount);
        }

        [TestMethod]
        public void CheckGetTotalCaloriesWithVegetables()
        {
            Salad salad = new Salad();
            salad.MixtureOfVegetables = Data.GetVegetablesForSalad();

            Assert.IsTrue(salad.GetTotalCalories() == Test.ColoriesOfSalad);
        }

        [TestMethod]
        public void CheckGetTotalCaloriesWithSaladIsEmpty()
        {
            Salad salad = new Salad();
            salad.MixtureOfVegetables = Data.GetAllIsNotVegetables();

            Assert.IsTrue(salad.GetTotalCalories() == Test.ZeroCount);
        }

        [TestMethod]
        public void CheckGetTotalCaloriesWithNotOnlyVegetables()
        {
            Salad salad = new Salad();
            salad.MixtureOfVegetables = Data.GetVegetablesWithAnotherObject();

            Assert.IsTrue(salad.GetTotalCalories() == Test.ZeroCount);
        }

        [TestMethod]
        public void CheckSaladToString()
        {
            Salad salad = new Salad();
            salad.MixtureOfVegetables = Data.GetVegetablesForCheckSaladToString();

            Assert.IsTrue(salad.ToString().Contains(Text.CheckToString));
        }

        [TestMethod]
        public void CheckSaladToStringWithEmptySalad()
        {
            Salad salad = new Salad();
            salad.MixtureOfVegetables = new List<object>();

            Assert.IsTrue(salad.ToString() == Text.SaladIsEmpty);
        }

        [TestMethod]
        public void CheckSaladToStringWithOneVegetable()
        {
            Salad salad = new Salad();
            salad.MixtureOfVegetables = Data.GetSameVegetablesOnly();

            Assert.IsTrue(salad.ToString() == string.Format(Text.OneVegetable, salad.MixtureOfVegetables.ElementAt(0)));
        }

        [TestMethod]
        public void CheckSortByColor()
        {
            Salad salad = new Salad();
            salad.MixtureOfVegetables = Data.GetVegetablesForSalad();

            var sortByColor = Operations.SortBy(salad.MixtureOfVegetables, vegetable => ((Vegetable)vegetable).Color);

            Assert.IsTrue(((Vegetable)sortByColor.ElementAt(0)).Color == Test.FirstColor &&
                          ((Vegetable)sortByColor.ElementAt(salad.MixtureOfVegetables.Count - 1)).Color == Test.LastColor);
        }

        [TestMethod]
        public void CheckSortByColorByEmptySalad()
        {
            Salad salad = new Salad();
            salad.MixtureOfVegetables = Data.GetVegetablesWithNull();

            var sortByColor = Operations.SortBy(salad.MixtureOfVegetables, vegetable => ((Vegetable)vegetable).Color);

            Assert.IsTrue(sortByColor.Count == Test.ZeroCount);
        }

        [TestMethod]
        public void CheckSearchByColor()
        {
            Salad salad = new Salad();
            salad.MixtureOfVegetables = Data.GetVegetablesForSalad();

            var searchByColor = Operations.Search(salad.MixtureOfVegetables, vegetable => ((Vegetable)vegetable).Color == Test.FirstColor);

            Assert.IsTrue(searchByColor.Count == Test.CountOfResultSearch);
        }

        [TestMethod]
        public void CheckSearchByColorInEmptySalad()
        {
            Salad salad = new Salad();
            salad.MixtureOfVegetables = Data.GetVegetablesWithAnotherObject();

            var searchByColor = Operations.Search(salad.MixtureOfVegetables, vegetable => ((Vegetable)vegetable).Color == Test.FirstColor);

            Assert.IsTrue(searchByColor.Count == Test.ZeroCount);
        }
    }
}