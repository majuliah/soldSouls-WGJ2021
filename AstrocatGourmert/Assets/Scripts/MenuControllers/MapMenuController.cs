using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameLogic
{
    public class MapMenuController : MonoBehaviour
    {
        [SerializeField] Button _button;
        [SerializeField] GameManager _gameManager;

        void OnEnable()
        {
            _button.onClick.AddListener(_gameManager.InitGame);
        }
    }   
}
