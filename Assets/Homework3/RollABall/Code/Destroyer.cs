using UnityEngine;


namespace RollABall
{
    internal sealed class Destroyer : MonoBehaviour
    {
        #region UnityMethods

        private void Start()
        {
            Destroy(gameObject);
        }

        #endregion
    }
}
