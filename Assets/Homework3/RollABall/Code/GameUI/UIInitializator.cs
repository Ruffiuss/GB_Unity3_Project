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
        private List<GameObject> _uiLayers;

        #endregion


        #region ClassLifeCycles

        internal UIInitializator(UIData uiData)
        {
            var spawnedUI = Object.Instantiate(uiData.GameUIProvider, Vector3.zero, Quaternion.identity);
            _uiController = new UIController(uiData, spawnedUI);

            DefineUILayers(spawnedUI);           
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
            _uiLayers = new List<GameObject>();

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
                                _uiLayers.Add(layer.gameObject);
                                break;
                            default:
                                break;
                        }
                    }

                }

            }
        }

        #endregion
    }
}