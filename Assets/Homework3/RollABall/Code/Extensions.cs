using System.Collections.Generic;


namespace RollABall
{ 
    public static  class Extensions
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

        #endregion
    }
}