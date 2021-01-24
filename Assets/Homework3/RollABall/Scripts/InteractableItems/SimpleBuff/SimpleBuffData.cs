using UnityEngine;
using System;


namespace RollABall
{ 
    [CreateAssetMenu( fileName = "SimpleBuff", menuName = "Data/SubInteractable/SimpleBuff")]
    public sealed class SimpleBuffData : ScriptableObject, ISubInteractable
    {
        #region Fields

        public SimpleBuffStruct SimpleBuffStruct;

        #endregion


        #region Properties

        GameObject ISubInteractable.SubInteractableView => SimpleBuffStruct.SimpleBuffView;

        #endregion


        #region ClassLifeCycles

        public SimpleBuffData(SimpleBuffStruct simpleBuffStruct)
        {
            SimpleBuffStruct = simpleBuffStruct;
        }

        #endregion
    }
}