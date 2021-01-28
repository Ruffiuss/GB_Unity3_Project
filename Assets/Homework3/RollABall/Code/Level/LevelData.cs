using UnityEngine;


namespace RollABall
{
    [CreateAssetMenu(fileName = "Level", menuName = "Data/Level")]
    public sealed class LevelData : UnityEngine.ScriptableObject
    {
        public GameObject LevelProvider;
    }
}