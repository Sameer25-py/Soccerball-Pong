using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        public static Action<int>  Goal;
        public static Action<bool> PlayWithAI;
        public        Ball         Ball;

        public GameObject MainMenu;

        private List<Vector2> _randomDirections = new()
        {
            Vector2.up,
            Vector2.down
        };

        private void OnEnable()
        {
            Goal += OnGoalScored;
        }

        private void OnGoalScored(int obj)
        {
            Ball.SetDirection(Vector2.zero);
            Ball.transform.position = Vector2.zero;
            Invoke(nameof(StartGameWithDelay), 1f);
        }

        private void StartGameWithDelay()
        {
            Ball.SetDirection(_randomDirections[UnityEngine.Random.Range(0, _randomDirections.Count)]);
        }

        private void StartGame()
        {
            Ball.SetDirection(Vector2.zero);
            Ball.transform.position = Vector2.zero;
            Invoke(nameof(StartGameWithDelay), 1f);
        }
        
        public void SingePlay()
        {
            MainMenu.SetActive(false);
            PlayWithAI?.Invoke(false);
            StartGame();
        }

        public void MultiPlay()
        {
            MainMenu.SetActive(false);
            PlayWithAI?.Invoke(true);
            StartGame();
        }

        public void Settings() { }
    }
}