namespace RollABall
{
    internal sealed class InteractableSimpleBuffModel : IUpdatable, IImprover
    {
        #region Fields

        private UnityEngine.Vector3 DEBUG_VECTOR = new UnityEngine.Vector3(0, 0.001f, 0);

        private InteractableStruct _interactableStruct;

        #endregion


        #region ClassLifeCycles

        internal InteractableSimpleBuffModel(InteractableStruct interactableStruct)
        {
            _interactableStruct = interactableStruct;
        }

        #endregion


        #region Methods

        public void UpdateTick()
        {
            foreach (var item in _interactableStruct.SpawnedInteractable)
            {
                item.transform.position += DEBUG_VECTOR;
            }
        }

        #endregion
    }
}