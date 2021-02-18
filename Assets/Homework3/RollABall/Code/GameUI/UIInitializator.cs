using System.Collections.Generic;
using UnityEngine;


namespace RollABall
{
    internal sealed class UIInitializator
    {
        #region Fields

        private UIController _uiController;
        private Canvas _canvas;
        private List<Canvas> _canvases;
        private Dictionary<string, GameObject> _uiLayers;

        #endregion


        #region ClassLifeCycles

        internal UIInitializator(UIData uiData)
        {
            var spawnedUI = Object.Instantiate(uiData.GameUIProvider, Vector3.zero, Quaternion.identity);
            DefineUILayers(spawnedUI);

            _uiController = new UIController(_uiLayers);
        }

        #endregion


        #region Methods

        internal UIController GetUIController()
        {
            return _uiController;
        }

        private void DefineUILayers(GameObject provider)
        {
            _canvases = new List<Canvas>();
            _uiLayers = new Dictionary<string, GameObject>();

            for (int i = 0; i < provider.transform.childCount; i++)
            {
                if (provider.transform.GetChild(i).TryGetComponent(out _canvas))
                {
                    _canvases.Add(_canvas);
                    for (int i2 = 0; i2 < provider.transform.GetChild(i).transform.childCount; i2++)
                    {
                        var layer = provider.transform.GetChild(i).transform.GetChild(i2);

                        switch (layer.tag)
                        {
                            case "UILayer":
                                _uiLayers.Add(layer.name, layer.gameObject);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        public void SubscribeGameProcess(IGameProcessable gameProcess)
        {
            gameProcess.GameEnded += _uiController.ShowGameEnd;
        }

        #endregion
    }
}