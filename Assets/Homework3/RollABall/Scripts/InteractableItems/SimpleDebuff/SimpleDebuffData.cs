using UnityEngine;
using System;


namespace RollABall
{ 
    [CreateAssetMenu( fileName = "SimpleDebuff", menuName = "Data/SubInteractable/SimpleDebuff")]
    public sealed class SimpleDebuffData : ScriptableObject, ISubInteractable
    {
        #region Fields

        public SimpleDebuffStruct SimpleDebuffStruct;

        #endregion


        #region Properties

        GameObject ISubInteractable.SubInteractableView => SimpleDebuffStruct.SimpleDebuffView; 

        #endregion


        #region ClassLifeCycles

        public SimpleDebuffData(SimpleDebuffStruct simpleDebuffStruct)
        {
            SimpleDebuffStruct = simpleDebuffStruct;
        }

        #endregion
    }
}