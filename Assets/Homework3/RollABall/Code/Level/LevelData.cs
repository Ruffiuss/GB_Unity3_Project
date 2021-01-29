using UnityEngine;


namespace RollABall
{
    [CreateAssetMenu(fileName = "Level", menuName = "Data/Level")]
    public sealed class LevelData : ScriptableObject
    {
        public GameObject LevelProvider;
    }
}