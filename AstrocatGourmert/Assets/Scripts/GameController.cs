using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] int maxTime = 120;
        [SerializeField] GameManager _gameManager;

        void OnEnable()
        {
            DontDestroyOnLoad(gameObject);
        }

        //Ao dar 2 minutos, termina o jogo.
        IEnumerator InitGame()
        {
            for (int i = 0; i < maxTime; i++)
            {
                yield return new WaitForSeconds(1);
            }

            _gameManager.GameOver();
        }

        public void StopGame()
        {
            StopCoroutine(InitGame());
        }
        
        public void StartGame()
        {
            StartCoroutine(InitGame());
        }

    }
}