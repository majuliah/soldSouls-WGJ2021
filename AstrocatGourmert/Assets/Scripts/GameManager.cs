using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameLogic
{
public class GameManager : MonoBehaviour
{
    public enum Scene
    {
        MainScene,
        SampleScene,
        EndScene
    }
    [SerializeField] GameController gameController;
    [SerializeField] FoodController foodController;
    [SerializeField] GalatiCat playerController;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject gameHud;
    
    
    void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(gameController);
        DontDestroyOnLoad(foodController);
        DontDestroyOnLoad(gameHud);
        gameHud.SetActive(false);
    }

    void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
    
    // Ao iniciar o jogo
    public void InitGame()
    {
        Time.timeScale = 1;
        // playerController.CanMove(true);
        mainMenu.SetActive(false);
        gameHud.SetActive(true);
        Load(Scene.SampleScene);
        gameController.StartGame();
        foodController.SpawFoods();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ReturnGame()
    {
        Time.timeScale = 1;
    }
    
    // Ao finalizar o tempo
    public void GameOver()
    {
        Time.timeScale = 1;
        gameOverMenu.SetActive(true);
        // playerController.CanMove(false);
    }

    // Ao achar todos os itens do mundo
    public void EndGame()
    {
        gameHud.SetActive(false);
        gameController.StopGame();
        Load(Scene.EndScene);
    }
}
}