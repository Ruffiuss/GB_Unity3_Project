using UnityEngine;
using System;


namespace RollABall
{
    [Serializable]
    public struct GameStruct
    {
        public LevelData Level;
        public PlayerData Player;
        public InteractableData Interactable;
    }
}