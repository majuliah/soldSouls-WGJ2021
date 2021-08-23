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
        AudioManager _audioManager;
        bool alreadyPlayered = false;

        void OnEnable()
        {
            DontDestroyOnLoad(gameObject);
            _audioManager = FindObjectOfType<AudioManager>();
        }

        //Ao dar 2 minutos, termina o jogo.
        IEnumerator InitGame()
        {
            for (int i = 0; i < maxTime; i++)
            {
                if (i >= maxTime - 10 && !alreadyPlayered)
                {
                    alreadyPlayered = true;
                    _audioManager.Play("tempo");
                }
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