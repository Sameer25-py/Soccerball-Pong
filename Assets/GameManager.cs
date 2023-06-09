using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        public static Action<int> Goal;
        public        Ball        Ball;

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

        private void Start()
        {
            StartGameWithDelay();
        }
    }
}