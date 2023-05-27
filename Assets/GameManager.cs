using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        public static Action<int> Goal;
        public        Ball        Ball;

        private void OnEnable()
        {
            Goal += OnGoalScored;
        }

        private void OnGoalScored(int obj)
        {
            Ball.SetDirection(Vector2.zero);
            Ball.transform.position = Vector2.zero;
            Invoke(nameof(StartGameWithDelay),1f);
        }

        private void StartGameWithDelay()
        {
            Vector2 randomVerticalDirection = new(0f, UnityEngine.Random.Range(-1f, 1f));
            Ball.SetDirection(randomVerticalDirection);
        }

        private void Start()
        {
            StartGameWithDelay();
        }
    }
}