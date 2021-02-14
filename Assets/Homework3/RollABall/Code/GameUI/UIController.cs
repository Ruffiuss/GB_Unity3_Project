using UnityEngine;
using System.Collections.Generic;


namespace RollABall
{
    internal sealed class UIController : IControllable
    {
        #region Fields

        private Dictionary<string, GameObject> _uiLayers;
        private readonly string _endgameScreen = "GameResult";

        #endregion


        #region ClassLifeCycles

        public UIController(Dictionary<string, GameObject> layers)
        {
            _uiLayers = layers;
        }

        #endregion


        #region Methods

        public void ShowGameEnd(int score)
        {
            foreach (var layer in _uiLayers)
            {
                if (layer.Key.Equals(_endgameScreen))
                {
                    var text = layer.Value.GetComponentInChildren<UnityEngine.UI.Text>();
                    text.color = Color.red;
                    text.alignment = TextAnchor.MiddleCenter;
                    text.fontSize = 19;
                    text.text = $"U WON! Score:{score}";
                    layer.Value.SetActive(true);
                }
            }           
        }

        #endregion
    }
}