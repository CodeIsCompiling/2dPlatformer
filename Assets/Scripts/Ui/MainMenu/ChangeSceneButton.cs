using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ui.MainMenu
{
    public class ChangeSceneButton : MonoBehaviour
    {
        public Button thisButton;
        public string nameOfScene;

        private void Awake()
        {
            thisButton.onClick.AddListener(StartGame);
        }

        private void OnValidate()
        {
            if (thisButton == null)
            {
                thisButton =  GetComponent<Button>();
            }
        }

        private void StartGame()
        {
            SceneManager.LoadScene(nameOfScene);
            thisButton.interactable = false;
        }
    }
}
