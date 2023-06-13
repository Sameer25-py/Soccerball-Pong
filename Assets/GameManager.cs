using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        public static Action<int>  Goal;
        public static Action<bool> PlayWithAI;
        public        Ball         Ball;

        public GameObject MainMenu;
        public GameObject Settings;

        public static Action<float> SetBallSpeed;
        public static Action<bool>  ChangeVibration;
        public static Action<bool>  ChangeSound;

        private bool isVibrationOn = true;

        public AudioSource AudioSource;

        public GameObject MatchUI;
        public Timer      Timer;

        public TMP_Text P1goal, P2goal;

        private int _p1Score = 0;
        private int _p2Score = 0;

        private bool _isMultiPlay = false;

        public GameObject Victory,        Loss, GameOver, Pause;
        public TMP_Text   GameOverp1Goal, GameOverp2Goal;

        private List<Vector2> _randomDirections = new()
        {
            new Vector2(-0.5f, 1f),
            new Vector2(0.5f, -1f),
            new Vector2(0.5f, 1f),
            new Vector2(-0.5f, -1f)
        };

        private void OnEnable()
        {
            Goal            += OnGoalScored;
            SetBallSpeed    += OnBallSpeedSet;
            ChangeVibration += OnChangeVibrationCalled;
            ChangeSound     += OnChangeSoundCalled;
            Timer.TimerEnd  += OnTimerEnd;
        }

        private void OnTimerEnd()
        {
            PauseGame();
            MatchUI.SetActive(false);
            if (_isMultiPlay)
            {
                GameOverp1Goal.text = _p1Score.ToString();
                GameOverp2Goal.text = _p2Score.ToString();
                GameOver.SetActive(true);
            }
            else
            {
                if (_p1Score >= _p2Score)
                {
                    Victory.SetActive(true);
                }
                else
                {
                    Loss.SetActive(true);
                }
            }
        }

        private void OnChangeSoundCalled(bool obj)
        {
            if (obj)
            {
                AudioSource.mute = false;
            }
            else
            {
                AudioSource.mute = true;
            }
        }

        private void OnChangeVibrationCalled(bool obj)
        {
            isVibrationOn = obj;
        }

        private void OnBallSpeedSet(float obj)
        {
            Ball.Speed = obj;
        }

        private void OnGoalScored(int obj)
        {
            if (isVibrationOn)
            {
                Handheld.Vibrate();
            }

            if (obj == 0)
            {
                _p2Score += 1;
            }
            else
            {
                _p1Score += 1;
            }

            P1goal.text = _p1Score.ToString();
            P2goal.text = _p2Score.ToString();

            Ball.Stop();
            Invoke(nameof(StartGameWithDelay), 1f);
        }

        private void StartGameWithDelay()
        {
            Ball.SetDirection(_randomDirections[UnityEngine.Random.Range(0, _randomDirections.Count)]);
        }

        private void StartGame()
        {
            Timer.StartTimer(180f);
            _p1Score    = _p2Score    = 0;
            P1goal.text = P2goal.text = "0";
            MatchUI.SetActive(true);
            Ball.Stop();
            Invoke(nameof(StartGameWithDelay), 1f);
        }

        public void SingePlay()
        {
            MainMenu.SetActive(false);
            _isMultiPlay = false;
            PlayWithAI?.Invoke(true);
            StartGame();
        }

        public void MultiPlay()
        {
            MainMenu.SetActive(false);
            _isMultiPlay = true;
            PlayWithAI?.Invoke(false);
            StartGame();
        }

        public void ShowSettings()
        {
            MainMenu.SetActive(false);
            Settings.SetActive(true);
        }

        public void BackToMenu()
        {
            PauseGame();
            Pause.SetActive(false);
            MatchUI.SetActive(false);
            GameOver.SetActive(false);
            Victory.SetActive(false);
            Loss.SetActive(false);
            Settings.SetActive(false);
            MainMenu.SetActive(true);
        }

        public void PauseGame()
        {
            Pause.SetActive(true);
            Timer.PauseTimer();
            Ball.Stop();
        }

        public void ResumeGame()
        {
            Pause.SetActive(false);
            Timer.ResumeTimer();
            Ball.SetDirection(_randomDirections[UnityEngine.Random.Range(0, _randomDirections.Count)]);
        }
    }
}