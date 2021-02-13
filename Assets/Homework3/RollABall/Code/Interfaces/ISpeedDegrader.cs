namespace RollABall
{
    internal interface ISpeedDegrader : IInteractable
    {
        event System.Action<UnityEngine.Collider, float> SpeedDegrade;
        void DefineSpeedProperty(float speedProp);
    }
}