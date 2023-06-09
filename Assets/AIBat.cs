using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class AIBat : MonoBehaviour
    {
        [SerializeField] private Vector2 clampedXRange, clampedYRange;

        [SerializeField] private bool lockX, lockY;

        [SerializeField] private float aiSensitivity = 2f;

        [SerializeField] private float errorThreshold = 0.4f;

        private bool _enableMovement;

        private Vector2 _newPosition;

        private Ball _ball;

        private void OnEnable()
        {
            _ball        = FindObjectOfType<Ball>(true);
            _newPosition = transform.position;
        }

        private void Update()
        {
            if (!_ball) return;
            float distance = Vector2.Distance(_ball.transform.position, transform.position);
            if (distance <= aiSensitivity)
            {
                if (UnityEngine.Random.Range(0f, 1f) <= errorThreshold)
                {
                    return;
                }

                _newPosition   = _ball.transform.position;
                _newPosition.x = Mathf.Clamp(_newPosition.x, clampedXRange.x, clampedXRange.y);
                _newPosition.y = Mathf.Clamp(_newPosition.y, clampedYRange.x, clampedYRange.y);
            }
        }

        private void FixedUpdate()
        {
            transform.position = new Vector2(
                lockX ? transform.position.x : _newPosition.x,
                lockY ? transform.position.y : _newPosition.y
            );
        }
    }
}