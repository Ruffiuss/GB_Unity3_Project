namespace RollABall
{
    internal sealed class GameProcessController : IGameProcessable
    {
        #region Fields

        public event System.Action<int> GameEnded = delegate (int score) { };
        private int _score = 0;

        #endregion


        #region Methods

        public void ChangeScore(int scorePoints)
        {
            _score += scorePoints;

            if (_score >= GlobalProperties.SCORE_TO_WIN)
            {
                GameEnded.Invoke(_score);
            }
        }

        #endregion
    }
}