using System.Collections.Generic;


namespace RollABall
{ 
    public static class Extensions
    {
        #region Methods

        public static int SymbolCount(this string self)
        {
            int count = 0;
            foreach (char symbol in self)
            {
                count++;
            }
            return count;
        }

        public static List<TValue> GetValueList<TKey, TValue>(this Dictionary<TKey, TValue> self)
        {
            List<TValue> values = new List<TValue>();  
            foreach (var v in self.Values)
            {
                values.Add(v);
            }
            return values;
        }

        #endregion
    }
}