using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class MusicButton : MonoBehaviour
    {
        private bool   _isMusicOn = true;
        public  Sprite ActiveSprite, InactiveSprite;
        private Button _button;

        private void OnEnable()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClicked);
        }

        public void OnButtonClicked()
        {
            if (_isMusicOn)
            {
                _isMusicOn           = false;
                _button.image.sprite = InactiveSprite;
            }
            else
            {
                _isMusicOn           = true;
                _button.image.sprite = ActiveSprite;
            }

            GameManager.ChangeSound?.Invoke(_isMusicOn);
        }
    }
}