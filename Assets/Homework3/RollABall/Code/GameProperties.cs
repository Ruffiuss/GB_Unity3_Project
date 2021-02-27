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
        public const KeyCode SAVE_PLAYER_POSITION = KeyCode.C;
        public const KeyCode LOAD_PLAYER_POSITON = KeyCode.V;
    }

    public static class GlobalProperties
    {
        public const float MIN_SPEEDBUFF = 250.0f;
        public const float MAX_SPEEDBUFF = 500.0f;
        public const float MIN_PLAYER_SPEED = 400.0f;
        public const float MAX_PLAYER_SPEED = 1200.0f;
        public const float MAX_BUFFED_PLAYER_SPEED = 4000.0f;
        public const float MIN_PLAYER_MASS = 0.1f;
        public const float MAX_PLAYER_MASS = 5.0f;

        public const int SCORE_TO_WIN = 2;

        public const string SAVES_FOLDER_NAME = "Saves";
        public const string SAVES_FILE_NAME = "Save.mar";
    }
}