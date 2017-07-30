namespace Salad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Operations
    {
        public static List<object> SortBy(List<object> vegatables, Func<object, object> orderCriteria)
        {
            var isResult = Helper.IsResult(vegatables);

            return isResult ? vegatables.OrderBy(orderCriteria).ToList() :
                              new List<object>();
        }

        public static List<object> Search(List<object> vegatables, Func<object, bool> searchCriteria)
        {
            var isResult = Helper.IsResult(vegatables);

            return isResult ? vegatables.Where(searchCriteria).ToList() :
                              new List<object>();
        }
    }
}
