namespace RollABall
{
    internal sealed class InteractableModel
    {
        #region Fields


        internal InteractableStruct _interactableStruct;

        #endregion


        #region ClassLifeCycles

        internal InteractableModel(InteractableStruct interactableStruct)
        {
            _interactableStruct = interactableStruct;
        }

        #endregion
    }
}