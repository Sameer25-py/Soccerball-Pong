using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class DifficultyButton : MonoBehaviour
    {
        public float BallSpeed;

        public  Sprite SelectedSprite;
        private Button _button;

        private void OnEnable()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClicked);
            GameManager.SetBallSpeed += SetBallSpeedCalled;
        }

        private void SetBallSpeedCalled(float obj)
        {
            if (obj == BallSpeed)
            {
                _button.image.sprite = SelectedSprite;
            }
            else
            {
                _button.image.sprite = null;
            }
        }

        private void OnButtonClicked()
        {
            GameManager.SetBallSpeed?.Invoke(BallSpeed);
        }
    }
}