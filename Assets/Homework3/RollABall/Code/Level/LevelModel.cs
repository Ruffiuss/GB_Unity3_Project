namespace RollABall
{ 
    internal sealed class LevelModel
    {
        #region Fields

        private LevelStruct _levelStruct;

        #endregion


        #region ClassLifeCycles

        internal LevelModel(LevelStruct levelStruct)
        {
            _levelStruct = levelStruct;
        }

        #endregion
    }
}