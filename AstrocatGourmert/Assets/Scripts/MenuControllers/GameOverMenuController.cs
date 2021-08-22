
using System;
using UnityEngine;

namespace GameLogic
{
    public class GameOverMenuController : MonoBehaviour
    {
        public Action onTouchAnyKey;

        void OnEnable()
        {
            Cursor.lockState = CursorLockMode.None;  
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                onTouchAnyKey?.Invoke();
            }
        }
    }
}