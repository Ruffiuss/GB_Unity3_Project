using UnityEngine;


namespace RollABall
{
    public static class InputManager
    {
        public const string HORIZONTAL = "Horizontal";
        public const string VERTICAL = "Vertical";
        public const string FIRE1 = "Fire1";
        public const KeyCode ESCAPE = KeyCode.Escape;
        public const KeyCode RESTART = KeyCode.R;
    }

    public static class GlobalProperties
    {
        public const float MIN_SPEEDBUFF = 250;
        public const float MAX_SPEEDBUFF = 500;
        public const float MIN_PLAYER_SPEED = 400;
        public const float MAX_PLAYER_SPEED = 1200;
        public const float MIN_PLAYER_MASS = 0.1f;
        public const float MAX_PLAYER_MASS = 5.0f;
        public const int SCORE_TO_WIN = 2;
    }
}