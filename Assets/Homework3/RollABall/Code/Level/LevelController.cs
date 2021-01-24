namespace RollABall
{
    internal sealed class LevelController
    {
        #region Fields

        private LevelModel _levelModel;

        #endregion


        #region ClassLifeCycles

        public LevelController(LevelModel levelModel)
        {
            _levelModel = levelModel;
        }

        #endregion
    }
}