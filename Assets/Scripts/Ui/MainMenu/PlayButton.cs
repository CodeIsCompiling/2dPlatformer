using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ui.MainMenu
{
    public class PlayButton : MonoBehaviour
    {
        public TextMeshProUGUI PlayText;
        public Button playButton;
        public Image playButtonImage;

        private void Awake()
        {
            playButton.onClick.AddListener(StartGame);
            PlayText.text = "Test Text";
            PlayText.color = Color.oliveDrab;
            playButtonImage.color = Color.hotPink;
        }

        private void StartGame()
        {
            SceneManager.LoadScene(1);
            playButton.interactable = false;
        }
    }
}
