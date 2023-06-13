using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class VibrationButton : MonoBehaviour
    {
        private bool   _isVibrationOn = true;
        public  Sprite ActiveSprite, InactiveSprite;
        private Button _button;

        private void OnEnable()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClicked);
        }

        public void OnButtonClicked()
        {
            if (_isVibrationOn)
            {
                _isVibrationOn       = false;
                _button.image.sprite = InactiveSprite;
            }
            else
            {
                _isVibrationOn       = true;
                _button.image.sprite = ActiveSprite;
            }

            GameManager.ChangeVibration?.Invoke(_isVibrationOn);
        }
    }
}