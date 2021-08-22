using GameLogic;
using UnityEngine;
using UnityEngine.UI;

public class MenuNavigationController : MonoBehaviour
{
    [SerializeField] public Button _button;
    [SerializeField] GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _button.onClick.AddListener(_gameManager.InitGame);
    }
    
}