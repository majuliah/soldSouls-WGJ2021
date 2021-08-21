using UnityEngine;
using UnityEngine.UI;

public class MenuNavigationController : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] GameManager _gameManager;
    [SerializeField] GameObject _destination;

    // Start is called before the first frame update
    void Start()
    {
        _button.onClick.AddListener(() =>
        {
            _destination.SetActive(true);
            gameObject.SetActive(false);
        });
    }
    
}