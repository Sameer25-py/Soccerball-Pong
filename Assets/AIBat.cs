﻿using System;
using UnityEngine;
using Random = System.Random;

namespace DefaultNamespace
{
    public class AIBat : MonoBehaviour
    {
        [SerializeField] private Vector2 clampedXRange, clampedYRange;

        [SerializeField] private bool lockX, lockY;

        [SerializeField] private float aiSensitivity = 2f;

        [SerializeField] private float coolDown = 2f;

        private Collider2D _collider2D;

        private bool _enableMovement;

        private Vector2 _newPosition;

        private Ball _ball;

        private float _elapsedTime = 0f;

        private void OnEnable()
        {
            _ball        = FindObjectOfType<Ball>(true);
            _newPosition = transform.position;
            _collider2D  = GetComponent<BoxCollider2D>();
        }

        private void Update()
        {
            if (!_ball) return;
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > coolDown)
            {
                _elapsedTime = 0f;
                float distance = Vector2.Distance(_ball.transform.position, transform.position);
                if (distance <= aiSensitivity)
                {
                    _newPosition   =  _ball.transform.position;
                    _newPosition   += Vector2.one * UnityEngine.Random.Range(-1f, 1f);
                    _newPosition.x =  Mathf.Clamp(_newPosition.x, clampedXRange.x, clampedXRange.y);
                    _newPosition.y =  Mathf.Clamp(_newPosition.y, clampedYRange.x, clampedYRange.y);
                    _newPosition = new Vector2(
                        lockX ? transform.position.x : _newPosition.x,
                        lockY ? transform.position.y : _newPosition.y
                    );
                }
            }
        }

        private void FixedUpdate()
        {
            float step = 5f * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, _newPosition, step);
        }
    }
}