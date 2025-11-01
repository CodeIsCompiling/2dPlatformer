using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ui.MainMenu
{
    public class LevelSelectButton : MonoBehaviour
    {
        public Button levelSelect;
        public GameObject mainCanvas;
        public GameObject levelSelectCanvas;

        private void Awake()
        {
            levelSelect.onClick.AddListener(ShowLevelSelect);
        }

        private void ShowLevelSelect()
        {
            mainCanvas.SetActive(false);
            levelSelectCanvas.SetActive(true);
        }

    }
}
