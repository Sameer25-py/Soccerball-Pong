using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class AIManager : MonoBehaviour
    {
        [SerializeField] private Bat AIBat;

        private void OnEnable()
        {
            GameManager.PlayWithAI += OnPlayWithAI;
        }

        private void OnPlayWithAI(bool obj)
        {
            if (!obj)
            {
                AIBat.GetComponent<Bat>()
                    .enabled = true;
                AIBat.GetComponent<AIBat>()
                    .enabled = false;
            }

            else
            {
                AIBat.GetComponent<AIBat>()
                    .enabled = true;
                AIBat.GetComponent<Bat>()
                    .enabled = false;
            }
        }

        private void OnDisable()
        {
            GameManager.PlayWithAI += OnPlayWithAI;
        }
    }
}