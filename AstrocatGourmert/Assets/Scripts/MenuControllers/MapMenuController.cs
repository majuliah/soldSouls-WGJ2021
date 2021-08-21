using System;
using UnityEngine;

public class MapMenuController : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;

    // Start is called before the first frame update
    void OnEnable()
    {
        // ir para o próximo planeta
        // iniciar o jogo ao finalizar a chegada.
        
        _gameManager.InitGame();
    }
}
