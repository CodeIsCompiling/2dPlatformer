using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Ui.MainMenu
{
    public class SettingsPopup : MonoBehaviour
    {
        public Button button;
        private void Awake()
        {
            button.onClick.AddListener(ClosePopup);
        }

        public void OpenPopup()
        {
            gameObject.SetActive(true);
        }
        private void ClosePopup()
        {
            gameObject.SetActive(false);
        }
    }
}
