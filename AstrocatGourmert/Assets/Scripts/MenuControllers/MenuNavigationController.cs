using GameLogic;
using UnityEngine;
using UnityEngine.UI;

public class MenuNavigationController : MonoBehaviour
{
    [SerializeField] public Button playButton;
    [SerializeField] public Button creditosButton;
    [SerializeField] GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(_gameManager.InitDialog);
        creditosButton.onClick.AddListener(_gameManager.EndGame);
    }
    
}